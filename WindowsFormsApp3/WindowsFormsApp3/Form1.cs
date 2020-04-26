using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        double r = 0;
        int q = 0;
        int a = 0;
        int v = 0;
        public Form1()
        {


            
            InitializeComponent();
            textBox1.ReadOnly = true;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("USD");
            comboBox1.Items.Add("RUB");
            comboBox1.Items.Add("EUR");
            comboBox2.Items.Add("USD");
            comboBox2.Items.Add("RUB");
            comboBox2.Items.Add("EUR");
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.Items.Add("USD");
            comboBox4.Items.Add("RUB");
            comboBox4.Items.Add("EUR");
            comboBox5.Items.Add("USD");
            comboBox5.Items.Add("RUB");
            comboBox5.Items.Add("EUR");
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string ss;
            using (Stream stream = client.OpenRead("https://www.banki.ru/products/currency/usd/"))
            {
                using (StreamReader sr = new StreamReader(stream))
                    ss = sr.ReadToEnd();
            }
            String Rate = Regex.Match(ss, @"<div class=""currency-table__large-text"">(\d+,\d+)</div>").Groups[1].Value;
            textBox3.Text = Rate;
          
             
            using (Stream stream = client.OpenRead("https://www.banki.ru/products/currency/eur/"))
            {
                using (StreamReader sr = new StreamReader(stream))
                    ss = sr.ReadToEnd();
            }
            Rate = Regex.Match(ss, @"<div class=""currency-table__large-text"">(\d+,\d+)</div>").Groups[1].Value;
            textBox4.Text = Rate;
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox2.Text & comboBox1.Text =="USD")
            {
                String s = textBox2.Text;
                a = a + Convert.ToInt32(s);
                textBox1.Text = a.ToString();
            }else if (comboBox1.Text == comboBox2.Text & comboBox1.Text == "RUB")
            {
                String s = textBox2.Text;
                q = q + Convert.ToInt32(s);
                textBox1.Text = q.ToString();
            }else if (comboBox1.Text == comboBox2.Text & comboBox1.Text == "EUR")
            {
                String s = textBox2.Text;
                v = v + Convert.ToInt32(s);
                textBox1.Text = v.ToString();
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "USD")
            {
                textBox1.Text = a.ToString();
            }else if (comboBox1.Text == "RUB")
            {
                textBox1.Text = q.ToString();
            }
            else if (comboBox1.Text == "EUR")
            {
                textBox1.Text = v.ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "USD")
            {
                textBox5.Text = a.ToString();
            }
            else if (comboBox4.Text == "RUB")
            {
                textBox5.Text = q.ToString();
            }
            else if (comboBox4.Text == "EUR")
            {
                textBox5.Text = v.ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string ss;
            using (Stream stream = client.OpenRead("https://www.banki.ru/products/currency/usd/"))
            {
                using (StreamReader sr = new StreamReader(stream))
                    ss = sr.ReadToEnd();
            }
            String Rate = Regex.Match(ss, @"<div class=""currency-table__large-text"">(\d+,\d+)</div>").Groups[1].Value;
            double val = Convert.ToDouble(Rate);

            if (textBox6.Text !="")
            {
                if (comboBox5.Text == "USD" & comboBox4.Text == "RUB")
                {
                    int t = Convert.ToInt32(textBox6.Text);
                    r = r + t * val;
                    textBox5.Text = r.ToString();
                    r = 0;
                } else if (comboBox5.Text == "RUB" & comboBox4.Text == "USD") 
                {
                    int t = Convert.ToInt32(textBox6.Text);
                    r = r + t / val;
                    textBox5.Text = r.ToString();
                    r = 0;
                }
                using (Stream stream = client.OpenRead("https://www.banki.ru/products/currency/eur/"))
                {
                    using (StreamReader sr = new StreamReader(stream))
                        ss = sr.ReadToEnd();
                }
                Rate = Regex.Match(ss, @"<div class=""currency-table__large-text"">(\d+,\d+)</div>").Groups[1].Value;
                val = Convert.ToDouble(Rate);
                if (comboBox5.Text == "EUR" & comboBox4.Text == "RUB")
                {
                    int t = Convert.ToInt32(textBox6.Text);
                    r = r + t * val;
                    textBox5.Text = r.ToString();
                    r = 0;
                }
                else if (comboBox5.Text == "RUB" & comboBox4.Text == "EUR")
                {
                    int t = Convert.ToInt32(textBox6.Text);
                    r = r + t / val;
                    textBox5.Text = r.ToString();
                    r = 0;
                }
                if (comboBox5.Text == "EUR" & comboBox4.Text == "USD")
                {
                    int t = Convert.ToInt32(textBox6.Text);
                    r = r + t / 0.92;
                    textBox5.Text = r.ToString();
                    r = 0;
                }
                else if (comboBox5.Text == "USD" & comboBox4.Text == "EUR")
                {
                    int t = Convert.ToInt32(textBox6.Text);
                    r = r + t * 0.92;
                    textBox5.Text = r.ToString();
                    r = 0;
                }



            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "0")
            {
                if (comboBox1.Text == comboBox2.Text & comboBox1.Text == "USD")
                {
                    String s = textBox2.Text;
                    a = a - Convert.ToInt32(s);
                    textBox1.Text = a.ToString();
                }
                else if (comboBox1.Text == comboBox2.Text & comboBox1.Text == "RUB")
                {
                    String s = textBox2.Text;
                    q = q - Convert.ToInt32(s);
                    textBox1.Text = q.ToString();
                }
                else if (comboBox1.Text == comboBox2.Text & comboBox1.Text == "EUR")
                {
                    String s = textBox2.Text;
                    v = v - Convert.ToInt32(s);
                    textBox1.Text = v.ToString();
                }
            }
            
        }
    }
}
