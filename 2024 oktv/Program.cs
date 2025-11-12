namespace _2024_oktv
{
    internal class Program
    {

        static List<Barlang> barlangok = new List<Barlang>();

        static void Main(string[] args)
        {

            feladat_3();

            feladat_4();

            feladat_5();

            feladat_6();

            feladat_7();

        }

        public static void feladat_3()
        {

            StreamReader sr = new StreamReader("C:\\Users\\Bodisz\\source\\repos\\2024 oktv\\2024 oktv\\barlangok.txt");

            string fejlec = sr.ReadLine();

            while (!sr.EndOfStream)
            {

                barlangok.Add(new Barlang(sr.ReadLine()));

            }

            sr.Close();

        }

        public static void feladat_4()
        {
            Console.WriteLine($"Barlangok száma: {barlangok.Count}");
        }

        public static void feladat_5()
        {

            int osszMelyseg = 0;

            int miskolciBarlangok = 0;

            foreach (var item in barlangok)
            {

                if (item.Telepules.StartsWith("Miskolc"))
                {

                    osszMelyseg += item.Melyseg;

                    miskolciBarlangok++;

                }

            }

            Console.WriteLine($"A barlangok mélységének átlaga: {(double)(osszMelyseg / miskolciBarlangok):0.000}");
        }

        public static void feladat_6()
        {

            Console.WriteLine("Kérem a védetségi szintet:");
            string szint = Console.ReadLine();

            int maxHossz = 0;

            foreach (var item in barlangok)
            {
             
                if (item.Vedettseg == szint)
                {

                    if (item.Hossz > maxHossz)
                    {
                        maxHossz = item.Hossz;
                    }

                }

            }

            if (maxHossz != 0)
            {
                foreach (var item in barlangok)
                {

                    if (item.Hossz == maxHossz)
                    {
                        Console.WriteLine(item);
                    }

                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen védettségi szinttel barlang az adatok között!");
            }

        }

        public static void feladat_7()
        {

            Dictionary<string, int> stat = new Dictionary<string, int>();

            foreach (var item in barlangok)
            {

                if (!stat.ContainsKey(item.Vedettseg))
                {

                    stat.Add(item.Vedettseg, 1);

                }
                else
                {
                    stat[item.Vedettseg]++;
                }

            }

            foreach (var item in stat)
            {
                Console.WriteLine($"\t{item.Key}:{item.Value}db");
            }

        }

        
    }
}
