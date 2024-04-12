using EvalTechnique.Test.Client.ViewModel;
using System;
using System.Linq;
using System.Windows.Input;

namespace EvalTechnique.Test.Client.Commands
{
    internal class SwitchViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MainViewModel _mainViewModel;
        public SwitchViewCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            int selectedIndex = _mainViewModel.ViewModels.IndexOf(_mainViewModel.SelectedViewModel);

            if (parameter?.ToString() == "p")
            {
                if (selectedIndex == 0) selectedIndex = _mainViewModel.ViewModels.Count - 1;
                else selectedIndex--;
            }
            else if (parameter?.ToString() == "n")
            {
                if (selectedIndex == _mainViewModel.ViewModels.Count - 1) selectedIndex = 0;
                else selectedIndex++;
            }
            else return;

            _mainViewModel.SelectedVideoType = _mainViewModel.VideoTypes.ElementAt(selectedIndex);
            _mainViewModel.SelectedViewModel = _mainViewModel.ViewModels[selectedIndex];
        }
    }
}
