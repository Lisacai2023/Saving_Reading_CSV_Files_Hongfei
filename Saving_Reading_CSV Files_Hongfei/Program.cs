using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace Saving_Reading_CSV_Files_Hongfei
{

    //Saving_Reading_CSV_Files
    //Hongfei
    //Week8_03/08/2024
    internal class Program
    {
        static string folderPath = @"..\..\..\CSVFiles\";
        static string fileName = @"StudentExamlpleCSVHelper.csv";

        static void Main(string[] args)
        {

            //CSVHelper();

            //ReadingFromCSV();

            List<Student> students = new List<Student>();
            {
                new Student()
                {
                    FirstName = "Erica",
                    LastName = "Lee",
                    Grade = 90

                };
            };

            //using File.Open
            //using writer
            //using csv Write 

            string fullPath = folderPath + fileName;

            using (var stream = File.Open(fullPath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(students);
                        writer.Flush();
                    }
                }
            }


        }//main 


        public static void CSVHelper()
        {

            //How to work with an external package

            List<Student> students = new List<Student>();

            string fullPath = folderPath + fileName;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                //CultureInfo.InvariantCulture
                using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    students = csv.GetRecords<Student>().ToList();

                }
            }

            foreach (Student item in students)
            {
                Console.WriteLine(item.ToString());
            }
        }

        //-------------------------------------------------------------------------------------

        //Read from CSV file without using csv helper
        public static void ReadingFromCSV()
        {
            string folderPath = @"..\..\..\CSVFiles\";
            string fullPath = folderPath + "StudentExamlple.csv";

            //File Exists() returns a bool
            if (File.Exists(fullPath))
            {
                string[] lines = File.ReadAllLines(fullPath);
                List<Student> students = new List<Student>();

                foreach (string item in lines)
                {
                    string[] studentFields = item.Split(",", StringSplitOptions.TrimEntries);
                    string firstName = studentFields[0];
                    string lastName = studentFields[1];
                    int grade = int.Parse(studentFields[2]);

                    students.Add(new Student(firstName, lastName, grade));

                }

                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }


            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            //string[] stringsFromCSV = new string[]
            //{
            //    $"Tian, Zhang, {85}",
            //    $"Joy, Wang, {95}",
            //    $"Sam, Lee, {90}",
            //    $"Jane, Zhang, {85}"
            //};


        }

        

        public static void SavingToCSV()
        {
            string folderPath = @"..\..\..\CSVFiles\";

            string[] csvString = new string[]
{
                $"Tian, Zhang, {85}",
                $"Joy, Wang, {95}",
                $"Sam, Lee, {90}"
};

            //Put CSV file into CSV folder
            //C:\Users\Andre\OneDrive\Desktop\CHF\RTC\2024winter\CSI224\
            //week9\Saving_Reading_CSV Files_Hongfei\Saving_Reading_CSV Files_Hongfei\CSVFiles\StudentExamlple.csv


            using (StreamWriter sw = new StreamWriter(folderPath+"StudentExamlple.csv", false))
            {
                foreach (string item in csvString)
                {
                    sw.WriteLine(item);
                }
            }

        }

        public static void CSVExample()
        {
            //    new Student("Tian", "Zhang", 85), 
            //    new Student("Joy", "Wang", 95),
            //    new Student("Sam", "Lee", 90)
            string[] csvString = new string[]
            {
                $"Tian, Zhang, {85}",
                $"Joy, Wang, {95}",
                $"Sam, Lee, {90}"
            };

            List<Student> students = new List<Student>();

            foreach (string csv in csvString)
            {
                string[] splitString = csv.Split(",", StringSplitOptions.TrimEntries);
                string firstName = splitString[0];
                string lastName = splitString[1];
                string grade = splitString[2];

                Student newStudent = new Student(firstName, lastName, int.Parse(grade));
                students.Add(newStudent);
            }

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

        }



    }//class




}//namespace
