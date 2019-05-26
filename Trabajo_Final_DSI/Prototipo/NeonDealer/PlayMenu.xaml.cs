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
    public sealed partial class PlayMenu : Page
    {
        public PlayMenu()
        {
            this.InitializeComponent();
            Yes.IsEnabled = false;
            Yes.Visibility = Visibility.Collapsed;
            No.IsEnabled = false;
            No.Visibility = Visibility.Collapsed;
            Panel.Visibility = Visibility.Collapsed;
        

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

    private void Play_Return(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(MainPage));
        }
        private void ClickMultiplayer(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(Multiplayer));
        }
        private void ClickGameplay(object sender, RoutedEventArgs e)
        {
            // this.Frame.Navigate(typeof(Gameplay));
            Yes.IsEnabled = true;
            Yes.Visibility = Visibility.Visible;
            No.IsEnabled = true;
            No.Visibility = Visibility.Visible;
            //Panel.IsEnabled = true;
            Panel.Visibility = Visibility.Visible;
        }
        private void ClickPlay(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(Gameplay));
        }
        private void ClickCancel(object sender, RoutedEventArgs e)
        {
            Yes.IsEnabled = false;
            Yes.Visibility = Visibility.Collapsed;
            No.IsEnabled = false;
            No.Visibility = Visibility.Collapsed;
            //Panel.IsEnabled = true;
            Panel.Visibility = Visibility.Collapsed;
        }
    }
}
