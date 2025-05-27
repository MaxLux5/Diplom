using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Diplom.Models
{
    /// <summary>
    /// Модель, представляющая собой товар.
    /// </summary>
    public partial class ProductModel : ObservableObject
    {
        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _type;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private int _stockQuantity;
        [ObservableProperty]
        private int _purchasePrice;
        [ObservableProperty]
        private int _salePrice;
        [ObservableProperty]
        private string _manufacturer;

        public ProductModel(int id, string type, string name, int stockQuantity,
            int purchasePrice, int salePrice, string manufacturer)
        {
            _id = id;
            _type = type;
            _name = name;
            _stockQuantity = stockQuantity;
            _purchasePrice = purchasePrice;
            _salePrice = salePrice;
            _manufacturer = manufacturer;
        }
    }
}