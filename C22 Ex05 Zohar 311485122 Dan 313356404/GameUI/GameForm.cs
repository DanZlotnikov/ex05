using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;

namespace GameUI
{
    public partial class GameForm : Form
    {
        public int boardHeight;
        public int boardWidth;

        private Image[] valuesImages;

        Game.Game game;

        public GameForm(int boardHeight, int boardWidth, string? player1, string? player2)
        {
            this.boardHeight = boardHeight;
            this.boardWidth = boardWidth;

            game = new Game.Game(boardHeight, boardWidth, player1, player2);
            valuesImages = new Image[(boardHeight * boardWidth) / 2];

            // TODO: chane to any turn
            game.OnComputerDidTurn += () =>
            {
                RefreshBoard();
            };

            game.OnWinning += (player1) =>
            {
                var confirmResult = MessageBox.Show($"{player1.Name} Is the winner with score of {player1.Score}.", "Winning", MessageBoxButtons.OK);

                    Close();
                

            };
            InitializeComponent();
        }

        private async void Game_Load(object sender, EventArgs e)
        {
            await LoadResources();

            InitBoard();

            RefreshBoard();
        }

        private async Task LoadResources()
        {       
            this.valuesImages = await Task.WhenAll(valuesImages.Select(async x => await GetImageAsync("https://picsum.photos/80")));
        }

        public async Task<Image> GetImageAsync(string url)
        {
            var tcs = new TaskCompletionSource<Image>();
            Image webImage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
            request.Method = "GET";
            await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                .ContinueWith(task =>
                {
                    var webResponse = (HttpWebResponse)task.Result;
                    Stream responseStream = webResponse.GetResponseStream();
                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                        responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
                        responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

                    if (responseStream != null) webImage = Image.FromStream(responseStream);
                    tcs.TrySetResult(webImage);
                    webResponse.Close();
                    responseStream.Close();
                });
            return tcs.Task.Result;
        }


        private void InitBoard()
        {
            for (int i = 0; i < boardHeight * boardWidth; i++)
            {
                var cell = this.game.GetCell(i);
                var btn = new Button();
                btn.Width = 50;
                btn.Height = 50;
                btn.Left = 50 * (i % boardWidth);
                btn.Top = 50 * (i / boardWidth);

                btn.FlatStyle = FlatStyle.Flat;;
                btn.Name = $"{i}";
                btn.Click += (x, c) =>
                {
                    game.PlayTurn(int.Parse(((Button)x).Name));
                };
                this.gamePanel.Controls.Add(btn);
            }

            this.gamePanel.Width = boardWidth * 50;
            this.gamePanel.Height = boardHeight * 50;

            this.Width = this.gamePanel.Width + 50;
            this.Height = gamePanel.Height + 200;
        }

        private async void RefreshBoard()
        {
            var currentPlayer = game.GetCurrentPlayer();

            for (int i = 0; i < game.BoardSize(); i++)
            {
                var btn = gamePanel.Controls[i] as Button;
                var cell = game.GetCell(i);
                var lastPlayingPlayer = game.GetLastPlayingPlayer();
                
                btn.FlatAppearance.BorderColor = cell.owner == null ? cell.revelad ? GetPlayerColor(lastPlayingPlayer) : Color.Black : GetPlayerColor(cell.owner);
                btn.FlatAppearance.BorderSize = cell.revelad ? 5 : 1;
                //btn.Text = $"{cell.value} , ${cell.revelad}";
                btn.Enabled = !(currentPlayer is CompuerPlayer) && !cell.revelad;
                btn.Image = cell.revelad ? GetValueImage(cell.value) : null;
            }

            player2Name.Text = game.player2.Name;
            player2Score.Text = $"{game.player2.Score}";

            player1Name.Text = game.player1.Name;
            player1Score.Text = $"{game.player1.Score}";

            if (currentPlayer is CompuerPlayer && !game.IsGameOver)
            {
                await ((CompuerPlayer)currentPlayer).DoTurn();
            }
        }

        private Color GetPlayerColor(Game.Player player)
        {
            return player == game.player1 ? Color.Red : Color.Green;
        }

        private Image GetValueImage(int value)
        {
            return this.valuesImages[value];
        }
    }
}
