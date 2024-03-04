namespace DynamicRepositoryPattern
{// this class need to be there in infrasturcture
    public class Transaction
    {
        public const string TransactionTable = "TransactionTable";
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Gender { get; set; }
    }
}
