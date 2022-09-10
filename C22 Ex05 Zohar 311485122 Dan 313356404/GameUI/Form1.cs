namespace GameUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new GameForm(2,3, "Zohar",null);
            form.ShowDialog();
            this.Show();
        }
    }
}