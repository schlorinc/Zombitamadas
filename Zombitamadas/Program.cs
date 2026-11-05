namespace Zombitamadas
{
    internal class Program
    {
        static Random r = new Random();
        static string[] Nevkiosztas(int elemekSzama)
        {
            string[] nevek = { "Adam", "Bence", "Daniel", "David", "Erik", "Gabor", "Hanna", "Istvan", "Janos", "Kata", "Lili", "Mate", "Nora", "Peter", "Reka", "Robert", "Samuel", "Tamas", "Viktor", "Zoltan", "Marcus", "Victor", "Damien", "Drake", "Raven", "Morgana", "Lucius", "Dante", "Silas", "Vladimir" };
            string[] tomb = new string[elemekSzama];
            for (int i = 0; i < elemekSzama; i++)
            {
                int index = r.Next(0, nevek.Length);
                tomb[i] = nevek[index];
            }
            return tomb; //itt nem a tömböt küldi, hanbem a memóriából a referenciacímet
        }

        static void kiir(string[] tomb) //megkapja a memóriacímet, és azzal dolgozik, amit ott talál, kiírja
        {
            foreach (var item in tomb)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static int[] LakossagEreje(int lakossagSzama)
        {
            int[] tomb = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                tomb[i] = 100;
            }
            return tomb;
        }

        static int[] zombikErejeKezdeti(int lakossagSzama, int sebzesMin, int sebzesMax)
        {
            int[] tomb = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                tomb[i] = r.Next(sebzesMin, sebzesMax);
            }
            return tomb;
        }

        static void KiirSzamokat(int[] tomb)
        {
            foreach (var item in tomb)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-------------------------------------");
        }

        static void Harc(string[] lakossag, string[] zombik, int[] lakossagEletereje, int[] zombikEreje)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                int index = r.Next(0, lakossag.Length); //hanyadik lakost támadjuk meg
                Console.WriteLine($"{zombik[i]} zombi rátámadt {zombikEreje[i]} erővel {lakossag[index]}, akinek kezdeti életereje: {lakossagEletereje[index]}");
                lakossagEletereje[index] -= zombikEreje[i];
                if (lakossagEletereje[index] <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{lakossag[index]} lakosmeghalt.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{lakossag[index]} lakos életereje: {lakossagEletereje[index]}");
                }
            } 
        }

        static void Main(string[] args)
        {
            Console.Write("Hány lakosa legyen a városnak: (1-20)");
            int lakossagSzama = Convert.ToInt32(Console.ReadLine());
            string[] lakossag = Nevkiosztas(lakossagSzama);
            int[] lakossagEletereje = LakossagEreje(lakossagSzama);

            Console.WriteLine("A lakosság: ");
            kiir(lakossag); //memóriacímet adjuk át
            KiirSzamokat(lakossagEletereje);

            string[] zombik = Nevkiosztas(lakossagSzama);
            int sebzesMin = 10;
            int sebzesMax = 30;
            int[] zombikEreje = zombikErejeKezdeti(lakossagSzama, sebzesMin, sebzesMax);

            Console.WriteLine("A zombik: ");
            kiir(zombik);
            KiirSzamokat(zombikEreje);

            Harc(lakossag, zombik, lakossagEletereje, zombikEreje);
        }
    }
}
