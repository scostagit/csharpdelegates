using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate void ValidacaoHandler(object sender, ValidacaoEventArgs e);

    public class TextoBoxValidacao : TextBox
    {
        private ValidacaoHandler _validacao;
        public event ValidacaoHandler Validacao
        {
            add
            {
                this._validacao += value;
                OnTextoBoxValidacao();
            }
            remove
            {
                this._validacao -= value;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            this.OnTextoBoxValidacao();
        }

        protected virtual void OnTextoBoxValidacao()
        {
            if (this._validacao != null)
            {
                var isValid = true;

                var invocacoes = this._validacao.GetInvocationList();
                ValidacaoEventArgs eventArgs = new ValidacaoEventArgs(this.Text);

                foreach (ValidacaoHandler item in invocacoes)
                {
                    item(this, eventArgs);

                    if (!eventArgs.EhValido)
                    {
                        isValid = false;
                        break;
                    }
                }
             
                this.Background = isValid
                        ? new SolidColorBrush(Colors.White)
                        : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
