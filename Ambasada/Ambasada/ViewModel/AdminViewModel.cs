using Ambasada.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.ViewModel
{
    public class AdminViewModel
    {
        private Tombola tombola;
        private ObservableCollection<Uposlenik> lista;

        public Tombola Tombola { get => tombola; set => tombola = value; }
        internal ObservableCollection<Uposlenik> Lista { get => lista; set => lista = value; }

    }
}
