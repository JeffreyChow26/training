using System;
using System.Collections.Generic;

namespace Training.Day4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DoB { get; set; }
        public StudentGuardian Guardian { get; set; }
        public List<SubjectResult> Results { get; set; }
    }
}
