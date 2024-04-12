using System.Windows;
using System.Windows.Controls;

namespace EvalTechnique.Test.Client.Components
{
    /// <summary>
    /// Interaction logic for TextInfo.xaml
    /// </summary>
    public partial class TextInfo : UserControl
    {
        public TextInfo()
        {
            InitializeComponent();
        }

        #region Hint

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(TextInfo), new PropertyMetadata(null, SetHintText));

        private static void SetHintText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TextInfo)d).txtHint.Text = e.NewValue?.ToString();
        }

        #endregion

        #region Value



        public string Info
        {
            get { return (string)GetValue(InfoProperty); }
            set { SetValue(InfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Info.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InfoProperty =
            DependencyProperty.Register("Info", typeof(string), typeof(TextInfo), new PropertyMetadata(null, (d, e) => ((TextInfo)d).txtInfo.Content = e.NewValue?.ToString()));



        #endregion
    }
}
