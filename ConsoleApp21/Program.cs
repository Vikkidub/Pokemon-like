using ConsoleApp21;

Encounter();
void Encounter()
{
    var charmander = new Pokemon("Charmander", 5, 2);
    var squirtle = new Pokemon("Squirtle", 6, 1);

    Console.WriteLine("Wild Squirtle appeared.");
    Console.WriteLine("Go Charmander!");
    while (charmander.Health > 0 && squirtle.Health > 0)
    {
        Console.WriteLine("Scratch(1) Growl(2) Snooze(3)");
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                charmander.Scratch(charmander, squirtle);
                Console.WriteLine($"Charmander scratched Squirtle for {charmander.Damage} damage");
                Console.WriteLine($"Squirtle has {squirtle.Health} health remaining");
                Console.ReadLine();
                squirtle.OpponentAction(squirtle, charmander);
                Console.ReadLine();
                break;
            case "2":
                charmander.Growl(charmander);
                Console.WriteLine($"Charmander used growl. Its power grows..");
                Console.ReadLine();
                squirtle.OpponentAction(squirtle, charmander);
                Console.ReadLine();
                break;
            case "3":
                charmander.Snooze(charmander);
                Console.WriteLine($"Charmander went to sleep. It regained health");
                Console.ReadLine();
                squirtle.OpponentAction(squirtle, charmander);
                Console.ReadLine();
                break;
            default:
                Console.WriteLine($"{input} is not a valid input. Enter a number 1,2 or 3");
                break;
        }
    }
    Console.WriteLine("The battle has concluded!");
    Console.WriteLine($"Charmander has {charmander.Health} health remaining, while Squirtle has {squirtle.Health}");
}

Console.ReadLine();