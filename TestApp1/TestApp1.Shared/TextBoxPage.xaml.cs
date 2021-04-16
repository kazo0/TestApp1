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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TextBoxPage : Page
    {
        public TextBoxPage()
        {
            this.InitializeComponent();

			Submit.Click += Submit_Click;
        }

		private void Submit_Click(object sender, RoutedEventArgs e)
		{
            var frame = Windows.UI.Xaml.Window.Current.Content as Frame;
            frame.Navigate(typeof(MainPage));
        }
	}
}
