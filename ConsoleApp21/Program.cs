using ConsoleApp21;

// var trainer = new Trainer(); 
// trainer.CreateTrainer();
var pokemon = new Pokemon("Charmander", 5, 2, 1, 1000);        // player pokemon
var opponent = new Pokemon("Wild Squirtle", 6, 1, 1, 1000);    // opponent pokemon

SelectPokemon();
void SelectPokemon() 
{
    Console.WriteLine("Which pokemon will you choose?");
    Console.WriteLine("Charmander(1), Squirtle(2) or Pikachu(3)");
    var input = Console.ReadLine();
    if (input == "1") { Console.WriteLine($"You chose {pokemon.Name}"); } 
    else if (input == "2") {
        pokemon.Name = "Squirtle"; pokemon.Health = 6; pokemon.Damage = 1;
        Console.WriteLine($"You chose {pokemon.Name}");
    }
    else if (input == "3")
    {
        pokemon.Name = "Pikachu"; pokemon.Health = 4; pokemon.Damage = 3;
        Console.WriteLine($"You chose {pokemon.Name}");
    }
    else if (input == "4") // for testing purposes
    {
        pokemon.Name = "Banana"; pokemon.Health = 99; pokemon.Damage = 99;
        Console.WriteLine($"You chose {pokemon.Name}. I don't remember this pokemon..?");
    }
    else
    {
        Console.WriteLine($"'{input}' is not a valid input. Enter a number 1,2 or 3");
    }
}
Menu();
 void Menu()
{
        Console.WriteLine("Where do you want to go next?");
        Console.WriteLine("Pokemon safari(1), Pokemon Center(2), Gym(3), PokeDex(4)");
        var input = Console.ReadLine();
        if (input == "1") { Console.WriteLine("You take a walk in the grass hoping to find some pokemon"); pokemon.PokemonSafari(pokemon, opponent); Menu(); }
        else if (input == "2") { Console.WriteLine("Your pokemon gets taken good care of and has its hitpoints replenished"); Menu(); }
        else if (input == "3") { AccessGym(); Menu(); }
        else if (input == "4") { pokemon.PokeDex(); Menu(); }
        else { Console.WriteLine($"'{input}' is not a valid input. Enter a number 1,2 or 3"); Menu(); }
}
void AccessGym()
{
    if (pokemon.Level > 9) { Console.WriteLine("Congratulations! You can now challenge this gym"); }
    else
    {
          Console.WriteLine("You need to be at least level 10 to challenge this gym."); 
          Console.WriteLine("Come back when you are stronger!"); 
          Console.ReadLine(); Menu();
    }
}

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("To be continued. Thanks for playing!");
Console.ReadLine( );