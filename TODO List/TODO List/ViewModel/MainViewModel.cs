using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TODO_List.Models;
using TODO_List.View;

namespace TODO_List.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public List<Chalange> chalangeList = new List<Chalange>();
        public ICommand AddTask { get; private set; }
        public ICommand EditTask { get; private set; }
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
            AddTask = new RelayCommand(OpenAddNewTaskPanel);
            DeleteTask = new RelayCommand(DeleteSelectedTask);
            EditTask = new RelayCommand(EditSelectedTask);
        }

        private void EditSelectedTask()
        {
            EditPanel editPanel = new EditPanel();
            EditTaskViewModel.InitData(this, editPanel);
            editPanel.Show();
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

        public static async void AddNewTask(MainViewModel mainView, string taskString)
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke(delegate { mainView.chalangeList.Add(ChallangeCreator.AddChallange(taskString)); });
                mainView.RaisePropertyChanged(() => mainView.ChalangeList);
            });
        }

        public static async void EditSelectedTask(MainViewModel mainView, string taskString)
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke(delegate { mainView.ChalangeList[mainView.ChalangeList.IndexOf(mainView.SelectedChalange)].TaskName = taskString; });
                mainView.RaisePropertyChanged(() => mainView.ChalangeList);
            });
        }

        private void OpenAddNewTaskPanel()
        {
            AddPanel _addPanel = new AddPanel();
            AddPanelViewModel.InitData(this, _addPanel);
            _addPanel.Show();
        }
    }
}