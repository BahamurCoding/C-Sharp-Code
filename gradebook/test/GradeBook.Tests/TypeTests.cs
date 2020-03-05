using System;
using Xunit;


namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);//Delegate
    public class TypeTests
    {
        int count = 0; 
        [Fact]

        public void WriteLogDelegateCanPointToMethod()
        {

            WriteLogDelegate log = ReturnMessage; 

            //log = new WriteLogDelegate(ReturnMessage); long form
            log += IncramentCount; 

            var result = log("Hello");

            Console.WriteLine(result);
            Assert.Equal(2, count); 

        }

        string ReturnMessage(string message)
        {
            count++;    
            return message; 

        }

        string IncramentCount(string message)
        {
            count++;    
            return "message"; 

        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {

            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //act\
            
            //assert
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {

            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            //act\
            
            //assert
            Assert.Same(book1, book2);// Point To the same Reference
            Assert.True(Object.ReferenceEquals(book1,book2));
        }

        [Fact]
        public void Test69()
        {

            // Arrange
            var book1 = GetBook("Book 1");
            SetName(book1,"New Name");
            //act\
            
            //assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void PassByValue()
        {

            // Arrange
            var book = GetBook("Book 1");
            GetBookSetName(book,"New Name");
            //act\
            
            //assert
            Assert.Equal("Book 1", book.Name);
        }


        [Fact]
        public void PassByRef()
        {

            // Arrange
            var book = GetBook("Book 1");
            GetSetNameByRef( ref book,"New Name");
            //act\
            
            //assert
            Assert.Equal("New Name", book.Name);
        }

        [Fact]
        public void XPassByValue(){
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }


        [Fact]
        public void XPassByRef(){
            var x = GetInt();
            XSetIntRef(ref x);

            Assert.Equal(42, x);
        }


        [Fact]
        public void StringsBehaveLikeValueTypes(){

            string name = "Pedro";
            var upper = MakeUppercase(name);

            Assert.Equal("PEDRO", upper);

        }


        private string MakeUppercase(string param){

            param = param.ToUpper(); 
            return param; 
        }



        void XSetIntRef(ref int x){
            x = 42; 
        }
        void SetInt(int x){
            x = 42;
        }
        int GetInt(){
            return 3; 
        }

        void GetSetNameByRef(ref InMemoryBook book, String name){

        book = new InMemoryBook(name);            

        }

        void GetBookSetName(InMemoryBook book, String name){

            book = new InMemoryBook(name);

        }
        void SetName(InMemoryBook book, String name){

            book.Name = name; 

        }

        InMemoryBook GetBook(String name){

            return new InMemoryBook(name);

        }
    }
}
