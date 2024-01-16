using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class DetailsProducto : ContentPage
{
    private DetailsProductoViewModel _viewModel;
    private Producto _productoTraido;

    public DetailsProducto(Producto producto)
	{
		InitializeComponent();
        _productoTraido = producto;
        _viewModel = new DetailsProductoViewModel(producto);
        BindingContext = _viewModel;
    }
}