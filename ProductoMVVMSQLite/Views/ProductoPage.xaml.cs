using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class ProductoPage : ContentPage
{
    private ProductoViewModel _viewModel;

    public ProductoPage()
	{
		InitializeComponent();
        _viewModel = new ProductoViewModel();
        BindingContext = _viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.ListaProductos.Clear();
        _viewModel.traerProductos();

    }
    private async void OnClickShowDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Producto producto)
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailsProducto(producto));
        }

    ((ListView)sender).SelectedItem = null; // Deselecciona el elemento después de la navegación
    }
}