namespace PersonnageLoLApp.Models;

public class PersonnageLoL
{
    public int Id { get; set; }
    public string Nom { get; set; } = "";
    public string Role { get; set; } = "";
    public int PV { get; set; }
    public int Attaque { get; set; }
}