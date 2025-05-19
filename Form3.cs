using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yunusbaharliste
{
    public partial class Form3 : Form
    {
        public string filePath = "kayitlar2.txt";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    if (!dataGridView1.Rows[i].IsNewRow)
                    {
                        List<string> cellValues = new List<string>();


                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            object value = dataGridView1[j, i].Value;

                            string stringValue = value == null ? "" : value.ToString();

                            cellValues.Add(stringValue);
                        }


                        sw.WriteLine(string.Join(",", cellValues));


                        Application.Exit();
                    }
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();


            if (!File.Exists(filePath))
                return;

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    string[] values = line.Split(',');


                    dataGridView1.Rows.Add(values);
                }
            }
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                Application.Exit();
            }
        }
    }
}
