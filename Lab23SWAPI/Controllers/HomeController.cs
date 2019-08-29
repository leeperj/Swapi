using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab23SWAPI.Models;
using System.Net.Http;
using Microsoft.IdentityModel.Protocols;

namespace Lab23SWAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api/");
           
            return client;
        }
        public static async Task<List<PeopleResult>> Luke()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("api/people/1/");
            var person = await response.Content.ReadAsAsync<List<PeopleResult>>();
            return person;
        }
        public static async Task<List<PlanetResult>> Dagobah()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("api/planets/5/");
            var planet = await response.Content.ReadAsAsync<List<PlanetResult>>();
            return planet;
        }

    }
}
