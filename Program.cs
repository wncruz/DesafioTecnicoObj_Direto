using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool primeiraVez = true;

            while (true)
            {
                if (AguardaOk() == DialogResult.OK)
                {
                    PerguntarQualPrato(primeiraVez);
                    primeiraVez = false;
                }
                else
                {
                    break;
                }
            }
        }

        public static DialogResult AguardaOk()
        {
            return MessageBox.Show("Pense em um prato que gosta.", "Jogo Gourmet", MessageBoxButtons.OKCancel);
        }

        public static void PerguntarQualPrato(bool _primeiraVez)
        {
            PerguntarSeMassa(_primeiraVez);
        }

        public static void PerguntarSeMassa(bool _primeiraVez)
        {
            if (MessageBox.Show("O prato que pensou é massa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PerguntarSeLasanha(_primeiraVez);
            }
            else
            {
                PerguntarSeBoloChocolate(_primeiraVez);
            }
        }

        public static void PerguntarSeLasanha(bool _primeiraVez)
        {
            if (MessageBox.Show("O prato que pensou é lasanha?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Acertei" + (_primeiraVez ? "!" : " de novo"), "Jogo Gourmet", MessageBoxButtons.OK);
            }
            else
            {
                PerguntaEntaoQualPrato("Lasanha");
            }
        }

        public static void PerguntarSeBoloChocolate(bool _primeiraVez)
        {
            if (MessageBox.Show("O prato que pensou é Bolo de Chocolate?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Acertei" + (_primeiraVez ? "!" : " de novo"), "Jogo Gourmet", MessageBoxButtons.OK);
            }
            else
            {
                PerguntaEntaoQualPrato("Bolo de Chocolate");
            }
        }

        public static void PerguntaEntaoQualPrato(string prato)
        {
            var nomePrato = ShowInputDialog("Qual prato você pensou?", "Desisto");
            if (nomePrato != null)
            {
                var melhorQue = ShowInputDialog(nomePrato + " é ________, mas " + prato + " não.", "Complete");
                //MessageBox.Show($"{nomePrato} é melhor massa.", "Mensagem");
            }            
        }

        
        public static string ShowInputDialog(string prompt, string title)
        {
            Form inputForm = new Form()
            {
                Width = 400,
                Height = 200,
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = prompt, Width = 350 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Button okButton = new Button() { Text = "OK", Left = 100, Width = 100, Top = 80 };
            Button cancelButton = new Button() { Text = "Cancelar", Left = 210, Width = 100, Top = 80 };

            string result = null;

            okButton.Click += (sender, e) =>
            {
                result = inputBox.Text;
                inputForm.Close();
            };

            cancelButton.Click += (sender, e) =>
            {
                result = null;
                inputForm.Close();
            };

            inputForm.Controls.Add(textLabel);
            inputForm.Controls.Add(inputBox);
            inputForm.Controls.Add(okButton);
            inputForm.Controls.Add(cancelButton);
            inputForm.AcceptButton = okButton;
            inputForm.CancelButton = cancelButton;

            inputForm.ShowDialog();
            return result;
        }
        
    }
}
