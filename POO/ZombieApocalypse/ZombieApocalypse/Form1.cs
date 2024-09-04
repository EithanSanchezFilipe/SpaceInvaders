using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ZombieApocalypse
{
    public partial class Form1 : Form
    {
        private Timer updateTimer;
        public Form1()
        {
            InitializeComponent();

            

            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
            this.FormClosing += MainForm_FormClosing;
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            if (key == ConsoleKey.A)
            {

            }
            else if (key == ConsoleKey.Escape)
                Environment.Exit(0);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.Stop();    // Stop the timer
            updateTimer.Dispose(); // Dispose of the timer
        }
    }
}
