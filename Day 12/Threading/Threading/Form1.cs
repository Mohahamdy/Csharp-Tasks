using System.Net;

namespace Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            await File.WriteAllBytesAsync("D:\\Technical Materials\\C#\\Mohamed Hamdy\\Day 12\\Download by Form\\file.rar", await httpClient.GetByteArrayAsync(textBox1.Text));
            MessageBox.Show("DOWNLOADED");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            HttpClient httpsClient = new HttpClient();
            HttpResponseMessage httpResponse = await httpsClient.GetAsync(textBox2.Text);
            richTextBox1.Text = await httpResponse.Content.ReadAsStringAsync();
        }


    }
}
