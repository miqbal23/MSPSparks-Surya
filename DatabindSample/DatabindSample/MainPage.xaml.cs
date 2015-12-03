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

namespace DatabindSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<StrukturData> Data = new ObservableCollection<StrukturData>();

        public MainPage()
        {
            this.InitializeComponent();

            AddNewData("Muhamad Iqbal","Universitas Gunadarma","Assets/img_iqbal.jpg");
            AddNewData("Alvin Julian","Surya University","Assets/img_alvin.jpg");
            AddNewData("Deni Pramulia","Universitas Indonesia","Assets/img_deni.jpg");
            AddNewData("Sangadji Prabowo","Universitas Indonesia","Assets/img_adji.jpg");

            this.ListMsp.ItemsSource = Data;
        }

        private void AddNewData(string _nama, string _kampus, string _imgUrl)
        {
            var _data = new StrukturData
            {
                Nama = _nama,
                Kampus = _kampus,
                Gambar = _imgUrl
            };

            Data.Add(_data);
        }
    }
}
