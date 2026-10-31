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
            comboBox1.SelectedIndex = 0;
            checkBox1.Checked = false;
            pictureBox1.Image = null;
            numericUpDown1.Value = numericUpDown1.Minimum;
            richTextBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Бүртгэх";
            maskedTextBox1.Mask = "0000-0000";
            comboBox1.Items.AddRange(new object[] { "-- Тэнхим сонгох --", "Компьютерын ухаан", "Мэдээллийн технологи", "Програм хангамж" });
            comboBox1.SelectedIndex = 0;
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
            string tenkhim = comboBox1.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(kod))
            {
                MessageBox.Show("Оюутны кодоо оруулна уу!", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ListView рүү мэдээлэл нэмэх
            ListViewItem item = new ListViewItem(kod);
            item.SubItems.Add(utas);
            item.SubItems.Add(nas);
            listView1.Items.Add(item);

            // дэлгэрэнгүй харуулах
            richTextBox1.Text = $"--- БҮРТГЭГДСЭН ОЮУТАН ---\nКод: {kod}\nУтас: {utas}\nНас: {nas}\nТэнхим: {tenkhim}";

            progressBar1.Value = 100;
        }
    }
}
