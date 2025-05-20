using Apollo.EyeErp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apollo.EyeErp.Legacy
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private Label label1;
        private Button btnSerializace;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSerializace_Click(object sender, EventArgs e)
        {
            Shared.Class1.GetGreeting("World");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.btnSerializace = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSerializace
            // 
            this.btnSerializace.Location = new System.Drawing.Point(703, 70);
            this.btnSerializace.Name = "btnSerializace";
            this.btnSerializace.Size = new System.Drawing.Size(180, 54);
            this.btnSerializace.TabIndex = 0;
            this.btnSerializace.Text = "Deserializace";
            this.btnSerializace.UseVisualStyleBackColor = true;
            this.btnSerializace.Click += new System.EventHandler(this.btnSerializace_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(685, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "C:\\Users\\Marek\\source\\repos\\Apollo.EyeErp.sln\\Apollo.Eyeerp.Legacy\\bin\\Debug\\Task" +
    " - 753023.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zadej cestu k souboru k deserializace";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(961, 184);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSerializace);
            this.Name = "Form1";
            this.Text = "Deserializace - legacy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSerializace_Click_1(object sender, EventArgs e)
        {
            try
            {
                string inputText = this.textBox1.Text.Trim();
                
                if (!string.IsNullOrEmpty(inputText))
                {
                    string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string name = "Task_" + date + ".xml";
                    Console.WriteLine(name);
                    var task = XmlSerializerHelper.DeserializeFromXml(inputText);
                    XmlSerializerHelper.SerializeToXml(name, task);
                }
                else {
                     MessageBox.Show("Zadej cestu k souboru!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch(Exception ex) { 
                Console.WriteLine("An error", ex);
            }
        }


  
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
