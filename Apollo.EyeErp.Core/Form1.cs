using System;

namespace Apollo.EyeErp.Core;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnSerialize_Click(object sender, EventArgs e)
    {
        var c = new Apollo.EyeErp.Shared.Class1();
        c.Test = "Hello World!";    
        Apollo.EyeErp.Shared.Class1.GetGreeting("World");
    }
}
