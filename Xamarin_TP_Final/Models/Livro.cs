using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using Xamarin_TP_Final.Data;

namespace Xamarin_TP_Final.Models
{
    public class Livro
    {
        private SQLiteConnection database;

        public Livro()
        {
            database = DependencyService.Get<ISQLite>().GetConexao();
            database.CreateTable<Livro>();
        }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Email { get; set; }

        [PrimaryKey]
        public int Isbn { get; set; }

        static object locker = new object();

        public int SalvarLivro(Livro livro)
        {
            lock (locker)
            {
                if (GetLivro(livro.Isbn) != null)
                {
                    return database.Update(livro);
                }
                return database.Insert(livro);
            }
        }

        public IEnumerable<Livro> GetLivros()
        {
            lock (locker)
            {
                return (from c in database.Table<Livro>() select c).ToList();
            }
        }

        public Livro GetLivro(int Isbn)
        {
            lock (locker)
            {
                return database
                    .Table<Livro>()
                    .Where(c => c.Isbn == Isbn)
                    .FirstOrDefault();
            }
        }

        public int RemoverLivro(int Isbn)
        {
            lock (locker)
            {
                return database.Delete<Livro>(Isbn);
            }
        }
    }
}
