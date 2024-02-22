using BTGClient.Core.Models;
using BTGClient.ViewModels;

namespace BTGClient.Views;

public partial class ClientListPage : ContentPage
{
	public ClientListPage()
	{
		InitializeComponent();
	}

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if(e != null)
			(BindingContext as ClientListViewModel).NavigationCommand.Execute((Client)e.SelectedItem);
    }
}