// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using WebBookmarkApp.Models;
using System.Linq;

namespace WebBookmarkApp.Controllers
{
    public interface IHomeController
    {
        IActionResult About();
        IActionResult Create();
        IActionResult Create(Note note);
        IActionResult Index();
        IActionResult Notes(string? type = null, string? tag = null);
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

        public IActionResult Notes(string? type = null, string? tag = null)
        {
            IEnumerable<Models.Note> filtered = _notes;
            if (!string.IsNullOrEmpty(type))
            {
                if (type == "bookmark")
                    filtered = filtered.Where(n => n.IsBookmark);
                else if (type == "note")
                    filtered = filtered.Where(n => !n.IsBookmark);
            }
            if (!string.IsNullOrEmpty(tag))
            {
                filtered = filtered.Where(n => n.Tags.Contains(tag));
            }
            return View(filtered.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Note note)
        {
            // 允许书签内容为空
            if (note.IsBookmark)
            {
                note.Content = string.Empty;
            }
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