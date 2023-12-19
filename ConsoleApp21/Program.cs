using ConsoleApp21;

var trainer = new Trainer();
trainer.CreateTrainer();
var pokemon = new Pokemon("Charmander", 5, 2);        // player pokemon
var opponent = new Pokemon("Wild Squirtle", 6, 1);    // opponent pokemon

SelectPokemon();
void SelectPokemon()
{
    Console.WriteLine("Which starting pokemon will you choose?");
    Console.WriteLine("Charmander(1), Squirtle(2) or Banana(3)");
    var input = Console.ReadLine();
    if (input == "1") { Console.WriteLine($"You chose {pokemon.Name}"); } 
    else if (input == "2") {
        pokemon.Name = "Squirtle"; pokemon.Health = 6; pokemon.Damage = 1;
        Console.WriteLine($"You chose {pokemon.Name}");
    }
    else if (input == "3")
    {
        pokemon.Name = "Banana"; pokemon.Health = 3; pokemon.Damage = 4;
        Console.WriteLine($"You chose {pokemon.Name}");
    }
    else
    {
        Console.WriteLine($"'{input}' is not a valid input. Enter a number 1,2 or 3");
    }
}

Encounter();
 void Encounter()
{
    Console.WriteLine($"{opponent.Name} appeared.");
    Console.WriteLine($"Go {pokemon.Name}!");
    while (pokemon.Health > 0 && opponent.Health > 0)
    {
        Console.WriteLine("Scratch(1) Growl(2) Snooze(3)");
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                pokemon.Scratch(pokemon, opponent);
                Console.WriteLine($"{pokemon.Name} scratched {opponent.Name} for {pokemon.Damage} damage");
                Console.WriteLine($"{opponent.Name} has {opponent.Health} health remaining");
                Console.ReadLine();
                opponent.OpponentAction(opponent, pokemon);
                Console.ReadLine();
                break;
            case "2":
                pokemon.Growl(pokemon);
                Console.WriteLine($"{pokemon.Name} used growl. Its power grows..");
                Console.ReadLine();
                opponent.OpponentAction(opponent, pokemon);
                Console.ReadLine();
                break;
            case "3":
                pokemon.Snooze(pokemon);
                Console.WriteLine($"{pokemon.Name} went to sleep. It regained health");
                Console.ReadLine();
                opponent.OpponentAction(opponent, pokemon);
                Console.ReadLine();
                break;
            default:
                Console.WriteLine($"'{input}' is not a valid input. Enter a number 1,2 or 3");
                break;
        }
    }
    Console.WriteLine("The battle has concluded!");
    Console.WriteLine($"{pokemon.Name} has {pokemon.Health} health remaining while {opponent.Name} has {opponent.Health}");
}

Console.ReadLine();