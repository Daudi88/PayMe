using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PayMe.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A method that takes care of changing a property.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
