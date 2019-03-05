using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SlingingHash
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            try
            {
                //keep repeating to enter only one paramter
                if (args.Length != 1)
                {
                    Console.WriteLine("please enter only one parameter.");
                }
                else {
                    //read the argument to read the file
                    StreamReader fileName = new StreamReader(args[0]);

                    //m = size of the array - make sure to parse int the input because 
                    // it returns a string!
                    int m = int.Parse(fileName.ReadLine());
                    //n = number of record in the file - same thing make sure
                    // to parse int it.
                    int n = int.Parse(fileName.ReadLine());


                    //create list of arrays of employee.

                    //PAET 1-2 //// division method!!!
                    //Employee[] hash = new Employee[m];

                    //PART3
                    List<Employee>[] hash = new List< Employee >[m];
                    for (int i =0; i<m; i++)
                    {
                        hash[i] = new List<Employee>();
                    }


                    //collision keeps track of the number of collision
                    int collision = 0;
                    double A = (Math.Sqrt(5)-1) / 2.0;
                    for (int i = 0; i < n; i++)
                    {
                        Employee selectedEmployee = new Employee(fileName.ReadLine());
                        int key = selectedEmployee.id;
                        //we are using the division method on the next line.
                        int index = (key) % m;

                        //using the multipication method
                        //int index =  (int)Math.Floor( (m * ( key * A % 1 ) ) );

                        //Console.WriteLine(m + " * ( " + key + " * " + A +  " % 1 ) = " + (m * (key * A % 1)) );
                        //Console.WriteLine(index);

                        //check if index at hash is null

                        //if (hash[index].Count == 0)
                        //{
                        //    hash[index].Add(selectedEmployee);
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Adding " + selectedEmployee.name + " to table at index " + index + " \t\t ( " + (hash[index].Count-1) + " collisions ) ");
                        //    hash[index].Add(selectedEmployee);
                        //}






                        /*
                        if (hash[index] == null)
                        {

                            //division method!!!
                            hash[index] = selectedEmployee;
                            Console.WriteLine("Attempting to hash " + selectedEmployee.name + " at index " + index + "... SUCCESS ");


                        }
                        else
                        {
                            //division mehtod
                            Console.WriteLine("Attempting to hash " + selectedEmployee.name + " at index " + index + "... OUCH!!! Collision with " + hash[index].name );
                            collision++;

                        }
                          
                    */
                        
                        if (hash[index].Count == 0)
                           {
                                
                                Console.WriteLine("Adding " + selectedEmployee.name + " to table at index " + index + " ( " + hash[index].Count + " collisions)");
                                hash[index].Add(selectedEmployee);

                            }
                             else
                            {
                                
                                Console.WriteLine("Adding " + selectedEmployee.name + " to table at index " + " ( " + hash[index].Count + " collisions)");
                                hash[index].Add(selectedEmployee);
                                collision++;
                            }


                    }
                    //print the numbers of collisions.
                    Console.WriteLine("Total collisions: " + collision);


                    /*
                    fileName.ReadLine();

                    int lookupSize = int.Parse(fileName.ReadLine());
                    Console.WriteLine("size of lookup records: " + lookupSize);

                    Employee[] lookupNames = new Employee[lookupSize];

                    for (int i = 0; i<lookupSize-1; i++)
                    {
                        Employee selectedEmployee = new Employee(fileName.ReadLine());
                        lookupNames[i] = selectedEmployee;
                    }
                    */



                }


            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
            }



        }

        public int stringToint(string word)
        {

            int result = 0;

            for (int i =0; i<word.Length; i++)
            {

            }


            return result;
        }
    }
}
