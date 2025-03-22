using Microsoft.AspNetCore.Mvc;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> todoList = new List<TodoItem>();

        public IActionResult Index()
        {
            return View(todoList);
        }

        [HttpPost]
        public IActionResult Add(string title, string description)
        {
            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                todoList.Add(new TodoItem
                {
                    Id = todoList.Count + 1,
                    Title = title,
                    Description = description,
                    IsCompleted = false
                });
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = todoList.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                todoList.Remove(item);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleComplete(int id)
        {
            var item = todoList.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, string newTitle, string newDescription)
        {
            var item = todoList.FirstOrDefault(t => t.Id == id);
            if (item != null && !string.IsNullOrWhiteSpace(newTitle) && !string.IsNullOrWhiteSpace(newDescription))
            {
                item.Title = newTitle;
                item.Description = newDescription;
            }
            return RedirectToAction("Index");
        }

    }
}
