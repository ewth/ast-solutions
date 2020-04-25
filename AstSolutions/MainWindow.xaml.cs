using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AstSolutions
{
    /// <summary>
    /// The general approach here is to move the "interesting" parts out to classes, and leave just the bulk of the UI work in MainWindow.xaml.cs.
    /// This isn't strictly required in a small prototype-ish program like this, but makes it easier to review in my opinion.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Generate some randomish numbers for 1
            var random = new Random();
            var randomNumbers = new List<int>();

            // 6 was specially chosen by randomly dragging a textbox and it happened to fit 6 lines. SCIENCE.
            for (var i = 0; i < 6; i++)
            {
                randomNumbers.Add(random.Next(1,99));
            }

            TextLargestSmallest.Text = string.Join("\r\n", randomNumbers);
        }

        /// <summary>
        /// Find largest and smallest integer from text field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Question didn't specify integers, only numbers. But for simplicity, numbers = integers for this purpose.</remarks>
        private void ButtonLargestSmallestProcess_Click(object sender, RoutedEventArgs e)
        {


            InterestingParts.LargestSmallest largestSmallest;
            int method = RadioLargestSmallestMethod1.IsChecked == true ? 1 :
                RadioLargestSmallestMethod2.IsChecked == true ? 2 :
                RadioLargestSmallestMethod3.IsChecked == true ? 3 : 1;

            // Use of try...catch here is more to keep MessageBox within this class than because I'm concerned about exceptions
            try
            {
                largestSmallest = InterestingParts.FindLargestSmallest(TextLargestSmallest.Text, method);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Method: 0, Largest: 11231231231231231231232, Smallest:1231231
            var resultString = $"Method {method}: Largest: {largestSmallest.Largest}, Smallest: {largestSmallest.Smallest}";
            // Over about 60 characters causes the label to go skewiff. Shouldn't get to 60 characters but... we've dealt with real users before.
            if (resultString.Length > 60)
            {
                resultString = $"M{method}: L{largestSmallest.Largest} S{largestSmallest.Smallest}";
                if (resultString.Length > 60)
                {
                    resultString = resultString.Substring(0, 57) + "...";
                }
            }

            LabelLargestSmallestResult.Content = resultString;

        }

        /// <summary>
        /// Just pass on click event to Process button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioLargestSmallestMethod1_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonLargestSmallestProcess_Click(sender,e);
        }
    }
}
