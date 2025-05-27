using Diplom.Services.Abstractions;
using Diplom.View.Dialogs.ProductMenu;
using Diplom.ViewModel.Dialogs.ProductMenu;

namespace Diplom.Services
{
    public class DialogService : IDialogService
    {
        private static DialogService _instance;


        private DialogService() { }


        public static DialogService GetInstance()
        {
            return _instance ??= new DialogService();
        }

        public void ShowAddProductDialog()
        {
            var dialog = new AddProductDialog();
            dialog.DataContext = new AddProductDialogViewModel(dialog);
            dialog.OpenDialog();
        }
        public void ShowOrderProductDialog()
        {
            var dialog = new OrderProductDialog();
            dialog.DataContext = new OrderProductDialogViewModel(dialog);
            dialog.OpenDialog();
        }
    }
}