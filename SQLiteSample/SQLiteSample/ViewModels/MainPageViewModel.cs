using SQLite.Net;
using SQLiteSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteSample.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<MSPCrew> _items;

        public ObservableCollection<MSPCrew> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }

        public ObservableCollection<MSPCrew> GetItems()
        {
            _items = new ObservableCollection<MSPCrew>();

            using (var db = new SQLiteConnection(App.SQLITE_PLATFORM,App.DB_PATH))
            {
                var query = db.Table<MSPCrew>().OrderBy(c => c.Name);
                foreach (var msp in query)
                {
                    var _item = new MSPCrew()
                    {
                        Id = msp.Id,
                        Name = msp.Name,
                        Campus = msp.Campus
                    };
                    _items.Add(_item);
                }
            }
            return _items;
        }

    }
}
