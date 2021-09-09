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
    public class AddPanelViewModel : ViewModelBase
    {
        public ICommand AddTask { get; private set; }
        public ICommand Cancel { get; private set; }
        static public MainViewModel MainViewModel;
        static public AddPanel AddPanel;
        private string taskString { get; set; }
        public string TaskString
        {
            get
            {
                return taskString;
            }
            set
            {
                taskString = value;
            }
        }
        public AddPanelViewModel()
        {
            AddTask = new RelayCommand(AddNewTask);
            Cancel = new RelayCommand(CancelCreateNewTask);
        }

        public static void InitData(MainViewModel mainViewModel, AddPanel addPanel)
        {
            MainViewModel = mainViewModel;
            AddPanel = addPanel;
        }

        private void CancelCreateNewTask()
        {
            AddPanel.Close();
        }

        private void AddNewTask()
        {
            MainViewModel.AddNewTask(MainViewModel, taskString);
            CancelCreateNewTask();
        }
    }
}
