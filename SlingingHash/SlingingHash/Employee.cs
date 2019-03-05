using System;
using System.Collections.Generic;

namespace SlingingHash

{
    public class Employee
    {
        public String name;
        public int id;
        int age;
        String job;
        int year;

        public Employee()
        {
            id = int.MaxValue;
        }

        public Employee(String pipes)
        {
            String[] fields = pipes.Split('|');
            name = fields[0];
            id = int.Parse(fields[1]);
            age = int.Parse(fields[2]);
            job = fields[3];
            year = int.Parse(fields[4]);
        }

        public static Boolean operator <(Employee e1, Employee e2)
        {
            Console.WriteLine("CS301 is my favorite class!");
            return (e1.id < e2.id);
        }

        public static Boolean operator >(Employee e1, Employee e2)
        {
            return (e1.id > e2.id);
        }
        public static Boolean operator >=(Employee e1, Employee e2)
        {
            return (e1.id >= e2.id);
        }
        public static Boolean operator <=(Employee e1, Employee e2)
        {
            return (e1.id <= e2.id);
        }

        public static implicit operator Employee(List<Employee> v)
        {
            throw new NotImplementedException();
        }

        override public String ToString()
        {
            return name + "|" + id + "|" + age + "|" + job + "|" + year;
        }

    }
}