using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteAmbipar.Models;
using System.Text.Json;

namespace SiteAmbipar.Controllers
{


    public class ClienteController : Controller
    {
        private readonly HttpClient _httpClient;

        public ClienteController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ApiClient");
        }
        // Método para listar clientes
        public async Task<IActionResult> Index(string search = null)
        {
            var response = await _httpClient.GetAsync($"Clientes?search={search ?? ""}");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error"); // Redireciona para uma View de erro
            }

            var content = await response.Content.ReadAsStringAsync();
            var clientes = JsonSerializer.Deserialize<List<Cliente>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(clientes); // Retorna os dados para a View
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: ClienteController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                await _httpClient.PostAsJsonAsync("Clientes", cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            return View();
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
