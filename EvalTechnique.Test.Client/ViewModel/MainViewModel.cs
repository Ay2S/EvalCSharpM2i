using EvalTechnique.Test.Client.BusinessObjects;
using EvalTechnique.Test.Client.BusinessObjects.Enums;
using EvalTechnique.Test.Client.Commands;
using System.Linq;
using System.Windows.Input;

namespace EvalTechnique.Test.Client.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public ViewModelCollection ViewModels { get; set; }

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; RaisePropertyChanged(); }
        }

        private VideoType _selectedVideoType;
        public VideoType SelectedVideoType
        {
            get => _selectedVideoType;
            set { _selectedVideoType = value; RaisePropertyChanged(); }
        }

        #region Commands

        public ICommand SwitchViewCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            ViewModels = new ViewModelCollection
            {
                new VideoListViewModel(VideoType.All),
                new VideoListViewModel(VideoType.Movie),
                new VideoListViewModel(VideoType.Serie)
            };

            SelectedViewModel = ViewModels.First();
            SelectedVideoType = (SelectedViewModel as VideoListViewModel).VideoType;

            SwitchViewCommand = new SwitchViewCommand(this);
        }
    }
}
