using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /*
     * EVENTOS  E DELEGATES
     
        * O Delegate é uma estrutura de dados para a representação, fortemente tipada, da assinatura de um método: 
        * seu tipo de retorno, a ordem e os tipos de seus parâmetros. 
        * São componentes de um delegate o seu tipo de retorno, os parâmetros e também a ordem dos parâmetros!
    
        * O evento é uma mensagem de que algo aconteceu: seja um clique em um botão, uma mudança no item selecionado de uma lista ou uma 
        pausa em um serviço do Windows. 
        * Podemos assinar estes eventos por meio de delegates. 
        * Para assinarmos um evento, é necessário usar um delegate com uma assinatura que combine com o método que o emissor do evento espera invocar. 
        * Com isto, vemos a importância dos delegates para a representação da assinatura de métodos!    

     */
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
        //private readonly AgenciasListBox lstAgencias;
        private readonly ListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();

            //this e dp tipo MainWindow.
            // lstAgencias = new AgenciasListBox(this);
            lstAgencias = new ListBox();
            AtualizarControles();
            this.AtualizarListaDeAgengicas();
        }

        private void AtualizarControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            //atribuindo a lista de delegate.
            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(this.ListBox_SelectionChanged);

            //coisas do WPF vc tem o canvas e children: vc vai adicionar um novo filho. 
            container.Children.Add(lstAgencias);

            this.btnEditar.Click += new RoutedEventHandler(this.btnEditar_Click);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var agenciaSelecionada = (Agencia)this.lstAgencias.SelectedItem;
            var janelaEdicao = new EdicaoAgencia(agenciaSelecionada);
            var resultado = janelaEdicao.ShowDialog().Value;

            if (resultado)
            {
                //Usuario clicou em Ok
            }
            else
            {
                //Usuario clicou em cancelar
            }
        }

        private void AtualizarListaDeAgengicas()
        {
            lstAgencias.Items.Clear();
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSelecionada = (Agencia)this.lstAgencias.SelectedItem;

            txtNumero.Text = agenciaSelecionada.Numero;
            txtNome.Text = agenciaSelecionada.Nome;
            txtTelefone.Text = agenciaSelecionada.Telefone;
            txtEndereco.Text = agenciaSelecionada.Endereco;
            txtDescricao.Text = agenciaSelecionada.Descricao;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            var confirmacao = 
                MessageBox.Show(
                    "Você deseja realmente excluir este item?",
                    "Confirmação",
                    MessageBoxButton.YesNo);
            if (confirmacao == MessageBoxResult.Yes)
            {
                //Excluir
            }
            else
            {
                //Não faz nada
            }
        }
    }
}
