using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Diplom.DataBaseConnector;
using Diplom.Models;
using Diplom.Services.Abstractions;
using System.Windows;

namespace Diplom.ViewModel.Dialogs.ProductMenu
{
    /// <summary>
    /// ViewModel диалогового окна, которое используется для добавления товара.
    /// </summary>
    public partial class AddProductDialogViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _typeText;
        [ObservableProperty]
        private string _nameText;
        [ObservableProperty]
        private int? _stockQuantityValue;
        [ObservableProperty]
        private int? _purchasePriceValue;
        [ObservableProperty]
        private int? _salePriceValue;
        [ObservableProperty]
        private string _manufacturerText;

        private IDialog _dialog;


        public AddProductDialogViewModel(IDialog dialog)
        {
            _dialog = dialog;
        }


        [RelayCommand]
        private void AddProduct()
        {
            if (TypeText == string.Empty || StockQuantityValue is null ||
                NameText == string.Empty || PurchasePriceValue is null ||
                ManufacturerText == string.Empty || SalePriceValue is null)
            {
                MessageBox.Show("Есть незаполненные поля.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Id устанавливает база данных, потому здесь вводится значение -1.
            var product = new ProductModel(-1, TypeText, NameText, (int)StockQuantityValue,
                (int)PurchasePriceValue, (int)SalePriceValue, ManufacturerText);
            if (!DataBase.GetInstance().AddNewProduct(product)) return;

            _dialog.CloseDialog();
        }
    }
}
