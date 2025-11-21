namespace UtulekSpoluprace
{
    public class Zvire
    {
        public string Name { get; set; }
        public bool Adopted { get; set; }
        public int Age { get; set; }
        public string AnimalType { get; set; }

        public Zvire(string name, bool adopted, int age, string animalType)
        {
            Name = name;
            Adopted = adopted;
            Age = age;
            AnimalType = animalType;
        }
        
        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Adopted: {Adopted}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Animal Type: {AnimalType}");
        }
        public void AdoptedToggle()
        {
            Adopted = !Adopted;
        }
    }
}