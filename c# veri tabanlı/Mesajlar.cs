﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace otomasyon
{
    public partial class Mesajlar : Form
    {
        public Mesajlar()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=CRAZYY\\SQLEXPRESS01;Initial Catalog=otamosyon;Integrated Security=True");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from Mesajlar", baglantı);
            SqlDataReader oku = komut.ExecuteReader();


            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Mesajİd"].ToString();
                ekle.SubItems.Add(oku["Adsoyad"].ToString());
                ekle.SubItems.Add(oku["Mesaj"].ToString());

                listView1.Items.Add(ekle);
            }
            baglantı.Close();
        }


        private void Mesajlar_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Mesajlar (Adsoyad,Mesaj) values('" + textBox1.Text + "','" + richTextBox1.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigoster();
        }
        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text ;
            richTextBox1.Text= listView1.SelectedItems[0].SubItems[2].Text ;    







        }
    }
}
