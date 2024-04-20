// See https://aka.ms/new-console-template for more information


using System.Globalization;
using System.Reflection;
using System.Text;
using UltraVisionCentre;// тут центр ПЗ у вигляді бібліотеки

using UltraVisionModels; //тут наші моделі користувачів




class MainClass
{
    public static void Main(string[] args)
    {
        //підрубаємо милозвучну
        Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        //це тянемо з DLL
        SoftwareCenter softwarecenter = new SoftwareCenter("1234567890");
        //невелика компанія, три співробітника :)
        Programmer programmer = new("Іван", "ivan@gmail.com", "123456", "+380123456789", "Senior", softwarecenter);
        Cashier cashier = new("Петро", "petr1k@gmail.com", "111111", "+380987654321", "IBAN123456789", new Fiscal("ПриватБанк", null));
        Admin admin = new("Володимир", "volodya@gmail.com", "qwerty", "+38012121212", "Начальник відділу", new AccessControl("Менеджер або вище"));

        //імітація бази даних
        List<User> users = new List<User> { programmer, cashier, admin };

        User? user = null;
        while (user == null)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Вас вітає UltraVision! Будь ласка, увійдіть в систему або натисніть Enter для виходу.");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Введіть ім'я:");
            string name = Console.ReadLine().Trim();
            if (name == "")//Користувач натиснув Enter
            {
                Console.WriteLine("До побачення!");
                Environment.Exit(0); //ТОЧКА ВИХОДУ
            }
            Console.WriteLine("Введіть пароль:");
            string password = Console.ReadLine().Trim();
            //перевірка логіну і паролю
            user = users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user == null)//Неправильні дані
            {
                Console.WriteLine("неправильне ім'я або пароль, натисніть Enter щоб продовжити.");//Виведення помилки
                Console.ReadLine();//Користувач натиснув Enter
            }
        }
        //Результат успішний
        while (true)
        {
            //Отримання методів
            Type type = user.GetType();
            //Фільтрація методів
            List<MethodInfo> methods = type.GetMethods().Where(m => m.DeclaringType == type && !m.Name.Contains('_')).ToList();

            try{
                //Виведення списку методів
                Console.WriteLine("Виберіть метод:");
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(" " + method.Name);
                }
                //Очікування введення даних
                string methodName = Console.ReadLine();
                if(string.IsNullOrEmpty(methodName)){
                    //Закінчення сеансу (натиснуто Enter)
                    Console.WriteLine("До побачення!");
                    Environment.Exit(0);//ТОЧКА ВИХОДУ
                }
                // Отримання дескриптора метода
                MethodInfo methodInfo = type.GetMethod(methodName);
                // Виклик метода
                Console.ForegroundColor = ConsoleColor.Green;
                object? result = methodInfo.Invoke(user, null);
                if (result != null)
                {
                    // Виведення результату роботи
                    Console.WriteLine(result);
                }
                Console.ResetColor();
            }
            catch(Exception e){
                //Виведення помилки
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка:");
                Console.WriteLine(e.Message);
                Console.ResetColor();
                Console.WriteLine("Натисніть Enter щоб продовжити.");
                Console.ReadLine();
            }
        }

    }
}
