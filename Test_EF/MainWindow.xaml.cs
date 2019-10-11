using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_EF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            TestDBEntities erg = new Test_EF.TestDBEntities();
        public MainWindow()
        {
            InitializeComponent();



            //Datenbank-Context erstellen
            dg1.ItemsSource = erg.Kundes.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Element aus der Liste suchen
            var gesucht = Convert.ToInt32(txtKid.Text);

            var qry = (from k in erg.Kundes
                       where k.KNR == gesucht
                       select k).FirstOrDefault();

            //Name des Elementes verändern

            qry.Name = txtName.Text;

            dg1.ItemsSource = null;
            dg1.ItemsSource = erg.Kundes.ToList();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //alle änderungen in die Datenbank übernehmen

            try
            {
                erg.SaveChanges();
                MessageBox.Show("Alles gut");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //neues Kundenobjekt erzeugen
           var kneu = new Kunde();
            kneu.KNR = Convert.ToInt32(txtKid.Text);
            kneu.Name = txtName.Text;
            kneu.Ort = "Hof";
            kneu.Gehalt = 5555;

            erg.Kundes.Add(kneu);
            erg.SaveChanges();

            dg1.ItemsSource = null;
            dg1.ItemsSource = erg.Kundes.ToList();

        }
    }
}
