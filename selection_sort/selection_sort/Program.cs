using System;
using System.IO;

namespace selection_sort
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


                    //write selection sort code here

                    int min;
                    int minIndex;
                    int comparisons = 0;
                    int exchanges = 0;


                    Console.WriteLine("********SELECTION SORT********");


                    for (int i = 0; i < dataEmployee.Length-1; i++)
                    {

                        min = dataEmployee[i].id;
                        minIndex = i;

                        for (int j = i; j < dataEmployee.Length; j++)
                        {
                            comparisons++;
                            if ( dataEmployee[j].id < min )
                            {
                                min = dataEmployee[j].id;
                                minIndex = j;
                            }

                        }
                        exchanges++;
                        (dataEmployee[minIndex], dataEmployee[i]) = (dataEmployee[i], dataEmployee[minIndex]);

                        for (int m = 0; m < dataEmployee.Length; m++)
                        {
                            Console.Write(" " + dataEmployee[m].id);
                        }
                        Console.WriteLine("");


                    }

                    //print exchanges and comparisons
                    Console.WriteLine("Comparisons: " + comparisons);
                    Console.WriteLine("Exchanges: " + exchanges);


                    //for (int m = 0; m < dataEmployee.Length; m++)
                    //{
                    //    Console.Write(" " + dataEmployee[m].id);
                    //}
                    //Console.WriteLine("");




                    StreamWriter sw = new StreamWriter("AFTER_ANSWER_SELECTION_SORT.txt");
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