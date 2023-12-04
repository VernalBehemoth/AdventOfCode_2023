bool keepRunning = true;
while (keepRunning)
{
    Console.WriteLine("Select the Day's Task to Run:");
    Console.WriteLine("1. Day 1");
    Console.WriteLine("2. Day 2");
    // ... More days
    Console.WriteLine("0. Exit");

    var selection = Console.ReadLine();
    IDayTask? task = selection switch
    {
        "1" => new Day1(),
        "2" => new Day2Logic(),
        // ... More cases
        _ => null,
    };

    if (task != null)
    {
        task.RunTask();
    }
    else if (selection == "0")
    {
        keepRunning = false;
    }
    else
    {
        Console.WriteLine("Invalid selection, please try again.");
    }

    if (keepRunning)
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }
}