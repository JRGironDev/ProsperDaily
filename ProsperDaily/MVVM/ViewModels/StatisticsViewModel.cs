using System.Collections.ObjectModel;
using PropertyChanged;
using ProsperDaily.MVVM.Models;

namespace ProsperDaily.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class StatisticsViewModel
{
    public ObservableCollection<TransactionsSummary> Summary { get; set; }

    public ObservableCollection<Transaction> SpendingList { get; set; }

    public void GetTransactionsSummary()
    {
        var data = App.TransactionsRepo.GetItems();
        var result = new List<TransactionsSummary>();
        var groupedTransctions = data.GroupBy(t => t.OperationDate).ToList();

        foreach (var group in groupedTransctions)
        {
            var transactionSummary = new TransactionsSummary
            {
                TransactionsDate = group.Key,
                TransactionsTotal = group.Sum(x => x.IsIncome ? x.Amount : -x.Amount),
                ShownDate = group.Key.ToString("dd/MM/yyyy")
            };

            result.Add(transactionSummary);
        }

        result = result.OrderBy(x => x.TransactionsDate).ToList();

        Summary = new ObservableCollection<TransactionsSummary>(result);

        var spendingList = data.Where(x => x.IsIncome == false).ToList();

        SpendingList = new ObservableCollection<Transaction>(spendingList);
    }

}
