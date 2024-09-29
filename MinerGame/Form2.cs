using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerGame
{
    public partial class Settings : Form
    {   
        public Settings()
        {
            InitializeComponent();
            difficultySelect.DataSource = AppData.gameDifficulties;
            difficultySelect.DisplayMember = "label";
            difficultySelect.ValueMember = "difficulty";
            difficultySelect.SelectedIndex = Array.IndexOf(AppData.gameDifficulties, AppData.currentDifficulty);
        }

        private void label1_Click(object sender, EventArgs e)
        {
  
        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            AppData.currentDifficulty = (GameDifficulty)difficultySelect.SelectedItem;
            this.Close();
        }

        private void difficultySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveSettings.Enabled = (GameDifficulty)difficultySelect.SelectedItem != AppData.currentDifficulty;
        }
    }
}
