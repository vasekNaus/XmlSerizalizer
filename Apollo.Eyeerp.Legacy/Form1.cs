using Apollo.EyeErp.Shared.Model;
using Apollo.EyeErp.Shared.Utilities;
using System;

using System.IO;

using System.Windows.Forms;


namespace Apollo.EyeErp.Legacy
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private Label label1;
        private Button btnFindFile;
        private Button btnSerializace;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

        }

        private void btnSerializace_Click(object sender, EventArgs e)
        {

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
            this.btnFindFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.KeyPreview = true;
            // 
            // btnSerializace
            // 
            this.btnSerializace.Enabled = false;
            this.btnSerializace.Location = new System.Drawing.Point(557, 110);
            this.btnSerializace.Name = "btnSerializace";
            this.btnSerializace.Size = new System.Drawing.Size(140, 31);
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
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zadej cestu k souboru k deserializace";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnFindFile
            // 
            this.btnFindFile.Location = new System.Drawing.Point(467, 110);
            this.btnFindFile.Name = "btnFindFile";
            this.btnFindFile.Size = new System.Drawing.Size(84, 31);
            this.btnFindFile.TabIndex = 3;
            this.btnFindFile.Text = "Prozkoumat";
            this.btnFindFile.UseVisualStyleBackColor = true;
            this.btnFindFile.Click += new System.EventHandler(this.btnFindFile_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(719, 189);
            this.Controls.Add(this.btnFindFile);
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
                string inputPath = this.textBox1.Text.Trim();

                if (!File.Exists(inputPath))
                {
                    MessageBox.Show("Slozka nebyla nalezena", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var task = XmlSerializerHelper.DeserializeFromXml<MyTask>(inputPath);

                string typeName = task.GetType().Name;
                string idValue = task.Id.ToString();

                string outputFileName = $"{typeName}_{idValue}.xml";

                XmlSerializerHelper.SerializeToXml(outputFileName, task);

                MessageBox.Show("Deserializace probehla!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.textBox1.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                btnSerializace.Enabled = false;

            }
            else if (textBox1.Text.Length > 0) { 
                btnSerializace.Enabled = true;

            }
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;


                string folderPath = Path.GetDirectoryName(filePath);

                if (Directory.Exists(folderPath))
                {
                    btnSerializace.Enabled = true;
                    this.textBox1.ResetText();
                    this.textBox1.AppendText(filePath);

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSerializace.PerformClick(); 
            }
            
        }
    }
}
