using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_TP_Final.Models;
using Xamarin_TP_Final.ViewModels;
using Xamarin_TP_Final.Views;

namespace Xamarin_TP_Final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        LivroViewModel vmLivro;

        public MainPage()
        {
            vmLivro = new LivroViewModel();
            BindingContext = vmLivro;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vmLivro = new LivroViewModel();
            BindingContext = vmLivro;
            base.OnAppearing();
        }

        private void handleNew(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NovoLivro());
        }

        private void handleAutor(object sender, EventArgs args)
        {
            DisplayAlert("Autor", "João Pedro Tanaca Ramos", "OK");
        }

        private async void OnLivroTapped(
            object sender,
            ItemTappedEventArgs args
        )
        {
            var selecionado = args.Item as Livro;
            string action =
                await DisplayActionSheet(selecionado.Nome,
                "Cancelar",
                "Deletar",
                "Editar",
                "Detalhes");
            switch (action)
            {
                case "Deletar":
                    vmLivro.DeletarLivro (selecionado);
                    await Navigation.PushAsync(new MainPage());
                    break;
                case "Editar":
                    await Navigation.PushAsync(new NovoLivro(selecionado));
                    break;
                case "Detalhes":
                    await DisplayAlert(selecionado.Nome,
                    "Autor: " +
                    selecionado.Autor +
                    "\nEmail: " +
                    selecionado.Email +
                    "\nISBN: " +
                    selecionado.Isbn,
                    "OK");
                    break;
            }
        }

        private async void handleCoord(object sender, EventArgs e)
        {
            try
            {
                var localizacao = await Geolocation.GetLastKnownLocationAsync();
                if (localizacao != null)
                {
                    await DisplayAlert("Localização",
                    "Latitude: " +
                    localizacao.Latitude.ToString() +
                    "\nLongitude: " +
                    localizacao.Longitude.ToString(),
                    "OK");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Erro ", fnsEx.Message, "Ok");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Erro: ", pEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro : ", ex.Message, "Ok");
            }
        }
    }
}
