namespace MinerGame
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Cell[][] cellsData;
        Button[][] cellButtons;
        const int cellSize = 25;

        private void toggleMainButton()
        {
            startButton.Visible = !startButton.Visible;
            startButton.Enabled = !startButton.Enabled;

            restartButton.Visible = !restartButton.Visible;
            restartButton.Enabled = !restartButton.Enabled;
        }

        private void fillCells()
        {
            int fieldsSize = AppData.currentDifficulty.fieldSize;
            cellsData = new Cell[fieldsSize][];
            Random random = new Random();

            for (int i = 0; i < fieldsSize; i++)
            {
                Cell[] row = new Cell[fieldsSize];
                for (int j = 0; j < fieldsSize; j++)
                {
                    row[j] = new Cell { hasBomb = random.Next(0, 100) <= 12 };
                }
                cellsData[i] = row;
            }
        }

        private void fillBombsAround()
        {
            for (int i = 0; i < cellsData.Length; i++)
            {
                for (int j = 0; j < cellsData[i].Length; j++)
                {
                    cellsData[i][j].bombsAround = checkBombAround(i, j);
                }
            }
        }

        private int checkBombAround(int cellI, int cellJ)
        {
            int fieldsSize = AppData.currentDifficulty.fieldSize;
            int startI = cellI == 0 ? 0 : cellI - 1;
            int startJ = cellJ == 0 ? 0 : cellJ - 1;
            int endI = cellI + 1 == fieldsSize ? cellI : cellI + 1;
            int endJ = cellJ + 1 == fieldsSize ? cellJ : cellJ + 1;

            int bombs = 0;

            for (int i = startI; i <= endI; i++)
            {
                for (int j = startJ; j <= endJ; j++)
                {
                    if (i == cellI && j == cellJ) continue;
                    if (cellsData[i][j].hasBomb) bombs++;
                }
            }

            return bombs;
        }

        private void createField()
        {
            int fieldsSize = AppData.currentDifficulty.fieldSize;

            Button[][] localButtons = new Button[fieldsSize][];

            for (int i = 0; i < fieldsSize; i++)
            {
                Button[] localRowButtons = new Button[fieldsSize];
                for (int j = 0; j < fieldsSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(i * cellSize + 15, j * cellSize + 70);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.Gray;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.MouseDown += cell_MouseDown;

                    localRowButtons[j] = button;
                    this.Controls.Add(button);
                }
                localButtons[i] = localRowButtons;
            }

            cellButtons = localButtons;
        }

        private void clearField()
        {
            if (cellButtons is null) return;
            for (int i = 0; i < cellButtons.Length; i++)
            {
                for (int j = 0; j < cellButtons[i].Length; j++)
                {
                    this.Controls.Remove(cellButtons[i][j]);
                }
            }

        }


        public void startGame()
        {
            clearField();
            fillCells();
            fillBombsAround();
            createField();
        }

        private void cell_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button is null) return;
            if (e.Button == MouseButtons.Left)
            {
                cell_LeftClick(button);
            }
            if (e.Button == MouseButtons.Right)
            {
                cell_RightClick(button);
            }
        }

        private void cell_LeftClick(Button button)
        {
            int i = (button.Location.X - 15) / cellSize;
            int j = (button.Location.Y - 70) / cellSize;
            Cell cell = cellsData[i][j];
            if (cell.isOpen || cell.isMarked) return;
            openCell(i, j);
            if (cell.hasBomb)
            {
                LoseMessage loseMessage = new LoseMessage(this);
                loseMessage.Show();
            }
            else if (cell.bombsAround == 0) openAround(i, j);
            cellsData[i][j] = cell;
        }

        private void openAround (int cellI, int cellJ)
        {
            openCell(cellI, cellJ);
            if (cellsData[cellI][cellJ].bombsAround > 0) return;

            int fieldsSize = AppData.currentDifficulty.fieldSize;
            int startI = cellI == 0 ? 0 : cellI - 1;
            int startJ = cellJ == 0 ? 0 : cellJ - 1;
            int endI = cellI + 1 == fieldsSize ? cellI : cellI + 1;
            int endJ = cellJ + 1 == fieldsSize ? cellJ : cellJ + 1;

            for (int i = startI; i <= endI; i++)
            {
                for (int j = startJ; j <= endJ; j++)
                {
                    if (cellsData[i][j].isOpen) continue;
                    System.Diagnostics.Debug.WriteLine(cellsData[i][j].bombsAround.ToString() + " " + cellsData[i][j].getContent());
                    openAround(i, j);
                }
            }
        }

        private void openCell(int i, int j)
        {
            cellsData[i][j].isOpen = true;
            cellButtons[i][j].Text = cellsData[i][j].getContent();
            cellButtons[i][j].BackColor = Color.White;
        }

        private void cell_RightClick(Button button)
        {
            int i = (button.Location.X - 15) / cellSize;
            int j = (button.Location.Y - 70) / cellSize;
            Cell cell = cellsData[i][j];
            if (cell.isOpen) return;
            cell.isMarked = !cell.isMarked;
            button.Text = cell.getContent();
            button.BackColor = Color.White;
            cellsData[i][j] = cell;
        }



        private void startButton_Click(object sender, EventArgs e)
        {
            toggleMainButton();
            startGame();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            toggleMainButton();
            startGame();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.Show();
        }
    }
}