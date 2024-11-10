using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using personBeheerSysteem;
using System.Windows;

namespace persoonBeheerSysteem
{
    public partial class RegistrationWindow : Window
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegistrationWindow()
        {
            InitializeComponent();
            // Obtain the UserManager instance from the service provider
            _userManager = ((App)Application.Current).ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Fetch user details from the UI
            var username = UsernameTextBox.Text;
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a valid username, email, and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new IdentityUser object
            var user = new IdentityUser { UserName = username, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            // Handle the registration result
            if (result.Succeeded)
            {
                MessageBox.Show("User registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close(); // Close the registration window
            }
            else
            {
                // Display the error messages
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                MessageBox.Show($"Registration failed: {errors}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
