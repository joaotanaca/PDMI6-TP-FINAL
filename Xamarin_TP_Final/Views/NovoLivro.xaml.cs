using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_TP_Final.Models;

namespace Xamarin_TP_Final.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoLivro : ContentPage
    {
        public NovoLivro()
        {
            InitializeComponent();
        }

        public NovoLivro(Livro livro)
        {
            InitializeComponent();
            txtNome.Text = livro.Nome;
            txtAutor.Text = livro.Autor;
            txtEmail.Text = livro.Email;
            txtIsbn.Text = livro.Isbn.ToString();
        }

        public void OnSalvar(object sender, EventArgs args)
        {
            Livro livro =
                new Livro()
                {
                    Nome = txtNome.Text,
                    Autor = txtAutor.Text,
                    Email = txtEmail.Text,
                    Isbn = int.Parse(txtIsbn.Text)
                };

            App.LivroModel.SalvarLivro (livro);
            Limpar();
            Navigation.PopAsync();
        }

        public void OnCancelar(object sender, EventArgs args)
        {
            Limpar();
            Navigation.PopAsync();
        }

        private void Limpar()
        {
            txtNome.Text =
                txtAutor.Text = txtEmail.Text = txtIsbn.Text = string.Empty;
        }
    }
}
