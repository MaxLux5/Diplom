using CommunityToolkit.Mvvm.Input;
using Diplom.DataBaseConnector;
using Diplom.Models;
using Diplom.Services.Abstractions;
using System.Collections.ObjectModel;

namespace Diplom.ViewModel.Components.PurchaseMenu
{
    public partial class PurchaseMenuComponentViewModel
    {
        private IDialogService _dialogService;


        public ObservableCollection<ProductModel> PurchasedProducts { get; private set; } = new ObservableCollection<ProductModel>();


        public PurchaseMenuComponentViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }


        [RelayCommand]
        private void LoadData()
        {
            var collection = DataBase.GetInstance().GetPurchasedProductsCollection();
            if (collection is null) return;

            PurchasedProducts.Clear();
            foreach (var item in collection)
            {
                PurchasedProducts.Add(item);
            }
        }
        [RelayCommand]
        private void OrderProduct()
        {
            _dialogService.ShowOrderProductDialog();
            LoadData();
        }
    }
}
