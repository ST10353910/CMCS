using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace CMCS
{
    public partial class SubmitClaimWindow : Window
    {
        // Event to notify when a claim is submitted
        public event Action<string> ClaimSubmitted;

        private string uploadedDocumentPath;

        public SubmitClaimWindow()
        {
            InitializeComponent();
        }

        private void UploadDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog to select a document
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Documents|*.pdf;*.doc;*.docx;*.jpg;*.png|All Files|*.*",
                Title = "Select a Document"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Get the path of the selected file
                uploadedDocumentPath = openFileDialog.FileName;

                // Display the name of the uploaded document
                UploadedDocumentTextBlock.Text = Path.GetFileName(uploadedDocumentPath);
            }
        }

        private void SubmitClaimButton_Click(object sender, RoutedEventArgs e)
        {
            string hourlyRate = HourlyRateTextBox.Text;
            string hoursWorked = HoursWorkedTextBox.Text;
            string additionalNotes = AdditionalNotesTextBox.Text;

            if (string.IsNullOrWhiteSpace(hourlyRate) || string.IsNullOrWhiteSpace(hoursWorked))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if a document is uploaded
            if (string.IsNullOrWhiteSpace(uploadedDocumentPath))
            {
                MessageBox.Show("Please upload a document before submitting your claim.", "No Document", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Here you would typically save the claim data and the document path
            // For example, save the uploaded document to a specific directory

            // Raise the event to notify about the claim submission
            ClaimSubmitted?.Invoke($"Claim submitted: {hourlyRate} per hour for {hoursWorked} hours.\nNotes: {additionalNotes}\nDocument: {Path.GetFileName(uploadedDocumentPath)}");

            MessageBox.Show("Your claim has been submitted successfully!", "Submission Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
