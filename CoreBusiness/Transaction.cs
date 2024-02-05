namespace CoreBusiness // Namespace declaration
{
    // Class representing a transaction
    public class Transaction
    {
        // Property to store the transaction ID
        public int TransactionId { get; set; }

        // Property to store the timestamp of the transaction
        public DateTime TimeStamp { get; set; }

        // Property to store the ID of the product involved in the transaction
        public int ProductId { get; set; }

        // Property to store the name of the product involved in the transaction, with an empty string as default value
        public string ProductName { get; set; } = ""; // in case product name changes

        // Property to store the price of the product involved in the transaction
        public double Price { get; set; }

        // Property to store the quantity of the product before the transaction
        public int BeforeQty { get; set; }

        // Property to store the quantity of the product sold in the transaction
        public int SoldQty { get; set; }

        // Property to store the name of the cashier involved in the transaction, with an empty string as default value
        public string CashierName { get; set; } = "";
    }
}
