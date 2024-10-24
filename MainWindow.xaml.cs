using System.Windows;

namespace CMCS
{
    public partial class LecturerDashboard : Window
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        // Event handler for the "Submit Claim" button and menu item
        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the SubmitClaimWindow
            SubmitClaimWindow submitClaimWindow = new SubmitClaimWindow();

            // Subscribe to the ClaimSubmitted event
            submitClaimWindow.ClaimSubmitted += ClaimSubmittedHandler;

            // Show the SubmitClaimWindow as a dialog
            submitClaimWindow.ShowDialog();
        }

        private void ClaimSubmittedHandler(string claimDetails)
        {
            // Update the ListBox with claim details
            TrackClaimListBox.Items.Add(claimDetails);
            MessageBox.Show(claimDetails, "Claim Submitted", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for the "Track Claim" menu item
        private void TrackClaim_Click(object sender, RoutedEventArgs e)
        {
            // Logic to track claims
            // For demonstration, we will display the status of the last submitted claim
            if (TrackClaimListBox.Items.Count > 0)
            {
                var lastClaim = TrackClaimListBox.Items[TrackClaimListBox.Items.Count - 1].ToString();
                ClaimStatusTextBlock.Text = lastClaim; // Assuming this displays the claim status
                ClaimStatusTextBlock.Visibility = Visibility.Visible; // Show the status text
            }
            else
            {
                ClaimStatusTextBlock.Text = "No claims submitted.";
                ClaimStatusTextBlock.Visibility = Visibility.Visible; // Show the status text
            }
        }

        // Event handler for the "Upload Documents" button
        private void UploadDocuments_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle document upload
            MessageBox.Show("Upload Documents button clicked.");
        }

        // Event handler for the "Logout" menu item
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Clear all claims from the ListBox
            TrackClaimListBox.Items.Clear();

            // Optionally show a message confirming the logout
            MessageBox.Show("You have been logged out. All claims have been cleared.", "Logout", MessageBoxButton.OK, MessageBoxImage.Information);

            // Logic to handle further actions upon logout, such as closing the window
            this.Close(); // Optionally close the dashboard window
        }

        // Event handler for the "Claims Approval" menu item
        private void ClaimsApproval_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the ClaimsApprovalWindow
            ClaimsApprovalWindow approvalWindow = new ClaimsApprovalWindow();

            // Show the ClaimsApprovalWindow as a dialog
            approvalWindow.ShowDialog();
        }
    }
}
