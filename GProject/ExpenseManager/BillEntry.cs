using System;
namespace ExpenseManager
{
    public class BillEntry
    {
        public string BillType { get; set; }
        public double BillAmount { get; set; }
        //public DateTime DueDate { get; set; }
        public bool Paid { get; set; }
        public string Status { get; set; }

        public BillEntry() { }

        public BillEntry(string billType, double billAmount, bool paid, string status)
        {
            BillType = billType;
            BillAmount = billAmount;
            //DueDate = dueDate;
            Paid = paid;
            Status = status;
        }
    }
}

