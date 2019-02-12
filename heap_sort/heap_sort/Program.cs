using System;
using System.IO;

namespace heap_sort
{
    class MainClass
    {

        int heapsize;
        public int comparison = -5;
        public int exch = 0;

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


                    Console.WriteLine("***HEAP SORT***");
                    for (int m = 0; m < dataEmployee.Length; m++)
                    {
                        Console.Write(" " + dataEmployee[m].id);
                    }
                    Console.WriteLine("");

                    MainClass aa = new MainClass();
                    aa.heapSort(dataEmployee);

                    //for (int m = 0; m < dataEmployee.Length; m++)
                    //{
                    //    Console.Write(" " + dataEmployee[m].id);
                    //}
                    //Console.WriteLine("");
                    //Console.WriteLine("comparison: " );





                    StreamWriter sw = new StreamWriter("AFTER_HEAP_SORT.txt");
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




        public void maxHeapify(Employee[] arr, int index)
        {

            int left = (index + 1) * 2 - 1; //2 * index;
            int right = (index + 1) * 2; //2 * index + 1;
            int largest = index;

            comparison = comparison + 5;

            if (left <= heapsize && arr[left].id > arr[index].id)
            {
                largest = left;
                //comparison = comparison + 5;
            }


            if (right <= heapsize && arr[right].id > arr[largest].id)
            {

                //comparison = comparison + 5;
                largest = right;
            }

            if (largest != index)
            {
                //(arr[index],arr[largest]) = (arr[largest],arr[index]);
                //Swap(arr, index, largest);

                //comparison = comparison + 5;

                exchange(arr, index, largest);
                maxHeapify(arr, largest);
            }




        }



        public void buildMaxHeap(Employee[] input)
        {
            // input.heapSize = input.length;
            heapsize = input.Length-1;


            for (int i = (input.Length)/2 ; i >= 0 ; i-- )
            {
                maxHeapify(input, i);
            }



        }

        public void heapSort(Employee[] input)
        {


            buildMaxHeap(input);
            for (int i = input.Length-1 ; i >0 ; i--  )
            {

                for (int m = 0; m < input.Length; m++)
                {
                    Console.Write(" " + input[m].id);
                }
                Console.WriteLine("");


                exchange(input, 0, i);
                //( input[1] , input[i] ) = ( input[i] , input[1] );
                // input.heapsize = A.heapsize - 1;
                heapsize--;
                maxHeapify(input,0);


                
            }

            for (int m = 0; m < input.Length; m++)
            {
                Console.Write(" " + input[m].id);
            }
            Console.WriteLine("");
            Console.WriteLine("comparison: "+ comparison);
            Console.WriteLine("exchanges: " + exch);

        }

        //function to exchange two elements
        private void exchange(Employee[] arr, int x, int y)
        {
            Employee temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
            exch++;
        }

    }
}