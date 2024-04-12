using EvalTechnique.Test.Client.Modals;
using EvalTechnique.Test.Client.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EvalTechnique.Test.Client.Commands
{
    internal class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private VideoListViewModel _viewModel;
        public AddCommand(VideoListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var dialog = new AddNewVideoView();
            if (dialog.ShowDialog().GetValueOrDefault() && dialog.VideoItem != null)
            {
                if (_viewModel.VideoItems == null)
                    _viewModel.VideoItems = new ObservableCollection<BusinessObjects.VideoItem>();

                _viewModel.VideoItems.Add(dialog.VideoItem);
            }
        }
    }
}
