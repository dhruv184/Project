namespace ExpenseManager;

public partial class Page4 : ContentPage
{
    private List<BillEntry> billEntries = new List<BillEntry>();

    public Page4()
	{
		InitializeComponent();
	}

    private void SubmitButton(object sender, EventArgs e)
    {
        try
        {
            if (billEntries.Count == 0)
            {
                DisplayAlert("Error", "Please add at least one bill entry.", "OK");
                return;
            }

            Navigation.PushAsync(new Page5(billEntries));
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur during submission
            Console.WriteLine($"Error during submission: {ex.Message}");
        }
    }

    private void AddBillButtonClicked(object sender, EventArgs e)
    {
        try
        {
            if (pickerBillType.SelectedItem == null &&
                string.IsNullOrWhiteSpace(entryBillType.Text))
            {
                DisplayAlert("Error", "Please enter both Bill Type and Amount.", "OK");
                return; // Exit the method if either BillType or BillAmount is null
            }
            else if (string.IsNullOrWhiteSpace(txtBillAmount.Text))
            {
                DisplayAlert("Error", "Please enter both Bill Type and Amount.", "OK");
                return; // Exit the method if either BillType or BillAmount is null
            }

            AddBillToList();
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur during adding a bill
            Console.WriteLine($"Error adding bill: {ex.Message}");
        }
    }

    private void switchEntryOrSelect_Toggled(object sender, ToggledEventArgs e)
    {
        try
        {
            if (switchEntryOrSelect.IsToggled)
            {
                entryBillType.IsVisible = true;
                pickerBillType.IsVisible = false;
            }
            else
            {
                entryBillType.IsVisible = false;
                pickerBillType.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur during toggling
            Console.WriteLine($"Error during toggling: {ex.Message}");
        }
    }

    private void AddBillToList()
    {
        try
        {
            BillEntry billEntry = new BillEntry
            {
                BillType = switchEntryOrSelect.IsToggled ? entryBillType.Text : pickerBillType.SelectedItem.ToString(),
                BillAmount = double.Parse(txtBillAmount.Text),
                //DueDate = dpDueDate.Date,
                Paid = false, // Assuming all newly added bills are unpaid
                Status = "Pending" // Assuming all newly added bills have a status of pending
            };

            billEntries.Add(billEntry);

            DisplayAlert("Success", "Bill added successfully.", "OK");

            ClearEntries();
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur during adding a bill to the list
            Console.WriteLine($"Error adding bill to list: {ex.Message}");
        }
    }

    private void ClearEntries()
    {
        try
        {
            entryBillType.Text = string.Empty;
            txtBillAmount.Text = string.Empty;
            //dpDueDate.Date = DateTime.Today;
            pickerBillType.SelectedItem = null;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur during clearing entries
            Console.WriteLine($"Error clearing entries: {ex.Message}");
        }
    }
}
