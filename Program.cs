// See https://aka.ms/new-console-template for more information


using System.Reflection;
using UltraVisionCentre;


abstract class User
{
   public string Name { get; set; }
   public string Email { get; set; }
   public string Password { get; set; }
   public string Phone { get; set; }
}

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

class MainClass
{
   public static void Main(string[] args)
   {
      SoftwareCenter softwarecenter = new SoftwareCenter("1234567890");

      Programmer programmer = new("Іван", "ivan@gmail.com", "123456", "+380123456789", "Senior", softwarecenter);
      //REPL that allows to choose method and call it (use System.Reflection)

      Type type = programmer.GetType();
      //filter methods 
      List<MethodInfo> methods = type.GetMethods().Where(m => m.DeclaringType == type).ToList();

      Console.WriteLine("Виберіть метод:");
      foreach (MethodInfo method in methods)
      {
         Console.WriteLine(method.Name);
      }
      string methodName = Console.ReadLine();
      MethodInfo methodInfo = type.GetMethod(methodName);
      methodInfo.Invoke(programmer, null);

      Console.WriteLine("Кінець програми!");
   }
}
