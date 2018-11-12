using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            HobbiListBox.Items.Add("Úszás");
            HobbiListBox.Items.Add("Horgászat");
            HobbiListBox.Items.Add("Futás");

            BetoltesButton.Click += (sender, e) =>
            {
                try
                {
                    string tartalom = Beolvasas();
                    MessageBox.Show(tartalom);
                }
                catch(FileNotFoundException fnfe)
                {
                    MessageBox.Show("A fájl nem található");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Hiba");
                }
            };

            MentesButton.Click += (sender, e) =>
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                string fileNev = saveFileDialog1.FileName;

                using (var writer = File.CreateText(fileNev))
                {
                  
                    
                }

                
                using (var reader = File.OpenText(fileNev))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                    }
                }



            };
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UjHobbiTextBox.Text))
            {
                HobbiListBox.Items.Add(UjHobbiTextBox.Text);
            }
        }

        private string Beolvasas()
        {
            string FileNev = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(FileNev))
            {
                
                throw new Exception("A fájlnév üres");
            }
            return File.ReadAllText(FileNev);
        }
    }
}
