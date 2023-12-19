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
        public Pokemon(string name, int health, int damage) {
            Name = name;
            Health = health;
            Damage = damage;
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
                Console.WriteLine($"{actor.Name} scratched {receiver.Name} for {actor.Damage} damage");
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
        public void PokeDex()
        {
            Console.WriteLine($"Pokemon stats. Name: {Name}, Health: {Health}, Damage: {Damage}.");
        }
    }
}
