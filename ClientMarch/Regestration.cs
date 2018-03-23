using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Components;
using MetroFramework.Interfaces;
using MetroFramework.Forms;
namespace ClientMarch
{
    public partial class Regestration : MetroForm
    {
        public Regestration()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            connect con = new connect();
            string ad = con.add__user(metroTextBox1.Text, metroTextBox2.Text, metroTextBox4.Text, metroTextBox5.Text, metroComboBox1.SelectedItem.ToString());
            MessageBox.Show(ad);
            Close();
        }


        private void metroTextBox5_Click(object sender, EventArgs e)
        {

           
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Regestration_Load(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedItem.ToString() == "Автосервис")
                metroLabel6.Text = "Название сервиса";
            else
                metroLabel6.Text = "Ваше имя";
        }
    }
}
