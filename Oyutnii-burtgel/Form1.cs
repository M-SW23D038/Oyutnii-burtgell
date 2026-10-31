namespace Oyutnii_burtgel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            textBox1.Clear();
            maskedTextBox1.Clear();
            richTextBox1.Clear();

            // anhnii tolowt oruulah
            comboBox1.SelectedIndex = 0;
            checkBox1.Checked = false;
            radioButton1.Checked = false;
            numericUpDown1.Value = numericUpDown1.Minimum;

            
            pictureBox1.Image = null;
            listView1.Items.Clear();
            progressBar1.Value = 0;

            // 6. CheckedListBox deer songogdson checkuudiig arilgah
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            // 7. ListBox arilgah
            if (listBox1.Items.Count > 0)
            {
                listBox1.ClearSelected();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            button1.Text = "Бүртгэх";
            maskedTextBox1.Mask = "0000-0000";

            
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[] { "-- Тэнхим сонгох --", "Компьютерын ухаан", "Мэдээллийн технологи", "Програм хангамж" });
            comboBox1.SelectedIndex = 0;

            
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(new object[] { "Програмчлал", "Өгөгдлийн бүтэц", "Алгоритм", "Өгөгдлийн сан", "Сүлжээ" });

            
            listBox1.Items.Clear();
            listBox1.Items.AddRange(new object[] { "Монгол", "Англи", "Орос", "Хятад", "Япон", "Солонгос" });


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            treeView1.Nodes.Clear();
            TreeNode rootNode = treeView1.Nodes.Add("Мэдээлэл зүйн тэнхим");
            rootNode.Nodes.Add("Компьютерын ухаан");
            rootNode.Nodes.Add("Мэдээллийн технологи");
            rootNode.Nodes.Add("Програм хангамж");

            TreeNode rootNode2 = treeView1.Nodes.Add("Байгалийн ухааны сургууль");
            rootNode2.Nodes.Add("Математик");
            rootNode2.Nodes.Add("Физик");

            treeView1.ExpandAll(); // Модны бүх салааг дэлгэж харуулах
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Today.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-age)) age--;
            if (age >= numericUpDown1.Minimum && age <= numericUpDown1.Maximum)
                numericUpDown1.Value = age;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Зураг|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kod = textBox1.Text;
            string utas = maskedTextBox1.Text;
            string nas = numericUpDown1.Value.ToString();
            string tenkhim = comboBox1.SelectedIndex > 0 ? comboBox1.SelectedItem.ToString() : "";
            string surgalt = radioButton1.Checked ? "Өдрийн" : "Оройн";
            string tetgeleg = checkBox1.Checked ? "Тийм" : "Үгүй";
            string torsonOdor = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string hel = listBox1.SelectedItem != null ? listBox1.SelectedItem.ToString() : "";
            string hicheeluud = "";
            foreach (var item in checkedListBox1.CheckedItems)
            {
                if (hicheeluud != "") hicheeluud += ", ";
                hicheeluud += item.ToString();
            }

            
            if (string.IsNullOrWhiteSpace(kod))
            {
                MessageBox.Show("Оюутны кодоо оруулна уу!", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            listView1.View = View.Details;
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Код", 90);
                listView1.Columns.Add("Утас", 90);
                listView1.Columns.Add("Нас", 50);
            }

            ListViewItem lvi = new ListViewItem(kod);
            lvi.SubItems.Add(utas);
            lvi.SubItems.Add(nas);
            listView1.Items.Add(lvi);




            richTextBox1.Clear();
            richTextBox1.SelectionColor = Color.DarkBlue;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            richTextBox1.AppendText("--- БҮРТГЭГДСЭН ОЮУТАН ---\n");

            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText($"Код: {kod}\n" +
                                        $"Утас: {utas}\n" +
                                        $"Нас: {nas}\n" +
                                        $"Төрсөн өдөр: {torsonOdor}\n" +
                                        $"Сургалт: {surgalt}\n" +
                                        $"Тэнхим: {tenkhim}\n" +
                                        $"Тэтгэлэг: {tetgeleg}\n" +
                                        $"Хичээл: {hicheeluud}\n" +
                                        $"Хэл: {hel}");


            progressBar1.Value = 100;
        }

    }
}
