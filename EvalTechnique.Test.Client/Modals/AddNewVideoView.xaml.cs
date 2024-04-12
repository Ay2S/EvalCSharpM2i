using EvalTechnique.Test.Client.BusinessObjects;
using EvalTechnique.Test.Client.Proxy;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace EvalTechnique.Test.Client.Modals
{
    /// <summary>
    /// Interaction logic for AddNewVideoView.xaml
    /// </summary>
    public partial class AddNewVideoView : Window
    {
        public AddNewVideoView()
        {
            InitializeComponent();
        }

        public VideoItem VideoItem { get; set; }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (rdMovie.IsChecked.GetValueOrDefault()
                && int.TryParse(txtDuration.txtValue.Text, out int duration))
            {
                VideoItem = new VideoItem(txtTitle.txtValue.Text, duration, BusinessObjects.Enums.StateFlag.Create);
            }

            if (rdSerie.IsChecked.GetValueOrDefault()
                && int.TryParse(txtNbSeasens.txtValue.Text, out int nbSeasons)
                && int.TryParse(txtNbEpisodes.txtValue.Text, out int nbEpisodes)
                && nbEpisodes > nbSeasons)
            {
                var episodes = Enumerable.Range(0, nbEpisodes / nbSeasons).Select(ep => new Episode($"Episode{ep + 1}")).ToList();
                var seasons = Enumerable.Range(0, nbSeasons).Select(s => new Season(s + 1, episodes)).ToList();

                VideoItem = new VideoItem(txtTitle.txtValue.Text, seasons, BusinessObjects.Enums.StateFlag.Create);
            }

            // Sauvegarder en BDD
            VideoProxy.GetInstance().AddNewVideoItem(new List<VideoItem> { VideoItem });

            DialogResult = true;
            this.Close();
        }
    }
}
