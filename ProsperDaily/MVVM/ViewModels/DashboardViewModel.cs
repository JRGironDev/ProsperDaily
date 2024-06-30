namespace ProsperDaily.MVVM.ViewModels;

public class DashboardViewModel
{
    public ObservableCollection<Transaction> Transactions { get; set; }

    public DashboardViewModel()
    {
        Transactions = new ObservableCollection<Transaction>(App.TransactionRepo.GetItems());
    }
}
