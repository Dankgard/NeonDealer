using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace NeonDealer
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool spain = true;

        public MainPage()
        {
            this.InitializeComponent();
            Idiom2.IsEnabled = false;
            Idiom2.Visibility = Visibility.Collapsed;
        }

        private void Idiom_Click(object sender, RoutedEventArgs e)
        {
            if (spain)
            {
                Idiom2.IsEnabled = true;
                Idiom2.Visibility = Visibility.Visible;
                Idiom.IsEnabled = false;
                Idiom.Visibility = Visibility.Collapsed;
                spain = false;
            }
            else
            {
                Idiom.IsEnabled = true;
                Idiom.Visibility = Visibility.Visible;
                Idiom2.IsEnabled = false;
                Idiom2.Visibility = Visibility.Collapsed;
                spain = true;
            }
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayMenu));
        }
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Options));
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Edit));
        }
    }
}
