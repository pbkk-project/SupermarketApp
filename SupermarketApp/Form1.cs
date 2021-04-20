﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SupermarketApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mkadr\Documents\SMARKETDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //Tombol silang
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //tombol clear
        private void button2_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PassTb.Text = "";
        }

        public static string Sellername = "";
        //tombol login
        private void button3_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "ADMIN")
                    {
                        if (UnameTb.Text == "Admin" && PassTb.Text == "Admin")
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If You are the Admin, Enter Correct Username and Password");
                        }
                    }
                    else
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(8) from SellerTbl where SellerName='" + UnameTb.Text + "' and SellerPass='" + PassTb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Sellername = UnameTb.Text;
                            SellingForm sell = new SellingForm();
                            sell.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                        }
                        Con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select A Role");
                }
            }
        }
    }
    
}
