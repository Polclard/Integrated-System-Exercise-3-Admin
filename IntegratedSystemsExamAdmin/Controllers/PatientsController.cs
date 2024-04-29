using IntegratedSystemsExamAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace IntegratedSystemsExamAdmin.Controllers
{
    public class PatientsController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5176/api/Admin/GetAllPatients";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Patient>>().Result;
            return View(data);
        }

        public IActionResult Details(string id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5176/api/Admin/GetDetailsForPatient";
            var model = new
            {
                Id = id
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL, content).Result;
            var result = response.Content.ReadAsAsync<Patient>().Result;



            HttpClient client1 = new HttpClient();
            string URL1 = "http://localhost:5176/api/Admin/GetAllVaccinesForPatient";
            var model1 = new
            {
                Id = id
            };
            HttpContent content1 = new StringContent(JsonConvert.SerializeObject(model1), Encoding.UTF8, "application/json");
            HttpResponseMessage response1 = client1.PostAsync(URL1, content1).Result;
            var result1 = response1.Content.ReadAsAsync<List<Vaccine>>().Result;

            result.VaccinationSchedule = result1;

            return View(result);

        }

    }
}
