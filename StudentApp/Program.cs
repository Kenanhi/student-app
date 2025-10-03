using Newtonsoft.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Xml;

class Program
{
    static async Task Main()
    {
        List<ToDoItem> tasks;
        

        if (File.Exists("todos.json"))
        {
            string json = File.ReadAllText("todos.json");
            tasks = JsonConvert.DeserializeObject<List<ToDoItem>>(json);
        }
        else
        {
            tasks = new List<ToDoItem>
            {
                new ToDoItem("Go to sleep", false),
                new ToDoItem("Go to pee", true),
                new ToDoItem("Take a shower", true),
                new ToDoItem("Get coffein ", true),
                new ToDoItem("Eat enough", false)
            };
        }

        while (true)
        {
            System.Console.WriteLine(" 1.List all tasks \n 2.Add a task. \n 3.Mark a task as done \n 4. Mark as undone \n 5.Show only completed \n  6. Delete a task \n 7. Save and exit\n");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        string status = tasks[i].IsDone ? "[x]" : "[ ]";
                        System.Console.WriteLine($"{i + 1}. {status} {tasks[i].Title}");
                    }
                    break;


                case "2":
                    System.Console.WriteLine("Add a title name: ");
                    string? title = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        tasks.Add(new ToDoItem(title, false));
                        System.Console.WriteLine("Tasks added!");
                    }

                    else
                    {
                        System.Console.WriteLine("Invalid title input. Please try again: ");
                    }
                    break;


                case "3":
                    System.Console.WriteLine("Which task do you want to mark as done?");
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out int number))
                    {
                        int index = number - 1;
                        if (index >= 0 && index < tasks.Count)
                        {
                            tasks[index].IsDone = true;
                            System.Console.WriteLine($"Task '{tasks[index].Title}' marked as done! ");
                        }
                        else
                        {
                            System.Console.WriteLine("No task with that number");
                        }

                    }

                    else
                    {
                        System.Console.WriteLine("Invalid number..");
                    }
                    break;
                case "4":
                    System.Console.WriteLine("Which task do you want to mark as undone?");
                    string? undoneInput = Console.ReadLine();

                    if (int.TryParse(undoneInput, out int undoneNumber))
                    {
                        int undoneIndex = undoneNumber - 1;
                        if (undoneIndex >= 0 && undoneIndex < tasks.Count)
                        {
                            tasks[undoneIndex].IsDone = false;
                            System.Console.WriteLine($"Task '{tasks[undoneIndex].Title}' marked as undone! ");
                        }
                        else
                        {
                            System.Console.WriteLine("No task with that number");
                        }

                    }

                    else
                    {
                        System.Console.WriteLine("Invalid number..");
                    }

                    break;

                case "5":
                    var doneTasks = tasks.Where(t => t.IsDone);
                    foreach (var t in doneTasks)
                    {
                        System.Console.WriteLine($"{t.Title} + {t.IsDone}");
                    }


                    break;
                case "6":
                    System.Console.WriteLine("Select a task to remove: ");
                    string? removeInput = Console.ReadLine();
                    if (int.TryParse(removeInput, out int removeNumber))
                    {
                        int removeIndex = removeNumber - 1;
                        if (removeIndex >= 0 && removeIndex < tasks.Count)
                        {
                            tasks.RemoveAt(removeIndex);
                            Console.WriteLine("Task removed!");
                        }
                        else
                        {
                            Console.WriteLine("No task with that number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number..");
                    }

                    break;

                case "7":
                    string json = JsonConvert.SerializeObject(tasks, Newtonsoft.Json.Formatting.Indented);
                    await File.WriteAllTextAsync("todos.json", json);
                    System.Console.WriteLine("Tasks saved asynchronously. Exiting...");
                    return;

            }
        }
    }
}