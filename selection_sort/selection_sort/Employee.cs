using System;
namespace selection_sort
{
    public class Employee
    {
        public string name, age, job, year;
        public int id;
        //int age;
        //string job;
        //int year;


        /*
         * create a constructor that separate informations of one line and assign it the our fields           
         */
        public Employee(string data)
        {
            string[] allIformation = data.Split('|');
            name = allIformation[0];
            id = int.Parse(allIformation[1]);
            age = allIformation[2];
            job = allIformation[3];
            year = allIformation[4];

        }

        //the format method create and display the content in a "pretty" format
        //public void format()
        //{
        //    Console.WriteLine("Name:\t\t" + name);
        //    Console.WriteLine("ID:\t\t" + id);
        //    Console.WriteLine("Age:\t\t" + age);
        //    Console.WriteLine("Job:\t\t" + job);
        //    Console.WriteLine("Year:\t\t" + year);
        //    Console.WriteLine("-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-");
        //}

        public override string ToString()
        {

            return id + " " + name + " " + age + " " + job + " " + year;
        }

        public static implicit operator Employee(int v)
        {
            throw new NotImplementedException();
        }
    }
}
