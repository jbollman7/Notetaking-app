using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XAMLUI.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();
            EraseCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });
            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });
        }



        public ObservableCollection<string> AllNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;
        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote)); //name of the method here.

                PropertyChanged?.Invoke(this, args);        //? is sugar to check if its null
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        
    }
}
