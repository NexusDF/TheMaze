using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Button[,] Block = new Button[4, 4];
        public bool[,] Flag = new bool[4, 4];
        public Form1()
        {
            InitializeComponent();
            Block[0, 0] = button1;
            Block[0, 1] = button2;
            Block[0, 2] = button3;
            Block[0, 3] = button4;
            Block[1, 0] = button5;
            Block[1, 1] = button6;
            Block[1, 2] = button7;
            Block[1, 3] = button8;
            Block[2, 0] = button9;
            Block[2, 1] = button10;
            Block[2, 2] = button11;
            Block[2, 3] = button12;
            Block[3, 0] = button13;
            Block[3, 1] = button14;
            Block[3, 2] = button15;
            Block[3, 3] = button16;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Flag[i, j] = false;
                }
            }
            NewGame();
        }

        public void NewGame()
        {
            Random random = new Random();
            int rand = random.Next(7, 12);
            for (int i = 0; i < rand; i++)
            {
                int rand_X = random.Next(0, 4);
                int rand_Y = random.Next(0, 4);
                Flag[rand_X, rand_Y] = true;
                Block[rand_X, rand_Y].BackColor = Color.Blue;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clicking(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clicking(0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clicking(0, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clicking(0, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clicking(1, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clicking(1, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Clicking(1, 2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Clicking(1, 3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Clicking(2, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Clicking(2, 1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Clicking(2, 2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Clicking(2, 3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clicking(3, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Clicking(3, 1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Clicking(3, 2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Clicking(3, 3);
        }

        public void Clicking(int x, int y)
        {
            Flag[x, y] = !Flag[x, y];
            for (int i = 0; i < 4; i++)
            {
                Flag[x, i] = !Flag[x, i];
            }
            for (int i = 0; i < 4; i++)
            {
                Flag[i, y] = !Flag[i, y];
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Flag[i, j] == true)
                    {
                        Block[i, j].BackColor = Color.Blue;
                    }
                    else
                    {
                        Block[i, j].BackColor = Color.Red;
                    }
                }
            }
        }
    }
}