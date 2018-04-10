using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
    public delegate bool ValidacaoHandler (string texto);

    public class TextoBoxValidacao : TextBox
    {
        public event ValidacaoHandler Validacao;
    }
}
