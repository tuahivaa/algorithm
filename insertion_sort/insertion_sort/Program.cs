using System;
using System.IO;

namespace insertion_sort
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Employee[] dataEmployee;

            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("pass in parameter");
                }
                else
                {

                    //direclty pass the first/second command line parameter to the streamreader
                    //args[0] = employee file
                    StreamReader employeeFile = new StreamReader(args[0]);

                    //read the very first line of the our employe file, it tells us how many employe we have in our file
                    string firstLineSR = employeeFile.ReadLine();
                    int numbersOfEmployee = int.Parse(firstLineSR);

                    //have an array of employee ready to be used in our for loop.
                    dataEmployee = new Employee[numbersOfEmployee];

                    //for loop to go through our employee file, and create an array of employe with their informations in it
                    for (int i = 0; i < numbersOfEmployee; i++)
                    {
                        string line = employeeFile.ReadLine();
                        dataEmployee[i] = new Employee(line);
                    }












                    int key;
                    int comparison = 0;
                    int exchange = 0;

                    for (int i =1;i<dataEmployee.Length; i++)
                    {
                        key = dataEmployee[i].id;
                        int j = i - 1;

                        while ( j >= 0 && dataEmployee[j].id > key)
                        {
                            comparison++;
                            exchange++;
                            dataEmployee[j + 1].id = dataEmployee[j].id;
                            j = j - 1;



                        }

                        //for (int m = 0; m < dataEmployee.Length; m++)
                        //{
                        //    Console.Write(" " + dataEmployee[m].id);
                        //}
                        //Console.WriteLine("");

                        exchange++;
                        dataEmployee[j + 1].id = key;

                    }

                    for (int i =0; i<dataEmployee.Length; i++)
                    {
                        Console.Write(" " + dataEmployee[i].id);
                    }

                    Console.WriteLine("");
                    Console.WriteLine("comparisons: " + comparison);
                    Console.WriteLine("exchanges: " + exchange);

                    //write a sorted files
                    StreamWriter sw = new StreamWriter("AFTER_ANSWER_BUBBLE_SORT.txt");
                    for (int i = 0; i < dataEmployee.Length; i++)
                    {
                        sw.WriteLine(dataEmployee[i]);
                    }
                    sw.Close();








                    employeeFile.Close();
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
            }
        }


    }
}
