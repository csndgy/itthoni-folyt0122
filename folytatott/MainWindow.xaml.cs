using Microsoft.Win32;
using System.Collections.ObjectModel;
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
using System.IO;
using System.Data;
using System.Collections;

namespace felvetelizok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        ObservableCollection<IFelvetelizok> felvetelizok = new ObservableCollection<IFelvetelizok>();

        
       /* public void FileBeolvasas(string fileNev)
        {
            //sorok = new List<Adatok>();
            foreach (var sor in File.ReadAllLines(fileNev).Skip(1))
            {
               
                string[] beolv = sor.Split(";");
                Adatok adatok = new Adatok();
                adatok.OM_Azonosito = beolv[0];
                adatok.Neve = beolv[1];
                adatok.Email = beolv[2];
                adatok.SzuletesiDatum = DateTime.Parse(beolv[3]);
                adatok.ErtesitesiCime = beolv[4];
                adatok.Matematika = int.Parse(beolv[5]);
                adatok.Magyar = int.Parse(beolv[6]);

                Adatok felv = new Adatok();
                felv.ModositCSVSorral(sor);
                //felv.Beolvasas(sor);
                felvetelizok.Add(felv);
            }

        }
       */
        public MainWindow()
        {
            InitializeComponent();
            dgAdatok.ItemsSource = felvetelizok;
            
            
        }


        public void Import_Click_Button(object sender, RoutedEventArgs e)
        {
            OpenFileDialog adatokBetoltese = new OpenFileDialog();
            if (adatokBetoltese.ShowDialog() == true)
            {
                foreach (string sor in File.ReadAllLines(adatokBetoltese.FileName).Skip(1))
                {
                    felvetelizok.Add(new Adatok(sor));
                }
                dgAdatok.ItemsSource = felvetelizok;
            }

        }

        private void Torles_Click_Button(object sender, RoutedEventArgs e)
        {
            if (dgAdatok.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kijelölt elem!","Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else felvetelizok.RemoveAt(dgAdatok.SelectedIndex);
        }

        private void Felvesz_Click_Button(object sender, RoutedEventArgs e)
        {
           // Felvetel felvetel = new Felvetel();
            //felvetel.ShowDialog();
        }
    }
}
            