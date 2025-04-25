using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_Four
{
    // MoFalSha's Project Connect Four (I'm Still Learning)
    public partial class Form1 : Form
    {
     
        GameController controller;
        public Form1()
        {
            InitializeComponent();
          
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           controller = new GameController(panel1,lblPlayerTurn);
           
        }
        
        private void DisableColumnButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;

        }


        private void EndGame()
        {
            DisableColumnButtons();
            
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            short column = Convert.ToInt16(btn.Tag); // start from 1 

            if (controller.HandleAMove(column - 1))
            {
                if (controller.CheckGameEnd())
                {
                    EndGame();
                };
            }

            else
            {
                btn.Enabled = false;
                MessageBox.Show("You can't Play here.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            // it will redraw the board because BoardRenderer constructor will be called and it call DrawGrid(this,null)
            controller = new GameController(panel1, lblPlayerTurn); 
            
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            
        }

     
    }
}
