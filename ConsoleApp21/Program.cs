using ConsoleApp21;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Xml.Linq;

// var trainer = new Trainer(); 
// trainer.CreateTrainer();
var activePokemon = new Pokemon("Charmander", 5, 2, 1, 1000);        // player pokemon
var opponentPokemon = new Pokemon("Wild Squirtle", 6, 1, 1, 1000);    // opponent pokemon
var pokemon = new List<String>();

SelectPokemon();
void SelectPokemon() 
{
    Console.WriteLine("Which pokemon will you choose?");
    Console.WriteLine("Charmander(1), Squirtle(2) or Pikachu(3)");
    var input = Console.ReadLine();
    if (input == "1") { Console.WriteLine($"You chose {activePokemon.Name}"); pokemon.Add("Charmander"); } 
    else if (input == "2") {
        activePokemon.Name = "Squirtle"; activePokemon.Health = 6; activePokemon.Damage = 1;
        Console.WriteLine($"You chose {activePokemon.Name}");
        pokemon.Add("Squirtle");
    }
    else if (input == "3")
    {
        activePokemon.Name = "Pikachu"; activePokemon.Health = 4; activePokemon.Damage = 3;
        Console.WriteLine($"You chose {activePokemon.Name}");
        pokemon.Add("Pikachu");
    }
    else if (input == "4") // for testing purposes
    {
        activePokemon.Name = "Banana"; activePokemon.Health = 99; activePokemon.Damage = 99;
        Console.WriteLine($"You chose {activePokemon.Name}. I don't remember this pokemon..?");
        pokemon.Add("Banana");
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
        if (input == "1") { Console.WriteLine("You take a walk in the grass hoping to find some pokemon"); activePokemon.PokemonSafari(activePokemon, opponentPokemon); Menu(); }
        else if (input == "2") { Console.WriteLine("Your pokemon gets taken good care of and has its hitpoints replenished"); Menu(); }
        else if (input == "3") { AccessGym(); }
        else if (input == "4") { PokeDex(); Menu(); }
        else { Console.WriteLine($"'{input}' is not a valid input. Enter a number 1,2 or 3"); Menu(); }
}
void AccessGym()
{
    if (activePokemon.Level > 9) { Console.WriteLine("Congratulations! You can now challenge this gym"); }
    else
    {
          Console.WriteLine("You need to be at least level 10 to challenge this gym."); 
          Console.WriteLine("Come back when you are stronger!"); 
          Console.ReadLine(); Menu();
    }
}
void PokeDex()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("PokeDex entries: " + pokemon.Count);
    for (int i = 0; i < pokemon.Count; i++) { Console.WriteLine(pokemon[i]); }
    Console.WriteLine($"Active pokemon: {activePokemon.Name}, Health: {activePokemon.Health}, Damage: {activePokemon.Damage}, Level {activePokemon.Level}");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine();
}
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("To be continued. Thanks for playing!");
Console.ReadLine( );