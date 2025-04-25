using System;
using System.Collections.Generic;
using System.Linq;
using static Develop;

public class Develop
{
    public class Developer
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }

        public Developer(string fullName, int id, string department)
        {
            FullName = fullName;
            Id = id;
            Department = department;
        }

        public override string ToString()
        {
            return $"{FullName}, {Id}, {Department}"; 
        }
    }

}