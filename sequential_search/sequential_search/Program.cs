using System;
using System.IO;

namespace sequential_search
{
    class MainClass
    {
        public static void Main(string[] args)
        {
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
                    //args[1] = query file
                    StreamReader employeeFile = new StreamReader(args[0]);
                    StreamReader queryFile = new StreamReader(args[1]);

                    //read the very first line of the our employe file, it tells us how many employe we have in our file
                    string firstLineSR = employeeFile.ReadLine();
                    int numbersOfEmployee = int.Parse(firstLineSR);

                    //read the first line of our queryFile, it tells us which employee we want to look at.
                    string firstLineQuery = queryFile.ReadLine();
                    int numbersOfQuery = int.Parse(firstLineQuery);

                    //have an array of employee ready to be used in our for loop.
                    Employee[] dataEmployee = new Employee[numbersOfEmployee];
                    //have an array of ID.
                    int[] dataQuery = new int[numbersOfQuery];

                    //for loop to go through our employee file, and create an array of employe with their informations in it
                    for (int i = 0; i < numbersOfEmployee; i++)
                    {
                        string line = employeeFile.ReadLine();
                        dataEmployee[i] = new Employee(line);
                    }

                    //for (int i = 0; i < numbersOfEmployee; i++)
                    //{
                    //    Console.WriteLine(data[i]);
                    //}

                    //average is used to calculate the average of comparison overall.
                    double average = 0;

                    //read the query file and put each ID in an array
                    for (int i = 0; i < numbersOfQuery; i++)
                    {
                        //position is the position of the employee we look for in the file.
                        int position = 0;

                        dataQuery[i] = int.Parse(queryFile.ReadLine());

                        for (int j = 0; j < numbersOfEmployee; j++)
                        {
                            if (dataQuery[i] == dataEmployee[j].id )
                            {
                                Console.WriteLine("Looking for " + dataQuery[i] + " ... Found " + dataEmployee[j].name + " at position " + position + " after " + (position+1) + " comparisons.");
                                //add one because we are one count behind.
                                average = average + position + 1;
                                break;
                            }

                            position++;
                        }
                    }
                    average = average / numbersOfQuery;
                    Console.WriteLine("Average number of comparisons overall : " + average);

                    employeeFile.Close();
                    queryFile.Close();
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
