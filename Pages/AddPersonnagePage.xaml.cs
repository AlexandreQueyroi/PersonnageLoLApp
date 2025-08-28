using PersonnageLoLApp.Models;
using PersonnageLoLApp.Services;

namespace PersonnageLoLApp.Pages;

public partial class AddPersonnagePage : ContentPage
{
    private readonly ApiService _api = new();

    public AddPersonnagePage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var personnage = new PersonnageLoL
        {
            Nom = NomEntry.Text,
            Role = RoleEntry.Text,
            PV = int.TryParse(PvEntry.Text, out var pv) ? pv : 0,
            Attaque = int.TryParse(AttaqueEntry.Text, out var atk) ? atk : 0
        };

        await _api.CreatePersonnageAsync(personnage);

        await DisplayAlert("Succès", "Personnage ajouté avec succès !", "OK");

        await Navigation.PopModalAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}