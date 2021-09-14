using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using TODO_List.View;

namespace TODO_List.ViewModel
{
    public class EditTaskViewModel : ViewModelBase
    {
        public ICommand EditTask { get; private set; }
        public ICommand Cancel { get; private set; }
        static private MainViewModel MainViewModel;
        static private EditPanel EditPanel;
        private string editedTaskString { get; set; }
        public string EditedTaskString
        {
            get
            {
                return editedTaskString;
            }
            set
            {
                editedTaskString = value;
            }
        }
        public EditTaskViewModel()
        {
            EditTask = new RelayCommand(EditSelectedTask);
            Cancel = new RelayCommand(CancelEditTask);
        }

        private void CancelEditTask()
        {
            EditPanel.Close();
        }
        public void InitData(MainViewModel mainViewModel, EditPanel editPanel)
        {
            MainViewModel = mainViewModel;
            EditPanel = editPanel;
        }
        private void EditSelectedTask()
        {
            MainViewModel.EditSelectedTask(MainViewModel, EditedTaskString);
            EditedTaskString = String.Empty;
            CancelEditTask();
        }
    }
}
