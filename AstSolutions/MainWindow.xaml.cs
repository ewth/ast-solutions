using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            // Generate some randomish numbers for Largest Smallest
            var random = new Random();
            var randomNumbers = new List<int>();
            // 6 was specially chosen by randomly dragging a textbox and it happened to fit 6 lines. SCIENCE.
            for (var i = 0; i < 6; i++)
            {
                randomNumbers.Add(random.Next(1,99));
            }
            LargestSmallestText.Text = string.Join("\r\n", randomNumbers);
        }

        /// <summary>
        /// Find largest and smallest integer from text field (when Process button clicked).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Question didn't specify integers, only numbers. But for simplicity, numbers = integers for this purpose.</remarks>
        private void ButtonLargestSmallestProcess_Click(object sender, RoutedEventArgs e)
        {
            // Declare (but don't instantiate) collection
            LargestSmallest.LargestSmallestResult largestSmallest;

            // Determine method to use depending on radio button choice
            int method = LargestSmallestRadioMethod1.IsChecked == true ? 1 :
                LargestSmallestRadioMethod2.IsChecked == true ? 2 :
                LargestSmallestRadioMethod3.IsChecked == true ? 3 : 1;

            // Use of try...catch here is more to keep MessageBox within this class than because I'm concerned about exceptions
            try
            {
                largestSmallest = LargestSmallest.FindLargestSmallest(LargestSmallestText.Text, method);
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

            LargestSmallestLabelResult.Content = resultString;

        }

        /// <summary>
        /// Just pass on click event to Process button when a group radio button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LargestSmallestRadioMethod1_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonLargestSmallestProcess_Click(sender,e);
        }

        /// <summary>
        /// Remove duplicates from string when process button clicked, using specified method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemoveDuplicatesProcess_OnClick(object sender, RoutedEventArgs e)
        {
            // Determine method to use depending on radio button choice
            int method = RadioRemoveDuplicatesMethod1.IsChecked == true ? 1 :
                RadioRemoveDuplicatesMethod2.IsChecked == true ? 2 :
                RadioRemoveDuplicatesMethod3.IsChecked == true ? 3 : 1;

            try
            {
                TextRemoveDuplicateOutput.Text =
                    RemoveDuplicates.RemoveDuplicatesFromString(TextRemoveDuplicateInput.Text, method);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Pass on click to Process button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioRemoveDuplicatesMethod1_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonRemoveDuplicatesProcess_OnClick(sender, e);
        }

        /// <summary>
        /// Determine anagram status on Check click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnagramButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            if (Anagram.IsAnagram(AnagramTextFirst.Text, AnagramTextSecond.Text))
            {
                AnagramLabelResult.Content = "Yes!";
                AnagramLabelResult.Foreground = Brushes.DarkGreen;
                AnagramLabelResult.FontSize = 24;
            }
            else
            {
                AnagramLabelResult.Content = "No.";
                AnagramLabelResult.Foreground = Brushes.DarkRed;
                AnagramLabelResult.FontSize = 14;
            }
        }

        private void MobileButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneNumber.IsValidPhonenumber(MobileTextNumber.Text))
            {
                MobileLabelResult.Content = "Valid!";
                MobileLabelResult.Foreground = Brushes.DarkGreen;
                MobileLabelResult.FontSize = 24;
            }
            else
            {
                MobileLabelResult.Content = "Invalid.";
                MobileLabelResult.Foreground = Brushes.DarkRed;
                MobileLabelResult.FontSize = 14;
            }
        }
    }
}
