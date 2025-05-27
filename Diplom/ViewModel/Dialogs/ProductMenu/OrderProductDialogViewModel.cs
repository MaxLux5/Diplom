using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using Diplom.DataBaseConnector;
using Diplom.Services.Abstractions;
using Diplom.Models;

namespace Diplom.ViewModel.Dialogs.ProductMenu
{
    /// <summary>
    /// ViewModel диалогового окна, которое используется для заказа товара.
    /// </summary>
    public partial class OrderProductDialogViewModel : ObservableObject
    {
        [ObservableProperty]
        private ProductModel _selectedProduct;
        [ObservableProperty]
        private int _value;
        [ObservableProperty]
        private int _minValue;

        private IDialog _dialog;


        public ObservableCollection<ProductModel> Products { get; private set; } = new ObservableCollection<ProductModel>();


        public OrderProductDialogViewModel(IDialog dialog)
        {
            _dialog = dialog;

            MinValue = 1000;
            Value = MinValue;
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
        private void OrderProduct()
        {
            if(SelectedProduct is null)
            {
                MessageBox.Show("Не выбран материал.", "Ошибка заказа!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            //if (!DataBase.GetInstance().ChangeMaterialStockQuantity(SelectedMaterial, Value)) return;
            if (!DataBase.GetInstance().ChangeProduct(SelectedProduct, Value)) return;

            _dialog.CloseDialog();
        }
    }
}
