using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CMCS
{
    public partial class ClaimsApprovalWindow : Window
    {
        public event Action<string> ClaimStatusChanged; // Event to notify status change

        public List<Claim> PendingClaims { get; set; }

        public ClaimsApprovalWindow()
        {
            InitializeComponent();
            LoadPendingClaims();
        }

        private void LoadPendingClaims()
        {
            PendingClaims = new List<Claim>
            {
                new Claim { HourlyRate = "20", HoursWorked = "5", AdditionalNotes = "Worked on project X", Status = "Pending" },
                new Claim { HourlyRate = "25", HoursWorked = "3", AdditionalNotes = "Consultation", Status = "Pending" }
            };

            ClaimsListView.ItemsSource = PendingClaims;
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((Button)sender).DataContext;
            claim.Status = "Approved";
            ClaimStatusChanged?.Invoke($"Claim for {claim.HoursWorked} hours at {claim.HourlyRate} approved."); // Notify status change
            MessageBox.Show($"Claim approved: {claim.HourlyRate} for {claim.HoursWorked} hours.", "Approval", MessageBoxButton.OK, MessageBoxImage.Information);
            ClaimsListView.Items.Refresh();
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((Button)sender).DataContext;
            claim.Status = "Rejected";
            ClaimStatusChanged?.Invoke($"Claim for {claim.HoursWorked} hours at {claim.HourlyRate} rejected."); // Notify status change
            MessageBox.Show($"Claim rejected: {claim.HourlyRate} for {claim.HoursWorked} hours.", "Rejection", MessageBoxButton.OK, MessageBoxImage.Warning);
            ClaimsListView.Items.Refresh();
        }
    }

    public class Claim
    {
        public string HourlyRate { get; set; }
        public string HoursWorked { get; set; }
        public string AdditionalNotes { get; set; }
        public string DocumentPath { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string LecturerName { get; set; }
    }
}
