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
using System.IO;

namespace Ricerca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(file))
                using (StreamReader r = new StreamReader(file))
                {
                    try
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            lblNomi.Text += $"{line}\n";
                            lista.Add(line);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }
        List<string> lista = new List<string>();
        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            lista.Add(nome);
            lista.Sort();
            lblNomi.Text = null;
            for (int i = 0; i < lista.Count; i++)
            {
                lblNomi.Text += $"{lista[i]}\n";
            }
        }

        string file = "nomi.txt";

        public void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter w = new StreamWriter(file))
            {
                try
                {
                    for(int i = 0; i < lista.Count; i++)
                    {
                        w.WriteLine(lista[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show($"La lista è stata salvata sul file {file}");
        }


        private void btnRicerca_Click(object sender, RoutedEventArgs e)
        {
            string ricerca = txtRicerca.Text;
            using (StreamWriter w = new StreamWriter(file))
            {
                try
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        w.WriteLine(lista[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (lista.Contains(ricerca))
            {
                MessageBox.Show($"Il file {file} contiene : {ricerca}");
            }
            else
            {
                MessageBox.Show($"Il file {file} non contiene : {ricerca}");
            }

        }
    }
}
