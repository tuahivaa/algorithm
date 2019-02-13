using System;
using System.IO;

namespace quick_sort
{
    class MainClass
    {
        public static int comparison, ex, recursiveCalls = 0;
        //public static int exchange = 0;
        //public static int recursiveCalls = 0;


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


                    Console.WriteLine("***QUICK SORT***");
                    MainClass aa = new MainClass();
                    aa.write(dataEmployee);
                    //aa.quickSort(dataEmployee, 0, dataEmployee.Length-1);

                    //aa.randomizedQuicksort(dataEmployee, 0, dataEmployee.Length-1);

                    aa.tailRecursiveQuickSort(dataEmployee, 0, dataEmployee.Length - 1);

                    aa.write(dataEmployee);
                    Console.WriteLine("Comparisons: " + comparison);
                    Console.WriteLine("Exchanges: " + ex);
                    Console.WriteLine("Recursive calls: " + (recursiveCalls)*2);




                    StreamWriter sw = new StreamWriter("AFTER_QUICK_SORT.txt");
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


        //encapsulate the logic to print the data
        public void write( Employee[] arr )
        {
            for (int m = 0; m < arr.Length; m++)
            {
                Console.Write(" " + arr[m].id);
            }
            Console.WriteLine("");
        }

        private void exchange(Employee[] arr, int x, int y)
        {
            Employee temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
            ex++;
            //write(arr);
        }


        public void quickSort( Employee[] arr, int p, int r )
        {
            int q = 0;
            if ( p < r )
            {

                q = partition(arr, p, r);
                quickSort(arr, p, q-1);
                quickSort(arr, q+1, r);

            }

        }

        public int partition( Employee[] arr, int p, int r )
        {

            Employee x = arr[r];
            int i = p;
            for ( int j = p ; j < r ; j++ )
            {
                comparison++;
                if ( arr[j].id <= x.id )
                {

                    exchange(arr, i, j);
                    i++;


                }

            }
            //write(arr);
            exchange(arr, i, r);
            return i;

        }

        public int randomizedPartition(Employee[] arr, int p, int r)
        {

            Random i = new Random();
            int x = i.Next(p, r);
            exchange(arr, r, x);
            return partition(arr, p, r);

        }

        public void randomizedQuicksort(Employee[] arr, int p, int r)
        {
            int q = 0;
            if (p < r)
            {

                q = randomizedPartition(arr, p, r);
                randomizedPartition(arr, p, q-1);
                randomizedPartition(arr, q+1, r);
            }

        }

        public void tailRecursiveQuickSort(Employee[] arr, int p, int r)
        {
            int q;
            while ( p<r )
            {

                q = partition(arr, p, r);
                tailRecursiveQuickSort(arr, p, q-1);
                p = q + 1;
                recursiveCalls++;

            }

        }

    }
}
