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
        private readonly IConfiguration _config;
        private readonly IUserSecretRepository _userSecretRepository;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IUserSecretRepository userSecretRepository)
        {
            _logger = logger;
            _config = config;
            _userSecretRepository = userSecretRepository;
        }

        public IActionResult Index()
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