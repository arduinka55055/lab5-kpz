using System.IO.Compression;
using UltraVisionCentre;

namespace UltraVisionModels;

class Programmer : User
{
    public string Representative;
    public SoftwareCenter softwarecenter;

    public Programmer(string name, string email, string password, string phone, string representative, SoftwareCenter softwarecenter)
    {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        Representative = representative;
        this.softwarecenter = softwarecenter;
    }
    //
    public void GetDatabaseAccess()
    {
        Console.WriteLine($"Програміст {Name} отримав доступ до бази даних!");
    }
    public void CreateAdmin()
    {
        Console.WriteLine($"Програміст {Name} створив адміністратора!");
    }
    public void InstallUpdate()
    {
        softwarecenter.LicenseCode();
        softwarecenter.DownloadCode();
        Console.WriteLine($"Програміст {Name} встановив оновлення!");
    }
    public void ChangeInterface()
    {
        softwarecenter.LicenseCode();
        Console.WriteLine($"Програміст {Name} змінив інтерфейс!");
    }
}