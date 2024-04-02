using System.Collections.ObjectModel;
using System.Data;

namespace ExpenseManager;

public partial class Page6 : ContentPage
{
    private ObservableCollection<string> historyList = new ObservableCollection<string>();

    public Page6()
	{
		InitializeComponent();
        historyListView.ItemsSource = historyList;
    }

    private void NumberButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            Button button = (Button)sender;
            inputEntry.Text += button.Text;
        }
        catch (Exception)
        {
            // Handle the exception appropriately, such as logging or displaying an error message
            inputEntry.Text = "Error";
        }
    }

    private void OperatorButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            Button button = (Button)sender;
            inputEntry.Text += button.Text;
        }
        catch (Exception)
        {
            inputEntry.Text = "Error";
        }
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            inputEntry.Text = "";
        }
        catch (Exception)
        {
            inputEntry.Text = "Error";
        }
    }

    private void EqualButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            string expression = inputEntry.Text;
            var result = new DataTable().Compute(expression, null);
            inputEntry.Text = result.ToString();
            AddToHistory(expression + " = " + result.ToString());
        }
        catch (Exception)
        {
            inputEntry.Text = "Error";
        }
    }

    private void BracketsButton_Clicked1(object sender, EventArgs e)
    {
        try
        {
            inputEntry.Text += "(";
        }
        catch (Exception)
        {
            inputEntry.Text = "Error";
        }
    }

    private void BracketsButton_Clicked2(object sender, EventArgs e)
    {
        try
        {
            inputEntry.Text += ")";
        }
        catch (Exception)
        {
            inputEntry.Text = "Error";
        }
    }

    private void DecimalButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            inputEntry.Text += ".";
        }
        catch (Exception)
        {
            inputEntry.Text = "Error";
        }
    }

    private void ClearHistory_Clicked(object sender, EventArgs e)
    {
        historyList.Clear();
    }

    private void AddToHistory(string expression)
    {
        historyList.Add(expression);
    }
}