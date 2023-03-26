using Microsoft.AspNetCore.Mvc;
using SnippetsApplication.Models;
using SnippetsApplication.Models.Interfaces;
using SnippetsApplication.Models.Repositories;
using System.Diagnostics;

namespace SnippetsApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserSecretRepository _userSecretRepository;

        public HomeController(ILogger<HomeController> logger, IUserSecretRepository userSecretRepository)
        {
            _logger = logger;
            _userSecretRepository = userSecretRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUserSecret()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUserSecret(UserSecret UserSecretIn)
        {
            _userSecretRepository.AddUserSecret(UserSecretIn);
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