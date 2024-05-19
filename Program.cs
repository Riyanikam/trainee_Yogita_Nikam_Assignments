using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Net.Http.Headers;

namespace ConsoleAppCURD
{
    internal class Program
    {
        class Task//Here we Create a class Task
         {
            public string Title { get; set; }
            public string Description { get; set; }
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

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input.Enter a number");
                    continue;
                }

                switch (choice)//Using Switch Case we have take a choice
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
                
                   //this Case is newly Updated

                   case 3://by using the switch I have updated the task you cn only update the task also and description also and both the task and description 
                        int TskToUpdate;
                        int attribChoice;
                        string newval;
                        string newvaltwo;

                        Console.WriteLine("Enter the task number you want to Update");
                        TskToUpdate = int.Parse(Console.ReadLine()) - 1;

                        if (TskToUpdate < 0 || TskToUpdate >= taskList.Count)
                        {
                            Console.WriteLine("The task Index is Invalid");
                        }
                        else
                        {
                            Console.WriteLine("Select the attribute to update");
                            Console.WriteLine("1.Update Title");
                            Console.WriteLine("2.Update Description");
                            Console.WriteLine("3.Update Title and Description both");//Newly added choice

                            Console.Write("Enter your Choice");
                            attribChoice = int.Parse(Console.ReadLine());

                            switch (attribChoice)
                            {
                                case 1://for Updating only title
                                    Console.WriteLine("Enter a new value of the Title");
                                    newval = Console.ReadLine();
                                    taskList[TskToUpdate].Title = newval;
                                    break;
                                case 2://for Updating only description
                                    Console.WriteLine("Enter a new value of the Description");
                                    newval = Console.ReadLine();
                                    taskList[TskToUpdate].Description = newval;
                                    break;
                                case 3://Here we can update both the thing 
                                    Console.WriteLine("Enter a new value of the Title");
                                    newval = Console.ReadLine();

                                    Console.WriteLine("Enter a new value of the Description");
                                    newvaltwo = Console.ReadLine();

                                    taskList[TskToUpdate].Title = newval;
                                    taskList[TskToUpdate].Description = newvaltwo;
                                    break;

                                    default:
                                    Console.WriteLine("Invalid Choice\n");
                                    break;
                            }
                            
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

                            if (!int.TryParse(Console.ReadLine(), out indexTodel) || indexTodel < 1 || indexTodel > taskList.Count)
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
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 1
Enter the task title
do code
Enter the task Description
do code in cpp
Task is created
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 2
Task List

Task: do code - do code in cpp
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 3
Enter the task number you want to Update
1
Select the attribute to update
1.Update Title
2.Update Description
3.Update Title and Description both
Enter your Choice 1
Enter a new value of the Title
write testcase
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 2
Task List

Task: write testcase - do code in cpp
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 3
Enter the task number you want to Update
1
Select the attribute to update
1.Update Title
2.Update Description
3.Update Title and Description both
Enter your Choice 2
Enter a new value of the Description
make the testcase
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice  2
Task List

Task: write testcase - make the testcase
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 3
Enter the task number you want to Update
1
Select the attribute to update
1.Update Title
2.Update Description
3.Update Title and Description both
Enter your Choice 3
Enter a new value of the Title
coding
Enter a new value of the Description
code should be in java
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
Enter a choice 2
Task List

Task: coding  - code should be in java
List of the task,Enter your  choice
1.Create a Task
2.Read a Task
3.Update a Task
4.Remove a Task
5.Exit
*/
