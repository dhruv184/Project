using System;
namespace ExpenseManager
{
    public class Items
    {
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemDiscount { get; set; }
        //public DateTime SelectedDate { get; set; }
        public double TotalPrice { get; set; }

        public Items(string itemName, double itemPrice, int itemQuantity, double itemDiscount, double totalPrice)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemQuantity = itemQuantity;
            ItemDiscount = itemDiscount;
            //SelectedDate = selectedDate;
            TotalPrice = totalPrice;
        }
        public double CalculateTotalPrice()
        {
            double totalPrice = (ItemPrice * ItemQuantity * 1.13) - (ItemPrice * ItemQuantity * 1.13 * ItemDiscount / 100);
            return totalPrice;
        }
    }
}

