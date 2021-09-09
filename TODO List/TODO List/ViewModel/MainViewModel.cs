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
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public List<Chalange> chalangeList = new List<Chalange>();
        public ICommand AddTask { get; private set; }
        public ICommand Test { get; private set; }
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
            Test = new RelayCommand(TestFunc);
        }

        private void TestFunc()
        {
            int selectedItem = ChalangeList.IndexOf(SelectedItem);
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