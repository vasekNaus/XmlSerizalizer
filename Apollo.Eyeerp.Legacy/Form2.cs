using Apollo.EyeErp.Shared.Model;
using Apollo.EyeErp.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Legacy
{
  //public class MyXmlSerializerService : XmlSerializerService
  //{
  //  protected override XmlSerializer CreateSerializer<T>()
  //  {
  //    if (typeof(T) == typeof(MyTask))
  //    {
  //      return new XmlSerializer(typeof(MyTask), new Type[] { typeof(MyTask) });
  //    }
  //    else
  //    {
  //      return base.CreateSerializer<T>();
  //    }
  //  }
  //}

  public partial class Form2 : Form
  {

    private Shared.Utilities.XmlSerializerService xmlSerializerHelper;
    public Form2()
    {
      InitializeComponent();

      xmlSerializerHelper = new Shared.Utilities.XmlSerializerService();
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

            var task = xmlSerializerHelper.DeserializeFromXmlFile<MyTask>(inputText);
            xmlSerializerHelper.SerializeToXmlFile(task, name);


            string xml = System.IO.File.ReadAllText(inputText);

            task = XmlSerializerService.DeserializeObject<MyTask>(xml);
            xml = XmlSerializerService.SerializeObject<MyTask>(task);
            System.IO.File.WriteAllText("Old." + name, xml, Encoding.UTF8);

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

    private void btnFind_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Select a file";

      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        string filePath = openFileDialog.FileName;


        string folderPath = Path.GetDirectoryName(filePath);

        if (Directory.Exists(folderPath))
        {
          btnSerialize.Enabled = true;
          this.textBox1.ResetText();
          this.textBox1.AppendText(filePath);

        }
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (textBox1.Text.Length == 0)
      {
        btnSerialize.Enabled = false;

      }
      else if (textBox1.Text.Length > 0)
      {
        btnSerialize.Enabled = true;

      }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
  }
}
