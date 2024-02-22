using BTGClient.Core.Models;
using BTGClient.Core.Repositories.Interfaces;
using BTGClient.Utils.Interfaces;
using BTGClient.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BTGClient.ViewModels
{
    [QueryProperty(nameof(_update), "update")]
    public partial class ClientListViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddresRepository _addresRepository;

        private ObservableCollection<Client> _clients;
        private bool _update;

        [ObservableProperty]
        private bool _labelIsVisible;
        [ObservableProperty]
        private bool _listVisible;
        public ClientListViewModel(IClientRepository clientRepository, IAddresRepository addresRepository)
        {
            _clientRepository = clientRepository;
            _addresRepository = addresRepository;
            Clients = new ObservableCollection<Client>(_clientRepository.GetAll());
            LabelIsVisible = !Clients.Any();
            ListVisible = !LabelIsVisible;
        }

        #region Properties
        public ObservableCollection<Client> Clients { get => _clients; set { _clients = value; OnPropertyChanged(nameof(Clients)) ; } }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Clients = new ObservableCollection<Client>(_clientRepository.GetAll());
            LabelIsVisible = !Clients.Any();
            ListVisible = !LabelIsVisible;
        }
        #endregion

        #region Methods
        [RelayCommand]
        async Task Navigation(Client? client = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"client",  client ?? new Client()}
            };
            await Shell.Current.GoToAsync($"clientPage", parameters: parameters);
        }
        #endregion
    }
}
