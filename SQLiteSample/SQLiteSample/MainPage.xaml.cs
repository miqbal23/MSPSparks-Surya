using SQLiteSample.Models;
using SQLiteSample.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel viewmodel = null;
        ObservableCollection<MSPCrew> items = null;

        public MainPage()
        {
            this.InitializeComponent();

            //refreshButton_Click(this, new RoutedEventArgs());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            viewmodel = new MainPageViewModel();
            if (nameTxtBox.Text != string.Empty && campusTxtBox.Text != string.Empty)
            {
                viewmodel.SaveItem(new BaseViewModel()
                {
                    Name = nameTxtBox.Text,
                    Campus = campusTxtBox.Text
                });
            }

            refreshButton_Click(this, new RoutedEventArgs());
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            nameListView.ItemsSource = null;
            campusListView.ItemsSource = null;

            items = viewmodel.GetItems();

            nameListView.ItemsSource = items;
            campusListView.ItemsSource = items;
        }
    }
}
