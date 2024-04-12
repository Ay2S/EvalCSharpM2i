using EvalTechnique.Test.Client.BusinessObjects;
using EvalTechnique.Test.Client.BusinessObjects.Enums;
using EvalTechnique.Test.Client.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EvalTechnique.Test.Client.ViewModel
{
    internal class VideoListViewModel : BaseViewModel
    {
        private VideoType _videoType; 
        public VideoType VideoType
        {
            get => _videoType;
            set { _videoType = value; RaisePropertyChanged(); }
        }

        private int _totalResult;
        public int TotalResult
        {
            get => _totalResult;
            set { _totalResult = value; RaisePropertyChanged(); }
        }
        
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; RaisePropertyChanged(); }
        }

        #region Commands

        public ICommand SearchCommand { get; }

        public ICommand AddCommand { get; }

        #endregion

        public ObservableCollection<VideoItem> VideoItems { get; set; }

        public VideoListViewModel()
        {
            SearchCommand = new SearchCommand(this);
            AddCommand = new AddCommand(this);
        }

        public VideoListViewModel(VideoType videoType) : this()
        {
            VideoType = videoType;
        }
    }
}
