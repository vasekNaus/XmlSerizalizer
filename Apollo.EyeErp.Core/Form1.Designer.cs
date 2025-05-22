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
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string inputText = this.textBox1.Text.Trim();

            XmlDocument doc = new XmlDocument();
            doc.Load(inputText);

            XmlNode idNode = doc.SelectSingleNode("/Task/Id");
            string idValue = idNode.InnerText;

            if (!string.IsNullOrEmpty(idValue))
            {
                if (!string.IsNullOrEmpty(inputText))
                {
                    string typeName = "Task";
                    using (var reader = System.Xml.XmlReader.Create(inputText))
                    {
                        if (reader.ReadToFollowing("Task"))
                        {
                            var xsiType = reader.GetAttribute("xsi:type");
                            if (!string.IsNullOrEmpty(xsiType))
                                typeName = xsiType;
                        }
                    }

                    string name = $"{typeName}_{idValue}.xml";

                    var task = XmlSerializerHelper.DeserializeFromXml(inputText);
                    XmlSerializerHelper.SerializeToXml(name, task);
                    MessageBox.Show("Deserializace proběhla", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textBox1.ResetText();
                }
            }
            else
            {
                MessageBox.Show("Zadej cestu k souboru!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Deserializace neproběhla", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    
    private void button2_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Select a file";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;


            string folderPath = Path.GetDirectoryName(filePath);

            if (Directory.Exists(folderPath))
            {
                button1.Enabled = true;
                this.textBox1.ResetText();
                this.textBox1.AppendText(filePath);

            }
        }
    }
    #endregion

    private Label label1;
    private Button button1;
    private TextBox textBox1;
    private Button button2;
}
