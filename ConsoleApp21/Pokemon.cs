using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Pokemon(string name, int health, int damage, int level, int experience)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Level = level;
            Experience = experience;
        }
        public void Scratch(Pokemon actor, Pokemon receiver)
        {
            receiver.Health -= actor.Damage;
        }
       public void Growl(Pokemon actor)
        {
            actor.Damage ++;
        }
       public void Snooze(Pokemon actor)
        {
            actor.Health += 5;
        }
        public void OpponentAction(Pokemon actor, Pokemon receiver)
        {
            var rand = new System.Random();
            var randomNumber = rand.Next(1, 4);
            if (randomNumber == 1) {
                Scratch(actor,receiver);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{actor.Name} scratched {receiver.Name} for {actor.Damage} damage");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{receiver.Name} has {receiver.Health} health left");
            }
            else if (randomNumber == 2){
                Growl(actor);
                Console.WriteLine($"{actor.Name} used growl. Its power grows..");
            }
            else if (randomNumber == 3)
            {
                Snooze(actor);
                Console.WriteLine($"{actor.Name} went to sleep. It regained health");
            }
            else { Console.WriteLine("OpponentAction 'if' statement issue"); }
        }
        public void LevelUp(Pokemon winner)
        {
            List<int> levelThresholds = new List<int> { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

            int highestThreshold = 0;

            foreach (int threshold in levelThresholds)
            {
                if (winner.Experience >= threshold)
                {
                    highestThreshold = threshold;
                }
                else
                {
                    break;
                }
            }

            if (highestThreshold > 0 && highestThreshold > winner.Level * 1000) 
            {
                int levelsGained = (highestThreshold / 1000) - winner.Level;
                winner.Level += levelsGained;
                Console.WriteLine($"{winner.Name} has leveled up {levelsGained} times! They are now level {winner.Level}");
            }
        }
       public void PokemonSafari(Pokemon pokemon, Pokemon opponent)
        {
            var rand = new Random();
            var randomNumber = rand.Next(1, 5);
            if (randomNumber == 1) { opponent.Name = "Wild Charmander"; opponent.Health = 5; opponent.Damage = 2; opponent.Experience = 1000; }
            else if (randomNumber == 2) { opponent.Name = "Wild Squirtle"; opponent.Health = 6; opponent.Damage = 1; opponent.Experience = 1000; }
            else if (randomNumber == 3) { opponent.Name = "Wild Pikachu"; opponent.Health = 4; opponent.Damage = 3; opponent.Experience = 1000; }
            else if (randomNumber == 4) { opponent.Name = "Wild Banana"; opponent.Health = 3; opponent.Damage = 4; opponent.Experience = 3000; }
            else { Console.WriteLine("SelectOpponent error"); }
            Encounter(pokemon, opponent);
        }
        public void Encounter(Pokemon pokemon, Pokemon opponent)
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
            BattleSummary(pokemon, opponent);
        }
         void BattleSummary(Pokemon pokemon, Pokemon opponent)
        {
          //  int battleExperience = 1000;
            Console.WriteLine("The battle has concluded!");
            Console.WriteLine($"{pokemon.Name} has {pokemon.Health} health remaining while {opponent.Name} has {opponent.Health}");
            Console.WriteLine();
            if (pokemon.Health > opponent.Health)
            {
                Console.WriteLine("You have won the battle");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{pokemon.Name} gained {opponent.Experience} XP!");
                pokemon.Experience += opponent.Experience;
                LevelUp(pokemon);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else { Console.WriteLine("You have lost the battle. Resting up at local pokemon center.."); }
            PokemonCenter(pokemon);
            Console.ReadLine();
        }
        public void PokemonCenter(Pokemon pokemon)
        {
            switch (pokemon.Name)
            {
                case "Charmander": pokemon.Health = 5; pokemon.Damage = 2;
                    break;
                case "Squirtle": pokemon.Health = 6; pokemon.Damage = 1;
                    break;
                case "Pikachu":
                    pokemon.Health = 4; pokemon.Damage = 3;
                    break;
                case "Banana":
                    pokemon.Health = 99; pokemon.Damage= 99;
                 //   Console.WriteLine("Should you really be bringing that in here?");
                    break;
                default: Console.WriteLine("** Default proc PokemonCenter **");
                    break;
            }
        }
    }
}
