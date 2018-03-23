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
using MetroFramework.Controls;
namespace ClientMarch
{
    public partial class AutoService__main : MetroForm
    {
        connect con= new connect();
        user us;
        public AutoService__main( user md)
        {
            us = md;
            InitializeComponent();
        }

        private void AutoService__main_Load(object sender, EventArgs e)
        {
            string info =  con.Connect__Service(us.get__token()) ;
            if(info == "Error 404|")
            {
                Service__info__add ser = new Service__info__add();
                ser.ShowDialog();
            }
        }
    }
}
