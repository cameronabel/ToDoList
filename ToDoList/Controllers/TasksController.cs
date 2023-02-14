using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class TasksController : Controller
  {
    [HttpGet("/tasks")]
    public ActionResult Display()
    {
      List<Task> allTasks = Task.GetAll();
      return View(allTasks);
    }
    [HttpGet("/tasks/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/tasks")]
    public ActionResult Create(string description)
    {
      Task myTask = new Task(description);
      return RedirectToAction("Display");
    }
    [HttpPost("/tasks/delete")]
    public ActionResult DeleteAll()
    {
      Task.ClearAll();
      return RedirectToAction("Display");
    }
  }
}