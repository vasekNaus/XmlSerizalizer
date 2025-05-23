using Apollo.EyeErp.Shared.Model;
using Apollo.EyeErp.Shared.Utilities;
using System.Xml;

namespace Apollo.EyeErp.Core;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        button1 = new Button();
        textBox1 = new TextBox();
        button2 = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(17, 95);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
       
        label1.Size = new Size(304, 25);
        label1.TabIndex = 0;
        label1.Text = "Zadej cestu k souboru k deserializace";
        label1.Click += label1_Click;
        // 
        // button1
        // 
        button1.Location = new Point(843, 184);
        button1.Margin = new Padding(4, 5, 4, 5);
        button1.Name = "button1";
        button1.Size = new Size(179, 44);
        button1.TabIndex = 1;
        button1.Enabled = false;
        button1.Text = "Deserializace";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(17, 143);
        textBox1.Margin = new Padding(4, 5, 4, 5);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(1005, 31);
        textBox1.TabIndex = 2;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // button2
        // 
        button2.Location = new Point(656, 184);
        button2.Margin = new Padding(4, 5, 4, 5);
        button2.Name = "button2";
        button2.Size = new Size(179, 44);
        
        button2.TabIndex = 3;
        button2.Text = "Prozkoumat";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1147, 298);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Controls.Add(label1);
        Name = "Form1";
        Text = "Deserializace - core";
     
        ResumeLayout(false);
        PerformLayout();
    }

    
    #endregion

    private Label label1;
    private Button button1;
    private TextBox textBox1;
    private Button button2;
}
