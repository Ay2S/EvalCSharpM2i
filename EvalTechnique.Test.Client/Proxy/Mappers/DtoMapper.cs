using EvalTechnique.EBusiness;
using EvalTechnique.Test.Client.BusinessObjects;
using EvalTechnique.Test.Client.BusinessObjects.Enums;
using EvalTechnique.Test.Client.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace EvalTechnique.Test.Client.Proxy.Mappers
{
    internal static class DtoMapper
    {
        public static VideoDataBaseItem ToVideoDataBaseItem(this VideoItem videoItem)
        {
            if (videoItem == null) return null;

            switch (videoItem.VideoType)
            {
                case VideoType.Movie:
                    return new Movie { Title = videoItem.Title, Duration = videoItem.Duration };
                case VideoType.Serie:
                    var seasons = videoItem.Seasons.Select(s => new EBusiness.Season { Number = s.Number, Episodes = s.Episodes.Select(ep => new EBusiness.Episode { Title = ep.Title }).ToList() });
                    return new Serie { Title = videoItem.Title, Seasons = seasons.ToList() };
                default:
                    throw new VideoTypeNotSupportedException("Ce type de vidéo n'est encore géré par ce mapping !");
            }
        }

        public static IEnumerable<VideoDataBaseItem> ToVideoDataBaseItems(this IEnumerable<VideoItem> videoItems)
        {
            return videoItems.Select(v => v.ToVideoDataBaseItem());
        }
    }
}
