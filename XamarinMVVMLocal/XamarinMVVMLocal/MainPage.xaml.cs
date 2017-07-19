using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMVVMLocal.ViewModel;

namespace XamarinMVVMLocal
{
    public partial class MainPage : ContentPage
    {
        //código informando que a variável ViewModel é uma MainViewModel
        private MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        //código para pegar o nome selecionado
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.NavegarCommand.Execute(e.SelectedItem);
        }
    }
}
