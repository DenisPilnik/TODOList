using EnvDTE;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TODO_List.Models;

namespace TODO_List.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public List<Chalange> chalangeList = new List<Chalange>();
        public ICommand AddTask { get; private set; }
        public ICommand DeleteTask { get; private set; }
        Chalange selectedChalange { get; set; }
        public Chalange SelectedChalange
        {
            get
            {
                return selectedChalange;
            }
            set
            {
                selectedChalange = value;
            }
        }
        public ObservableCollection<Chalange> ChalangeList
        {
            get
            {
                return new ObservableCollection<Chalange>(chalangeList);
            }
        }
        public MainViewModel()
        {
            AddTask = new RelayCommand(AddNewTask);
            DeleteTask = new RelayCommand(DeleteSelectedTask);
        }

        private async void DeleteSelectedTask()
        {
            await Task.Run(() =>
            {
                chalangeList.Remove(selectedChalange);
                selectedChalange = null;
                RaisePropertyChanged(() => ChalangeList);
            });
        }

        private async void AddNewTask()
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke(delegate { chalangeList.Add(ChallangeCreator.AddChallange(chalangeList.Count)); });
                RaisePropertyChanged(() => ChalangeList);
            });
        }
    }
}