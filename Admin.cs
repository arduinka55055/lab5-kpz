namespace UltraVisionModels;

public class Admin: User {
    public string AccessGroup { get; set; }
    public AccessControl accessControl { get; set; }

    public Admin(string name, string email, string password, string phone, string accessGroup, AccessControl accessControl) {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        AccessGroup = accessGroup;
        this.accessControl = accessControl;
    }

    public void CreateMovie() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} створив фільм!");
        accessControl.LogToAudit();
    }
    public void ListMovies() {
        Console.WriteLine($"Адміністратор {Name} переглянув список фільмів!");
    }
    public void EditMovie() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} відредагував фільм!");
        accessControl.LogToAudit();
    }
    public void DeleteMovie() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} видалив фільм!");
    }
    //
    public void CreateUser() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} створив користувача!");
        accessControl.LogToAudit();
    }
    public void ListUsers() {
        Console.WriteLine($"Адміністратор {Name} переглянув список користувачів!");
    }
    public void EditUser() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} відредагував користувача!");
        accessControl.LogToAudit();
    }
    public void DeleteUser() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} видалив користувача!");
        accessControl.LogToAudit();
    }
    //
    public void ViewBookings() {
        Console.WriteLine($"Адміністратор {Name} переглянув список бронювань!");
    }
    public void EditBooking() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} відредагував бронювання!");
        accessControl.LogToAudit();
    }
    public void DeleteBooking() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} видалив бронювання!");
        accessControl.LogToAudit();
    }
    //
    public void ViewAuditLog() {
        accessControl.GrantAccess();
        Console.WriteLine($"Адміністратор {Name} переглянув журнал аудиту!");
        accessControl.LogToAudit();
    }
}

public class AccessControl {
    public string AccessGroup { get; set; }

    public AccessControl(string accessGroup) {
        AccessGroup = accessGroup;
    }

    public void GrantAccess() {
        Console.WriteLine("Доступ надано!");
    }
    public void DenyAccess() {
        Console.WriteLine("Доступ заборонено!");
    }
    public void LogToAudit() {
        Console.WriteLine("Записано в журнал аудиту!");
    }
}
