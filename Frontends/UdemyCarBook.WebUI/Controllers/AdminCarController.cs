using CarBook.ViewModel.ViewModels.BrandViewModels;
using CarBook.ViewModel.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text;

namespace UdemyCarBook.WebUI.Controllers
{
    [Authorize]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Cars/CarListWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarViewModel>>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandViewModel>>(jsonData);
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem()
                                                {
                                                    Text = x.name +" /" +x.model,
                                                    Value = x.brandId.ToString()
                                                }).ToList();
            ViewBag.brandValues = brandValues;
                                               
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarViewModel model)
        {
            model.CoverImageUrl = "x";
            var client = _httpClientFactory.CreateClient();
            var jsonvalue = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonvalue,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7238/api/Cars", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("CreateCar");

            }
            TempData["False"] = "İşlem Başarısız";
            return RedirectToAction("CreateCar");
        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7238/api/Cars?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandViewModel>>(jsonData);
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem()
                                                {
                                                    Text = x.name + " /" + x.model,
                                                    Value = x.brandId.ToString()
                                                }).ToList();
            ViewBag.brandValues = brandValues;




            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7238/api/Cars/" + id);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCarViewModel>(jsonData2);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarViewModel car)
        {
            var client = _httpClientFactory.CreateClient();
            car.CoverImageUrl = "";
            var JsonData = JsonConvert.SerializeObject(car);
            StringContent content = new StringContent(JsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7238/api/Cars", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("UpdateCar");
            }
            TempData["False"] = "İşlem Başarısız";
            return RedirectToAction("UpdateCar");
        }
    }
}
