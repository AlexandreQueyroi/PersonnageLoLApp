using System.Windows.Input;
using PersonnageLoLApp.Services;
using PersonnageLoLApp.Pages;
namespace PersonnageLoLApp;

public partial class MainPage : ContentPage
{
    private readonly ApiService _api = new();

    public ICommand DeleteCommand { get; }

    public MainPage()
    {
        InitializeComponent();

        DeleteCommand = new Command<int>(async (id) => await DeletePersonnage(id));
        BindingContext = this;
    }

    private async Task DeletePersonnage(int id)
    {
        bool confirm = await DisplayAlert("Confirmer", "Supprimer ce personnage ?", "Oui", "Non");
        if (!confirm) return;

        await _api.DeletePersonnageAsync(id);
        var personnages = await _api.GetPersonnagesAsync();
        PersonnagesList.ItemsSource = personnages;
    }
    

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddPersonnagePage());
    }
    
    private async void OnLoadClicked(object sender, EventArgs e)
    {
        var personnages = await _api.GetPersonnagesAsync();
        PersonnagesList.ItemsSource = personnages;
    }
}