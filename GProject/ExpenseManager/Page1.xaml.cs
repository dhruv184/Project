namespace ExpenseManager;

public partial class Page1 : ContentPage
{
    List<BudgetItem> Budget = new List<BudgetItem>();

    public Page1()
	{
		InitializeComponent();

        categoryPicker_SelectedIndexChanged(null, EventArgs.Empty);
    }

    private void Goto_Clicked(object sender, EventArgs e)
    {
        try
        {
            string selectedCategory = (string)categoryPicker.SelectedItem;

            if (string.IsNullOrEmpty(selectedCategory))
            {
                DisplayAlert("Error", "Please select a category.", "OK");
                return;
            }

            if (selectedCategory == "Grocery")
            {
                double budget = 0;

                if (!double.TryParse(budgetTextBox.Text, out budget) || budget <= 0)
                {
                    DisplayAlert("Error", "Please enter a valid budget amount.", "OK");
                    return;
                }

                Budget.Add(new BudgetItem(selectedCategory, budget));
            }

            switch (selectedCategory)
            {
                case "Grocery":
                    double amount = Budget.Find(item => item.Category == "Grocery").Amount;
                    Navigation.PushAsync(new Page2(amount));
                    break;
                case "Bill Payments":
                    Navigation.PushAsync(new Page4());
                    break;
                case "Calculator":
                    Navigation.PushAsync(new Page6());
                    break;
            }
        }
        catch (Exception ex)
        {
            // Handle submit button click errors
            Console.WriteLine($"Error during submit button click: {ex.Message}");
        }
    }

    private void categoryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (categoryPicker.SelectedItem == null)
            {
                budgetTextBox.IsVisible = false;
                return;
            }

            string selectedCategory = (string)categoryPicker.SelectedItem;

            // Check if the selected category is "Grocery"
            if (selectedCategory == "Grocery")
            {
                // If "Grocery" is selected, make the budget entry visible
                budgetTextBox.IsVisible = true;
            }
            else
            {
                // If any other category is selected, hide the budget entry
                budgetTextBox.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            // Handle category picker selection change errors
            Console.WriteLine($"Error during category picker selection change: {ex.Message}");
        }
    }

    public class BudgetItem
    {
        public string Category { get; set; }
        public double Amount { get; set; }

        public BudgetItem(string category, double amount)
        {
            Category = category;
            Amount = amount;
        }
    }
}
