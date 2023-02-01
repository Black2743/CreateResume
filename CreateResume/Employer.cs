﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateResume
{
    internal class Employee
    {
        public String Name { get; }  
        public String Surname { get; }  
        private String Patronymic;  //отчество
        public DateTime Age { get; }
        public Employee(string name, string surname, string patronymic, DateTime age)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Age = age;
        }
    
        public Employee(String[] strings)
        {
            Name= strings[0];
            Surname= strings[1];
            Patronymic= strings[2];
        }
        public int CalcuteAge() 
        {
            
            var now = DateTime.Today;
            return now.Year - Age.Year - 1 +
                ((now.Month > Age.Month || now.Month == Age.Month && now.Day >= Age.Day) ? 1 : 0);

        }
    }
}
