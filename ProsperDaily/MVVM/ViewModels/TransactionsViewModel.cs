using ProsperDaily.MVVM.Models;

namespace ProsperDaily;

public class TransactionsViewModel
{
    public Transaction Transaction { get; set; } = new Transaction();

    public string SaveTransaction()
    {
        if (Transaction.Amount <= 0)
        {
            return "Amount must be greater than 0";
        }

        App.TransactionRepo.SaveItem(Transaction);

        return App.TransactionRepo.StatusMessage;
    }
}
