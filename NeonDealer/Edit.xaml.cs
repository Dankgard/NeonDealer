﻿using System;
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
    public sealed partial class Edit : Page
    {
        public Edit()
        {
            this.InitializeComponent();
            colorpicker.Visibility = Visibility.Collapsed;
            modelpicker.Visibility = Visibility.Collapsed;
        

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
    private void Edit_Return(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ChooseColor(object sender, RoutedEventArgs e)
        {
            colorpicker.Visibility = Visibility.Visible;
            modelpicker.Visibility = Visibility.Collapsed;
        }

        private void ChooseModel(object sender, RoutedEventArgs e)
        {
            colorpicker.Visibility = Visibility.Collapsed;
            modelpicker.Visibility = Visibility.Visible;
        }
    }
}
