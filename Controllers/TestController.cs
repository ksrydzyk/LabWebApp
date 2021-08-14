using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System;


namespace MvcMovie.Controllers
{
    public class TestController : Controller
    {
        // 
        // GET: /Test/
        private TelemetryClient aiClient;

        public TestController(TelemetryClient aiClient)
        {
            this.aiClient = aiClient;
        }   

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/

        public IActionResult Parameters(string name, int count)
        {
            this.aiClient.TrackEvent("Parameters invoked", new Dictionary<string, string> {{"Name", name}, {"Count", Convert.ToString(count)}});

            //displays parameters specified in URL     
            ViewData["Message"] = "Hello and welcome " + name;
            ViewData["NumTimes"] = count;

            return View();
        }
    }
}   