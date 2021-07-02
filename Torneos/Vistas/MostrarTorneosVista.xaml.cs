using Torneos.VistaModelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Torneos.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarTorneosVista : ContentPage
    {
        public MostrarTorneosVista()
        {
            InitializeComponent();
            BindingContext = new MostrarTorneosVistaModelo();
        }
    }
}