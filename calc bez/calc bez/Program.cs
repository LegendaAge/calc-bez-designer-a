using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc_bez
{
    class Program : Form
    {

        static void Main(string[] args)
        {
            Program pr = new Program();
            Application.Run(pr.NewForm());
        }
        Form form;
        Button b;
        TextBox first;
        TextBox second;
        TextBox wynik;
        Label dzialanie;
        Label rowne;
        Button odejmowanie;
        Button dodawanie;
        Button mnozenie;
        Button dzielenie;
        Button rowne2;
        Button kropka;
        Button wyczysc;


        public Form NewForm()
        {
            form = new Form();
            form.Size=new Size(350, 250);

            int x = 0;
            int y = 30;
            int u = 10;
            first = new TextBox();
            first.Location = new Point(0, 0);
            form.Controls.Add(first);

            second = new TextBox();
            second.Location = new Point(120, 0);
            form.Controls.Add(second);

            wynik = new TextBox();
            wynik.Location = new Point(240, 0);
            form.Controls.Add(wynik);

            dzialanie = new Label();
            dzialanie.Location = new Point(105, 0);
            dzialanie.Text = "";
            form.Controls.Add(dzialanie);

            rowne = new Label();
            rowne.Location = new Point(225, 0);
            rowne.Text = "=";
            form.Controls.Add(rowne);

            odejmowanie = new Button();
            odejmowanie.Location = new Point(240, 30);
            odejmowanie.Text = "-";
            odejmowanie.Click += dzialaniee;
            form.Controls.Add(odejmowanie);
            

            dodawanie = new Button();
            dodawanie.Location = new Point(240, 60);
            dodawanie.Text = "+";
            dodawanie.Click += dzialaniee;
            form.Controls.Add(dodawanie);
           

            mnozenie = new Button();
            mnozenie.Location = new Point(240, 90);
            mnozenie.Text = "*";
            mnozenie.Click += dzialaniee;
            form.Controls.Add(mnozenie);
           
            dzielenie = new Button();
            dzielenie.Location = new Point(240, 120);
            dzielenie.Text = "/";
            dzielenie.Click += dzialaniee;
            form.Controls.Add(dzielenie);

            rowne2 = new Button();
            rowne2.Location = new Point(160, 120);
            rowne2.Text = "=";
            rowne2.Click += wynikk;
            form.Controls.Add(rowne2);

            kropka = new Button();
            kropka.Location = new Point(0, 120);
            kropka.Text = ",";
            kropka.Click += liczba;
            form.Controls.Add(kropka);

            wyczysc = new Button();
            wyczysc.Location = new Point(0, 150);
            wyczysc.Text = "Clean";
            wyczysc.Click += clean;
            form.Controls.Add(wyczysc);

            for (int i = 1; i <= 10; i++)
            {
                u -= 1;
                b = new Button();
                b.Location = new Point(x, y);
                b.Text = u.ToString();
                b.Click += liczba;
                b.Name = u.ToString();
                form.Controls.Add(b);
                x += 80;
                if (i % 3 == 0)
                {
                    y += 30;
                    x = 0;
                }
                if (i % 9 == 0)
                {

                    x += 80;

                }
            }
            return form;
        }



        public void wynikk(object sender, EventArgs e)
        {
            try
            {

                switch (dzialanie.Text)
                {
                    case "+":
                        wynik.Text = (double.Parse(first.Text) + double.Parse(second.Text)).ToString();
                        break;
                    case "-":
                        wynik.Text = (double.Parse(first.Text) - double.Parse(second.Text)).ToString();
                        break;
                    case "/":
                        wynik.Text = (double.Parse(first.Text) / double.Parse(second.Text)).ToString();
                        break;
                    case "*":
                        wynik.Text = (double.Parse(first.Text) * double.Parse(second.Text)).ToString();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void liczba(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (dzialanie.Text == "")
            {
                first.Text += b.Text;
            }
            else
            {
                second.Text += b.Text;
            }
        }
        public void dzialaniee(object sender, EventArgs e)    
        {
            dzialanie.Text = ((Button)sender).Text;
        }
        public void clean(object sender, EventArgs e)
        {
            first.Clear();
            second.Clear();
            wynik.Clear();
            dzialanie.Text = "";
            

        }

    }
}
