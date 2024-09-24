namespace FinancialVantage.Domain
{
    public class FinancialTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public ApplicationUser User {  get; set; }
        public string UserId { get; set; }
    }
}
