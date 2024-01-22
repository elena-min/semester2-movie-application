using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Strategy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize(Roles = "Employee")]
    public class BannedUsersPageModel : PageModel
    {
        [BindProperty]
        public Person Userr { get; set; }
        private readonly UserController _userController;
        private readonly BannedUserController _banController;

        public List<User> BannedUsers { get; set; }

        [BindProperty]
        public List<User> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public BannedUsersPageModel(UserController userController, BannedUserController banController)
        {
            _userController = userController;
            _banController = banController;
        }
        public IActionResult OnGet(int pageIndex = 1)
        {
            try
            {
                var userID = User.FindFirst("Id").Value;

                if (userID == null)
                {
                    return RedirectToPage("/Login");
                }

                Userr = _userController.GetUserByID(Int32.Parse(userID.ToString()));

                if (Userr == null)
                {
                    return NotFound();
                }

                BannedUsers = new List<User>();
                foreach (User bannedUser in _banController.GetAllBannedUser())
                {
                    string reasonForbanning = _banController.GetReasonForBanning(bannedUser);
                    bannedUser.SetUserAsBanned(reasonForbanning);
                    BannedUsers.Add(bannedUser);
                }

                Results = BannedUsers;
                const int pageSize = 8;
                TotalResults = Results.Count;
                TotalPages = (int)Math.Ceiling((double)TotalResults / pageSize);
                pageIndex = Math.Max(1, Math.Min(pageIndex, TotalPages));
                CurrentPage = pageIndex;

                int startIndex = (pageIndex - 1) * pageSize;
                int endIndex = Math.Min(startIndex + pageSize - 1, TotalResults - 1);

                Results = Results.GetRange(startIndex, endIndex - startIndex + 1);

                if (Results.Count == 0)
                {
                    TempData["Message"] = "No banned users.";
                }

                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToPage("/Error");
            }
        }

        public IActionResult OnPost(int userId)
        {
            try
            {
                var currentuserID = User.FindFirst("Id").Value;

                if (currentuserID == null)
                {
                    return RedirectToPage("/Login");
                }

                Userr = _userController.GetUserByID(Int32.Parse(currentuserID.ToString()));

                if (Userr == null)
                {
                    return NotFound();
                }

                User userToBeUnBanned = _userController.GetUserByID(Int32.Parse(userId.ToString()));

                if (userToBeUnBanned == null)
                {
                    return NotFound();
                }

                TempData["Message"] = _banController.UnBanUserAccount(userToBeUnBanned);
                return RedirectToPage("/BannedUsersPage");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToPage("/BannedUsersPage");
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
