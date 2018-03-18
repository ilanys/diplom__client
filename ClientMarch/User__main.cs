using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
namespace ClientMarch
{
    public partial class User__main : MetroForm
    {
        user main;
        public User__main( user tem ) 
        {
            InitializeComponent();
            main = tem;
            
        }
        MetroLabel label__metro(Size size, Point point, string text, string name,bool Dark)
        {
            MetroLabel label = new MetroLabel();
            label.Size = size;
            label.Location = point;
            label.Text = text;
            label.Name = name;
            if (Dark)
                label.Theme = MetroFramework.MetroThemeStyle.Dark;
            return label; 
        }
        MetroTextBox textbox__metro(Size size, Point point, string text, string name,bool passwordchar,bool Dark)
        {
            MetroTextBox textb = new MetroTextBox();
            textb.Size = size;
            textb.Location = point;
            if (text != "")
                textb.Text = text;
            else
                textb.Text = "Нет данных";
            textb.Name = name;
            if (passwordchar)
                textb.UseSystemPasswordChar = true;
            if (Dark)
                textb.Theme = MetroFramework.MetroThemeStyle.Dark;
            return textb;
        }
        void Profile__setting()
        {
            MetroButton add_image = new MetroButton();
            PictureBox user__image = new PictureBox();
            MetroTextBox textb = new MetroTextBox();
            MetroLabel label = new MetroLabel();
            int width = 1576 / 2;
            int height = 849 / 2;

            // User Image
            user__image.Location = new Point(width, 30);
            user__image.Size = new Size(150, 150);
            user__image.SizeMode = PictureBoxSizeMode.Zoom;
            user__image.Image = Image.FromFile("C:\\Users\\isles\\Documents\\image\\default.png");

            // Button add__image
            add_image.Location = new Point(width, 200);
            add_image.Size= new Size (150, 30);
            add_image.Text = "Изменить";
            add_image.Theme = MetroFramework.MetroThemeStyle.Dark;
            add_image.Click += new_image;

            // Name
            metroPanel4.Controls.Add(user__image);
            metroPanel4.Controls.Add(add_image);
            metroPanel4.Controls.Add(label__metro(new Size(150, 20), new Point(width-70, 270), "Ваше имя:", "Name",true));
            metroPanel4.Controls.Add(textbox__metro(new Size(150, 20), new Point(width+80, 270),main.get__name().Split(' ')[0], "Name__text", false, true));

            metroPanel4.Controls.Add(label__metro(new Size(150, 20), new Point(width-70, 310), "Ваша фамилия:", "Name", true));
            metroPanel4.Controls.Add(textbox__metro(new Size(150, 20), new Point(width+80, 310), main.get__name().Split(' ')[1], "Name__text", false, true));

            metroPanel4.Controls.Add(label__metro(new Size(150, 20), new Point(width-70, 350), "Ваше пароль:", "Password", true));
            metroPanel4.Controls.Add(textbox__metro(new Size(150, 20), new Point(width+80, 350), "Пароль", "Password__text", true, true));
        }

        private void new_image(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (open.ShowDialog() != DialogResult.OK)
                return;

            connect con = new connect();
            con.add_image__user(main.get__token(), open.FileName);

        }


        void Garage()
        {
            MetroPanel auto = new MetroPanel();

            MetroTile label1 = new MetroTile();
            PictureBox picture = new PictureBox();
            connect conect = new connect();

            // Initialize the Panel control.



            
            //Button add Car
            MetroButton Add_Car = new MetroButton();
            Add_Car.Size = new Size(200, 40);
            Add_Car.Theme = MetroFramework.MetroThemeStyle.Dark;
            Add_Car.Location = new Point(metroPanel3.Width-Add_Car.Width-30, 20);
            Add_Car.Name = "Add__car";
            Add_Car.Text = "Добавить машину";


          string my_car  = conect.get__car(main.get__token());
            if(my_car!="")
            {

            }

            //Auto
            auto.Size = new Size(100, 100);
            auto.Location = new Point(70, 100);
            auto.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            auto.Theme = MetroFramework.MetroThemeStyle.Dark;


           
            picture.Size = new Size(50,50);
            picture.Location = new Point(auto.Width / 2 - picture.Width / 2, auto.Height / 2 - picture.Height/2);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Image = Image.FromFile("C:\\Users\\isles\\Documents\\image\\default.png");

            // Initialize the Label and TextBox controls.
            label1.Location = new Point(0, 0);
            label1.Text = "Мой гараж";
            label1.Style = MetroFramework.MetroColorStyle.Red;
            label1.Size = new Size(148, 53);

            // Add the Label and TextBox controls to the Panel.
            metroPanel3.Controls.Add(label1);
            metroPanel3.Controls.Add(Add_Car);
            metroPanel3.Controls.Add(auto);
            auto.Controls.Add(picture);

        }
        void main__form()
        {
            
            MetroPanel panel__left = new MetroPanel();
            MetroTile panel__left__title = new MetroTile();

            MetroPanel panel__Right = new MetroPanel();
            MetroTile panel__Right__title = new MetroTile();

            PictureBox[] picture__news = new PictureBox[8];
            MetroLabel[] body = new MetroLabel[8];
            MetroLabel[] date = new MetroLabel[8];
            for(int i=0;i<8;i++)
            {
                date[i] = new MetroLabel();
                picture__news[i] = new PictureBox();
                body[i] = new MetroLabel();
            }
          

            // Main
            
            // Left
            panel__left.Location = new Point(27, 72);
            panel__left.Size = new Size(1030, 720);
            panel__left.Name = "Left";
            panel__left.Theme = MetroFramework.MetroThemeStyle.Dark;
            panel__left.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;

            //Left label
            panel__left__title.Location = new Point(3, 3);
            panel__left__title.Size = new Size(148, 53);
            panel__left__title.Name = "Left__title";
            panel__left__title.Text = "Главное";
            panel__left__title.Style = MetroFramework.MetroColorStyle.Red;

            //Right
            panel__Right.Location = new Point(1082, 72);
            panel__Right.Size = new Size(472, 720);
            panel__Right.Name = "Right";
            panel__Right.Theme = MetroFramework.MetroThemeStyle.Dark;
            panel__Right.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;

            //Right__title

            panel__Right__title.Location = new Point(3, 3);
            panel__Right__title.Size = new Size(151, 53);
            panel__Right__title.Name = "Right__title";
            panel__Right__title.Text = "Новости";
            panel__Right__title.Style = MetroFramework.MetroColorStyle.Red;




           
            //Left Panel
            this.metroPanel2.Controls.Add(panel__left);
            panel__left.Controls.Add(panel__left__title);

            //Right Panel
            metroPanel2.Controls.Add(panel__Right);
            panel__Right.Controls.Add(panel__Right__title);


            connect con = new connect();
            string[] news = con.news().Split('=');
            int width=100;
            int j=0;
            for (int i=news.Length-2;i>=0;i--)
            {
                if (j > -8)
                {
                    //header
                    date[Math.Abs(j)].Location = new Point(26, width);
                    date[Math.Abs(j)].Size = new Size(76, 64);
                    date[Math.Abs(j)].Name = "Body__News "+i;
                    date[Math.Abs(j)].Text = news[i].Split('%')[0];
                    date[Math.Abs(j)].Theme = MetroFramework.MetroThemeStyle.Light;

                    //body
                    body[Math.Abs(j)].Location = new Point(106, width);
                    body[Math.Abs(j)].Size = new Size(247, 64);
                    body[Math.Abs(j)].Name = "Body__News " +i;
                    body[Math.Abs(j)].Text = news[i].Split('%')[1];
                    body[Math.Abs(j)].Theme = MetroFramework.MetroThemeStyle.Light;
                    //picturebox
                    picture__news[Math.Abs(j)].Location = new Point(359, width);
                    picture__news[Math.Abs(j)].Size = new Size(100, 64);
                    picture__news[Math.Abs(j)].Name = "Body__News "+i;
                    picture__news[Math.Abs(j)].Image = Image.FromFile(news[i].Split('%')[2]);
                    picture__news[Math.Abs(j)].SizeMode = PictureBoxSizeMode.Zoom;

                    panel__Right.Controls.Add(date[Math.Abs(j)]);
                    panel__Right.Controls.Add(body[Math.Abs(j)]);
                    panel__Right.Controls.Add(picture__news[Math.Abs(j)]);

                    width += 78;
                    j--;
                }
                else
                    break;
            }


        }

        private void User__main_Load(object sender, EventArgs e)
        {
          main__form();
          Garage();
          Profile__setting();
            metroPanel3.Hide();
            metroPanel4.Hide();
            metroLabel1.Text = main.get__name();
        }

        private void metroToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroPanel2.Visible=true;
            metroPanel3.Visible = metroPanel4.Visible = false;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroPanel3.Visible = true;
            metroPanel2.Visible = metroPanel4.Visible = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroPanel4.Visible = true;
            metroPanel2.Visible = metroPanel3.Visible = false;
        }
    }
}
