using System;

namespace LandOfTamagotchiAPI
{
    public class Tamagotchi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; } = DateTime.Today;
        public int HungerLevel { get; set; }
        public int HappinessLevel { get; set; }
    }
}