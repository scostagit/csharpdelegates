using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
    /*
     * O custo de criar controles customizados :
        Criamos novos controles e criar controles especializados é uma relação de perda-e-ganho: alteramos seu comportamento, mas perdemos 
        recursos do Visual Studio como o arrastar-e-soltar.
     */
    public class AgenciasListBox : ListBox
    {
        //instancia obrigatario da tela main do xaml.
        private readonly MainWindow _janelaMae;

        public AgenciasListBox(MainWindow janelaMae)
        {
            _janelaMae = janelaMae ?? throw new ArgumentNullException(nameof(janelaMae));
        }

        /*
         * Método virtual OnSelectionChanged :

            Precisávamos alterar o comportamento da ListBox, para isto, criamos um controle especializado chamado AgenciasListBox 
            e nele sobreescrevemos o método OnSelectionChanged para mudar seu comportamento.
         */

        //Em mudaça de seleção.
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            //chamada original
            base.OnSelectionChanged(e);

            //recuperar o item selenado e fazer o cast para item.
            var agenciaSelecionada = (Agencia)SelectedItem;

            _janelaMae.txtNumero.Text = agenciaSelecionada.Numero;
            _janelaMae.txtNome.Text = agenciaSelecionada.Nome;
            _janelaMae.txtTelefone.Text = agenciaSelecionada.Telefone;
            _janelaMae.txtEndereco.Text = agenciaSelecionada.Endereco;
            _janelaMae.txtDescricao.Text = agenciaSelecionada.Descricao;
        }
    }
}
