using IntegratedSystemsExamAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace IntegratedSystemsExamAdmin.Controllers
{
    public class VaccinesController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5176/api/Admin/GetAllVaccines";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Vaccine>>().Result;
            return View(data);
        }

        public IActionResult Details(string id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5176/api/Admin/GetDetailsForVaccine";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Vaccine>().Result;


            return View(result);

        }
    }
}
