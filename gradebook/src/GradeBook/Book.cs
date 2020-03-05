using System;
using System.Collections.Generic;
using System.IO;


namespace GradeBook{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade (double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded; 

        void ShowStats();
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        public abstract void ShowStats();
    }



    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            var filePath = $"{Name}.txt";
            using( var sw = File.AppendText(filePath)){

                sw.WriteLine(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }

            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            string[] text = File.ReadAllLines($"{Name}.txt");
            

            foreach(string line in text){
                result.Add(double.Parse(line));
            }

            return result;
            
        }

         public override void ShowStats(){

            var results = GetStatistics();

            Console.WriteLine($"Average: {results.Average}"); 
            Console.WriteLine($"Highest: {results.high}");
            Console.WriteLine($"Lowest: {results.low}");
            Console.WriteLine($"Average: {results.letter}");

        }
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
                throw new ArgumentException($"IIInvalids {nameof(grade)}");
            }   
        }
        public override event GradeAddedDelegate GradeAdded; // This is just a fieldin this class

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

        public override void ShowStats(){

            var results = GetStatistics();

            Console.WriteLine($"Average: {results.Average}"); 
            Console.WriteLine($"Highest: {results.high}");
            Console.WriteLine($"Lowest: {results.low}");
            Console.WriteLine($"Average: {results.letter}");

        }

        public override Statistics GetStatistics(){

            Statistics results = new Statistics();
            
            for(var index = 0; index < grades.Count; index++){
                results.Add(grades[index]);
            }

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