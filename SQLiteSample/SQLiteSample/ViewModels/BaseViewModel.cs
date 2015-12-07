using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteSample.Models;
using SQLite.Net;
using System.ComponentModel;

namespace SQLiteSample.ViewModels
{
    class BaseViewModel
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        private string _campus;

        public string Campus
        {
            get { return _campus; }
            set
            {
                if (_campus == value)
                    return;
                _campus = value;
                RaisePropertyChanged("Campus");
            }
        }

        private SQLiteConnection dbConn = new SQLiteConnection(App.SQLITE_PLATFORM, App.DB_PATH);

        public BaseViewModel GetItem(int itemId)
        {
            var item = new BaseViewModel();

            using (dbConn)
            {
                var _item = (dbConn.Table<MSPCrew>().Where(c => c.Id == itemId)).Single();
                item.Id = _item.Id;
                item.Name = _item.Name;
                item.Campus = _item.Campus;
            }
            return item;
        }

        public string SaveItem(BaseViewModel item)
        {
            string result = string.Empty;
            int success;

            using (dbConn)
            {
                try
                {
                    var existingItem = (dbConn.Table<MSPCrew>().Where(c => c.Id == item.Id)).SingleOrDefault();
                    if (existingItem != null)
                    {
                        existingItem.Name = item.Name;
                        success = dbConn.Update(existingItem);
                    }
                    else
                    {
                        success = dbConn.Insert(new MSPCrew()
                        {
                            Name = item.Name,
                            Campus = item.Campus
                        });
                    }
                    result = "Success";
                }
                catch
                {
                    result = "This item was not saved";
                }
            }
            return result;
        }

        public string DeleteItem(int itemId)
        {
            string result = string.Empty;

            using (dbConn)
            {
                var existingItem = dbConn.Query<MSPCrew>("Select * from MSPCrew where Id=" + itemId).FirstOrDefault();
                if (existingItem != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingItem);
                        if (dbConn.Delete(existingItem) > 0)
                        {
                            result = "Success";
                        }
                        else
                        {
                            result = "This item was not removed";
                        }
                    });
                }
            }
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
