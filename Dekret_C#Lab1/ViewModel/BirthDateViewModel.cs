using Dekret_CSharpLab1.Model;
using Dekret_CSharpLab1.Tools.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Dekret_CSharpLab1.ViewModel
{
    public class BirthDateViewModel : INotifyPropertyChanged
    {
        #region Fields
        private User _user = new User();
        private RelayCommand<object> _enterCommand;
        private RelayCommand<object> _closeCommand;


        #endregion

        #region Properties

        public DateTime BirthDate
        {
            get
            {
                return _user.BirthDate;
            }
            set
            {
                _user.BirthDate = value;   
            }
        }

        public int Age
        {
            get
            {
                return _user.Age;
            }
        }

        public string UserSunZodiac
        {
            get
            {
                return _user.UserSunZodiac;
            }
        }

        public string UserChineseZodiac
        {
            get
            {
                return _user.UserChineseZodiac;
            }
        }

        public RelayCommand<object> EnterCommand
        {
            get
            {
                return _enterCommand ?? (_enterCommand = new RelayCommand<object>(EnterInplementation,
                    o => CanExecuteCommand()));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }
        #endregion


        public bool CanExecuteCommand()
        {
            return (BirthDate)!=null;
        }


        private async void EnterInplementation(object obj)
        {
            await Task.Run(() => Thread.Sleep(1000));
            bool res = _user.processData();
            if (res)
            {

               OnPropertyChanged("Age");
               OnPropertyChanged("UserSunZodiac");
               OnPropertyChanged("UserChineseZodiac");
            }
            else
            {
                MessageBox.Show($"You can`t be born in {BirthDate} !");
            }

            if (_user.todayBirthday())
            {
                MessageBox.Show($"Happy Birthday!");
            }
           
        }

        #region INotifyPropertyImplementation
        public event PropertyChangedEventHandler PropertyChanged;

       // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
