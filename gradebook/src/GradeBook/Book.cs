using System;
using System.Collections.Generic;


namespace GradeBook{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public abstract class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

    }

    public class InMemoryBook : Book
    {
        List <double> grades;
        //This is long hand property
        // public string Name{
        //     get; 
        //     set;
        // }
      
        const string category = "test"; 
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade){
            if (grade >= 0.0 && grade <= 100.0){
                grades.Add(grade);    
                if (GradeAdded != null){
                    GradeAdded(this, new EventArgs());// Gets Called Here
                }
            }
            else{
                throw new ArgumentException($"Invalids {nameof(grade)}");
            }   
        }
        public event GradeAddedDelegate GradeAdded; // This is just a fieldin this class

        public double GetHighestGrade (){
            double highestGrade = double.MinValue; 

            foreach(var grade in grades){
                highestGrade = Math.Max(grade, highestGrade); 
            }

            return highestGrade;
        }

        public double GetAverageGrade(){
            double sum = 0.0;

            foreach(double grade in grades){

                sum += grade; 

            }

            return sum/grades.Count; 
        }

        public double GetLowestGrade(){
            double lowestGrade = double.MaxValue; 

            foreach(var grade in grades){
                lowestGrade = Math.Min(grade, lowestGrade); 
            }

            return lowestGrade;
        }

        public void ShowStats(){

            var results = GetStatistics();

            Console.WriteLine($"Average: {results.Average}"); 
            Console.WriteLine($"Highest: {results.high}");
            Console.WriteLine($"Lowest: {results.low}");
            Console.WriteLine($"Average: {results.letter}");

        }

        public Statistics GetStatistics(){

            Statistics results = new Statistics();

            results.Average = GetAverageGrade();
            results.high = GetHighestGrade();
            results.low = GetLowestGrade();
            results.letter = AddLetterGrade(results.Average); 

            return results; 

        }

        public char AddLetterGrade(double numberGrade){
            char letter; 
        switch (numberGrade){
            case var d when d >= 90.0:
                letter = 'A';
                break;
            case var d when d >= 80.0:
                letter = 'B';
                break;
            case var d when d >= 70.0:
                letter = 'C';
                break;
            case var d when d >= 60.0:
                letter = 'D';
                break;
            default:
                letter = 'F';
                break;
        }

        return letter;
        }
    
    }

}