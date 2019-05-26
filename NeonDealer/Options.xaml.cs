using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
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
    public sealed partial class Options : Page
    {
        private ObservableCollection<Option> video = new ObservableCollection<Option>();
        private ObservableCollection<Option> audio = new ObservableCollection<Option>();
        private ObservableCollection<Option> controls = new ObservableCollection<Option>();

        public Options()
        {
            this.InitializeComponent();
            video.Add(new Option("Calidad de texturas"));
            video.Add(new Option("Calidad de sombras"));
            video.Add(new Option("Modo daltónico"));
            video.Add(new Option("Sincronización vertical"));
            video.Add(new Option("Activar FXAA"));
            audio.Add(new Option("Activar subtítulos"));
            audio.Add(new Option("Silenciar"));
            audio.Add(new Option("Volumen general"));
            audio.Add(new Option("Volumen de SFX"));
            audio.Add(new Option("Volumen de música"));
            audio.Add(new Option("Volumen de voces"));
            controls.Add(new Option("Mostrar controles"));
            controls.Add(new Option("Invertir eje vertical"));
            controls.Add(new Option("Sensibilidad eje X"));
            controls.Add(new Option("Sensibilidad eje Y"));
            AudioList.IsEnabled = false;
            AudioList.Visibility = Visibility.Collapsed;
            VideoList.IsEnabled = false;
            VideoList.Visibility = Visibility.Collapsed;
            ControlsList.IsEnabled = false;
            ControlsList.Visibility = Visibility.Collapsed;
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            switch (args.VirtualKey)
            {          
                case VirtualKey.GamepadB:
                    Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
                    this.Frame.Navigate(typeof(MainPage));
                    break;
            }
        }

        private void Options_Return(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AudioOptions(object sender, RoutedEventArgs e)
        {
            AudioList.IsEnabled = true;
            AudioList.Visibility = Visibility.Visible;
            VideoList.IsEnabled = false;
            VideoList.Visibility = Visibility.Collapsed;
            ControlsList.IsEnabled = false;
            ControlsList.Visibility = Visibility.Collapsed;
        }

        private void VideoOptions(object sender, RoutedEventArgs e)
        {
            AudioList.IsEnabled = false;
            AudioList.Visibility = Visibility.Collapsed;
            VideoList.IsEnabled = true;
            VideoList.Visibility = Visibility.Visible;
            ControlsList.IsEnabled = false;
            ControlsList.Visibility = Visibility.Collapsed;
        }

        private void ControlOptions(object sender, RoutedEventArgs e)
        {
            AudioList.IsEnabled = false;
            AudioList.Visibility = Visibility.Collapsed;
            VideoList.IsEnabled = false;
            VideoList.Visibility = Visibility.Collapsed;
            ControlsList.IsEnabled = true;
            ControlsList.Visibility = Visibility.Visible;
        }
    }
}
