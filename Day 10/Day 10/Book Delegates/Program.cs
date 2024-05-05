using System.Net;
using System.Net.Http.Headers;

namespace Book_Delegates
{
    public delegate string UserDefined(Book B);

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public Book(string _ISBN, string _Title,
        string[] _Authors, DateTime _PublicationDate,
        decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }
        public override string ToString()
        {
            string txt = $"BOOK:\nISBN: {ISBN}\t Title: {Title}\t Publication Date: {PublicationDate}\t Price: {Price} \tAuthors:";
            foreach(string s in Authors) 
                txt += s+"," ;
            return txt ;

        }
    }
    
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string GetAuthors(Book B)
        {
            string txt = "";
            foreach(string c in B.Authors) 
                txt += c+"," ;
            return txt ;
        }
        public static string GetPrice(Book B)
        {
            return B.Price.ToString();
        }
    }
    
    public class LibraryEngine
    {
        //public static void ProcessBooks(List<Book> bList
        //,UserDefined fPtr)
        //{
        //    foreach (Book B in bList)
        //    {
        //        Console.WriteLine(fPtr(B));
        //    }
        //}
        public static void ProcessBooks(List<Book> bList
        , Func<Book,string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] authors1= { "mohamed", "ahmed" };
            string[] authors2= { "mohsen", "ali" };
            string[] authors3= { "lol", "mody" };

            Book B1 = new Book("M10","The Lol", authors1,DateTime.Now.AddYears(-10),400);
            Book B2 = new Book("M10","The Haha", authors2,DateTime.Now.AddYears(-11),500);
            Book B3 = new Book("M10","The Beauty", authors3,DateTime.Now.AddYears(-12),600);

            List<Book> B = new List<Book>() { B1,B2,B3};

            //----- User Defined Delegate ------//
            //UserDefined fPtr = new UserDefined(BookFunctions.GetTitle);
            //LibraryEngine.ProcessBooks(B, fPtr);

            //fPtr += BookFunctions.GetAuthors;
            //LibraryEngine.ProcessBooks(B, fPtr);

            //fPtr += BookFunctions.GetPrice;
            //LibraryEngine.ProcessBooks(B, fPtr);

            //----- Bulit-in Delegate ------//
            //Func<Book, string> fPtr = new Func<Book, string>(BookFunctions.GetTitle);
            //LibraryEngine.ProcessBooks(B, fPtr);

            //fPtr += BookFunctions.GetAuthors;
            //LibraryEngine.ProcessBooks(B, fPtr);

            //fPtr += BookFunctions.GetPrice;
            //LibraryEngine.ProcessBooks(B, fPtr);


            //----- Anonymous Method Delegate ------//
            //Func<Book, string> ftpr = delegate (Book b)
            //{
            //    return b.ToString();
            //};
            //LibraryEngine.ProcessBooks(B,ftpr);

            //Func<Book, string> ftpr2 = delegate (Book b)
            //{
            //    return b.ISBN;
            //};
            //Console.WriteLine(ftpr(B1));



            //----- Lunda Expression ------//
            //Func<Book,string> ftpr = (Book B) => B.ToString();
            //Console.WriteLine(ftpr(B1));


        }
    }
}
