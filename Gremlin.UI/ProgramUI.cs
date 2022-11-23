using static System.Console;
public class ProgramUI
{
    private readonly GremlinRepository _gRepo = new GremlinRepository();
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
                "1. Add Gremlin\n" +
                "2. View Next Gremlin\n" +
                "3. View All Gremlins\n" +
                "4. Process Gremlin\n" +
                "0. CloseApp\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    AddGremlin();
                    break;
                case "2":
                    ViewNextGremlin();
                    break;
                case "3":
                    ViewAllGremlins();
                    break;
                case "4":
                    ProcessGremlin();
                    break;
                case "0":
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

    private void ProcessGremlin()
    {
        Console.Clear();
        Console.WriteLine("Do you want to process this gremlin? y/n");
        ShowGremlinData();

        var userInput = Console.ReadLine();
        if (userInput == "Y".ToLower())
        {
            _gRepo.ProcessGremlin();
        }
        else
        {
            System.Console.WriteLine("Returning to Main Menu.");
        }

        Console.ReadKey();
    }

    private void ViewAllGremlins()
    {
        Console.Clear();
        foreach (GremlinEntity gremlin in _gRepo.GetGremlins())
        {
            System.Console.WriteLine(gremlin);
        }

        Console.ReadKey();
    }

    private void ViewNextGremlin()
    {
        Console.Clear();
        ShowGremlinData();
        Console.ReadKey();
    }
    private void ShowGremlinData()
    {
        System.Console.WriteLine(_gRepo.GetGremlin());
    }


    private void AddGremlin()
    {
        Console.Clear();

        GremlinEntity gremlin = new GremlinEntity();

        Console.WriteLine("Gremlin Name:");
        gremlin.Name = Console.ReadLine();

        if (_gRepo.AddGremlinToDatabase(gremlin))
        {
            Console.Write("Success!");
        }
        else
        {
            Console.Write("Fail!");
        }

        Console.ReadKey();
    }
}
