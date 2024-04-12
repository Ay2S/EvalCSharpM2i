using System;
using System.Windows;
using System.Windows.Controls;

namespace EvalTechnique.Test.Client.Components
{
    /// <summary>
    /// Interaction logic for TextField.xaml
    /// </summary>
    public partial class TextField : UserControl
    {
        public TextField()
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
            DependencyProperty.Register("Hint", typeof(string), typeof(TextField), new PropertyMetadata(null, SetHintText));

        private static void SetHintText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TextField)d).txtHint.Text = e.NewValue?.ToString();
        }

        #endregion

        #region Value

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(TextField),
                new PropertyMetadata(null, (d, e) => ((TextField)d).txtValue.Text = e.NewValue?.ToString()));

        #endregion

    }
}
