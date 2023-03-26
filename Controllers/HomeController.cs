using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public IActionResult GetUserSecret()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetSecret(string key)
        {
            JsonResponseViewModel model = new JsonResponseViewModel();
            UserSecret userSecretModel = new UserSecret();
            string returnedSecret = "";

            if (!String.IsNullOrEmpty(key)) {
                returnedSecret = _config[key];
            }

            if(string.IsNullOrEmpty(returnedSecret))
            {
                model.ResponseCode = 0;
                model.ResponseMessage = String.Format("No secret found for '{0}'.", key);
            } else
            {
                model.ResponseCode = 1;

                userSecretModel.UserSecretID = "4dd2d9d5-d5c3-4d88-b94b-6c8569072ea9";
                userSecretModel.SecretKey = key;
                userSecretModel.SecretValue = returnedSecret;

                model.ResponseMessage = JsonConvert.SerializeObject(userSecretModel);
            }

            return Json(model);
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