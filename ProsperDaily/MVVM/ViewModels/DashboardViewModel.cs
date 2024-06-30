using ProsperDaily.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProsperDaily.MVVM.ViewModels;


public class DashboardViewModel
{
    public ObservableCollection<Transaction> Transactions { get; set; }

    public DashboardViewModel()
    {
        FillData();
    }

    private void FillData()
    {
        var transactions = App.TransactionsRepo.GetItems();
        transactions = transactions.OrderByDescending(x => x.OperationDate).ToList();
        Transactions = new ObservableCollection<Transaction>(transactions);
    }
}
