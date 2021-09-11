using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
                RaisePropertyChanged(() => SelectedChalange);
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
            LoadTaskMethod();
        }
        private void LoadTaskMethod()
        {
            chalangeList.Clear();
            DataBase.VelocityWorker.GetChalangeFromDb().ForEach(delegate(Chalange chalange){
                Task.Run(() =>
                {
                    App.Current.Dispatcher.Invoke(delegate { chalangeList.Add(chalange); });
                    RaisePropertyChanged(() => ChalangeList);
                });
            }); 
        }

        private void EditSelectedTask()
        {
            EditPanel editPanel = new EditPanel();
            EditTaskViewModel.InitData(this, editPanel);
            editPanel.Show();
        }

        private void DeleteSelectedTask()
        {
            DataBase.VelocityWorker.DeleteChalangeFromDb(SelectedChalange);
            LoadTaskMethod();
        }

        public static void AddNewTask(MainViewModel mainView, string taskString)
        {
            DataBase.VelocityWorker.AddNewTask(ChallangeCreator.AddChallange(taskString));
            mainView.LoadTaskMethod();
        }

        public static void EditSelectedTask(MainViewModel mainView, string taskString)
        {
            DataBase.VelocityWorker.EditChalange(taskString, mainView.SelectedChalange);
            mainView.LoadTaskMethod();
        }
        private void OpenAddNewTaskPanel()
        {
            AddPanel _addPanel = new AddPanel();
            AddPanelViewModel.InitData(this, _addPanel);
            _addPanel.Show();
        }
    }
}