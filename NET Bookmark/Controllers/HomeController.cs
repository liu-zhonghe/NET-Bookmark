// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using WebBookmarkApp.Models;

namespace WebBookmarkApp.Controllers
{
    public interface IHomeController
    {
        IActionResult About();
        IActionResult Create();
        IActionResult Create(Note note);
        IActionResult Index();
        IActionResult Notes();
    }

    public class HomeController : Controller, IHomeController
    {
        public IActionResult Index()
        {
            var sampleNote = new Models.Note
            {
                Id = 1,
                Title = "欢迎使用网页书签应用",
                Content = "请点击导航栏查看笔记"
            };
            return View(sampleNote);
        }

        public IActionResult About()
        {
            return View();
        }

        private static List<Models.Note> _notes = new List<Models.Note>();

        public IActionResult Notes()
        {
            return View(_notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Note note)
        {
            if (ModelState.IsValid)
            {
                note.Id = _notes.Count + 1;
                note.CreatedAt = DateTime.Now;
                note.UpdatedAt = DateTime.Now;
                _notes.Add(note);
                return RedirectToAction("Notes");
            }
            return View(note);
        }

        public IActionResult Delete(int id)
        {
            var noteToDelete = _notes.FirstOrDefault(n => n.Id == id);
            if (noteToDelete != null)
            {
                _notes.Remove(noteToDelete);
            }
            return RedirectToAction("Notes");
        }
    }
}