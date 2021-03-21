using Microsoft.AspNetCore.Mvc;
using MVCLog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCLog.Controllers
{
    public class LogController : Controller
    {
        private readonly string apiUrl = "https://localhost:44334/api/log";
        public async Task<IActionResult> Index()
        {
            List<LogViewModel> listLogs = new List<LogViewModel>();
            int page = 1;
            int take = 50;
            int totalLogs = 0;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl  +"/pagination/" + page + "/" + take))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLogs = JsonConvert.DeserializeObject<List<LogViewModel>>(apiResponse);
                }

                using (var response = await httpClient.GetAsync(apiUrl + "/countAll/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Total = apiResponse;
                    totalLogs = System.Convert.ToInt32(ViewBag.Total);
                }
            }
            var pages = (totalLogs + 9) / take;
            ViewData["qtdPagina"] = pages;
            ViewData["pagina"] = page;
            return View(listLogs);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int page)
        {
            List<LogViewModel> listLogs = new List<LogViewModel>();
            int take = 50;
            int totalLogs = 0;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/pagination/" + page + "/" + take))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLogs = JsonConvert.DeserializeObject<List<LogViewModel>>(apiResponse);
                }

                using (var response = await httpClient.GetAsync(apiUrl + "/countAll/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Total = apiResponse;
                    totalLogs = System.Convert.ToInt32(ViewBag.Total);
                }
            }
            var pages = (totalLogs + 9) / take;
            ViewData["qtdPagina"] = pages;
            ViewData["pagina"] = page;
            return View(listLogs);
        }


        [HttpPost]
        public async Task<IActionResult> Search(DateTime initial,DateTime final, string description, int id, string ip)
        {
            List<LogViewModel> listLogs = new List<LogViewModel>();
            int totalLogs = 0;

            var dateInitial = initial.ToString("yyyy-MM-dd HH:mm:ss");

            var dateFinal = final.ToString("yyyy-MM-dd HH:mm:ss");


            if (description == null)
                description = "";
            if (ip == null)
                ip = "";
            if (initial == null)
                initial = DateTime.Parse("01/01/2000 00:00:00");
                dateInitial = initial.ToString("yyyy-MM-dd");

            if (final == null)
                final = DateTime.Now;
                dateFinal = final.ToString("yyyy-MM-dd");


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/search/" + description+ "/" + id + "/" +  ip + "/" +  dateInitial + "/" + dateFinal))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLogs = JsonConvert.DeserializeObject<List<LogViewModel>>(apiResponse);
                }

            
            }
            ViewBag.Total = listLogs.Count();
            var pages = 1;
            ViewData["qtdPagina"] = pages;
            ViewData["pagina"] = 1;
            return View(listLogs);
        }

        public async Task<IActionResult> GetAll()
        {
            List<LogViewModel> listLogs = new List<LogViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listLogs = JsonConvert.DeserializeObject<List<LogViewModel>>(apiResponse);
                }

            }
            ViewBag.Total = listLogs.Count();
            var pages = 1;
            ViewData["qtdPagina"] = pages;
            ViewData["pagina"] = 1;
            return View(listLogs);
        }
    }
}
