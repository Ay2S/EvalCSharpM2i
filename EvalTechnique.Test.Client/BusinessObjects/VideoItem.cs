using EvalTechnique.Test.Client.BusinessObjects.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvalTechnique.Test.Client.BusinessObjects
{
    /// <summary>
    /// Ce type, représentant un <see cref="EBusiness.VideoDataBaseItem"/> récupéré par le service,
    /// sert à mapper les différents sous-types (<see cref="EBusiness.Movie"/> et <see cref="EBusiness.Serie"/>)
    /// vers un seul objet qui servira pour alimenter la vue
    /// </summary>
    public class VideoItem
    {
        public VideoItem(string title, int duration, StateFlag stateFlag = StateFlag.None)
        {
            Title = title;
            Duration = duration;
            VideoType = VideoType.Movie;
            StateFlag = stateFlag;
        }

        public VideoItem(string title, List<Season> seasons, StateFlag stateFlag = StateFlag.None)
        {
            Title = title;
            Seasons = seasons;
            VideoType = VideoType.Serie;
            StateFlag = stateFlag;
        }

        public string Title { get; set; }

        public int Duration { get; set; }

        public VideoType VideoType { get; set; }

        public List<Season> Seasons { get; set; }

        public StateFlag StateFlag { get; set; }

        public string Details => ToString();

        public override string ToString()
        {
            switch (VideoType)
            {
                case VideoType.Movie:
                    return $"Film : {Title} | Durée : {Duration}";
                case VideoType.Serie:
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Série : {Title} | Nbre de saisons : {Seasons.Count} | Nbre Total d'épisodes : {Seasons.Sum(s => s.Episodes.Count)}");
                    foreach (Season season in Seasons) sb.Append(season.ToString());
                    return sb.ToString();
                default:
                    return string.Empty;
            }
        }
    }

    public class Season
    {
        public Season(int number, List<Episode> episodes)
        {
            Number = number;
            Episodes = episodes;
        }

        public int Number { get; set; }

        public List<Episode> Episodes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\t- Saison {Number} | Nbre d'épisodes : {Episodes.Count}");

            for (int i = 0; i < Episodes.Count; i++)
                sb.AppendLine($"\t\t- Episode {i + 1} : {Episodes[i].Title}");

            return sb.ToString();
        }
    }

    public class Episode
    {
        public Episode(string title) => Title = title;

        public string Title { get; set; }
    }
}
