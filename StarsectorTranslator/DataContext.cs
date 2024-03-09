using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using StarsectorTranslator.Models;

namespace StarsectorTranslator
{
    public class DataContext : INotifyPropertyChanged
    {
        private List<Translation> _lines;
        public List<Translation> Lines
        {
            get => _lines;
            set
            {
                _lines = value;
                NotifyPropertyChanged(nameof(Lines));
            }
        }

        public void NotifyPropertyChanged(string property)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
