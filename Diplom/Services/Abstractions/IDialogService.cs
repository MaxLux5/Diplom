using System;

namespace Diplom.Services.Abstractions
{
    /// <summary>
    /// Сервис, отвечающий за диалоговые окошки.
    /// </summary>
    public interface IDialogService
    {
        void ShowAddProductDialog();
        void ShowOrderProductDialog();
    }
}
