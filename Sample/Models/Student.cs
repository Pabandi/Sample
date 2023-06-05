using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Fammily  { get; set; }       
        
        public string   PhonNumber { get; set; }

        public int Age { get; set; }    


        public Student() { }

        public Student(int id, string name, string fammily, string phonNumber, int age)
        {
            Id = id;
            Name = name;
            Fammily = fammily;
            PhonNumber = phonNumber;
            Age = age;
        }   
    }
}