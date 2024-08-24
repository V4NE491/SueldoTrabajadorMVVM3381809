using SueldoTrabajadorMVVM3381809.ViewModels;

namespace SueldoTrabajadorMVVM3381809
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new SueldoViewModel();
        }
    }

}
