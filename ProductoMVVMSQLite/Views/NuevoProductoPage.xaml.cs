using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class NuevoProductoPage : ContentPage
{
    private Producto _producto;
    private NuevoProductoViewModel _viewModel;

    public NuevoProductoPage(Producto ProductoSiExiste)
	{
        if (ProductoSiExiste == null)
        {
            InitializeComponent();
            _viewModel = new NuevoProductoViewModel();
            BindingContext = _viewModel;
        }
        else
        {
            InitializeComponent();
            _viewModel = new NuevoProductoViewModel(ProductoSiExiste);
            BindingContext = _viewModel;
        }
    }
}