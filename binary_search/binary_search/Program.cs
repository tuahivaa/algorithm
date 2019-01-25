using System;
using System.IO;

namespace binary_search
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


                    for (int i = 0; i < numbersOfQuery; i++ )
                    {
                        //put query variales in dataquery array
                        dataQuery[i] = int.Parse(queryFile.ReadLine());
                    }


                    double average = 0;
                    double comparison = 0;

                    for (int i = 0; i < numbersOfQuery; i++)
                    {

                        int position = 0;
                        int ID = dataQuery[i];
                        double low = 0;
                        double high = Math.Max( dataEmployee.Length, low );
                        //Console.WriteLine(high);
                        int mid = 0;



                        while (low < high)
                        {
                            mid = (int)( Math.Floor( (low + high) / 2.0 ) ) ;
                            //Console.WriteLine(mid);
                            //Console.WriteLine("ID: "+dataEmployee[mid].id);

                            if (ID <= dataEmployee[mid].id)
                            {
                                high = mid;
                                //Console.WriteLine(high);
                                comparison++;
                                position++;
                                average = average + comparison + 1;
                            }
                            else
                            {
                                //Console.WriteLine(mid);
                                low = mid + 1;
                                //Console.WriteLine(low);
                                comparison++;
                                position++;
                                average = average + comparison + 1;
                            }

                        }



                        //Console.WriteLine( ID + " compared with " + dataEmployee[mid].id );
                        Console.WriteLine("Looking for " + ID + " ... Found " + dataEmployee[mid+1].name + " at position " + (mid+1 ) + " COMPARISON = " + position );

                    }
                    average = comparison / numbersOfQuery;
                    Console.WriteLine("Average number of comparisons overall: " + average);


                    ////average is used to calculate the average of comparison overall.
                    //double average = 0;

                    ////read the query file and put each ID in an array
                    //for (int i = 0; i < numbersOfQuery; i++)
                    //{
                    //    //position is the position of the employee we look for in the file.
                    //    int position = 0;

                    //    dataQuery[i] = int.Parse(queryFile.ReadLine());



                    //    //START BINARY SEARCH HERE!!!


                    //}
                    //average = average / numbersOfQuery;
                    //Console.WriteLine("Average number of comparisons overall : " + average);












                    employeeFile.Close();
                    queryFile.Close();
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
            }
        }

        public double binarySearch(int x, int T, int p, int r)
        {
            double low = p;
            double high = Math.Max(p, (r + 1));

            while (low < high)
            {

                int mid = (int)Math.Floor( (low + high) / 2);
                if ( x <=  T )
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }

            }

            return high;
        }


    }






}
