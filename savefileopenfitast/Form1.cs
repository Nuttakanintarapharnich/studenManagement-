namespace savefileopenfitast
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {// สร้างออบเจก จาก ไฟล์ไดอาลอก คลาส
            string strdata = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV(*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readALLline = File.ReadAllLines(openFileDialog.FileName);

                for (int i = 0; i < readALLline.Length; i++)
                {
                    string studenraw = readALLline[i];
                    string [] studenSplied = studenraw.Split(',');
                    studenn student = new studenn(studenSplied[0], studenSplied[1], studenSplied[2]);
                    dataGridView1.Rows.Add(studenSplied);

                    //todo add studen odject to datagridview
                    //adddata to gridview(studen);
                }


            }
                //string filepath = openFileDialog.FileName;
                //string data = File.ReadAllText(filepath);
                //addDataToGridView("01", "nlme", "cis");
                //this.textBox1.Text = data;
              //file.readalllines();


            

             void addDataToGridView(string id,string name,string major)
            {
                this.dataGridView1.Rows.Add(new string[] { id, name, major });
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    csv += column.HeaderText + ',';
                }
                //Add new line.
                csv += "\r\n";

                //Adding the Rows

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            //Add the Data rows.
                            csv += cell.Value.ToString().TrimEnd(',').Replace(",", ";") + ',';
                        }
                        // break;
                    }
                    //Add new line.
                    csv += "\r\n";
                }

                //Exporting to CSV.
                string folderPath = "CSV(*.csv) | *.csv";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                File.WriteAllText(folderPath + "Invoice.csv", csv);
                MessageBox.Show("ok");
            }
            catch
            {
                MessageBox.Show("ok");
            }
        }




            /*{ 
                string strData = string.Empty;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV(*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName != string.Empty)
                    {
                        int row = this.dataGridView1.Rows.Count;
                        for (int i = 0; i < row; i++)
                        {
                            int column = this.dataGridView1.Columns.Count;
                            for (int j = 0; j < column; j++)
                            {
                                strData = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                                string strraw = strData.Trim();
                            }



                            File.WriteAllText(saveFileDialog.FileName, strData, System.Text.Encoding.UTF8);
                        }
                    }
                }

            }*/





            /*private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        gpaxxxcalcula gpacalculater = new gpaxxxcalcula();
        
        private void button1_Click(object sender, EventArgs e)
        {

            //อ่านเท็กบ็อก
            string input = this.textBox4.Text;
            //แปลงสตริงที่อินพุตมา เเปลงจาก สตริง เป็นดับเบิิล
            double dInput = Convert.ToDouble(input);
            //ครีเอต ออบเจก
            gpacalculater.setGPA(dInput);
            gpacalculater.setminmax(dInput);

            //นำ gpx จากออบเจค
            double gpax = gpacalculater.getGPAx();
            double maxx = gpacalculater.getmax();
            double minx = gpacalculater.getmin();
            //นำข้อมูลจากเทกบ็อกมาไส่ str mtr
            
            this.textBox5.Text = gpax.ToString();
            this.textBox6.Text = maxx.ToString();
            this.textBox7.Text = minx.ToString();



            //ส่วนที่ตัวหนังสือเเละชื่อที่อยู่เมเจอ
            dataGridView1.Rows.Add(textBox2.Text, textBox3.Text, comboBox1.Text);

        }*/

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}