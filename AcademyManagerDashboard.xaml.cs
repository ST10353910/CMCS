using System.Windows;

namespace CMCS
{
    public partial class AcademyManagerDashboard : Window
    {
        public AcademyManagerDashboard()
        {
            InitializeComponent();
            // Load claims into FinalApprovalDataGrid
        }

        private void FinalApproval_Click(object sender, RoutedEventArgs e)
        {
            // Logic to show claims pending final approval
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
