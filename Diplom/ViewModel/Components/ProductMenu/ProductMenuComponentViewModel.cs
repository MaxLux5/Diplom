using CommunityToolkit.Mvvm.Input;
using Diplom.DataBaseConnector;
using Diplom.Services.Abstractions;
using Diplom.Models;
using System.Collections.ObjectModel;

namespace Diplom.ViewModel.Components.ProductMenu
{
    /// <summary>
    /// ViewModel компонента меню товаров.
    /// </summary>
    public partial class ProductMenuComponentViewModel
    {
        private IDialogService _dialogService;


        public ObservableCollection<ProductModel> Products { get; private set; } = new ObservableCollection<ProductModel>();


        public ProductMenuComponentViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }


        [RelayCommand]
        private void LoadData()
        {
            var collection = DataBase.GetInstance().GetProductCollection();
            if (collection is null) return;

            Products.Clear();
            foreach (var item in collection)
            {
                Products.Add(item);
            }
        }
        [RelayCommand]
        private void AddProduct()
        {
            _dialogService.ShowAddProductDialog();
            LoadData();
        }
        [RelayCommand]
        private void DeleteProduct(ProductModel product)
        {
            if (!DataBase.GetInstance().DeleteProduct(product)) return;
            LoadData();
        }
    }
}
