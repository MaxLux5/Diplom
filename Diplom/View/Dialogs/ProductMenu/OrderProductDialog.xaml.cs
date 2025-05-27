using Diplom.Services.Abstractions;
using System.Windows;

namespace Diplom.View.Dialogs.ProductMenu
{
    /// <summary>
    /// ViewModel диалогового окна, которое используется для заказа товара.
    /// </summary>
    public partial class OrderProductDialog : Window, IDialog
    {
        public OrderProductDialog()
        {
            InitializeComponent();
        }

        public void CloseDialog()
        {
            Close();
        }
        public void OpenDialog()
        {
            ShowDialog();
        }
    }
}
