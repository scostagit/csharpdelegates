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


            //var cancelarEventHandler = (RoutedEventHandler)btnCancelar_Click + Fechar;

            //Por baixo dos panos o codigo acima esta chando a classe Delegate e fazendo um combine
            //delegate + delegate = delegate.Combine(a,b)
            //public static Delegate Combine(Delegate a, Delegate b);


            //var okEventHandler = (RoutedEventHandler)Delegate.Combine(
            //                          (RoutedEventHandler)btnOk_Click, 
            //                          (RoutedEventHandler)Fechar); 


            /*var okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;

            var cancelarEventHandler = (RoutedEventHandler)Delegate.Combine(
                                      (RoutedEventHandler)btnCancelar_Click,
                                      (RoutedEventHandler)Fechar);*/

            // Criação e metodos anonimo
            //RoutedEventHandler dialogeResultTrue = delegate (object sender, RoutedEventArgs e) {
            //    DialogResult = true;
            //};

            //Criação de mentodo s anonimos.
            //RoutedEventHandler dialogeResultFalse = delegate (object sender, RoutedEventArgs e) {
            //    DialogResult = true;
            //};

            //Metodo anonimo com expressao lambda
            RoutedEventHandler dialogeResultTrue =  ( sender,  e)=>  DialogResult = true;          

            //Metodo anonomo com expressao lambem
            RoutedEventHandler dialogeResultFalse =  ( sender,  e)=>  DialogResult = false;
           
            //var vanis deixar o compilador inferir para mim.
            var okEventHandler = dialogeResultTrue  + Fechar;

            var cancelarEventHandler = (RoutedEventHandler)Delegate.Combine(
                                      dialogeResultFalse,
                                      (RoutedEventHandler)Fechar);

            //mesma coisa que o codigo acima

            //assinando os eventso do click
            this.btnOk.Click += new RoutedEventHandler(okEventHandler);
            this.btnCancelar.Click += new RoutedEventHandler(cancelarEventHandler);

            this.btnOk.Click += new RoutedEventHandler(Fechar);
            this.btnCancelar.Click += new RoutedEventHandler(Fechar);

            this.txtNumero.TextChanged += ValidarCampoNulo;
            this.txtNumero.TextChanged += ValidarDigito;
            this.txtNome.TextChanged += ValidarCampoNulo;
            this.txtTelefone.TextChanged += ValidarCampoNulo;
            this.txtDescricao.TextChanged += ValidarCampoNulo;
            this.txtEndereco.TextChanged += ValidarCampoNulo;
        }

        private void ValidarDigito(object sender, EventArgs e)
        {
            var text = sender as TextBox;

            var textoVazio = String.IsNullOrEmpty(text.Text);

            //Func<char, bool> validaCaracters = caractere =>
            //{
            //    return Char.IsDigit(caractere);
            //};  

            text.Background = text.Text.All(Char.IsDigit)
                            ? new SolidColorBrush(Colors.White)
                            : new SolidColorBrush(Colors.OrangeRed);
        }

        private void ValidarCampoNulo(object sender, EventArgs e)
        {
            var text = sender as TextBox;

            var textoVazio = String.IsNullOrEmpty(text.Text);

                text.Background = textoVazio
                                ? new SolidColorBrush(Colors.OrangeRed)
                                : new SolidColorBrush(Colors.White);
            
        }

        /*  private void btnOk_Click(object sender, RoutedEventArgs e)=>        
              DialogResult = true;    

          private void btnCancelar_Click(object sender, RoutedEventArgs e)=>        
              DialogResult = false; */


        /*
         * CONECIETO
         * 
         * COntra variancia
         * é capacidade de um parametro de metodo ser substituido pela classe pai.
         * o metodo fechar deve receber como segungo parametro um objeto do tipo RoutedEventArgs
         * mas como RoutedEventArgs herda de EventArgs eu posso passar a super classe. Isso é contra Varicia..
         */
        //private void Fechar(object sender, RoutedEventArgs e) =>
        //    this.Close();

        private void Fechar(object sender, EventArgs e) =>
           this.Close();

    }
}



