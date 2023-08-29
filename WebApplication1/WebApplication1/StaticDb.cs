using System.Reflection;
using WebApplication1.Models;

namespace WebApplication1
{
    public class StaticDb
    {
        public static List<Book> ListBooks = new List<Book>
        {
            new Book()
            {
                Author = "Sebastijan Ficek",
                Title = "Pacientot"
            },
            new Book()
            {
                Author = "Lusinda Rajli",
                Title = "Sedumte sestri"
            },
            new Book()
            {
                Author = "Dzon Shorz",
                Title = "Pod Mermerno nebo"
            },
            new Book()
            {
                Author = "Kolin Huver",
                Title = "Ova zavrshuva so nas"
            },
            new Book()
            {
                Author = "Dona Kroz",
                Title = "Papata Jovana"
            }
        };
    }
}
