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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Vkl();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void Vkl()
        {
            CarEntities car = new CarEntities();
            dataGridView1.DataSource = car.Поездки.ToList();
            dataGridView2.DataSource = car.Услуга.ToList();
            double sum = 0;
            int z = dataGridView1.RowCount;
            int z1 = dataGridView2.RowCount;
            for (int i = 0; i < z; i++)
            {
                if (DateTime.Parse(dataGridView1[2, i].Value.ToString()) <= DateTime.Now)
                {
                    sum += double.Parse(dataGridView1[7, i].Value.ToString());
                  
                }
            }
            for(int i=0; i<z1;i++)
            {
                if (DateTime.Parse(dataGridView2[3, i].Value.ToString()) <= DateTime.Now)
                {
                    sum -= double.Parse(dataGridView2[2, i].Value.ToString());
                }
            }
            label2.Text = sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Poezdki poezdki = new Poezdki();
            int s = dataGridView1.RowCount;
            poezdki.number = int.Parse(dataGridView1[0,s-1].Value.ToString()) + 1;
            poezdki.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vkl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Poezdki poezdki = new Poezdki();
            poezdki.number = dataGridView1.CurrentRow.Index+1;
            poezdki.s = 0;
            poezdki.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
