namespace ExpenseManager;

public partial class Page5 : ContentPage
{
    private List<BillEntry> billEntries;

    public Page5(List<BillEntry> billEntries)
    {
        InitializeComponent();

        this.billEntries = billEntries;
        listView.ItemsSource = billEntries;
        listView.ItemTapped += OnItemTapped;

        UpdateTotalPending(); // Calculate and display total pending amount initially
    }

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        try
        {
            if (e.Item is BillEntry billEntry)
            {
                bool paid = await DisplayAlert("Payment", "Have you paid the bill?", "Yes", "No");

                // Update text color based on payment status
                if (paid)
                {
                    billEntry.Paid = true;
                    billEntry.Status = "✔️"; // Change text to tick
                }
                else
                {
                    billEntry.Paid = false;
                    billEntry.Status = "Pending";
                }

                // Refresh ListView
                ((ListView)sender).SelectedItem = null; // Deselect item
                listView.ItemsSource = null;
                listView.ItemsSource = billEntries;

                UpdateTotalPending(); // Recalculate and display total pending amount
            }
        }
        catch (Exception ex)
        {
            // Handle item tap errors
            Console.WriteLine($"Error during item tap: {ex.Message}");
        }
    }

    private void UpdateTotalPending()
    {
        try
        {
            double totalPendingAmount = 0;
            foreach (var bill in billEntries)
            {
                if (!bill.Paid)
                {
                    totalPendingAmount += bill.BillAmount;
                }
            }
            totalPendingLabel.Text = $"Total Pending: {totalPendingAmount:C}";
        }
        catch (Exception ex)
        {
            // Handle update total pending errors
            Console.WriteLine($"Error during updating total pending: {ex.Message}");
        }
    }
}