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
    public partial class Form4 : Form
    {
        public string filePath = "kayitlar3.txt";
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Tüm satırları dolaş
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // Yeni satır (IsNewRow) olan boş kaydı kaydetmeyelim
                    if (!dataGridView1.Rows[i].IsNewRow)
                    {
                        List<string> cellValues = new List<string>();

                        // Her bir sütundaki değeri toplayalım
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            object value = dataGridView1[j, i].Value;
                            // Değer null ise boş, değilse string’e çevir
                            string stringValue = value == null ? "" : value.ToString();

                            // Virgül (,) veya özel karakter içerebileceğini düşünürsek 
                            // ihtiyaca göre temizleme/kaçış işlemi yapabilirsiniz.
                            cellValues.Add(stringValue);
                        }

                        // Satırı virgül ile birleştirip dosyaya yaz
                        sw.WriteLine(string.Join(",", cellValues));


                        Application.Exit(); // veya Application.Exit();
                    }
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();


            if (!File.Exists(filePath))
                return;

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Satırı virgüllerle parçala
                    string[] values = line.Split(',');

                    // Parçalanan değerleri yeni satır olarak ekle
                    dataGridView1.Rows.Add(values);
                }
            }
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Uygulamanın tamamen kapanmasını sağla
                Application.Exit();
            }
        }
    }
}
