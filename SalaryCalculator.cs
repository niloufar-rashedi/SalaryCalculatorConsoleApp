using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator
{
    public class SalaryCalculator
    {
        //Defining wage and employee information based on assignment instruction
        public const long Employees = 20;
        public const int HourlyWage = 100;
        public const int MonthlySalary = 2000; //Monthly loan increases by 5% every 5 months
        private static string[] employeeNames = new string[20];
        private static int[] hours = new int[20];
        private static int[] months = new int[20];

        //Number of months that an employee has worked is this company is unique for each employee
        Random rn = new Random();

        public void Run()
        {
            ShowAllEmployeeInformation();
        }

        private decimal CalculateSalaryForEachEmployee( int empID)
        {
            int h = hours[empID];
            int t = months[empID];
            double salary = 0;
            //Defining the condition for base salary of a full time employee
            if(h == 169)
                {
                    salary = MonthlySalary;
                }
            if (salary > 3 * MonthlySalary)
                {           
                     return 3 * MonthlySalary;
                }

            //Defining the condition for base salary of an employee-per-hour
            else
                {
                    salary = h * HourlyWage;
                    salary = (int)(salary * Math.Pow(1.05, t / 5)); 
                }
            return (decimal)salary;
        }
        private decimal CalculateTotalSalary()
        {
            decimal sum = 0;
            for (int i = 0; i < Employees; i++)
            {
                sum += CalculateSalaryForEachEmployee(i);
            }
            return sum;
        }
        private static void ShowAllEmployeeInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Namn\t\tTimmarPerMånad\t\tMånadslön");
            for (int i = 0; i < Employees; i++)
            {
                sb.Append($"{employeeNames} \t {months[i]} \t {hours[i]}" +
                    CalculateSalaryForEachEmployee(i));
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine($"Total summa av lönerna för den månaden: {DateTime.Now.Month} " , CalculateTotalSalary());
        }

    }
}
