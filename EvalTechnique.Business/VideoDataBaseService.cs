using EvalTechnique.EBusiness;
using System.Collections.Generic;

namespace EvalTechnique.Business
{
    public class VideoDataBaseService : IBusiness.IVideoDataBaseService
    {
        public List<VideoDataBaseItem> GetItems()
        {
            return VideoDataBaseManager.Current.GetItems();
        }

        public List<Movie> GetMovies()
        {
            return VideoDataBaseManager.Current.GetItemsByType<Movie>();
        }

        public List<Serie> GetSeries()
        {
            return VideoDataBaseManager.Current.GetItemsByType<Serie>();
        }

        public List<VideoDataBaseItem> GetByTitle(string searchTitle)
        {
            return VideoDataBaseManager.Current.GetByTitle(searchTitle);
        }

        public string Test()
        {
            return "OK";
        }

        public void AddNewVideoItems(List<VideoDataBaseItem> videoDataBaseItems)
        {
            VideoDataBaseManager.Current.AddNewVideoItems(videoDataBaseItems);
        }
    }
}
