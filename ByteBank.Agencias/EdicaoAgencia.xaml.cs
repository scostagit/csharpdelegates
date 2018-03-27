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
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;

        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();
            //se a agencia for nula lançaremos uma execção.
            this._agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            this.AtualizarControles();
            this.AtualizarCamposDeTexto();

        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = this._agencia.Numero;
            txtNome.Text = this._agencia.Nome;
            txtTelefone.Text = this._agencia.Telefone;
            txtEndereco.Text = this._agencia.Endereco;
            txtDescricao.Text = this._agencia.Descricao;
        }

        //nesse metodo iremos assinar todos os eventos.
        private void AtualizarControles()
        {
            //Duas formas de manipulas delegates. tudo funiona.

            var okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;
            //var cancelarEventHandler = (RoutedEventHandler)btnCancelar_Click + Fechar;

            //Por baixo dos panos o codigo acima esta chando a classe Delegate e fazendo um combine
            //delegate + delegate = delegate.Combine(a,b)
            //public static Delegate Combine(Delegate a, Delegate b);


            //var okEventHandler = (RoutedEventHandler)Delegate.Combine(
            //                          (RoutedEventHandler)btnOk_Click, 
            //                          (RoutedEventHandler)Fechar); 

            var cancelarEventHandler = (RoutedEventHandler)Delegate.Combine(
                                      (RoutedEventHandler)btnCancelar_Click,
                                      (RoutedEventHandler)Fechar);


            //mesma coisa que o codigo acima

            //assinando os eventso do click
            this.btnOk.Click += new RoutedEventHandler(btnOk_Click);
            this.btnCancelar.Click += new RoutedEventHandler(btnCancelar_Click);

            this.btnOk.Click += new RoutedEventHandler(Fechar);
            this.btnCancelar.Click += new RoutedEventHandler(Fechar);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)=>        
            DialogResult = true;    
        
        private void btnCancelar_Click(object sender, RoutedEventArgs e)=>        
            DialogResult = false; 

        private void Fechar(object sender, RoutedEventArgs e) =>
            this.Close();
        
    }
}


