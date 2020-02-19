using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using opg_201910_interview.Model;
using opg_201910_interview.Models;
using opg_201910_interview.Service;

namespace opg_201910_interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration configuration;
        private IFileManagement fileManagement;

        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            configuration = iConfig;
            _logger = logger;
            fileManagement = new FileManagement();
        }

        public IActionResult Index()
        {
            Files files = new Files
            {
                ClientId = int.Parse(configuration.GetSection("ClientSettingsA").GetSection("ClientId").Value),
                FilePath = configuration.GetSection("ClientSettingsA").GetSection("FileDirectoryPath").Value,
                FileFormat = configuration.GetSection("ClientSettingsA").GetSection("FileFormat").Value,
                FileOrder = configuration.GetSection("ClientSettingsA").GetSection("FileOrder").Value
            };

            var result = fileManagement.getFiles(files);
            ViewData["FilesClientA"] = JsonConvert.SerializeObject(result);
            files = new Files
            {
                ClientId = int.Parse(configuration.GetSection("ClientSettingsB").GetSection("ClientId").Value),
                FilePath = configuration.GetSection("ClientSettingsB").GetSection("FileDirectoryPath").Value,
                FileFormat = configuration.GetSection("ClientSettingsB").GetSection("FileFormat").Value,
                FileOrder = configuration.GetSection("ClientSettingsB").GetSection("FileOrder").Value
            };
            result = fileManagement.getFiles(files);
            ViewData["FilesClientB"] = JsonConvert.SerializeObject(result);
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
