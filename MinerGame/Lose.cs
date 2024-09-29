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
    public partial class LoseMessage : Form
    {
        MainWindow mainWindow;

        public LoseMessage(MainWindow form)
        {
            InitializeComponent();
            mainWindow = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainWindow.startGame();
            this.Close();
        }
    }
}
