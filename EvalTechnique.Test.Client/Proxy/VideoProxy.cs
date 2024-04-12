using EvalTechnique.Client;
using EvalTechnique.Test.Client.BusinessObjects;
using EvalTechnique.Test.Client.Proxy.Mappers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;

namespace EvalTechnique.Test.Client.Proxy
{
    internal class VideoProxy
    {
        private static VideoProxy _instance = null;
        public static VideoProxy GetInstance() => _instance = _instance ?? new VideoProxy();

        private readonly IBusiness.IVideoDataBaseService _service;
        private VideoProxy()
        {
            string serverUrl = ConfigurationManager.AppSettings["VideoServerUrl"];
            _service = ClientHelper.GetService<IBusiness.IVideoDataBaseService>(serverUrl);
        }

        public ObservableCollection<VideoItem> GetItems()
        {
            var dbResult = _service.GetItems();
            return new ObservableCollection<VideoItem>(dbResult.ToVideoItems());
        }

        public ObservableCollection<VideoItem> GetMovies()
        {
            var dbResult = _service.GetMovies();
            return new ObservableCollection<VideoItem>(dbResult.Select(m => m.ToVideoItem()));
        }

        public ObservableCollection<VideoItem> GetSeries()
        {
            var dbResult = _service.GetSeries();
            return new ObservableCollection<VideoItem>(dbResult.Select(s => s.ToVideoItem()));
        }

        public ObservableCollection<VideoItem> GetByTitle(string searchTitle)
        {
            var dbResult = _service.GetByTitle(searchTitle);
            return new ObservableCollection<VideoItem>(dbResult.ToVideoItems());
        }

        public void AddNewVideoItem(IEnumerable<VideoItem> videoItems)
        {
            _service.AddNewVideoItems(videoItems.ToVideoDataBaseItems().ToList());
        }
    }
}
