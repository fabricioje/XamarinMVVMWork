using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMVVMLocal.Model;
using XamarinMVVMLocal.Service;

namespace XamarinMVVMLocal.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //Não é a melhor forma de fazer, a melhor forma de fazer
        //isso é por inversão de dependência
        private readonly XamarinMVVMService dadosDoWebService = new XamarinMVVMService();

        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set
            {
                if (SetProperty(ref _texto, value)) ;//IF para se o SetProperty for True seja executado o Command
                InserirDadosCommand.ChangeCanExecute();//código para que o CanExecute do Command seja executado
            }
        }

        //propriedade para lista
        public ObservableCollection<Dados> Resultados { get; }

        //propriedade Command get only
        public Command InserirDadosCommand { get; }

        //propriedade do Command do botão para navegar para a próxima tema
        public Command<Dados> NavegarCommand { get; }

        public MainViewModel()
        {
            //Inicializa o Command
            InserirDadosCommand = new Command(ExecuteBotaoCommand, CanExecuteBotaoCommand);

            //Inicializa a ObservableCollection
            Resultados = new ObservableCollection<Dados>();

            //Inicializa o Command para fazer a navegação para próxima página
            NavegarCommand = new Command<Dados>(ExecuteNavegarCommand);
        }

        //metódo para execultar o Command
        async void ExecuteBotaoCommand()
        {
            //forma de executar o Display Alert, mas quebrando o MVVM
            //await App.Current.MainPage.DisplayAlert("Titulo", "Mensagem para o usuário", "Botão de Confirmação");

            //chama o método que busca os dados no web service
            var dadosRetornados = await dadosDoWebService.GetDadosAsync();

            //Adicionar os elementos retorados do web service para a lista
            foreach (var dado in dadosRetornados)
            {
                Resultados.Add(dado);
            }

        }

        //metódo para verificar se o Command pode ser executado
        bool CanExecuteBotaoCommand()
        {
            return string.IsNullOrWhiteSpace(Texto) == false;
        }

        //metódo para o Command para navegação de tela
        async void ExecuteNavegarCommand(Dados usuario)
        {
            await NavegarTelaAsync<SegundaViewModel>(usuario);
        }

    }
}
