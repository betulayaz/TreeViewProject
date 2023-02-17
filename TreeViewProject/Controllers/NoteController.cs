using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TreeViewProject.Models;

namespace TreeViewProject.Controllers
{
    public class NoteController : Controller
    {
        HttpClient client = new HttpClient();
      
        public ActionResult InsertNote()
        {
            List<tbl_notes> note = new List<tbl_notes>();
            client.BaseAddress = new Uri("https://localhost:44365/api/NoteApi");
            var response = client.GetAsync("NoteApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<tbl_notes>>();
                display.Wait();
                note = display.Result;
            }
            ViewBag.data = note;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertNote(tbl_notes note)
        {
            client.BaseAddress = new Uri("https://localhost:44365/api/NoteApi");
            var response = client.PostAsJsonAsync<tbl_notes>("NoteApi", note);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Home");
            }
            return View("InsertNote");
        }

        public ActionResult Delete(int id)
        {
            tbl_notes n = null;
            client.BaseAddress = new Uri("https://localhost:44365/api/NoteApi");
            var response = client.GetAsync("NoteApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<tbl_notes>();
                display.Wait();
                n = display.Result;
            }
            return View(n);
        }
        [HttpPost]
        public ActionResult Delete(tbl_notes n)
        {
            client.BaseAddress = new Uri("https://localhost:44365/api/NoteApi");
            var response = client.PutAsJsonAsync<tbl_notes>("NoteApi", n);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Home");
            }

            return View("Delete");
        }

    }
}