using System.Windows;

namespace CMCS
{
    public partial class CoordinatorDashboard : Window
    {
        public CoordinatorDashboard()
        {
            InitializeComponent();
            // Load claims into ClaimsDataGrid
        }

        private void ReviewClaims_Click(object sender, RoutedEventArgs e)
        {
            // Logic to show claims pending review
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            // Logic to approve selected claim
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            // Logic to reject selected claim
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Logic to logout and navigate to the login screen
        }
    }
}
