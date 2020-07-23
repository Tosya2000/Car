using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Машина
{
    public partial class Poezdki : Form
    {
        public int number { get; set; }
        public int s { get; set; }
        public Poezdki()
        {
            InitializeComponent();
            button2.Visible = false;
        }
        private void Poezdki_Load(object sender, EventArgs e)
        {
            textBox1.Text = number.ToString();
            CarEntities car = new CarEntities();
            int x = car.Клиент.Count();
            for (int i = 1; i <= x; i++)
            {
                Клиент клиент = car.Клиент.Find(i);
                comboBox2.Items.Add(клиент.ФИО.ToString());
                comboBox3.Items.Add(клиент.ФИО.ToString());
                comboBox4.Items.Add(клиент.ФИО.ToString());
                comboBox5.Items.Add(клиент.ФИО.ToString());
            }
            if ( s == 0)
            {
                Поездки поездки = car.Поездки.Find(number);
                comboBox1.Text = поездки.Направление;
                dateTimePicker1.Text = поездки.Дата.ToString();
                if(поездки.Пасажир_1=="Марина Слинка")   
                {
                    comboBox2.Text = поездки.Пасажир_1;
                    label10.Text = 7.ToString();
                }
                else
                {
                    if (поездки.Пасажир_1 == null)
                    {
                        comboBox2.Text = "";
                        label10.Text = 0.ToString();
                    }
                    else
                    {
                        comboBox2.Text = поездки.Пасажир_1;
                        label10.Text = 10.ToString();
                    }
                }
                if (поездки.Пасажир_2 == "Марина Слинка")
                {
                    comboBox3.Text = поездки.Пасажир_2;
                    label11.Text = 7.ToString();
                }
                else
                {
                    if (поездки.Пасажир_2 == null)
                    {
                        comboBox3.Text = "";
                        label11.Text = 0.ToString();
                    }
                    else
                    {
                        comboBox3.Text = поездки.Пасажир_2;
                        label11.Text = 10.ToString();
                    }
                }
                if (поездки.Пасажир_3 == "Марина Слинка")
                {
                    comboBox4.Text = поездки.Пасажир_3;
                    label12.Text = 7.ToString();
                }
                else
                {
                    if (поездки.Пасажир_3 == null)
                    {
                        comboBox4.Text = "";
                        label12.Text = 0.ToString();
                    }
                    else
                    {
                        comboBox4.Text = поездки.Пасажир_3;
                        label12.Text = 10.ToString();
                    }
                }
                if (поездки.Пасажир_4 == "Марина Слинка")
                {
                    comboBox5.Text = поездки.Пасажир_4;
                    label13.Text = 7.ToString();
                }
                else
                {
                    if (поездки.Пасажир_4 == null)
                    {
                        comboBox5.Text = "";
                        label13.Text = 0.ToString();
                    }
                    else {
                        comboBox5.Text = поездки.Пасажир_4;
                        label13.Text = 10.ToString();
                    }
                }
                textBox2.Text = поездки.Баланс.ToString();
                MessageBox.Show(поездки.Пасажир_4);
                button1.Visible = false;
                button2.Visible = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarEntities car = new CarEntities();
            int x = car.Клиент.Count();
            for (int i = 1; i <= x; i++)
            {
                Клиент клиент = car.Клиент.Find(i);
                if (клиент.ФИО.ToString() == comboBox3.Text)
                {
                    int s = int.Parse(клиент.Стоимость_проезда.ToString());
                    label11.Text = s.ToString();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarEntities car = new CarEntities();
            int x = car.Клиент.Count();
            for (int i = 1; i <= x; i++)
            {
                Клиент клиент = car.Клиент.Find(i);
                if (клиент.ФИО.ToString() == comboBox2.Text)
                {
                    int s= int.Parse(клиент.Стоимость_проезда.ToString());
                    label10.Text = s.ToString();
                }
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            int s = int.Parse(label10.Text)+int.Parse(label11.Text)+int.Parse(label12.Text)+int.Parse(label13.Text);
            textBox2.Text = s.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarEntities car = new CarEntities();
            int x = car.Клиент.Count();
            for (int i = 1; i <= x; i++)
            {
                Клиент клиент = car.Клиент.Find(i);
                if (клиент.ФИО.ToString() == comboBox4.Text)
                {
                    int s = int.Parse(клиент.Стоимость_проезда.ToString());
                    label12.Text = s.ToString();
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarEntities car = new CarEntities();
            int x = car.Клиент.Count();
            for (int i = 1; i <= x; i++)
            {
                Клиент клиент = car.Клиент.Find(i);
                if (клиент.ФИО.ToString() == comboBox5.Text)
                {
                    int s = int.Parse(клиент.Стоимость_проезда.ToString());
                    label13.Text = s.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarEntities car = new CarEntities();
            Поездки поездки = new Поездки();
            поездки.Номер_поездки = int.Parse(textBox1.Text);
            поездки.Направление = comboBox1.Text;
            поездки.Дата = DateTime.Parse(dateTimePicker1.Text);
            if (comboBox2.Text == "")
            {
                поездки.Пасажир_1 = null;
            }
            else
            {
                поездки.Пасажир_1 = comboBox2.Text;
            }
            if (comboBox3.Text == "")
            {
                поездки.Пасажир_2 = null;
            }
            else
            {
                поездки.Пасажир_2 = comboBox3.Text;
            }
            if (comboBox4.Text == "")
            {
                поездки.Пасажир_3 = null;
            }
            else
            {
                поездки.Пасажир_3 = comboBox4.Text;
            }
            if (comboBox5.Text == "")
            {
                поездки.Пасажир_4 = null;
            }
            else
            {
                поездки.Пасажир_4 = comboBox5.Text;
            }
            поездки.Баланс = double.Parse(textBox2.Text);
            car.Поездки.Add(поездки);
            car.SaveChanges();
            car.Dispose();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarEntities car = new CarEntities();
            Поездки поездки = car.Поездки.Find(int.Parse(textBox1.Text));
            поездки.Номер_поездки = int.Parse(textBox1.Text);
            поездки.Направление = comboBox1.Text;
            поездки.Дата = DateTime.Parse(dateTimePicker1.Text);
            if (comboBox2.Text == "")
            {
                поездки.Пасажир_1 = null;
            }
            else
            {
                поездки.Пасажир_1 = comboBox2.Text;
            }
            if (comboBox3.Text == "")
            {
                поездки.Пасажир_2 = null;
            }
            else
            {
                поездки.Пасажир_2 = comboBox3.Text;
            }
            if (comboBox4.Text == "")
            {
                поездки.Пасажир_3 = null;
            }
            else
            {
                поездки.Пасажир_3 = comboBox4.Text;
            }
            if (comboBox5.Text == "")
            {
                поездки.Пасажир_4 = null;
            }
            else
            {
                поездки.Пасажир_4 = comboBox5.Text;
            }
            поездки.Баланс = double.Parse(textBox2.Text);
            car.SaveChanges();
            car.Dispose();
            this.Close();
        }
    }
}
