﻿using AuthApp.DataContext;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        protected bool SetValue<T>(ref T target, T value, [CallerMemberName] string propName = null)
        {
            if (object.Equals(target, value))
                return false;

            target = value;
            OnPropertyChanged(propName);
            return true;
        }
    }
}
