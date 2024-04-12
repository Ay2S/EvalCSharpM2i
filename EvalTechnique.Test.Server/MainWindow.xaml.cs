using System;
using System.ComponentModel;
using System.Windows;

namespace EvalTechnique.Test.Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private bool serverStarted = false;
        private readonly BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();

            worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void btnRunServer_Click(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy) worker.RunWorkerAsync();
        }

        #region Worker methods

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                pbLoadingSate.IsIndeterminate = false;
                pbLoadingSate.Visibility = Visibility.Hidden;
                btnRunServer.Content = serverStarted ? "Arrêter le serveur" : "Démarrer le serveur";
                btnRunServer.IsEnabled = true;
                txtServerState.Text = serverStarted ? "SERVER ON" : "SERVER OFF";
            });
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (serverStarted)
                {
                    _ = EvalTechnique.Server.ServerHelper.StopService();
                    serverStarted = false;
                }
                else serverStarted = EvalTechnique.Server.ServerHelper.StartService<IBusiness.IVideoDataBaseService>();
            }
            catch
            {
                serverStarted = false;
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            pbLoadingSate.Visibility = Visibility.Visible;
            pbLoadingSate.IsIndeterminate = true;
            btnRunServer.Content = "Démarrage du serveur en cours ...";
            btnRunServer.IsEnabled = false;

        }

        #endregion

        public void Dispose()
        {
            worker.DoWork -= Worker_DoWork;
            worker.ProgressChanged -= Worker_ProgressChanged;
            worker.RunWorkerCompleted -= Worker_RunWorkerCompleted;
        }
    }
}
