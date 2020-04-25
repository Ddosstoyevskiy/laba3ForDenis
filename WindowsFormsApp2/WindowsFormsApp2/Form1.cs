using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        
        int sum = 0;
        int[ ,] win = { { 0, 0, 0}, { 0, 0, 0}, {0,0, 0} };
        int[,] step = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int player1=0;
        int player2 = 0;
        int c = 0;
        public Form1()
        {
            
            InitializeComponent();
            
        }

        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            int x=0;
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            int xc = this.Width / 2;
            int yc = this.Height / 2;
            g.TranslateTransform(xc, yc);
            



            for (int i= 0; i<=3; i++)
            {
                g.DrawLine(new Pen(Color.Gray, 4.0f), -300+x, -200, -300+x, 100);
                g.DrawLine(new Pen(Color.Gray, 4.0f), -300, -200+x, 0, -200+x);
                x=x+100;
            }
            if (win[0, 0] == 1 & win[1, 0] == 1 & win[2, 0] == 1)
            {
                g.DrawLine(new Pen(Color.Black, 4.0f), -300, -200, -300 + x, 100);
            }




        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            int xc = this.Width / 2;
            int yc = this.Height / 2;
            g.TranslateTransform(xc, yc);
            int x = e.X;
            int y = e.Y;


            for (int i = 0; i < 3; i++)
            {
                for (int q = 0; q < 3; q++)
                {
                    
                    sum += step[q, i];
                }
                
                

            }
            


            int j = 0;
            if (sum%2==0) {


                for (int i = 0; i < 3; i++)
                {

                    if (y > 20 & y < 120 & x > 25 + j & x < 125 + j)
                    {
                        Krest(g, j, 0, j, 0);
                        win[0+i,0] = 1;
                        step[0 + i, 0] = 1;

                    }
                    if (y > 120 & y < 220 & x > 25 + j & x < 125 + j)
                    {
                        Krest(g, j, 100, j, 100);
                        win[0 + i, 1] = 1;
                        step[0 + i, 1] = 1;
                    }
                    if (y > 220 & y < 320 & x > 25 + j & x < 125 + j)
                    {
                        Krest(g, j, 200, j, 200);
                        win[0 + i, 2] = 1;
                        step[0 + i, 2] = 1;
                    }
                    j = j + 100;
                }

            }
            else
            {
                for (int i = 0; i < 3; i++)
                {

                    if (y > 20 & y < 120 & x > 25 + j & x < 125 + j)
                    {
                        Zero(g, j, 0);
                        win[0 + i, 0] = 2;
                        step[0 + i, 0] = 1;
                    }
                    if (y > 120 & y < 220 & x > 25 + j & x < 125 + j)
                    {
                        Zero(g, j, 100);
                        win[0 + i, 1] = 2;
                        step[0 + i, 1] = 1;

                    }
                    if (y > 220 & y < 320 & x > 25 + j & x < 125 + j)
                    {
                        Zero(g, j, 200);
                        win[0 + i, 2] = 2;
                        step[0 + i, 2] = 1;
                    }
                    j = j + 100;
                }
            }

            sum = 0;

            if (win[0, 0] == 1 & win[1, 0] == 1 & win[2, 0] == 1) {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, -150, 0, -150);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[0, 1] == 1 & win[1, 1] == 1 & win[2, 1] == 1)
            {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, -50, 0, -50);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[0, 2] == 1 & win[1, 2] == 1 & win[2, 2] == 1) {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, 50, 0, 50);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[0, 0] == 1 & win[0, 1] == 1 & win[0, 2] == 1) {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -250, -200, -250, 100);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[1, 0] == 1 & win[1, 1] == 1 & win[1, 2] == 1) {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -150, -200, -150, 100);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[0, 0] == 1 & win[1, 1] == 1 & win[2, 2] == 1) {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, -200, 0, 100);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[2,0]==1 & win[2,1]==1 & win[2,2]==1) {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -50, -200, -50, 100);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[2, 0] == 1 & win[1, 1] == 1 & win[0, 2] == 1) {
                player1++;
                g.DrawLine(new Pen(Color.Black, 3.0f), 0, -200, -300, 100);
                WinLose(g, textBox1.Text);
                label2.Text = player1.ToString();
            } else if (win[0, 0] == 2 & win[1, 0] == 2 & win[2, 0] == 2)
            {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, -150, 0, -150);
                WinLose(g, textBox2.Text);
                label4.Text = player2.ToString();
            } else if (win[0, 1] == 2 & win[1, 1] == 2 & win[2, 1] == 2) {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, -50, 0, -50);
                WinLose(g, textBox2.Text);
                label4.Text = player2.ToString();
            } else if (win[0, 2] == 2 & win[1, 2] == 2 & win[2, 2] == 2) {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, 50, 0, 50);
                WinLose(g, textBox1.Text);
                label4.Text = player2.ToString();
            } else if (win[0, 0] == 2 & win[0, 1] == 2 & win[0, 2] == 2) {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -250, -200, -250, 100);
                WinLose(g, textBox2.Text);
                label4.Text = player2.ToString();
            } else if (win[1, 0] == 2 & win[1, 1] == 2 & win[1, 2] == 2) {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -150, -200, -150, 100);
                WinLose(g, textBox2.Text);
                label4.Text = player2.ToString();
            } else if (win[2, 0] == 2 & win[1, 2] == 2 & win[2, 2] == 2) {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -50, -200, -50, 100);
                WinLose(g, textBox2.Text);
                label4.Text = player2.ToString();
            } else if (win[0, 0] == 2 & win[1, 1] == 2 & win[2, 2] == 2)
            {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), -300, -200, 0, 100);
                WinLose(g, textBox2.Text);
                label4.Text = player2.ToString();
            } else if (win[2, 0] == 2 & win[1, 1] == 2 & win[0, 2] == 2) {
                player2++;
                g.DrawLine(new Pen(Color.Black, 3.0f), 0, -200, -300, 100);
                WinLose(g, textBox2.Text);
                label4.Text = player2.ToString();
            } else if (win[0, 0] != 0 & win[1, 0] != 0 & win[2, 0] != 0 & win[0, 1] != 0 & win[1, 1] != 0 & win[2, 1] != 0 & win[0, 2] != 0 & win[1, 2] != 0 & win[2, 2] != 0)
            {

                x = 0;

                DialogResult result = MessageBox.Show(
                  "Ничья(((( Начать сначала?",
                  "even score!!!",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Exclamation,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.ServiceNotification);
                if (result == DialogResult.Yes)
                {
                    x = 0;
                    g.Clear(Color.White);
                    for (int i = 0; i <= 3; i++)
                    {

                        g.DrawLine(new Pen(Color.Gray, 4.0f), -300 + x, -200, -300 + x, 100);
                        g.DrawLine(new Pen(Color.Gray, 4.0f), -300, -200 + x, 0, -200 + x);
                        x = x + 100;
                        for (int t = 0; t < 3; t++)
                        {
                            for (int q = 0; q < 3; q++)
                            {
                                win[q, t] = 0;
                                step[q, t] = 0;
                            }
                        }
                    }
                } else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            
           c++;

            
            

        }
        void Krest( Graphics g,int x1, int y1, int x2, int y2)
        {
            g.DrawLine(new Pen(Color.Red, 2.0f), -300+10+x1, -200+10+y1, -200-10+x2, -100-10+y2);
            g.DrawLine(new Pen(Color.Red, 2.0f), -200-10+x1, -200+10+y1, -300+10+x2, -100-10+y2);


        }
        void Zero(Graphics g,int x1,int y1)
        {
            g.DrawEllipse(new Pen(Color.Blue, 3.0f),-200+x1,-100+y1,-100,-100);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            
            label2.Text = "0";
            label4.Text = "0";
            listBox1.Items.Add($"{textBox1.Text}: {textBox2.Text}  | {player1}:{player2}");
            player1 = 0;
            player2 = 0;
        }
        void WinLose(Graphics g, String winner)   
        {
            int x = 0;
            DialogResult result = MessageBox.Show(
                  $"победитель {winner}!!!! Начать новую игру?",
                  "Win!!!",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Exclamation,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes)
            {
                
                g.Clear(Color.White);
                for (int i = 0; i <= 3; i++)
                {

                    g.DrawLine(new Pen(Color.Gray, 4.0f), -300 + x, -200, -300 + x, 100);
                    g.DrawLine(new Pen(Color.Gray, 4.0f), -300, -200 + x, 0, -200 + x);
                    x = x + 100;
                    for (int t = 0; t < 3; t++)
                    {
                        for (int q = 0; q < 3; q++)
                        {
                            win[q, t] = 0;
                            step[q, t] = 0;
                        }
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }

        }


    }
}
