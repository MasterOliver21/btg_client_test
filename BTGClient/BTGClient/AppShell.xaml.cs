using BTGClient.Utils.Interfaces;
using BTGClient.Views;

namespace BTGClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("clientListPage", typeof(ClientListPage));
            Routing.RegisterRoute("clientListPage/clientPage", typeof(ClientPage));

        }
    }
}
