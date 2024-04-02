using System.Diagnostics;

namespace ExpenseManager;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void Login_Clicked(object sender, EventArgs e)
    {
        try
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (IsValidCredentials(username, password))
            {
                Navigation.PushAsync(new Page1());

                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password (minimum of 8 letters). Please try again.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected exceptions
            Debug.WriteLine($"An error occurred: {ex.Message}");
        }

        static bool IsValidCredentials(string username, string password)
        {
            return username != null && password.Length >= 8 && password != null;
        }
    }
}