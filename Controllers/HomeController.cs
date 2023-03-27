using Microsoft.AspNetCore.Mvc;
using SnippetsApplication.Models;
using SnippetsApplication.Models.Interfaces;
using SnippetsApplication.Models.Repositories;
using System.Diagnostics;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Xml;
using System.Linq;

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
            XmlDocument csproj = new XmlDocument();
            csproj.Load(Environment.CurrentDirectory + "\\SnippetsApplication.csproj");
            if (csproj.DocumentElement != null) {
                XmlNode targetNode = csproj.SelectSingleNode("//UserSecretsId");

                if (targetNode != null)
                {
                    UserSecret newSecret = new UserSecret()
                    {
                        UserSecretID = targetNode.InnerText,
                        SecretKey = "UserSecretId",
                        SecretValue = targetNode.InnerText
                    };

                    _userSecretRepository.AddUserSecret(newSecret);
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}