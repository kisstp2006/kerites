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

namespace kerites
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char[] helyesbetuk =['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N','O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z','#',':'];
        bool helyes1, helyes2, helyes3 = false;
        int hazszamokparatlan = -1;
        int hazszamokparos = -0;
        int hazoldal = 0; //0=paros, 1=paratlan
        public MainWindow()
        {
            InitializeComponent();
            telekelsoszamjelez.Text = "❌";
            telekelsoszamjelez.Foreground = Brushes.Red;
            keritesszinjelez.Text = "❌";
            keritesszinjelez.Foreground = Brushes.Red;
            telekmeretjelez.Text = "❌";
            telekmeretjelez.Foreground = Brushes.Red;
            chackallcorrect();
        }

        private void telekellenorzes_Click(object sender, RoutedEventArgs e)
        {
            chackallcorrect();
            if (telekszam.Text.Length > 0 && telekszam.Text.Length < 3)
            {
                if (int.TryParse(telekszam.Text, out int szam))
                {
                    hazoldal = szam;
                    if (szam > -1 && szam < 2)
                    {
                        telekelsoszamjelez.Text = "✔️";
                        telekelsoszamjelez.Foreground = Brushes.Green;
                        helyes1 = true;
                    }
                    else
                    {
                        telekszam.Text = "";
                        telekelsoszamjelez.Text = "❌";
                        telekelsoszamjelez.Foreground = Brushes.Red;

                    }
                }
                else
                {
                    telekszam.Text = "";
                    telekelsoszamjelez.Text = "❌";
                    telekelsoszamjelez.Foreground = Brushes.Red;
                }
            }
            else
            {
                telekelsoszamjelez.Text = "❌";
                telekelsoszamjelez.Foreground = Brushes.Red;
            }
        }
        
        private void keritesszine_TextChanged(object sender, TextChangedEventArgs e)
        {
            chackallcorrect();
        }

        private void keritesszineellen_Click(object sender, RoutedEventArgs e)
        {
            chackallcorrect();
            keritesszine.Text = keritesszine.Text.ToUpper();
            if(keritesszine.Text.Length>0 && keritesszine.Text.Length < 2)
            {
                if ( helyesbetuk.Contains(keritesszine.Text[0]))
                {
                    keritesszinjelez.Text = "✔️";
                    keritesszinjelez.Foreground = Brushes.Green;
                    helyes2 = true;
                }
                else
                {
                    keritesszine.Text = "";
                    keritesszinjelez.Text = "❌";
                    keritesszinjelez.Foreground = Brushes.Red;
                }

            }
        }

        private void telekmeretllenorzes_Click(object sender, RoutedEventArgs e)
        {
            chackallcorrect();
            if (telekszelesseg.Text.Length > 0 && telekszelesseg.Text.Length < 3)
            {
                if (int.TryParse(telekszelesseg.Text, out int szam))
                {
                    if(szam >= 8 && szam < 21)
                    {
                        telekmeretjelez.Text = "✔️";
                        telekmeretjelez.Foreground = Brushes.Green;
                        helyes3 = true;
                    }
                    else
                    {
                        keritesszine.Text = "";
                        telekmeretjelez.Text = "❌";
                        telekmeretjelez.Foreground = Brushes.Red;

                    }
                }
                else
                {
                    keritesszine.Text = "";
                    telekmeretjelez.Text = "❌";
                    telekmeretjelez.Foreground = Brushes.Red;
                }
            }
        }

        private void telekszelesseg_TextChanged(object sender, TextChangedEventArgs e)
        {
            chackallcorrect();
        }

        private void telekszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            chackallcorrect();
        }

        private void házak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (házak.SelectedItem != null)
            {
                string selectedItem = (string)házak.SelectedItem;
                string[] parts = selectedItem.Split(',');
                int houseNumber = int.Parse(parts[3].Split(':')[1].Trim());

                valaszthatoszinek(houseNumber);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chackallcorrect()) {
                if (hazoldal==0)
                {
                    hazszamokparos += 2;
                    házak.Items.Add(telekszam.Text+", "+ telekszelesseg.Text+"M ," +keritesszine.Text+", Hazszam: "+ hazszamokparos);
                }
                else if (hazoldal==1) 
                {
                    hazszamokparatlan += 2;
                    házak.Items.Add(telekszam.Text + ", " + telekszelesseg.Text + "M ," + keritesszine.Text + ", Hazszam: " + hazszamokparatlan);

                }
                telekszam.Text = "";
                telekszelesseg.Text = "";
                keritesszine.Text = "";
                eladotthazakszama.Text = (házak.Items.Count).ToString();
                helyes2 = false;
                helyes1 = false;
                helyes3 = false;
                keritesszine.Text = "";
                telekmeretjelez.Text = "❌";
                telekmeretjelez.Foreground = Brushes.Red;
                keritesszine.Text = "";
                keritesszinjelez.Text = "❌";
                keritesszinjelez.Foreground = Brushes.Red;
                telekszam.Text = "";
                telekelsoszamjelez.Text = "❌";
                telekelsoszamjelez.Foreground = Brushes.Red;


                chackallcorrect();
                utcakepmutatfunc();
            }


        }

        private bool chackallcorrect()
        {
            Console.WriteLine("Checking Requirements");
            if(helyes1 && helyes2 && helyes3)
            {
                Console.WriteLine("All Requirements are met");
                beadas.IsEnabled = true;
                return true;

            }
            else
            {
                Console.WriteLine("Requirements are not met");
                beadas.IsEnabled = false;

                return false;
            }
        }
        private void valaszthatoszinek(int houseNumber)
        {
            char[] allColors = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char currentColor = ' ';
            char leftNeighborColor = ' ';
            char rightNeighborColor = ' ';

            for (int i = 0; i < házak.Items.Count; i++)
            {
                string item = (string)házak.Items[i];
                string[] parts = item.Split(',');
                int currentHouseNumber = int.Parse(parts[3].Split(':')[1].Trim());

                if (currentHouseNumber == houseNumber)
                {
                    currentColor = parts[2].Trim()[0];

                    if (i > 0)
                    {
                        string leftNeighbor = (string)házak.Items[i - 1];
                        leftNeighborColor = leftNeighbor.Split(',')[2].Trim()[0];
                    }

                    if (i < házak.Items.Count - 1)
                    {
                        string rightNeighbor = (string)házak.Items[i + 1];
                        rightNeighborColor = rightNeighbor.Split(',')[2].Trim()[0];
                    }

                    break;
                }
            }

            valaszthatoszinek2.Items.Clear();

            foreach (char color in allColors)
            {
                if (color != currentColor && color != leftNeighborColor && color != rightNeighborColor)
                {
                    valaszthatoszinek2.Items.Add(color);
                }
            }

            if (valaszthatoszinek2.Items.Count == 0)
            {
                valaszthatoszinek2.Items.Add("Nincs elérhető szín.");
            }
        }


        private void utcakepmutatfunc()
        {
            StringBuilder utcakep = new StringBuilder();
            StringBuilder hazszam = new StringBuilder();

            foreach (string item in házak.Items)
            {
                string[] parts = item.Split(',');
                int houseNumber = int.Parse(parts[3].Split(':')[1].Trim());
                if (houseNumber % 2 != 0)
                {
                    int plotWidth = int.Parse(parts[1].Replace("M", "").Trim());
                    char fenceColor = parts[2].Trim()[0];

                    for (int i = 0; i < plotWidth; i++)
                    {
                        utcakep.Append(fenceColor);
                    }

                    hazszam.Append(houseNumber.ToString().PadLeft(plotWidth + hazszam.Length, ' '));
                }
            }

            this.utcakep.Content = utcakep.ToString();
            utcakepmutat.Content = hazszam.ToString();
        }
    }
}