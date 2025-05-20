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
        btnSerialize = new Button();
        SuspendLayout();
        // 
        // btnSerialize
        // 
        btnSerialize.Location = new Point(557, 159);
        btnSerialize.Name = "btnSerialize";
        btnSerialize.Size = new Size(112, 34);
        btnSerialize.TabIndex = 0;
        btnSerialize.Text = "Serializovat";
        btnSerialize.UseVisualStyleBackColor = true;
        btnSerialize.Click += btnSerialize_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnSerialize);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button btnSerialize;
}
