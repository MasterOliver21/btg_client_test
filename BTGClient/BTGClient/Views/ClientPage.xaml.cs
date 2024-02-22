using BTGClient.ViewModels;

namespace BTGClient.Views;

public partial class ClientPage : ContentPage
{
	public ClientPage()
	{
		InitializeComponent();
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            if (!(BindingContext as ClientViewModel).IsNumeric(e.NewTextValue)) ((Entry)sender).Text = e.OldTextValue;
        }
    }
}