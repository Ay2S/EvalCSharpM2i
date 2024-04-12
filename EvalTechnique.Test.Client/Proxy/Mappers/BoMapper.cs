using EvalTechnique.EBusiness;
using EvalTechnique.Test.Client.BusinessObjects;
using EvalTechnique.Test.Client.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace EvalTechnique.Test.Client.Proxy.Mappers
{
    internal static class BoMapper
    {
        public static VideoItem ToVideoItem(this Movie m)
        {
            return new VideoItem(m.Title, m.Duration);
        }

        public static VideoItem ToVideoItem(this Serie s)
        {
            var seasons = s.Seasons.Select(season => new BusinessObjects.Season(season.Number, season.Episodes.Select(ep => new BusinessObjects.Episode(ep.Title)).ToList()));
            return new VideoItem(s.Title, seasons.ToList());
        }

        /// <summary>
        /// Normalisation du type des éléments de la liste
        /// </summary>
        /// <param name="items">Un certain <see cref="VideoDataBaseItem"/> pouvant être <see cref="Movie"/> ou <see cref="Serie"/></param>
        /// <returns></returns>
        /// <exception cref="VideoTypeNotSupportedException">Cas de télé-divertissements non gérés</exception>
        public static IEnumerable<VideoItem> ToVideoItems(this IEnumerable<VideoDataBaseItem> items)
        {
            List<VideoItem> result = new List<VideoItem>();
            if (items != null && items.Any())
            {
                foreach (VideoDataBaseItem item in items)
                {
                    if (item is Movie m)
                    {
                        result.Add(m.ToVideoItem());
                    }
                    else if (item is Serie s)
                    {
                        result.Add(s.ToVideoItem());
                    }
                    else
                    {
                        throw new VideoTypeNotSupportedException("Ce type de vidéo n'est encore géré !");
                    }
                }
            }

            return result;
        }
    }
}
