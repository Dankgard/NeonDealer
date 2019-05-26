using System;
using System.Collections.Generic;
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
    public sealed partial class Gameplay : Page
    {
        public Gameplay()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

            Deactivate();
            Mapa.Visibility = Visibility.Collapsed;
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            switch (args.VirtualKey)
            {
                case VirtualKey.GamepadMenu:
                    if (Panel.Visibility == Visibility.Collapsed)
                        Activate();
                    else
                        Deactivate();
                    break;

                case VirtualKey.GamepadView:
                    ShowMap();
                    break;
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {   
             if (e.VirtualKey == Windows.System.VirtualKey.Escape)
             {
                Activate();               
            }
        }

        private void ClickPause(object sender, RoutedEventArgs e)
        {
            Activate();
        }

        private void ClickRestart(object sender, RoutedEventArgs e)
        {
            Deactivate();
        }
        void Deactivate()
        {
            Panel.Visibility = Visibility.Collapsed;
            Restart.IsEnabled = false;
            Restart.Visibility = Visibility.Collapsed;
            Options.IsEnabled = false;
            Options.Visibility = Visibility.Collapsed;
            Exit.IsEnabled = false;
            Exit.Visibility = Visibility.Collapsed;
        }
        void Activate()
        {
            Panel.Visibility = Visibility.Visible;
            Restart.IsEnabled = true;
            Restart.Visibility = Visibility.Visible;
            Options.IsEnabled = true;
            Options.Visibility = Visibility.Visible;
            Exit.IsEnabled = true;
            Exit.Visibility = Visibility.Visible;
        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ClickOptions(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(OptionsGame));
        }

        private void ClickMap(object sender, RoutedEventArgs e)
        {
            ShowMap();
        }
        private void ClickVictory(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(Podium));
        }

        private void ShowMap()
        {
            if (Mapa.Visibility == Visibility.Collapsed)
                Mapa.Visibility = Visibility.Visible;
            else
                Mapa.Visibility = Visibility.Collapsed;
        }
    }
}
