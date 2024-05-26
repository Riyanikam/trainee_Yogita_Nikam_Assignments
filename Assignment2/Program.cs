using System;
using System.Collections.Generic;
using System.Xml;
namespace ConsoleAppTask2
{
    internal class Program
    {
       public class Item // Here we have created the class item
        {
            public int Id;
            public string Name;
            public int Price;
            public int Quality;
            public Item(int id,string name,int price,int quality)//Here we have created a constructor
            {
                Id=id;
                Name=name;
                Price=price;
                Quality=quality;
            }
            public override string ToString()
            {
                return $"ID: {Id},Name:{Name},Price:{Price},Quality:{Quality}";
            }
        }
        public class Inventory//Here we have created th class Inventory 
        {
            private List<Item>list;
            public Inventory()
            {
                list=new List<Item>();
            }
            public void AddItem(int newId, string name, int price, int quality)// function for the Add the items to the list
            {
                int i = 0;
                bool findDuplicated=false;
                while (i<list.Count)
                {
                    if (list[i].Id==newId)
                    {
                        Console.WriteLine("Item already exists");
                        findDuplicated = true;
                        break;
                    }
                    i++;
                }
                if (findDuplicated)
                {
                    return;
                }

                Item newItem=new Item(newId,name,price,quality);
                list.Add(newItem);
                Console.WriteLine("Item added successfully");
            }
            public void DisplayItems()//function for the Display the items of the list
            {
                if (list.Count==0)
                {
                    Console.WriteLine("Item list is empty");
                    return;
                }

                for (int i=0;i<list.Count;i++)
                {
                    Console.WriteLine(list[i]);
                }
            }
            public Item FindItemById(int id)//function for the FindItemById the items of the list
            {
                if (id<=0)
                {
                    Console.WriteLine("Enter a valid Id");
                    return null;
                }

                for (int i=0;i<list.Count;i++)
                {
                    if (list[i].Id==id)
                    {
                        return list[i];
                    }
                }

                Console.WriteLine("Item not found");
                return null;
            }
            public void UpdateItem(int id,string name,int price,int quality)//function for updating all the the items of the list
            {
                if (id<=0)
                {
                    Console.WriteLine("You have entered an invalid id. Please enter a valid id");
                    return;
                }
                for (int i=0;i<list.Count;i++)
                {
                    if (list[i].Id==id)
                    {
                        list[i].Name=name;
                        list[i].Price=price;
                        list[i].Quality=quality;
                        Console.WriteLine("Item updated");
                        return;
                    }
                }
                Console.WriteLine("Item not found");
            }
            public void DeleteItem(int id)//function for deleting  the items from the list
            {
                for (int i=0;i<list.Count;i++)
                {
                    if (list[i].Id==id)
                    {
                        list.RemoveAt(i);
                        Console.WriteLine("Item deleted");
                        return;
                    }
                }
                Console.WriteLine("Item not found");
            }
        }

        static void Main(string[] args)
        {
            Inventory In = new Inventory(); // Here we have created the object of the class and accessed it from its object name
            Console.WriteLine("*******Items are added*******");
            In.AddItem(1,"Maggi",20,10); // Added items
            In.AddItem(2,"Biscuits",30,20); 
            In.AddItem(3,"Chocolate",80,30); 
            In.AddItem(4,"BournVita",90,10); 
            In.DisplayItems(); // It will display all the items

            //here we find the item by its id
            Console.WriteLine("\n**********Found the  Item from ID***********");
            Console.WriteLine("The 4 Item found by ID");
            Item foundItem=In.FindItemById(4);
            if (foundItem!=null)
            {
                Console.WriteLine($"Found Item: {foundItem}");
            }

            //here we Update the item
            Console.WriteLine("\n**********Update all the Items**********");
            In.UpdateItem(2,"Bread", 50, 17);
            Console.WriteLine("The list After the Upation");
            In.DisplayItems();

            //here we have deleting the item
            Console.WriteLine("\n**********deletion of a Items**********");
            Console.WriteLine("The 3 item is delete");
            In.DeleteItem(3);
            Console.WriteLine("After deletion Items are");
            In.DisplayItems();
        }
    }
}

/*****************OUTPUT********************/
/*
*******Items are added*******
Item added successfully
Item added successfully
Item added successfully
Item added successfully
ID: 1,Name: Maggi,Price: 20,Quality: 10
ID: 2,Name: Biscuits,Price: 30,Quality: 20
ID: 3,Name: Chocolate,Price: 80,Quality: 30
ID: 4,Name: BournVita,Price: 90,Quality: 10

* *********Found the Item from ID***********
The 4 Item found by ID
Found Item: ID: 4,Name: BournVita,Price: 90,Quality: 10

* *********Update all the Items**********
Item updated
The list After the Upation
ID: 1,Name: Maggi,Price: 20,Quality: 10
ID: 2,Name: Bread,Price: 50,Quality: 17
ID: 3,Name: Chocolate,Price: 80,Quality: 30
ID: 4,Name: BournVita,Price: 90,Quality: 10

* *********deletion of a Items**********
The 3 item is delete
Item deleted
After deletion Items are
ID: 1,Name: Maggi,Price: 20,Quality: 10
ID: 2,Name: Bread,Price: 50,Quality: 17
ID: 4,Name: BournVita,Price: 90,Quality: 10

*/



