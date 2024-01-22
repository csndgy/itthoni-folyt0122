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

        /*public void Beolvasas(string sor)
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
        }*/
        public void FileBeolvasas(string fileNev)
        {
            //sorok = new List<Adatok>();
            foreach (var sor in File.ReadAllLines(fileNev).Skip(1))
            {
                //int szam = int.Parse(sor.Split(";")[0]);
                //string nev = sor.Split(";")[1];
                //string email = sor.Split(";")[2];
                //DateTime szulDat = DateTime.Parse(sor.Split(";")[3]);
                //string lakcim = sor.Split(";")[4];
                //int matekEred = int.Parse(sor.Split(";")[5]);
                //int magyarEred = int.Parse(sor.Split(";")[6]);


                Adatok felv = new Adatok();
                felv.ModositCSVSorral(sor);
                //felv.Beolvasas(sor);
                felvetelizok.Add(felv);
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog beolvasas = new OpenFileDialog();
            if (felvetelizok.Count > 0)
            {
                beolvasas.ShowDialog();
                MessageBox.Show("", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            else
            {


                if (beolvasas.FileName != "")
                {
                    string[] sorok = File.ReadAllLines(beolvasas.FileName);
                    List<Adatok> adatok = new List<Adatok>();
                    for (int i = 1; i < sorok.Length; i++)
                    {
                        string s = sorok[i];
                        string[] beolv = s.Split(";");
                        Adatok tanulo = new Adatok(beolv[0]
                            , beolv[1],
                            beolv[2],
                            DateTime.Parse(beolv[3]), beolv[4], int.Parse(beolv[5]),
                            int.Parse(beolv[6])
                            );
                        adatok.Add(tanulo);
                    }
                    dgAdatok.ItemsSource = adatok;
                }
            }
            
        }
    }
}
            