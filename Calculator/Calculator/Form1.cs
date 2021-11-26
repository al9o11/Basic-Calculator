using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double result = 0;
        string op = "";
        bool isOpSelected = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if ((txtBoxResult.Text == "0")||isOpSelected)
            {
                txtBoxResult.Clear();
            }
            if (button.Text == ".")
            {
                if (!txtBoxResult.Text.Contains("."))
                {
                    txtBoxResult.Text = txtBoxResult.Text + button.Text;
                }
            }
            else
            {
                txtBoxResult.Text = txtBoxResult.Text + button.Text;
            }
            isOpSelected = false;
        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                btnEqual.PerformClick();
                op = button.Text;
                isOpSelected = true;
                lblOperation.Text = result + " " + op;
            }
            else
            {
                op = button.Text;
                result = Double.Parse(txtBoxResult.Text);
                isOpSelected = true;
                lblOperation.Text = result + " " + op;
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtBoxResult.Text="0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxResult.Text = "0";
            result = 0;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (op)
            {
                case "+":
                    txtBoxResult.Text = (result+ Double.Parse(txtBoxResult.Text)).ToString();
                    break;
                case "-":
                    txtBoxResult.Text = (result - Double.Parse(txtBoxResult.Text)).ToString();
                    break;
                case "*":
                    txtBoxResult.Text = (result * Double.Parse(txtBoxResult.Text)).ToString();
                    break;
                case "/":
                    txtBoxResult.Text = (result / Double.Parse(txtBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtBoxResult.Text);
            lblOperation.Text = "";
        }
    }
}
