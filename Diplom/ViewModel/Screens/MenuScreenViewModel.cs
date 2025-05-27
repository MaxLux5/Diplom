using CommunityToolkit.Mvvm.ComponentModel;
using Diplom.Services.Abstractions;
using Diplom.ViewModel.Components.ProductMenu;
using Diplom.ViewModel.Components.PurchaseMenu;

namespace Diplom.ViewModel.Screens
{
    /// <summary>
    /// ViewModel скрина меню.
    /// </summary>
    public partial class MenuScreenViewModel : ObservableObject
    {
        [ObservableProperty]
        private PurchaseMenuComponentViewModel _purchaseMenuViewModel;
        [ObservableProperty]
        private ProductMenuComponentViewModel _productMenuViewModel;


        public MenuScreenViewModel(IDialogService dialogService)
        {
            PurchaseMenuViewModel = new PurchaseMenuComponentViewModel(dialogService);
            ProductMenuViewModel = new ProductMenuComponentViewModel(dialogService);
        }
    }
}