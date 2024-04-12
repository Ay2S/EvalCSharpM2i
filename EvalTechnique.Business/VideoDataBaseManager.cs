using EvalTechnique.EBusiness;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EvalTechnique.Business
{
    public class VideoDataBaseManager
    {
        private static VideoDataBaseManager manager = null;
        public static VideoDataBaseManager Current
        {
            get
            {
                if (manager == null)
                {
                    manager = new VideoDataBaseManager();
                    manager.Load();
                }
                return manager;
            }
        }

        private readonly string RELATIVE_XML_PATH = Path.Combine("EvalTechnique.Test.Server", "VideoDataBase.xml");
        private readonly string fileName;
        private EBusiness.VideoDataBase videoDataBase = null;

        private VideoDataBaseManager()
        {
            fileName = Path.Combine(
                Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.FullName,
                RELATIVE_XML_PATH);

            Load();
        }

        public void Load()
        {
            videoDataBase = Data.VideoDataBaseProvider.Load(fileName);
        }

        public void Save()
        {
            Data.VideoDataBaseProvider.Save(fileName, videoDataBase);
        }

        public List<EBusiness.VideoDataBaseItem> GetItems()
        {
            return videoDataBase.Items;
        }

        public List<TItem> GetItemsByType<TItem>() where TItem : VideoDataBaseItem
        {
            return
                videoDataBase.Items
                .Where(item => item is TItem)
                .Select(item => (TItem)item)
                .ToList();
        }

        public List<VideoDataBaseItem> GetByTitle(string searchTitle)
        {
            return
                videoDataBase.Items
                .Where(item => item.Title.IndexOf(searchTitle, System.StringComparison.InvariantCultureIgnoreCase) >= 0)
                .ToList();
        }

        public void AddNewVideoItems(List<VideoDataBaseItem> videoDataBaseItems)
        {
            videoDataBase.Items.AddRange(videoDataBaseItems);
            Save();
        }

        #region Mock Xml
        private void SaveMockVideoDb()
        {
            var videoDataBase = new EBusiness.VideoDataBase
            {
                Items = new List<EBusiness.VideoDataBaseItem>
                {
                    new Movie { Title = "Matrix", Duration = 110 },
                    new Movie { Title = "IronMan" },
                    new Serie {
                        Title = "Dr House",
                        Seasons = new List<Season>
                        {
                            new Season
                            {
                                Number = 1,
                                Episodes = new List<Episode>
                                {
                                    new Episode { Title = "Debut" },
                                    new Episode { Title = "Fin" }
                                }
                            },
                            new Season
                            {
                                Number = 2,
                                Episodes = new List<Episode>
                                {
                                    new Episode { Title = "Debut" },
                                    new Episode { Title = "Fin" }
                                }
                            }
                        }
                    }
                }
            };

            Data.VideoDataBaseProvider.Save("C:\\EvalTechnique\\test.xml", videoDataBase);
        }
        #endregion
    }
}
