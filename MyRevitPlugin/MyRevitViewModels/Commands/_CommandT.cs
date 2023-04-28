using CommunityToolkit.Mvvm.ComponentModel;

namespace MyRevitViewModels
{
    public abstract class _Command<T> : _Command
        where T : ObservableObject
    {
        protected T observable;
        public _Command(T observable)
        {
            this.observable = observable;
        }
    }
}
