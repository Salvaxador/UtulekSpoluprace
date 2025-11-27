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

            // věk - min
            int? minVek = null;
            while (true)
            {
                Console.Write("Minimální věk (nepovinné): ");
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) break;
                if (int.TryParse(s, out int v) && v >= 0) { minVek = v; break; }
                Console.WriteLine("Zadej platné celé číslo nebo nech prázdné.");
            }

            // věk - max
            int? maxVek = null;
            while (true)
            {
                Console.Write("Maximální věk (nepovinné): ");
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) break;
                if (int.TryParse(s, out int v) && v >= 0) { maxVek = v; break; }
                Console.WriteLine("Zadej platné celé číslo nebo nech prázdné.");
            }

            string adoptedInput;
            bool? adopted = null;
            while (true)
            {
                Console.Write("Adoptováno? (ano/ne/nechat prázdné): ");
                adoptedInput = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(adoptedInput)) { adopted = null; break; }
                if (adoptedInput == "ano") { adopted = true; break; }
                if (adoptedInput == "ne") { adopted = false; break; }
                Console.WriteLine("Zadej jen ano/ne nebo nechej prázdné.");
            }

            var list = service.Vyhledat(jmeno, druh, adopted, minVek, maxVek);

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

        public static void Adopce(Logika service)
        {
            Console.Write("Zadej jméno zvířete: ");
            string jmeno;
            while (string.IsNullOrWhiteSpace(jmeno = Console.ReadLine()))
                Console.Write("Zadej platné jméno: ");

            var matches = service.FindByName(jmeno);

            if (matches.Length == 0)
            {
                Console.WriteLine("Zvíře nenalezeno.");
                return;
            }

            if (matches.Length == 1)
            {
                matches[0].AdoptedToggle();
                Console.WriteLine($"Stav adopce pro '{matches[0].Name}' je nyní: {(matches[0].Adopted ? "Adoptováno" : "Neadoptováno")}");
                return;
            }

            // vícero shod -> vyber index
            Console.WriteLine("Našlo se více zvířat. Vyber index, které chceš označit:");
            for (int i = 0; i < matches.Length; i++)
            {
                Console.WriteLine($"[{i}] {matches[i].Name} - {matches[i].AnimalType}, věk {matches[i].Age}, adoptováno: {(matches[i].Adopted ? "ano" : "ne")}");
            }

            int index;
            while (true)
            {
                Console.Write("Index: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < matches.Length)
                    break;
                Console.WriteLine("Neplatný index, zkus to znovu.");
            }

            matches[index].AdoptedToggle();
            Console.WriteLine($"Stav adopce pro '{matches[index].Name}' je nyní: {(matches[index].Adopted ? "Adoptováno" : "Neadoptováno")}");
        }
    }
}
