using BTGClient.Core.Models;
using BTGClient.Core.Repositories.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Windows.Media.Protection.PlayReady;

namespace BTGClient.ViewModels
{
    [QueryProperty(nameof(NewClient), "client")]
    public partial class ClientViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IClientRepository _clientRepository;

        [ObservableProperty]
        private Client _newClient;

        [ObservableProperty]
        private bool _deleteButtonVisible;

        public ClientViewModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        [RelayCommand]
        private async Task SaveNewClient()
        {
            try
            {
                if (NewClient.Name is null)
                    throw new Exception("Nome não preenchido.");
                else if (NewClient.LastName is null)
                    throw new Exception("Sobrenome não preenchido.");
                else if (NewClient.Age is null || NewClient.Age < 0)
                    throw new Exception("Idade não preenchida corretamente.");
                else if (NewClient.Address is null)
                    throw new Exception("Endereço não preenchido.");
                _clientRepository.Insert(NewClient);
                await Shell.Current.DisplayAlert("Aviso!", "Cliente salvo com sucesso!", "Ok");
                await Back();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Aviso!", $"{ex.Message}", "Ok");
            }
        }
        [RelayCommand]
        private async Task Back()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"update",  true}
            };
            await Shell.Current.GoToAsync("..", parameters: parameters);
        }

        [RelayCommand]
        private async Task DeleteClient()
        {
            try
            {
                var resp = await Shell.Current.DisplayAlert("Aviso!", "Deseja fazer o delete deste cliente?", "Sim", "Não");
                if (resp)
                {
                    _clientRepository.Delete(NewClient);
                    await Shell.Current.DisplayAlert("Aviso!", "Cliente deletado com sucesso!", "Ok");
                    await Back();
                }
            }
            catch (Exception)
            {

            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var value = query["client"];
            if (value is Client && (value as Client).Name is null)
                DeleteButtonVisible = false;
            else
                DeleteButtonVisible = true;

        }


        public bool IsNumeric(string text)
        {
            return double.TryParse(text, out _);
        }
    }
}
