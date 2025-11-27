using System;

namespace UtulekSpoluprace
{
    public static class VypisClass
    {
        public static void PridatZvire(Logika service)
        {
            Console.Write("Jméno: ");
            string jmeno;
            while (string.IsNullOrWhiteSpace(jmeno = Console.ReadLine()))
                Console.Write("Zadej platné jméno: ");

            int vek;
            while (true)
            {
                Console.Write("Věk: ");
                if (int.TryParse(Console.ReadLine(), out vek) && vek >= 0)
                    break;
                Console.WriteLine("Zadej platný věk (0 nebo víc).");
            }

            Console.Write("Druh: ");
            string druh;
            while (string.IsNullOrWhiteSpace(druh = Console.ReadLine()))
                Console.Write("Zadej platný druh: ");

            service.PridatZvire(jmeno, vek, druh);
            Console.WriteLine("Zvíře přidáno!");
        }
    }
}
