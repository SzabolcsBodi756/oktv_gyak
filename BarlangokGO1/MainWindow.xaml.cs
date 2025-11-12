using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarlangokGO1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Barlang> barlangok = new List<Barlang>();

        public MainWindow()
        {
            InitializeComponent();

            Load();
        }


        private void Load()
        {

            StreamReader sr = new StreamReader("barlangok.txt");

            string fejlec = sr.ReadLine();

            while (!sr.EndOfStream)
            {

                barlangok.Add(new Barlang(sr.ReadLine()));

            }

            sr.Close();

        }

        private void tbKeres_Click(object sender, RoutedEventArgs e)
        {

            int azon = int.Parse(tbAzon_1.Text);
            Barlang b = barlangok.FirstOrDefault(x => x.Azon == azon);

            if (b == null)
            {
                MessageBox.Show("Ezzel az azonosítóval nem létezik barlang!");
                tbAzon_1.Clear();
                tbAzon_2.Clear();
                tbAzon_3.Clear();
                tbAzon_4.Content = "Barlang neve: ";
                tbMentes.IsEnabled = false;
            }
            else
            {
                tbAzon_2.Text = b.Hossz.ToString();
                tbAzon_3.Text = b.Melyseg.ToString();
                tbAzon_4.Content = "Barlang neve: " +  b.Nev.ToString();
                tbMentes.IsEnabled = true;
            }

        }

        private void tbMentes_Click(object sender, RoutedEventArgs e)
        {

            int azon = int.Parse(tbAzon_1.Text);
            Barlang b = barlangok.First(x => x.Azon == azon);

            int ujHossz = int.Parse(tbAzon_2.Text);
            int ujMelyseg = int.Parse(tbAzon_3.Text);

            if (ujHossz < b.Hossz || ujMelyseg < b.Melyseg)
            {
                MessageBox.Show("Hiba: Az új érték(ek) nem lehet(nek) kisebb(ek) a korábbinál!");
            }
            else
            {
                b.Hossz = ujHossz;
                b.Melyseg = ujMelyseg;
                MessageBox.Show("Adatok sikeresen módosítva!");
            }

        }

        private void tbFelvisz_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                int azon = int.Parse(tbAzon_1.Text);
                string nev = tbAzon_4.Content.ToString().Replace("Barlang neve:", "").Trim();
                int hossz = int.Parse(tbAzon_2.Text);
                int melyseg = int.Parse(tbAzon_3.Text);

                if (barlangok.Any(x => x.Azon == azon))
                {
                    MessageBox.Show("Ezzel az azonosítóval már létezik barlang!");
                    return;
                }


                string sor = $"{azon};{nev};{hossz};{melyseg};Ismeretlen;nem védett";
                Barlang uj = new Barlang(sor);


                barlangok.Add(uj);

                using (StreamWriter sw = new StreamWriter("C:\\Users\\Bodisz\\source\\repos\\2024 oktv\\2024 oktv\\barlangok.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine($"{uj.Azon};{uj.Nev};{uj.Hossz};{uj.Melyseg};{uj.Telepules};{uj.Vedettseg}");
                }


                MessageBox.Show("Új barlang sikeresen felvéve!");

                tbAzon_1.Clear();
                tbAzon_2.Clear();
                tbAzon_3.Clear();
                tbAzon_4.Content = "Barlang neve:";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatok felvitelekor: " + ex.Message);
            }

        }
    }
}
