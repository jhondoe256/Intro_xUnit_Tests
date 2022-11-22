using static System.Console;
public class ProgramUI
{
    private readonly UserRepository _customerRepo = new UserRepository();
    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        while (true)
        {
            Clear();
            WriteLine("=================\n" +
                "1. Add Customer\n" +
                "2. CloseApp\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    WriteLine("Thanks, Press any key");
                    ReadKey();
                    break;
                default:
                    WriteLine("Invalid Selection, Press any key.");
                    ReadKey();
                    break;
            }
        }
    }

    private void AddCustomer()
    {
        Clear();
        var customer = new UserProfile();
        try
        {
            WriteLine("Please enter the Customer Name.");
            customer.Name = ReadLine();
            WriteLine("Please enter the Customer Age.");
            customer.Age = int.Parse(ReadLine());
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
            customer = null;
        }

        if (_customerRepo.AddUser(customer))
        {
            System.Console.WriteLine("Success");
        }
        else
        {
            System.Console.WriteLine("Fail");
        }
        ReadKey();
    }


}
