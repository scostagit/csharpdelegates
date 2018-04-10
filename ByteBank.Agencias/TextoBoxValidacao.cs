using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate bool ValidacaoHandler (string texto);

    public class TextoBoxValidacao : TextBox
    {
        public event ValidacaoHandler Validacao;

        public TextoBoxValidacao()
        {
            this.TextChanged += TextoBoxValidacao_TextChanged;
        }

        private void TextoBoxValidacao_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Validacao != null)
            {
                var isValid = Validacao(this.Text);

                this.Background = isValid
                        ? new SolidColorBrush(Colors.OrangeRed)
                        : new SolidColorBrush(Colors.White);
            }
        }
    }
}
