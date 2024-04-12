using EvalTechnique.Test.Client.BusinessObjects;
using EvalTechnique.Test.Client.BusinessObjects.Enums;
using EvalTechnique.Test.Client.Proxy;
using EvalTechnique.Test.Client.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EvalTechnique.Test.Client.Commands
{
    internal class SearchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly VideoListViewModel _videoListViewModel;
        public SearchCommand(VideoListViewModel videoListViewModel)
        {
            _videoListViewModel = videoListViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            switch (_videoListViewModel.VideoType)
            {
                case VideoType.All:
                    _videoListViewModel.VideoItems = VideoProxy.GetInstance().GetItems();
                    break;
                case VideoType.Movie:
                    _videoListViewModel.VideoItems = VideoProxy.GetInstance().GetMovies();
                    break;
                case VideoType.Serie:
                    _videoListViewModel.VideoItems = VideoProxy.GetInstance().GetSeries();
                    break;
                default:
                    _videoListViewModel.VideoItems = new ObservableCollection<VideoItem>();
                    break;
            }

            _videoListViewModel.TotalResult = _videoListViewModel.VideoItems.Count;
            _videoListViewModel.RaisePropertyChanged(nameof(_videoListViewModel.VideoItems));
        }
    }
}
