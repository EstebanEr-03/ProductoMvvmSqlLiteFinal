using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class ProductoViewModel : ObservableObject
    {
        public ObservableCollection<Producto> ListaProductos { get; set; }
        public Producto selectedProduct { get; set; }
        public Producto productoNull = null;

        public ProductoViewModel() 
        {
            ListaProductos=new ObservableCollection<Producto>();
        }

        [RelayCommand]

        public async void traerProductos()
        {
            var ListaProducts = App.productoRepository.GetAll();
            foreach (var producto in ListaProducts)
            {
                ListaProductos.Add(producto);

            }
        }

        public ICommand CrearProducto =>
            new Command(async () =>
            {
               await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage(productoNull));
            });

    }
}
