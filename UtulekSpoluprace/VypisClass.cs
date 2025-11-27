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

        public static void VypisVsechna(Logika service)
        {
            var list = service.VsechnaZvire();
            if (list.Length == 0)
            {
                Console.WriteLine("Žádná zvířata v systému.");
                return;
            }

            foreach (var z in list)
            {
                z.PrintInfo();
                Console.WriteLine("----------------");
            }
        }

        public static void Vyhledat(Logika service)
        {
            Console.Write("Jméno (nepovinné): ");
            string jmeno = Console.ReadLine();

            Console.Write("Druh (nepovinné): ");
            string druh = Console.ReadLine();

            var list = service.Vyhledat(jmeno, druh, null, null, null);

            if (list.Length == 0)
            {
                Console.WriteLine("Nic nenalezeno.");
                return;
            }

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"[{i}]");
                list[i].PrintInfo();
                Console.WriteLine("----------------");
            }
        }
    }
}
