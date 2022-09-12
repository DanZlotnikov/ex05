namespace GameUI
{
    public partial class Form1 : Form
    {
        private int m_boardWidth = 4;
        private int m_boardHeight = 4;
        private bool m_isAgainstComputer = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            string? player2Text = m_isAgainstComputer ? null : PlayerName2.Text;
            var form = new GameForm(m_boardWidth, m_boardHeight, PlayerName1.Text, player2Text);
            form.ShowDialog();
            this.Show();
        }

        private void againstFriendComputerButton_Click(object sender, EventArgs e)
        {
            m_isAgainstComputer = !m_isAgainstComputer;
            if (m_isAgainstComputer)
            {
                againstFriendComputerButton.Text = "Against Computer";
                PlayerName2.ReadOnly = true;
                PlayerName2.Text = "- computer -";
            }
            else
            {
                againstFriendComputerButton.Text = "Against a friend";
                PlayerName2.ReadOnly = false;
                PlayerName2.Text = "";
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            if (m_boardHeight == 6)
            {
                if (m_boardWidth == 6)
                {
                    m_boardHeight = 4;
                    m_boardWidth = 4;
                }
                else
                {
                    m_boardWidth += 1;
                    m_boardHeight = 4;
                }
            }
            else
            {
                m_boardHeight += 1;
            }
            boardSizeButton.Text = String.Format("{0} x {1}", m_boardWidth, m_boardHeight);
        }
    }
}