using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    //Mark Simpson, IS 403, Data Structure Program
    //Allows the user to load up three different data structures and modify them depending on whatever
    //the user chooses in the menu options
    
    class Program
    {
        static void Main(string[] args)
        {
            //Stack Declaration
            Stack<String> myStack = new Stack<String>();

            //Queue Declaration
            Queue<String> myQueue = new Queue<String>();

            //Dictionary Declaration 
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            //Temporary stack that will be used to keep the integrity of the structure during the delete option
            Stack<String> TemporaryStack = new Stack<String>();
           
            //Temporary Queue that has the same purpose as the temporary stack as above
            Queue<String> TemporaryQueue = new Queue<String>();

            //variable declartion
            bool bMenu = true;
            bool b;
            bool c;
            uint iMenuOption = 0;
            uint iStackOption = 0;
            uint iQueueOption = 0;
            uint iDictionaryOption = 0;
            int iStackCount = 0;
            int iListAmount = 2000;
            int iCount = 0;
            int iCount2 = 0;
            int iDictionaryNumber = 0;
            string sStackAdd;
            string sDelete;
            string sElementDelete;
            string sReplace;
            string sPush;
            string sQueueAdd;
            string sDictionaryAdd;
            string sDictionarySearch;
            string sDictionaryDelete;
            string sHolder = "";

            Console.Write("Welcome! Please Select an Option\n\n");

            //Loop that keeps menu alive until the user decides its time to exit
            while (bMenu == true)
            {
                //Menu output
                Console.Write("1. Stack\n");
                Console.Write("2. Queue\n");
                Console.Write("3. Dictionary\n");
                Console.Write("4. Exit\n");

                do
                {
                    b = true;
                   
                    try
                    {
                        iMenuOption = uint.Parse(Console.ReadLine());
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                } while (b == false);



                if (iMenuOption == 1)
                {
                    c = true;

                    while (c == true)
                    {

                        Console.Write("\nYou have selected the Stack option\n\n");
                        Console.Write("1. Add one item to Stack\n");
                        Console.Write("2. Add Huge List of Items to Stack\n");
                        Console.Write("3. Display Stack\n");
                        Console.Write("4. Delete From Stack\n");
                        Console.Write("5. Clear Stack\n");
                        Console.Write("6. Search Stack\n");
                        Console.Write("7. Return to Main Menu\n");

                        do
                        {
                            try
                            {
                                iStackOption = uint.Parse(Console.ReadLine());
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        } while (b == false);

                        if (iStackOption == 1)
                        {
                            //Option that allows the user to manual load a stack however they want
                            Console.Write("\nPlease enter a string to add to the stack\n\n");

                            sStackAdd = Console.ReadLine();

                            //pushes the variable the user entered onto the stack
                            myStack.Push(sStackAdd);

                            Console.Write("\nItem Added\n\n");
                        }

                        else if (iStackOption == 2)
                        {
                            //the option that adds the huge list to the stack, this first line of code just clears out the stack
                            myStack.Clear();

                            //Loop that runs through the 2000 entries and pushes them back into the stack
                            for (iStackCount = 0; iStackCount < iListAmount; iStackCount++)
                            {
                                myStack.Push("New Entry: " + (iStackCount + 1));
                            }

                            Console.WriteLine("\n\nList Added\n\n");
                        }

                        else if (iStackOption == 3)
                        {
                            Console.WriteLine("\nCurrent Stack\n");

                            //Foreach loop that runs through each element of the stack and displays it
                            foreach (string element in myStack)
                            {

                                Console.WriteLine(element);
                            }
                            Console.WriteLine("\n");
                        }

                        else if (iStackOption == 4)
                        {

                            Console.WriteLine("\nWhich Stack Element would you like to delete?\n");

                            sDelete = Console.ReadLine();

                            int iRunner = myStack.Count;

                                    //Loop that runs through the size of the stack, the size is stored in the integer variable above
                                    for (iCount = 0; iCount < iRunner; iCount++)
                                    {
                                        //each element is popped out and evaluated 
                                        sElementDelete = myStack.Pop();

                                        if (sElementDelete == sDelete)
                                        {
                                            Console.WriteLine("\nElement Removed\n");
                                            //If the condition is true, the element stays popped out and is gone
                                            c = true;
                                        }

                                        else
                                        {
                                            //Otherwise, the element will be pushed into a temporary stack until its time to rebuild
                                            TemporaryStack.Push(sElementDelete);

                                        }
                                    }
                                    int iTempCount = TemporaryStack.Count;
                                    //This loop takes the temporary stack and rebuilds the orginal stack without the deleted element
                                    for (iCount2 = 0; iCount2 < iTempCount; iCount2++)
                                    {
                                        sReplace = TemporaryStack.Pop();
                                        sPush = sReplace;
                                        myStack.Push(sPush);
                                    }
                                }
                               
                        else if (iStackOption == 5)
                        {
                            //Option that clears the stack
                            myStack.Clear();
                            Console.WriteLine("\nStack Cleared\n");
                        }
                        //search option
                        else if (iStackOption == 6)
                        {
                            //grabs the user input and calls the stopwatch method and starts it
                            Console.WriteLine("\nWhich Element do you want to search for?\n");
                            string sSearch = Console.ReadLine();
                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                            sw.Start();

                            foreach (string search in myStack)
                            {
                                if (sSearch == search)
                                {
                                    //If the element is found, the stopwatch is stopped and the time is displayed. 
                                    Console.WriteLine("\nElement Found: " + search + "\n");
                                    sw.Stop();
                                    Console.WriteLine("\nTime Elasped to find element: " + sw.Elapsed + "\n");
                                    break;
                                }

                                if (search == myStack.Last())
                                {
                                    //When the search comes up empty, this code will run
                                    Console.WriteLine("\nElement Not Found\n ");
                                }
                            }
                        }

                        else if (iStackOption == 7)
                        {
                            Console.WriteLine("\n");
                            c = false;
                        }

                        else
                        {
                            Console.WriteLine("\nInvalid input, please enter one of the menu options\n");

                        }

                    }
                }
               
                else if (iMenuOption == 2)
                {
                    c = true;

                    while (c == true)
                    {

                        Console.Write("\nYou have selected the Queue option\n\n");
                        Console.Write("1. Add one item to Queue\n");
                        Console.Write("2. Add Huge List of Items to Queue\n");
                        Console.Write("3. Display Queue\n");
                        Console.Write("4. Delete From Queue\n");
                        Console.Write("5. Clear Queue\n");
                        Console.Write("6. Search Queue\n");
                        Console.Write("7. Return to Main Menu\n");

                        do
                        {

                            try
                            {
                                //Queue option, that is pretty much the exact same as the Stack option
                                iQueueOption = uint.Parse(Console.ReadLine());
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        } while (b == false);

                        if (iQueueOption == 1)
                        {
                            //Adds a spot back in the queue, except this time it uses the enqueue method
                            Console.Write("\nPlease enter a string to add to the Queue\n\n");
                            sQueueAdd = Console.ReadLine();
                            myQueue.Enqueue(sQueueAdd);
                            Console.Write("\nItem Added to Queue\n\n");
                        }
                        else if (iQueueOption == 2)
                        {
                            //exact same as the stack except using the enqueue method
                            myQueue.Clear();
                            for (iCount = 0; iCount < iListAmount; iCount++)
                            {
                                myQueue.Enqueue("New Entry: " + (iCount + 1));
                            }

                            Console.WriteLine("\n\nList Added to Queue\n\n");
                        }

                        else if (iQueueOption == 3)
                        {
                            Console.WriteLine("\n");
                            //same thing as the stack 
                            foreach (string element in myQueue)
                            {
                                Console.WriteLine(element);
                            }

                            Console.WriteLine("\n");
                        }

                        else if (iQueueOption == 4)
                        {
                            //same delete code as the stack except now queues are being used
                            Console.WriteLine("\nWhich Queue Element would you like to delete?\n");
                            sDelete = Console.ReadLine();
                            int iRunner = myQueue.Count;

                            for (iCount = 0; iCount < iRunner; iCount++)
                            {
                                sElementDelete = myQueue.Dequeue();
                                //checks the above statment before entering the if/else tree
                                if (sElementDelete == sDelete)
                                {
                                    Console.WriteLine("\nElement Removed\n");
                                    //same as before, now the element is gone and it won't be added to the temp queue
                                }
                                //otherwise the element is picked up by the temp queue until later
                                else
                                {
                                    TemporaryQueue.Enqueue(sElementDelete);
                                }
                            }

                            int iTempCount = TemporaryQueue.Count;

                            for (iCount2 = 0; iCount2 < iTempCount; iCount2++)
                            {
                                //loop that connects the temporary queue back with the original queue
                                sReplace = TemporaryQueue.Dequeue();
                                sPush = sReplace;
                                myQueue.Enqueue(sPush);
                            }
                        }

                        else if (iQueueOption == 5)
                        {
                            //clears out the queue
                            myQueue.Clear();
                            Console.WriteLine("\nQueue Cleared\n");
                        }

                        else if (iQueueOption == 6)
                        {
                            //same as the stack search
                            Console.WriteLine("\nWhich Element do you want to search for?\n");
                            string sSearch = Console.ReadLine();
                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                            sw.Start();

                            foreach (string search in myQueue)
                            {
                                if (sSearch == search)
                                {
                                    Console.WriteLine("\nElement Found: " + search + "\n");
                                    sw.Stop();
                                    Console.WriteLine("\nTime Elasped to find element: " + sw.Elapsed + "\n");
                                    break;
                                }

                                if (search == myQueue.Last())
                                {
                                    Console.WriteLine("\nElement Not Found\n ");
                                }
                            }
                        }
                        else if (iQueueOption == 7)
                        {
                            Console.WriteLine("\n");
                            c = false;
                        }

                        else
                        {
                            Console.WriteLine("\nInvalid, Please Select an option from the menu\n");
                        }
                      }
                    }
                //the same process except using a dictionary 
                else if (iMenuOption == 3)
                {
                    c = true;

                    while (c == true) { 

                    Console.Write("\nYou have selected the Dictionary option\n\n");
                    Console.Write("1. Add one item to Dictionary\n");
                    Console.Write("2. Add Huge List of Items to Dicationary\n");
                    Console.Write("3. Display Dictionary\n");
                    Console.Write("4. Delete From Dictionary\n");
                    Console.Write("5. Clear Dictionary\n");
                    Console.Write("6. Search Dictionary\n");
                    Console.Write("7. Return to Main Menu\n");

                    do
                    {
                        try
                        {
                            iDictionaryOption = uint.Parse(Console.ReadLine());
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine();
                        }

                    } while (b == false);

                    if (iDictionaryOption == 1)
                    {
                        //this time we need to add the dictionary key, as well as the value for the dictionary
                        //picks up both values from the user
                        Console.WriteLine("\nWhat String would you like to add to the dictionary?\n");
                        sDictionaryAdd = Console.ReadLine();

                        Console.WriteLine("\nWhat number value would you like to add to the dictionary?\n");

                        iDictionaryNumber = int.Parse(Console.ReadLine());

                        myDictionary.Add(sDictionaryAdd, iDictionaryNumber);

                        Console.WriteLine("\nDictionary Item Added\n");
                    }

                    else if (iDictionaryOption == 2)
                    {
                        //clears it out like before, next does the same as before just with dictionary value
                        myDictionary.Clear();

                        for (iCount = 0; iCount < iListAmount; iCount++)
                        {
                            myDictionary.Add("New Entry: " + (iCount + 1), (iCount + 1));
                        }

                        Console.WriteLine("\n\nDictionary List Added\n\n");
                    }

                    else if (iDictionaryOption == 3)
                    {
                        //displays whatever is in the dictionary just like before
                        foreach (KeyValuePair<string, int> element in myDictionary)
                        {
                            Console.WriteLine("\n" + element.Key + "\t" + element.Value.ToString() + "\t");
                        }
                    }

                    else if (iDictionaryOption == 4)
                    {
                        //the delete from the dictionary is less complicated, instead the .Remove method is used
                        Console.WriteLine("\nWhich Element do you want to delete from the dictionary?\n");
                        sDictionaryDelete = Console.ReadLine();
                        //runs thorugh the dictionary just like with the queue and stack
                        foreach (KeyValuePair<string, int> delete in myDictionary)
                        {
                            if (delete.Key == sDictionaryDelete)
                            {
                                //if the key finds a match, the .Remove method cleans it out, without having to resize
                                myDictionary.Remove(sDictionaryDelete);
                                Console.WriteLine("\nKey Pair deleted from Dictionary\n");
                                break;
                            }
                        }
                    }

                    else if (iDictionaryOption == 5)
                    {
                        //simply clears the dictionary
                        myDictionary.Clear();
                        Console.WriteLine("\nDictionary Cleared\n");
                    }

                    else if (iDictionaryOption == 6)
                    {
                        //does the search with the stopwatch just like before
                        Console.WriteLine("\nWhat Dictionary Item do you want to find\n");
                        sDictionarySearch = Console.ReadLine();
                        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                        sw.Start();

                        foreach (KeyValuePair<string, int> search in myDictionary)
                        {

                            //if the key is found the stopwatch time stops and will be held until the display
                            if (search.Key == sDictionarySearch)
                            {
                                sw.Stop();
                                sHolder = search.Key;
                            }
                        }
                        //Now outside of the for loop the displays are located, just to avoid duplicates
                        if (myDictionary.ContainsKey(sDictionarySearch))
                        {
                            sw.Stop();
                            Console.WriteLine("\nElement Found: " + sHolder + "  " + sw.Elapsed + "\n");
                        }
                        else
                        {
                            Console.WriteLine("\nElement not Found\n");
                        }
                    }

                    else if (iDictionaryOption == 7)
                    {
                        Console.WriteLine("\n\n");
                        c = false;
                    }

                    else
                    {
                        Console.WriteLine("\nInvalid, Please Select an option from the menu\n");
                    }
                }
             }

                else if (iMenuOption == 4)
                {
                    //just exits the program
                    Console.Write("\nThank you! GoodBye\n\n");
                    bMenu = false;
                }

                else
                {
                    Console.WriteLine("\nInvalid Input, please enter a 1, 2, 3, or 4\n");
                }                
            }            
        }
    }
}
