using EvalTechnique.Test.Client.BusinessObjects.Enums;
using EvalTechnique.Test.Client.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EvalTechnique.Test.Client.BusinessObjects
{
    internal class ViewModelCollection : ObservableCollection<BaseViewModel>
    {
        /// <summary>
        /// Indexer un <see cref="BaseViewModel"/> par le type de vidéo : <see cref="VideoType"/>
        /// </summary>
        /// <param name="videoType"></param>
        /// <returns></returns>
        public VideoListViewModel this[VideoType videoType]
        {
            get => (VideoListViewModel)this.FirstOrDefault(e => e is VideoListViewModel vm && vm.VideoType == videoType);
        }

        public ViewModelCollection() : base() { }

        public ViewModelCollection(IEnumerable<BaseViewModel> videosList) : base(videosList) { }
    }
}
