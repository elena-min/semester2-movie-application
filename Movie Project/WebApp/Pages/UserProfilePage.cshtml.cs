using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using Microsoft.AspNetCore.Authorization;
using System;
using LogicLayer.SortingStrategy;

namespace WebApp.Pages
{
    public class UserProfilePageModel : PageModel
    {
        public User Userr { get; set; }
        public string ReasonForBanning { get; set; }
        public List<MediaItem> FavoriteMovies { get; set; }
        public List<MediaItem> FavoriteSeries { get; set; }


        private readonly UserController _userController;
        private readonly EmployeeController _empController;
        private readonly FavoritesController _favoritesController;
        private readonly SortingContext _sortingContext; 


        public UserProfilePageModel(UserController userController, EmployeeController empController, FavoritesController favoritesController, SortingContext sortingContext)
        {
            _userController = userController;
            _empController = empController;
            _favoritesController = favoritesController;
            _sortingContext = sortingContext;
        }
        public IActionResult OnGet(int ID)
        {
            try
            {
                Userr = _userController.GetUserByID(ID);
                if (Userr == null)
                {
                    return NotFound();
                }

                FavoriteMediaItem favoriteMediaItem = new FavoriteMediaItem(Userr);

                if (_favoritesController.GetAllFavorites(Userr) != null)
                {
                    foreach (MediaItem item in _favoritesController.GetAllFavorites(Userr))
                    {
                        favoriteMediaItem.AddToFavorites(item);
                    }
                }

                if (favoriteMediaItem.GetAllFavorite() != null)
                {
                    foreach (MediaItem item in favoriteMediaItem.GetAllFavorite())
                    {
                        if (item is Movie)
                        {
                            FavoriteMovies.Add(item);
                        }
                        else if (item is Serie)
                        {
                            FavoriteSeries.Add(item);
                        }
                    }
                }

                _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy());
                FavoriteMovies = _sortingContext.GetSortedMediaItems(FavoriteMovies).ToList();
                FavoriteSeries = _sortingContext.GetSortedMediaItems(FavoriteSeries).ToList();

                if (!string.IsNullOrEmpty(Userr.ReasonForDeleting))
                {
                    ReasonForBanning = Userr.ReasonForDeleting;
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToPage("/Error");
            }
        }

        [Authorize(Roles = "Employee")]
        public IActionResult OnPostDeleteUser(int ID, string reason)
        {
            if (string.IsNullOrEmpty(reason))
            {
                TempData["Message"] = $"A reason for banning should be filled!";
                return RedirectToPage("/UserProfilePage", new { ID = ID });
            }

            try
            {
                User selectedUser = _userController.GetUserByID(ID);
                _empController.DeleteUserAccount(selectedUser, reason);
                return RedirectToPage("/Main");
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
                return RedirectToPage("/UserProfilePage", new { ID = ID });

            }

        }
        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
