using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook

    {
        public RankedGradeBook(string name, bool IsWeighted) : base(name, IsWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) 
            { 
                Console.WriteLine("Ranked grading requires at least 5 studnets.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) 
            {
                Console.WriteLine("Ranked grading requires at least 5 studnets.");
                return;
            }
            base .CalculateStudentStatistics(name);

        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 studnets.");
            }
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.ConvertAll(s => s.AverageGrade);
            grades.Sort();  
            grades.Reverse();
            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[threshold * 2 - 1] <= averageGrade)
                return 'B';
            else if (grades[threshold * 3 - 1] <= averageGrade)
                return 'C';
            else if (grades[threshold * 4 - 1] <= averageGrade)
                return 'D';
            return 'F';

             
        }
    }
}
