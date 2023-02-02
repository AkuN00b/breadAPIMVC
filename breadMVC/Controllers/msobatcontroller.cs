using Microsoft.AspNetCore.Mvc;
using breadMVC.Data;
using breadMVC.Models;
using Microsoft.AspNetCore.Components.Routing;

namespace breadMVC.Controllers
{
    public class msobatcontroller : Controller
    {
        private readonly ApplicationDbContext _db;
        private string _baseAddress = "https://localhost:7198/api/msobat/";


        public msobatcontroller(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<msobat> msobats;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                HttpResponseMessage response = await client.GetAsync("GetAll");

                if (response.IsSuccessStatusCode)
                {
                    msobats = await response.Content.ReadAsAsync<IEnumerable<msobat>>();
                    return View(msobats);
                }

                return NotFound();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(msobat obj)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);
                    HttpResponseMessage response = await client.PostAsJsonAsync("Create", obj);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["notifikasi"] = "Tambah Data Berhasil";
                        return RedirectToAction("Index");
                    }

                    return BadRequest();
                }
            }

            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            else
            {
                msobat? msobats;

                try
                {
                    msobats = _db.msobat.Find(id);
                }
                catch
                {
                    msobats = null;
                }

                if (msobats == null)
                {
                    return NotFound();
                }

                return View(msobats);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(msobat msobats)
        {
            if (ModelState.IsValid)
            {
                _db.msobat.Update(msobats);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(msobats);
        }

        public async Task<IActionResult> Delete(int id)
        {
            msobat msobats = _db.msobat.Find(id);

            msobats.oba_status = "Tidak Ada";
            _db.msobat.Update(msobats);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
