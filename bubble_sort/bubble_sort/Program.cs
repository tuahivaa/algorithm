using System;
using System.IO;

namespace bubble_sort
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







                    int exchange = 0;
                    int comparison = 0;

                    for (int i = 0; i < (dataEmployee.Length - 1); i++)
                    {

                        for (int j = 0; j < (dataEmployee.Length - 1 - i); j++)
                        {
                            comparison++;
                            if ( dataEmployee[j].id > dataEmployee[j+1].id )
                            {
                                (dataEmployee[j], dataEmployee[j + 1]) = (dataEmployee[j + 1], dataEmployee[j]);
                                for (int k = 0; k < (dataEmployee.Length); k++)
                                {
                                    //Console.Write(dataEmployee[k].id + " ");

                                }
                                //Console.WriteLine("");
                                exchange++;


                            }





                        }



                    }

                    Console.WriteLine("comparisons : " + comparison);
                    Console.WriteLine("exchange : " + exchange);





                    employeeFile.Close();
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
            }

        }


        public void bubbleSort( Employee[] a )
        {

            //for ( int i = 0; i< (a.Length-1) ; i++ )
            //{

            //    for (int j = 0; j< (a.Length-1); j++ )
            //    {

            //        if ( )
            //        {

            //        }

            //    }

            //}

        }

    }
}
