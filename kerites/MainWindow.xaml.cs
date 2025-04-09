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
        public MainWindow()
        {
            InitializeComponent();
            telekelsoszamjelez.Text = "❌";
            telekelsoszamjelez.Foreground = Brushes.Red;
            keritesszinjelez.Text = "❌";
            keritesszinjelez.Foreground = Brushes.Red;
            telekmeretjelez.Text = "❌";
            telekmeretjelez.Foreground = Brushes.Red;
        }

        private void telekellenorzes_Click(object sender, RoutedEventArgs e)
        {
            chackallcorrect();
            if (telekszam.Text.Length > 0 && telekszam.Text.Length < 3)
            {
                if (int.TryParse(telekszam.Text, out int szam))
                {
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
                    if(szam > 8 && szam < 21)
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chackallcorrect();
        }

        private void chackallcorrect()
        {
            Console.WriteLine("Checking Requirements");
            if(helyes1 && helyes2 && helyes3)
            {
                Console.WriteLine("All Requirements are met");
                beadas.IsEnabled = true;
            }
            else
            {
                Console.WriteLine("Requirements are not met");
                beadas.IsEnabled = false;
            }
        }

    }
}
