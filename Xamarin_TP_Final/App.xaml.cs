using Xamarin.Forms;
using Xamarin_TP_Final.Models;

namespace Xamarin_TP_Final
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        static Livro livroModel;

        public static Livro LivroModel
        {
            get
            {
                if (livroModel == null)
                {
                    livroModel = new Livro();
                }
                return livroModel;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
