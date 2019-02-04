using System;
using System.IO;

namespace merge_sort
{
    class MainClass
    {
        int comparisons = 0;
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


                    Console.WriteLine("***MERGE SORT***");
                    for (int m = 0; m < dataEmployee.Length; m++)
                    {
                        Console.Write(" " + dataEmployee[m].id);
                    }
                    Console.WriteLine("");


                    MainClass aa = new MainClass();
                    //aa.mergeSort(dataEmployee, 0, dataEmployee.Length-1);
                    aa.MergeSort(dataEmployee, 0 , dataEmployee.Length-1);

                    //for (int m = 0; m < dataEmployee.Length; m++)
                    //{
                    //    Console.Write(" " + dataEmployee[m].id);
                    //}
                    Console.WriteLine("comparisons: " + aa.comparisons);




                    StreamWriter sw = new StreamWriter("AFTER_ANSWER_MERGE_SORT.txt");
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
        //int comparisons = 0;

        private void Merge(Employee[] input, int left, int middle, int right)
        {
            Employee[] leftArray = new Employee[middle - left + 1];
            Employee[] rightArray = new Employee[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            //int comparisons = 0;
            for (int k = left; k < right + 1; k++)
            {
                comparisons++;
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i].id <= rightArray[j].id )
                {
                    //comparisons++;
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
            for (int m = 0; m < input.Length; m++)
            {
                Console.Write(" " + input[m].id);
            }
            Console.WriteLine("");
            //Console.WriteLine(" comparison: " + comparisons);
        }

        private void MergeSort(Employee[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }

        //public void merge(Employee[] arr, int left, int middle, int right)
        //{

        //    int n1 = middle - left + 1;
        //    int n2 = right - middle;

        //    Employee[] leftArray = new Employee[n1+1];
        //    Employee[] rightArray = new Employee[n2 + 1];

        //    //leftArray[0] = new Employee("Wurb Wifikyzo|4|59|Custodian|1987");
        //    //rightArray[0] = new Employee("Wurb Wifikyzo|4|59|Custodian|1987");

        //    Array.Copy(arr, left, leftArray, 0, middle - left + 1);
        //    Array.Copy(arr, middle + 1, rightArray, 0, right - middle);


        //    int i = 0;
        //    int j = 0;
        //    for (int k = left; k < right + 1; k++)
        //    {
        //        if (i == leftArray.Length)
        //        {
        //            arr[k] = rightArray[j];
        //            j++;
        //        }
        //        else if (j == rightArray.Length)
        //        {
        //            arr[k] = leftArray[i];
        //            i++;
        //        }
        //        else if (leftArray[i].id <= rightArray[j].id )
        //        {
        //            arr[k] = leftArray[i];
        //            i++;
        //        }
        //        else
        //        {
        //            arr[k] = rightArray[j];
        //            j++;
        //        }
        //    }


        //    //for (int i = 1; i < n1; i++)
        //    //{

        //    //    leftArray[i] = arr[left+i-1];

        //    //}
        //    //for (int j = 1 ; j < n2; j++ )
        //    //{

        //    //    rightArray[j] = arr[middle+j];

        //    //}

        //    ////infinite symbol
        //    ////left[n1 + 1] = int.MaxValue;
        //    ////right[n2 + 1] = int.MaxValue;

        //    //int q = 1;
        //    //int w = 1;

        //    //for (int k = left ; k < right; k++ )
        //    //{

        //    //    if (leftArray[q].id <= rightArray[w].id)
        //    //    {

        //    //        arr[k]= leftArray[q];
        //    //        q = q + 1;

        //    //    }else if (arr[k].id == rightArray[w].id)
        //    //    {

        //    //        w = w + 1;

        //    //    }

        //    //}



        //}

        //public void mergeSort(Employee[] arr, int left, int right)
        //{

        //    if (left < right)
        //    {

        //        int middle = (left+right) / 2;
        //        mergeSort(arr, left, middle);
        //        mergeSort(arr, middle+1,right);

        //        merge(arr, left, middle, right);

        //    }

        //}


    }
}