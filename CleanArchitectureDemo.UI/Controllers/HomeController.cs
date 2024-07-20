using CleanArchitectureDemo.Application.Configuration;
using CleanArchitectureDemo.Application.Interfaces;
using CleanArchitectureDemo.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace CleanArchitectureDemo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IOptions<EmailSettings> emailSettings, IUserService userService)
        {
            _logger = logger;
            _emailSettings = emailSettings.Value;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetListUser();

            ViewBag.Setting = $"User Count: {user.Count()} - {_emailSettings.SenderName}";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}