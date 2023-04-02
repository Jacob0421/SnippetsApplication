using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SnippetsApplication.Models;
using SnippetsApplication.Models.Interfaces;

namespace SnippetsApplication.Controllers
{
    public class UserSecretController : Controller
    {
        private readonly IUserSecretRepository _userSecret;
        private readonly IConfiguration _config;

        public UserSecretController(IConfiguration config, IUserSecretRepository userSecret)
        {
            _config = config;
            _userSecret = userSecret;
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
            _userSecret.AddUserSecret(UserSecretIn);
            return View();
        }

        public IActionResult GetUserSecret()
        {
            return View();
        }

        /// <summary>
        /// Gets secrets form User secrets store (secrets.json) based on a key provided by GetUserSecrets.cshtml
        /// </summary>
        /// <param name="key">Key is used to query for the Key-Value pairs in secrets.json</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSecret(string key)
        {
            JsonResponseViewModel model = new JsonResponseViewModel();
            UserSecret userSecretModel = new UserSecret();
            string returnedSecret = "";

            if (!String.IsNullOrEmpty(key))
            {
                returnedSecret = _config[key];
            }

            if (string.IsNullOrEmpty(returnedSecret))
            {
                model.ResponseCode = 0;
                model.ResponseMessage = String.Format("No secret found for '{0}'.", key);
            }
            else
            {
                model.ResponseCode = 1;

                userSecretModel.UserSecretID = "4dd2d9d5-d5c3-4d88-b94b-6c8569072ea9";
                userSecretModel.SecretKey = key;
                userSecretModel.SecretValue = returnedSecret;

                model.ResponseMessage = JsonConvert.SerializeObject(userSecretModel);
            }

            return Json(model);
        }

        public IActionResult UserSecrets()
        {
            return View(_userSecret.GetUserSecrets());
        }

        public IActionResult AddUserSecretId() {
            return View();
        }

    }
}
