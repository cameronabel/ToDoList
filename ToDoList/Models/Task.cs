using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
  /// <summary>
  /// Class <c>Task</c> models a task for a to-do list.
  /// </summary>
  public class Task
  {
    public string Description { get; set; }
    public int ID { get; }

    private static List<Task> _instances = new List<Task> { };
    private static int _rollingCounter = new int();

    /// <summary>
    /// This method returns a list of all tasks in the to-do list.
    /// </summary>
    /// <returns>
    /// List of tasks.
    /// </returns>
    public static List<Task> GetAll()
    {
      return _instances;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Task"/> class.
    /// </summary>
    /// <param name="description">The description of the task</param>
    public Task(string description)
    {
      ID = _rollingCounter;
      _rollingCounter++;
      Description = description;
      _instances.Add(this);
    }
    public string DisplayTask()
    {
      return $"Task# {this.ID}: {this.Description}";
    }
    /// <summary>
    /// This method clears the list of all tasks in the to-do list.
    /// </summary>
    public static void ClearAll()
    {
      _instances.Clear();
      _rollingCounter = 0;
    }
    public static void RemoveTask(int id)
    {
      _instances = _instances.Where(task => task.ID != id).ToList();
    }
  }
}