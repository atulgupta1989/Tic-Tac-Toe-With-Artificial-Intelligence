using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeAI
{
    public partial class Form1 : Form
    {
        static int Won = 0;
        static int lost = 0;
        static int total = 0;
        static int draw = 0;
        Button[,] btnarray = new Button[3, 3];
        bool  X_turn=true;
        bool O_turn=false;
        public Form1()
        {
            InitializeComponent();
            btnarray[0, 0] = button1;
            btnarray[0, 1] = button2;
            btnarray[0, 2] = button3;
            btnarray[1, 0] = button4;
            btnarray[1, 1] = button5;
            btnarray[1, 2] = button6;
            btnarray[2, 0] = button7;
            btnarray[2, 1] = button8;
            btnarray[2, 2] = button9;

           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(btnarray[2,2].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Tic_Tae(object sender, EventArgs e)
        {

            if (X_turn)
            {
                Button ab = sender as Button;
                ab.Text = "X";
                ab.Font = new Font(ab.Font.FontFamily, 15, ab.Font.Style | FontStyle.Bold);
                ab.Enabled = false;
                X_turn = false;
                CheckWin("*** Player ***");
                
            }
            else if (O_turn)
            {
                Button ab = sender as Button;
                ab.Text = "O";
                ab.Font = new Font(ab.Font.FontFamily, 15, ab.Font.Style | FontStyle.Bold);
                ab.Enabled = false;
                X_turn = true;
                O_turn = false;
            }
           
            if(X_turn==false)
            {
                AiPlayerTurn();
                CheckWin("*** Computer ***");
                X_turn = true;
            }
        }

        public void CheckWin(string player)
        {
            bool flag = checkvictory(player);
            int checkflag = 0;
            if (!flag)
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (string.IsNullOrEmpty(btnarray[i, j].Text))
                        {
                            checkflag++;
                        }
                    }
                }
                if (checkflag == 0)
                {
                    draw++;
                    MessageBox.Show("Draw");
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool checkvictory(string sign)
        {
           
            if ((btnarray[0, 0].Text == btnarray[0, 1].Text && btnarray[0, 1].Text == btnarray[0, 2].Text && btnarray[0, 0].Text!="" && btnarray[0, 1].Text!="" && btnarray[0, 2].Text!="")
                || (btnarray[1, 0].Text == btnarray[1, 1].Text && btnarray[1, 1].Text == btnarray[1, 2].Text && btnarray[1, 2].Text!="" && btnarray[1, 1].Text!="" && btnarray[1, 0].Text!="")
                || (btnarray[2, 0].Text == btnarray[2, 1].Text && btnarray[2, 1].Text == btnarray[2, 2].Text && btnarray[2, 0].Text!="" && btnarray[2, 1].Text!="" && btnarray[2, 2].Text!=""))
            {
                DisableButtons();
                MessageBox.Show(sign +" Won");
                return true;
            }
            if ((btnarray[0, 0].Text == btnarray[1, 0].Text && btnarray[1, 0].Text == btnarray[2, 0].Text && btnarray[0, 0].Text != "" && btnarray[1, 0].Text != "" && btnarray[2, 0].Text != "")
                || (btnarray[0, 1].Text == btnarray[1, 1].Text && btnarray[1, 1].Text == btnarray[2, 1].Text && btnarray[2, 1].Text != "" && btnarray[1, 1].Text != "" && btnarray[0, 1].Text != "")
                || (btnarray[0, 2].Text == btnarray[1, 2].Text && btnarray[1, 2].Text == btnarray[2, 2].Text && btnarray[0, 2].Text != "" && btnarray[1, 2].Text != "" && btnarray[2, 2].Text != ""))
            {
                DisableButtons();
                MessageBox.Show(sign + " Won");
                return true;
            }
            if ((btnarray[2, 0].Text == btnarray[1, 1].Text && btnarray[1, 1].Text == btnarray[0, 2].Text && btnarray[2,0].Text!="" && btnarray[1,1].Text!="" && btnarray[0,2].Text!=null))
            {
                DisableButtons();
                MessageBox.Show(sign + " Won");
                return true;
            }
            if ((btnarray[2, 2].Text == btnarray[1, 1].Text && btnarray[1, 1].Text == btnarray[0, 0].Text && !string.IsNullOrEmpty(btnarray[2,2].Text) && !string.IsNullOrEmpty(btnarray[1,1].Text) && !string.IsNullOrEmpty(btnarray[0,0].Text)))
            {
                DisableButtons();
                MessageBox.Show(sign + " Won");
                return true;
            }

            return false;
        }

        public void DisableButtons()
        {
            foreach(Button b in btnarray)
            {
                b.Enabled = false;
            }

        }
        public void AiPlayerTurn()
        {
            Button NextMove = null;
            NextMove = AiPlayer_WinBlock("O");
            if(NextMove==null)
            {
                NextMove = AiPlayer_WinBlock("X");
                if(NextMove==null)
                {
                    NextMove = BlockCorners();
                    if(NextMove==null)
                    {
                        NextMove = LookOpenSpace();
                    }
                }
               
            }
            if(NextMove!=null)
            PerformAiAction(NextMove);
        }

        public void PerformAiAction(Button btn)
        {
            btn.Text = "O";
            btn.Font = new Font(btn.Font.FontFamily, 15, btn.Font.Style | FontStyle.Bold);
            btn.Enabled = false;

        }
        public Button AiPlayer_WinBlock(string sign)
        {
            //if (btnarray[1, 1].Enabled == true && string.IsNullOrEmpty(btnarray[1, 1].Text))
            //    return button5;
            if ((btnarray[0,0].Enabled==false && btnarray[0,1].Enabled==false && btnarray[0, 0].Text.ToLower() == sign.ToLower() && btnarray[0, 1].Text == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 2].Text.ToLower()) ))
            {
                return button3;
            }
            if ((btnarray[0, 0].Enabled == false && btnarray[0, 2].Enabled == false && btnarray[0, 0].Text.ToLower() == sign.ToLower() && btnarray[0, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 1].Text.ToLower())))
            {
                return button2;
            }
            if ((btnarray[0, 1].Enabled == false && btnarray[0, 2].Enabled == false && btnarray[0, 1].Text.ToLower() == sign.ToLower() && btnarray[0, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 0].Text.ToLower())))
            {
                return button1;
            }

            if ((btnarray[1, 0].Enabled == false && btnarray[1, 1].Enabled == false && btnarray[1, 0].Text.ToLower() == sign.ToLower() && btnarray[1, 1].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 2].Text.ToLower())))
            {
                return button6;
            }
            if (btnarray[1, 0].Enabled == false && btnarray[1, 2].Enabled == false && (btnarray[1, 0].Text.ToLower() == sign.ToLower() && btnarray[1, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 1].Text.ToLower())))
            {
                return button5;
            }
            if ((btnarray[1, 1].Enabled == false && btnarray[1, 2].Enabled == false && btnarray[1, 1].Text.ToLower() == sign.ToLower() && btnarray[1, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 0].Text.ToLower())))
            {
                return button4;
            }

            if ((btnarray[2, 0].Enabled == false && btnarray[2, 1].Enabled == false && btnarray[2, 0].Text.ToLower() == sign.ToLower() && btnarray[2, 1].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 2].Text.ToLower())))
            {
                return button9;
            }
            if ((btnarray[2, 0].Enabled == false && btnarray[2, 2].Enabled == false && btnarray[2, 0].Text.ToLower() == sign.ToLower() && btnarray[2, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 1].Text.ToLower())))
            {
                return button8;
            }
            if ((btnarray[2, 2].Enabled == false && btnarray[2, 1].Enabled == false && btnarray[2, 1].Text.ToLower() == sign.ToLower() && btnarray[2, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 0].Text.ToLower())))
            {
                return button7;
            }

            //vertical
            if ((btnarray[0, 0].Enabled == false && btnarray[1, 0].Enabled == false && btnarray[0, 0].Text.ToLower() == sign.ToLower() && btnarray[1, 0].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 0].Text.ToLower())))
            {
                return button7;
            }
            if ((btnarray[1, 0].Enabled == false && btnarray[2, 0].Enabled == false && btnarray[1, 0].Text.ToLower() == sign.ToLower() && btnarray[2, 0].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 0].Text.ToLower())))
            {
                return button1;
            }
            if ((btnarray[0, 0].Enabled == false && btnarray[2, 0].Enabled == false && btnarray[2, 0].Text.ToLower() == sign.ToLower() && btnarray[0, 0].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 0].Text.ToLower())))
            {
                return button4;
            }

            if ((btnarray[1, 1].Enabled == false && btnarray[0, 1].Enabled == false && btnarray[0, 1].Text.ToLower() == sign.ToLower() && btnarray[1, 1].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 1].Text.ToLower())))
            {
                return button8;
            }
            if ((btnarray[2, 1].Enabled == false && btnarray[1, 1].Enabled == false && btnarray[1, 1].Text.ToLower() == sign.ToLower() && btnarray[2, 1].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 1].Text.ToLower())))
            {
                return button2;
            }
            if ((btnarray[2, 1].Enabled == false && btnarray[0, 1].Enabled == false && btnarray[2, 1].Text.ToLower() == sign.ToLower() && btnarray[0, 1].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 1].Text.ToLower())))
            {
                return button5;
            }

            if ((btnarray[1, 2].Enabled == false && btnarray[0, 2].Enabled == false && btnarray[0, 2].Text.ToLower() == sign.ToLower() && btnarray[1, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 2].Text.ToLower())))
            {
                return button9;
            }
            if ((btnarray[1, 2].Enabled == false && btnarray[2, 2].Enabled == false && btnarray[1, 2].Text.ToLower() == sign.ToLower() && btnarray[2, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 2].Text.ToLower())))
            {
                return button3;
            }
            if ((btnarray[2, 2].Enabled == false && btnarray[0, 2].Enabled == false && btnarray[2, 2].Text.ToLower() == sign.ToLower() && btnarray[0, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 2].Text.ToLower())))
            {
                return button6;
            }
            //Diagonal Winning Check
            if ((btnarray[0, 0].Enabled == false && btnarray[1, 1].Enabled == false && btnarray[0, 0].Text.ToLower() == sign.ToLower() && btnarray[1, 1].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 2].Text.ToLower())))
            {
                return button9;
            }
            if ((btnarray[2, 2].Enabled == false && btnarray[1, 1].Enabled == false && btnarray[1, 1].Text.ToLower() == sign.ToLower() && btnarray[2, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 0].Text.ToLower())))
            {
                return button1;
            }
            if ((btnarray[0, 0].Enabled == false && btnarray[2, 2].Enabled == false && btnarray[2, 2].Text.ToLower() == sign.ToLower() && btnarray[0, 0].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 1].Text.ToLower())))
            {
                return button5;
            }

            if ((btnarray[0, 2].Enabled == false && btnarray[1, 1].Enabled == false && btnarray[0, 2].Text.ToLower() == sign.ToLower() && btnarray[1, 1].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[2, 0].Text.ToLower())))
            {
                return button7;
            }
            if ((btnarray[1, 1].Enabled == false && btnarray[2, 0].Enabled == false && btnarray[1, 1].Text.ToLower() == sign.ToLower() && btnarray[2, 0].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[0, 2].Text.ToLower())))
            {
                return button3;
            }
            if ((btnarray[2, 2].Enabled == false && btnarray[0, 2].Enabled == false && btnarray[2, 2].Text.ToLower() == sign.ToLower() && btnarray[0, 2].Text.ToLower() == sign.ToLower() && string.IsNullOrEmpty(btnarray[1, 1].Text.ToLower())))
            {
                return button5;
            }
            return null;

        }

        public Button LookOpenSpace()
        {
            foreach(Button btn in btnarray)
            {
                if(string.IsNullOrEmpty(btn.Text))
                {
                    return btn;
                }
            }
            return null;
        }

        public Button BlockCorners()
        {
            if(btnarray[0,0].Text.ToLower()=="x")
            {
                if (string.IsNullOrEmpty(btnarray[0, 2].Text))
                    return button3;
                if (string.IsNullOrEmpty(btnarray[2, 2].Text))
                    return button9;
                if (string.IsNullOrEmpty(btnarray[2, 0].Text))
                    return button7;
            }
            if (btnarray[0, 2].Text.ToLower() == "x")
            {
                if (string.IsNullOrEmpty(btnarray[0, 0].Text))
                    return button1;
                if (string.IsNullOrEmpty(btnarray[2, 2].Text))
                    return button9;
                if (string.IsNullOrEmpty(btnarray[2, 0].Text))
                    return button7;
            }
            if (btnarray[2, 0].Text.ToLower() == "x")
            {
                if (string.IsNullOrEmpty(btnarray[0, 2].Text))
                    return button3;
                if (string.IsNullOrEmpty(btnarray[2, 2].Text))
                    return button9;
                if (string.IsNullOrEmpty(btnarray[0, 0].Text))
                    return button1;
            }
            if (btnarray[2, 2].Text.ToLower() == "x")
            {
                if (string.IsNullOrEmpty(btnarray[0, 2].Text))
                    return button3;
                if (string.IsNullOrEmpty(btnarray[0, 0].Text))
                    return button1;
                if (string.IsNullOrEmpty(btnarray[2, 0].Text))
                    return button7;
            }
            return null;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            foreach(Button btn in btnarray)
            {
                btn.Text = "";
                btn.Enabled = true;
                X_turn = true;
                total=total+1;
                draw++;
                label6.Text = draw.ToString();
                label7.Text = total.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = Won.ToString();
            label5.Text = lost.ToString();
            label6.Text = draw.ToString();
            total++;
            label7.Text = total.ToString();
        }
    }
}
