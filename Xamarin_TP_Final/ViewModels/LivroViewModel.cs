using System.Collections.Generic;
using System.Linq;
using Xamarin_TP_Final.Models;

namespace Xamarin_TP_Final.ViewModels
{
    public class LivroViewModel
    {
        public LivroViewModel()
        {
        }

        #region Propriedades
        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Email { get; set; }

        public int Isbn { get; set; }

        public List<Livro> Livros
        {
            get
            {
                return App.LivroModel.GetLivros().ToList();
            }
        }

        public void DeletarLivro(Livro livro)
        {
            App.LivroModel.RemoverLivro(livro.Isbn);
        }
        #endregion
    }
}
