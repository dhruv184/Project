namespace ExpenseManager
{
    public partial class Page2 : ContentPage
    {
        List<Items> itemList = new List<Items>();

        double totalAllItemsPrice = 0;
        double groceryBudget ;

        public Page2()
        {

            InitializeComponent();
            groceryBudget = 0;
        }

        public Page2(double budget)
        {
            InitializeComponent();
            groceryBudget = budget;
        }

        private void ItemButton(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(priceEntry.Text, out double iPrice) && int.TryParse(quantityEntry.Text, out int iQuantity) && double.TryParse(discountEntry.Text, out double iDiscount))
                {
                    //DateTime selectedDate = datePicker.Date;

                    Items item = new Items(itemEntry.Text, iPrice, iQuantity, iDiscount, 0);
                    item.TotalPrice = item.CalculateTotalPrice();
                    itemList.Add(item);

                    totalAllItemsPrice += item.TotalPrice;

                    DisplayAlert("Success", "Item added successfully.", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Invalid Input. Please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle item button click errors
                Console.WriteLine($"Error during item button click: {ex.Message}");
            }
        }

        private void ClearButton(object sender, EventArgs e)
        {
            try
            {
                itemEntry.Text = priceEntry.Text = quantityEntry.Text = discountEntry.Text = string.Empty;
            }
            catch (Exception ex)
            {
                // Handle clear button click errors
                Console.WriteLine($"Error during clear button click: {ex.Message}");
            }
        }

        private void DisplayButton(object sender, EventArgs e)
        {
            try
            {
                if (itemList.Count > 0)
                {
                    Navigation.PushAsync(new Page3(itemList, totalAllItemsPrice, groceryBudget));
                }
                else
                {
                    DisplayAlert("Error", "No Item Added. Please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle display button click errors
                Console.WriteLine($"Error during display button click: {ex.Message}");
            }
        }
    }
}