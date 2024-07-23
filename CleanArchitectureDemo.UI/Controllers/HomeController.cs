using CleanArchitectureDemo.Application.Configuration;
using CleanArchitectureDemo.Application.Interfaces;
using CleanArchitectureDemo.Application.Teams.Queries;
using CleanArchitectureDemo.Application.Users.Queries;
using CleanArchitectureDemo.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net.WebSockets;

namespace CleanArchitectureDemo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IUserQueries _userQueries;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IOptions<EmailSettings> emailSettings, IUserService userService, IUserQueries userQueries,
           IMediator mediator)
        {
            _logger = logger;
            _emailSettings = emailSettings.Value;
            _userService = userService;
            _userQueries = userQueries;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            //var user = await _userService.GetListUser();
            var user = await _userQueries.GetListUser();

            ViewBag.Setting = $"User Count: {user.Count()} - {_emailSettings.SenderName}";

            var data = await _mediator.Send(new GetTeamsQuery());

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