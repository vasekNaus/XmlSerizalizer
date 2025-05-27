using Apollo.EyeErp.Shared;
using Apollo.EyeErp.Shared.Model;
using Apollo.EyeErp.Shared.Utilities;
using System;
using System.Windows.Forms;
using System.Xml;

namespace Apollo.EyeErp.Core;

public partial class Form1 : Form
{
    private Shared.Utilities.XmlSerializerService xmlSerializerHelper2;

    public Form1()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown;
        xmlSerializerHelper2 = new Shared.Utilities.XmlSerializerService();


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

                    var task = xmlSerializerHelper2.DeserializeFromXmlFile<MyTask>(inputText);
                    xmlSerializerHelper2.SerializeToXmlFile(task, name);
                    MessageBox.Show("Deserializace proběhla", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private void button2_Click_1(object sender, EventArgs e)
    {

    }
    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (textBox1.Text.Length == 0)
        {
            button1.Enabled = false;

        }
        else if (textBox1.Text.Length > 0)
        {
            button1.Enabled = true;

        }
    }
}
