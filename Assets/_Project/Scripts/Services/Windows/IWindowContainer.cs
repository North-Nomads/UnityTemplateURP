using _Project.MVVM;
using _Project.UI.Views;

namespace _Project.UI.Services.Windows
{
    public interface IWindowContainer
    {
        TView Open<TView>() where TView : View;
        void Close<TView>() where TView : View;
    }
}