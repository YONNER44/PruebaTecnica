using Microsoft.AspNetCore.Mvc;
using BookRadar.Data;
using BookRadar.Models;
using Newtonsoft.Json.Linq;

namespace BookRadar.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // seguridad extra
        public async Task<IActionResult> Search(string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                ViewBag.Error = "Por favor ingresa un nombre de autor.";
                return View();
            }

            var url = $"https://openlibrary.org/search.json?author={Uri.EscapeDataString(authorName)}";
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);
            var docs = json["docs"];

            var results = new List<SearchHistory>();

            foreach (var doc in docs)
            {
                var title = doc["title"]?.ToString();
                var year = doc["first_publish_year"]?.ToObject<int?>();
                var publisherArray = doc["publisher"]?.ToObject<List<string>>();
                var publisher = (publisherArray != null && publisherArray.Any())
                    ? publisherArray.First()
                    : "Desconocido";

                var searchHistory = new SearchHistory
                {
                    Autor = authorName,
                    Titulo = title,
                    AnioPublicacion = year,
                    Editorial = publisher,
                    FechaConsulta = DateTime.Now
                };

                results.Add(searchHistory);
                _context.HistorialBusquedas.Add(searchHistory);
            }

            await _context.SaveChangesAsync();

            return View("Results", results);
        }

        public IActionResult History()
        {
            var history = _context.HistorialBusquedas
                .OrderByDescending(h => h.FechaConsulta)
                .ToList();
            return View(history);
        }
    }
}