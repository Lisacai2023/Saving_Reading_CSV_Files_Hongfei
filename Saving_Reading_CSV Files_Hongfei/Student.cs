using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Reading_CSV_Files_Hongfei
{
    internal class Student
    {
        string _firstName;
        string _lastName;
        int _grade;

        public Student()
        {

        }

        public Student(string firstName, string lastName, int grade)
        {
            FirstName=firstName;
            LastName=lastName;
            Grade=grade;
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Grade { get => _grade; set => _grade=value; }

        public override string ToString()
        {
            return $" First Name :{_firstName} \n" +
                $" Last Name : {_lastName} \n" + 
                $" Grade : {_grade}\n";
        }
    }
}
