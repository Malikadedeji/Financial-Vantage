namespace FinancialVantage.Domain
{
    public class FinancialTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public ApplicationUser User {  get; set; }

        //Foreign key for application user
        public string UserId { get; set; }
        public ApplicationUser AppUser { get; set; }

        public string FinancialInstrument { get; set; }


    }
}
