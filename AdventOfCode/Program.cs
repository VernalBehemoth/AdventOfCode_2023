bool keepRunning = true;
while (keepRunning)
{
    Console.WriteLine("Select the Day's Task to Run:");
    Console.WriteLine("1. Day 1");
    Console.WriteLine("2. Day 2");
    // Add more days as you implement them
    Console.WriteLine("0. Exit");

    var selection = Console.ReadLine();

    switch (selection)
    {
        case "1":
            new Day1().RunTask();
            break;
        case "2":
            Console.WriteLine("Soon");
            break;
        // Add more cases as needed
        case "0":
            keepRunning = false;
            break;
        default:
            Console.WriteLine("Invalid selection, please try again.");
            break;
    }

    if (keepRunning)
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }
}