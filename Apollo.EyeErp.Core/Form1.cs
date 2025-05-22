using Apollo.EyeErp.Shared;
using System;
using System.Windows.Forms;

namespace Apollo.EyeErp.Core;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown;

    }

    private void button1_Click_1(object sender, EventArgs e)
    {
       
    }


    private void Form1_Load(object sender, EventArgs e)
    {
       
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            button1.PerformClick();
        }
        else if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }
}
