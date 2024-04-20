namespace UltraVisionModels;

public class Cashier: User {
    public string FiscalCode { get; set; }
    public Fiscal Fiscal { get; set; }

    public Cashier(string name, string email, string password, string phone, string fiscalCode, Fiscal fiscal) {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
        FiscalCode = fiscalCode;
        Fiscal = fiscal;
    }

    public void SellTicket() {
        Console.WriteLine($"Касир {Name} продав білет!");
        Fiscal.SendDataToTaxOffice();
    }
    public void CancelTicket() {
        Console.WriteLine($"Касир {Name} скасував білет!");
        Fiscal.SendDataToTaxOffice();
    }
    public void PrintTicket() {
        Console.WriteLine($"Касир {Name} надрукував білет!");
    }
    public void BookTicket() {
        Console.WriteLine($"Касир {Name} забронював білет!");
    }
    public void CancelBooking() {
        Console.WriteLine($"Касир {Name} скасував бронювання білету!");
    }
    public void EditBooking() {
        Console.WriteLine($"Касир {Name} відредагував бронювання білету!");
    }
}

public class Fiscal{
    public string IBAN { get; set; }
    private AppDomain ProtectedDomain { get; set; }

    public Fiscal(string iban, AppDomain protectedDomain) {
        IBAN = iban;
        ProtectedDomain = protectedDomain;
    }

    public void SendDataToTaxOffice() {
        Console.WriteLine("Дані було відправлено в податкову!");
    }
}