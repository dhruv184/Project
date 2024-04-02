namespace ExpenseManager;

public partial class Page3 : ContentPage
{
    List<Items> itemList;
    double groceryBudget;

    public Page3(List<Items> itemList, double totalAllItemsPrice, double budget)
	{
		InitializeComponent();

        this.itemList = itemList;
        groceryBudget = budget;
        PopulateListView();
        BindingContext = new Page3ViewModel(totalAllItemsPrice);
        CheckBudget();
    }

    private void PopulateListView()
    {
        try
        {
            listView.ItemsSource = itemList;
        }
        catch (Exception ex)
        {
            // Handle populating list view errors
            Console.WriteLine($"Error during populating list view: {ex.Message}");
        }
    }

    private async void CheckBudget()
    {
        try
        {
            Page3ViewModel viewModel = (Page3ViewModel)BindingContext;
            if (viewModel.TotalAllItemsPrice > groceryBudget)
            {
                var result = await DisplayAlert("Alert", $"Total items price exceeds the budget for grocery by ${viewModel.TotalAllItemsPrice - groceryBudget}. Do you want to clear the list?", "Yes", "No");
                if (result)
                {
                    itemList.Clear();
                    PopulateListView();
                    listView.ItemsSource = null;
                    BindingContext = new Page3ViewModel(0);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle checking budget errors
            Console.WriteLine($"Error during checking budget: {ex.Message}");
        }
    }
     
    public class Page3ViewModel
    {
        public double TotalAllItemsPrice { get; set; }

        public Page3ViewModel(double totalAllItemsPrice)
        {
            TotalAllItemsPrice = totalAllItemsPrice;
        }
    }
}
