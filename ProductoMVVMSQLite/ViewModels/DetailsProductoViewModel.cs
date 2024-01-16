using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class DetailsProductoViewModel
    {

        public Producto _productoTraido { get; set; }
        public DetailsProductoViewModel(Producto productoTraido)
        {
            _productoTraido = productoTraido;
        }
        public ICommand ClickBorrarProducto =>
        new Command(async () =>
        {
            if (_productoTraido != null)
            {
                App.productoRepository.Delete(_productoTraido);
                await App.Current.MainPage.Navigation.PopAsync();
            }
        });

        public ICommand ClickEditarProducto =>
        new Command(async () =>
        {

            await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage(_productoTraido));

        });
    }
}
