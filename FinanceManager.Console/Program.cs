List<(int Id, DateTime Date, TransactionType Type, decimal Amount)> transactions = [];

enum TransactionType
{
    Deposit,
    Withdrawal
}