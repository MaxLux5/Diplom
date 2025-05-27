using System;

namespace Diplom.Services.Abstractions
{
    /// <summary>
    /// Диалоговое окошко.
    /// </summary>
    public interface IDialog
    {
        void OpenDialog();
        void CloseDialog();
    }
}
