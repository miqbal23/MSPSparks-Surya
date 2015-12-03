using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MSPSparks_FileAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageFolder folder = ApplicationData.Current.LocalFolder;

        StorageFile file;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if(content_txt.Text == null)
            {
                notiftxt.Text = "Content can't be null";
            }

            if(filename_txt.Text == null)
            {
                notiftxt.Text = "Filename can't be null. Please type the filename";
            }

            if(content_txt.Text != null && filename_txt.Text != null)
            {
                file = await folder.CreateFileAsync(filename_txt.Text, CreationCollisionOption.ReplaceExisting);

                await FileIO.WriteTextAsync(file, content_txt.Text);
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            string data = await FileIO.ReadTextAsync(file);
            notiftxt.Text = data.ToString();
        }
    }
}
