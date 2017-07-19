using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMVVMLocal.Model;

namespace XamarinMVVMLocal.ViewModel
{
    public class SegundaViewModel : BaseViewModel
    {
        public Dados Usuario { get; }

        public SegundaViewModel(Dados usuarioSelecionado)
        {
            Usuario = usuarioSelecionado;
        }
    }
}
