using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using personBeheerSysteem;
using System.Windows;

namespace persoonBeheerSysteem
{
    public partial class LoginWindow : Window
    {
        private readonly UserManager<IdentityUser> _userManager;

        public LoginWindow()
        {
            InitializeComponent();
            // Obtain the UserManager instance from the service provider
            _userManager = ((App)Application.Current).ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Fetch username and password from UI
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a valid username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Find user by username
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                MessageBox.Show("Invalid login attempt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if the password is correct
            var passwordCheck = await _userManager.CheckPasswordAsync(user, password);
            if (passwordCheck)
            {
                // Authentication successful
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close(); // Close the login window
            }
            else
            {
                MessageBox.Show("Invalid login attempt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}
