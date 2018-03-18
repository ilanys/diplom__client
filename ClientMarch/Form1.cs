using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

using MetroFramework.Forms;
namespace ClientMarch
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool connect = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            connect con = new connect();
            user us = con.connecting();
            if (us.get__Error() == "")
            {
                connect = true;
                return;
            }
            if(us.get__Error()== "Error500")
            metroLabel5.Text = "Сервер не доступен";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!connect)
            {
                connect con = new connect();
                user us = con.connecting();

                if (us.get__Error() != "")
                {
                    if (us.get__Error() == "Error404")
                    {
                        metroLabel5.Text = "Пользователя нет в базе данных или не правельный пароль";
                    }
                }
            }
            else
            {
                connect con = new connect();

                user us = con.LogIn(metroTextBox1.Text, metroTextBox2.Text);
                if (us.get__Error()=="")
                {
                    connect = true;

                    switch(us.get__type())
                    {
                        case "Автосервис": { break; }
                        case "Пользователь": {

                                User__main user__main = new User__main(us);
                                user__main.Show();
                                this.Hide();

                                break; }
                        default: {
                                User__main user__main = new User__main(us);
                                user__main.Show();
                                this.Hide();

                                break; }
                    }



                    return;
                }
                if (us.get__Error() == "Error500")
                    metroLabel5.Text = "Сервер не доступен";
            }

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {
            Regestration reg = new Regestration();
            reg.ShowDialog();
        }
    }
}
