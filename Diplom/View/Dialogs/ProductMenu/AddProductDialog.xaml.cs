using Diplom.Services.Abstractions;
using System.Windows;

namespace Diplom.View.Dialogs.ProductMenu
{
    /// <summary>
    /// Диалоговое окно для добавления товара.
    /// </summary>
    public partial class AddProductDialog : Window, IDialog
    {
        public AddProductDialog()
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
