using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace ConsoleAppCURD
{
    internal class Program
    {
        class Task//Here Create a Task class with it's parameter values and get,set for  further suppose
        {
            public string Title{ get; set; }
            public string Description{ get; set; }
            }

            static void Main(String[] args)
            {

                List<Task> taskList = new List<Task>();//Created a list for the operation provide by the generic type  

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("List of the task,Enter your  choice");//Displaying a menu to Enter Choice
                    Console.WriteLine("1.Create a Task");
                    Console.WriteLine("2.Read a Task");
                    Console.WriteLine("3.Update a Task");
                    Console.WriteLine("4.Remove a Task");
                    Console.WriteLine("5.Exit");

                    int choice;
                    Console.Write("Enter a choice");

                if (!int.TryParse(Console.ReadLine(),out choice))
                {
                    Console.WriteLine("Invalid Input.Enter a number");
                    continue;
                }

                switch (choice)//Using Switch Casewe have take a choice
                {
                    case 1://Create operation has been perform here
                        string Title;
                        string Description;
                        Console.WriteLine("Enter the task title");
                        Title = Console.ReadLine();
                        Console.WriteLine("Enter the task Description");
                        Description = Console.ReadLine();
                        Task newTask = new Task
                        {
                            Title = Title,
                            Description = Description
                        };
                        taskList.Add(newTask);
                        Console.WriteLine("Task is created");
                        break;


                    case 2://Here we have perform the Read operation
                            if (taskList.Count == 0)
                            {
                                Console.WriteLine("No Available task");
                            }
                            else
                            {
                                Console.WriteLine("Task List \n ");
                            foreach (var task in taskList)
                            {
                                Console.WriteLine($"Task: {task.Title} - {task.Description}");
                            }


                        }

                        break;

                    case 3://here we have done the updation and we can update both decription and title by entering choice in the switch case
                        int TskToUpdate;
                        int attribChoice;
                        string newval; 

                        Console.WriteLine("Enter the task number you want to Update");
                        TskToUpdate = int.Parse(Console.ReadLine())-1; 

                        if (TskToUpdate < 0 || TskToUpdate >= taskList.Count)                         {
                            Console.WriteLine("The task Index is Invalid");
                        }
                        else
                        {
                            Console.WriteLine("Select the attribute to update");
                            Console.WriteLine("1. Title");
                            Console.WriteLine("2. Description\n");

                            Console.Write("Enter your Choice");
                            attribChoice = int.Parse(Console.ReadLine()); 
                            Console.WriteLine("Enter a new value to be updated");
                            newval = Console.ReadLine(); 

                            switch (attribChoice)//here switch has been use for updation
                            {
                                case 1:
                                    taskList[TskToUpdate].Title = newval;
                                    break;
                                case 2:
                                    taskList[TskToUpdate].Description = newval;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice\n");
                                    break;
                            }
                            Console.WriteLine("Task Updated successfully!");
                        }
                        break;
                    case 4://deletion is done here remove the element of the specified position by giving the index  using list function and have check for the basic condition
                        int indexTodel;

                        if (taskList.Count == 0)
                        {
                            Console.WriteLine("No task is Available");
                        }
                        else
                        {
                            Console.WriteLine("Enter a Task index you want to delete");

                            if (!int.TryParse(Console.ReadLine(),out indexTodel) || indexTodel < 1 || indexTodel > taskList.Count)
                            {
                                Console.WriteLine("Invalid Index.");
                            }
                            else
                            {
                                taskList.RemoveAt(indexTodel - 1);
                                Console.WriteLine("Task deleted successfully");
                            }
                        }
                        break;

                    case 5://last case for remove ourself  from the program i.e exit
                        exit = true;
                        break;

                    default://default case of the switch case whwn we enter the invalid choice which is not Present
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}

/* OUTPUT OF THE CODE */
/*
List of the task, Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 1
Enter the task title
write a code
Enter the task Description
Write a code using C#
Task is created
List of the task, Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 2
Task List

Task: write a code - Write a code using C#
List of the task, Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 3
Enter the task number you want to Update
1
Select the attribute to update
1. Title
2. Description

Enter your Choice 1
Enter a new value to be updated
write the html
Task Updated successfully!
List of the task, Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 2
Task List

Task: write the html - Write a code using C#
List of the task, Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 4
Enter a Task index you want to delete
1
Task deleted successfully
List of the task, Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 2
No Available task
List of the task, Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 5

C:\Users\Admin\source\repos\ConsoleAppCURD\bin\Debug\net8.0\ConsoleAppCURD.exe (process 1068) exited with code 0.
Press any key to close this window . . .
*/