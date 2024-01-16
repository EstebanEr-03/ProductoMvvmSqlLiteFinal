using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
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
    public class NuevoProductoViewModel
    {
        public Producto _producto { get; set; }//solo para crear
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        public ObservableCollection<Producto> Products { get; set; }

        public NuevoProductoViewModel()
        {

        }
        public NuevoProductoViewModel(Producto productoLLevo)
        {
            _producto = productoLLevo;
            Nombre = productoLLevo.Nombre;
            Cantidad = productoLLevo.Cantidad.ToString();
            Descripcion = productoLLevo.Descripcion;
        }
        public ICommand GuardarProducto =>
        new Command(async () =>
        {
            if(_producto == null)
            {
                Producto productoCreado = new Producto
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Cantidad = Int32.Parse(Cantidad)
                };
                App.productoRepository.Add(productoCreado);
                Util.ListaProductos = App.productoRepository.GetAll();
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                _producto.Nombre = Nombre;
                _producto.Cantidad = Int32.Parse(Cantidad);
                _producto.Descripcion = Descripcion;
                App.productoRepository.Update(_producto);
                Util.ListaProductos = App.productoRepository.GetAll();
                await App.Current.MainPage.Navigation.PopAsync();
            }

        });
    }
}
