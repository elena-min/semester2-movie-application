using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserController _userController;

        [BindProperty]
        public User User { get; set; }

        public LoginModel(UserController userController)
        {
            _userController = userController;
        }
        public void OnGet()
        {
        }
    }
}
