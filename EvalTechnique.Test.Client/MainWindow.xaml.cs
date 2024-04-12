using System.Windows;

namespace EvalTechnique
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IBusiness.IVideoDataBaseService service = Client.ClientHelper.GetService<IBusiness.IVideoDataBaseService>("http://localhost:36990/IVideoDataBaseService");

            var test = service.Test();

            var items = service.GetItems();

            // TODO DONE: Implement these methods inside service/manager/dataprovider using linq extensions with lambda
            var movies = service.GetMovies();
            var series = service.GetSeries();
            var bytitle1 = service.GetByTitle("iron");
            var bytitle2 = service.GetByTitle("house");
            var bytitle3 = service.GetByTitle("Iron Man 1");

        }
    }
}
