using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(new ListViewItem(textBox1.Text));
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = listView1.SelectedItems.Count > 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = textBox1.Text.Length > 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сохранение пока недоступно!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = textBox2.Text.Length > 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Selected = item.Text.ToLower().Contains(textBox2.Text.ToLower());
            }
        }
    }
}
