using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogoDaVelha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int jogada = 1;


        //Verificar qual botão foi clicado, e alternar entre "X" e "O" dependendo do número da jogada
        private void Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.Text == "")
            {
                if (jogada % 2 == 0)
                {
                    clickedButton.Text = "O";
                }
                else
                {
                    clickedButton.Text = "X";
                }
                jogada++;
                vencedor();
            }
        }

        //Reiniciar o jogo, limpando os textos dos botões e resetando a contagem de jogadas
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            jogada = 1;
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                }
            }
        }

        //verificar se há um vencedor após cada jogada, verificando as linhas, colunas e diagonais do tabuleiro
        private void vencedor()
        {
            // Verificar linhas
            for (int i = 0; i < 3; i++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(0, i).Text != "" &&
                    tableLayoutPanel1.GetControlFromPosition(0, i).Text == tableLayoutPanel1.GetControlFromPosition(1, i).Text &&
                    tableLayoutPanel1.GetControlFromPosition(1, i).Text == tableLayoutPanel1.GetControlFromPosition(2, i).Text)
                {
                    MessageBox.Show($"O vencedor foi {tableLayoutPanel1.GetControlFromPosition(0, i).Text}!");
                    return;
                }
            }
            // Verificar colunas
            for (int j = 0; j < 3; j++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(j, 0).Text != "" &&
                    tableLayoutPanel1.GetControlFromPosition(j, 0).Text == tableLayoutPanel1.GetControlFromPosition(j, 1).Text &&
                    tableLayoutPanel1.GetControlFromPosition(j, 1).Text == tableLayoutPanel1.GetControlFromPosition(j, 2).Text)
                {
                    MessageBox.Show($"O vencedor foi {tableLayoutPanel1.GetControlFromPosition(j, 0).Text}!");
                    return;
                }
            }
            // Verificar diagonais
            if (tableLayoutPanel1.GetControlFromPosition(0, 0).Text != "" &&
                tableLayoutPanel1.GetControlFromPosition(0, 0).Text == tableLayoutPanel1.GetControlFromPosition(1, 1).Text &&
                tableLayoutPanel1.GetControlFromPosition(1, 1).Text == tableLayoutPanel1.GetControlFromPosition(2, 2).Text)
            {
                MessageBox.Show($"O vencedor foi {tableLayoutPanel1.GetControlFromPosition(0, 0).Text}!");
                return;
            }
            if (tableLayoutPanel1.GetControlFromPosition(2, 0).Text != "" &&
                tableLayoutPanel1.GetControlFromPosition(2, 0).Text == tableLayoutPanel1.GetControlFromPosition(1, 1).Text &&
                tableLayoutPanel1.GetControlFromPosition(1, 1).Text == tableLayoutPanel1.GetControlFromPosition(0, 2).Text)
            {
                MessageBox.Show($"O vencedor foi {tableLayoutPanel1.GetControlFromPosition(2, 0).Text}!");
                return;
            }
            //Verificar empate
            if(jogada > 9)
            {
                MessageBox.Show("Empate!");
            }
        } 
    }
}
