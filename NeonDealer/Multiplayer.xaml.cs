using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace NeonDealer
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Multiplayer : Page
    {
        private ObservableCollection<Multiplayer> Map = new ObservableCollection<Multiplayer>();
        public Multiplayer()
        {
            this.InitializeComponent();
            Map2.IsEnabled = false;
            Map2.Visibility = Visibility.Collapsed;
        }
        private void Multiplayer_Return(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayMenu));
        }

        private void Mode(object sender, RoutedEventArgs e)
        {
            if ((string)modebutton.Content == "Carrera")
                modebutton.Content = "Duelo por equipos";
            else
                modebutton.Content = "Carrera";
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Gameplay));
        }
        private void ClickMap1(object sender, RoutedEventArgs e)
        {
            if (Map2.IsEnabled == false)
            {
                Map2.IsEnabled = true;
                Map2.Visibility = Visibility.Visible;
                Map1.IsEnabled = false;
                Map1.Visibility = Visibility.Collapsed;
            }
            else
            {
                Map1.IsEnabled = true;
                Map1.Visibility = Visibility.Visible;
                Map2.IsEnabled = false;
                Map2.Visibility = Visibility.Collapsed;
            }
        }
    }
}
