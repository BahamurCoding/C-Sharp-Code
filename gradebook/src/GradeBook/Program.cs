using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args) //this is a method main
        {   
            //HelloWorld(args); //Module 1
            //AverageList(); //Module 2


    

            var book = new Book("Science Class");
            book.GradeAdded += OnGradeAdded; 
    
            AddValuesByUser(book);
            Console.WriteLine($"For the book names {book.Name}"); 
            book.ShowStats();

            
        }

    static void AverageList(){
            //List<double> grades = new List<double>(); //Explicit
            var grades = new List<double>(){12.7, 10.3, 6.11, 4.1}; //Impicit
            grades.Add(56.1);
            var result = 0.0; 
            //For each number in the array numbers. add this to results.
            foreach (double number in grades)
            {
                result += number;
            }
            Console.WriteLine($"Average Grade is: {result/grades.Count:N3}");
    }

        static void HelloWorld(string[] args){
            int size = args.Length;
            string varName;
            string stringInterpolationExample;
            if (size > 0) {
                //sting[] args. We have a string array 
                varName = "Hello " + args[0];
                //Add a '$' at the front. You don't have to use the + to concat
                // You just need to do {value} to show the value. 
                stringInterpolationExample = $"Hello My name is {args[0]!}";
            }
            else{
                stringInterpolationExample = "Hello No Name";
            }
            Console.WriteLine(stringInterpolationExample);
        }
    
    static void  AddValuesByUser(Book book){
        Console.WriteLine("Please type in a value then press eneter."); 
        var input = Console.ReadLine(); 
        
        while (input != "q"){
            
            if (input == "q"){
                break; 
            }
            try{
                var grade = double.Parse(input);
                book.AddGrade(grade);
            }
            catch(ArgumentException ex){
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex){
                Console.WriteLine(ex.Message); 
            }
            finally{
                Console.WriteLine("**"); 
            }
            Console.WriteLine("Your values was entered. Please enter another one or enter q to quit");
            input = Console.ReadLine();    
        };

    }

    static void OnGradeAdded(object sender, EventArgs e){

            Console.WriteLine("A Grade Was Added");

        }

    }
}
