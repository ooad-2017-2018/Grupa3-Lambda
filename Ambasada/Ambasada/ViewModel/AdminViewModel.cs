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
        private Tombola tombola = new Tombola();
        private ObservableCollection<Uposlenik> lista = new ObservableCollection<Uposlenik>();

        public AdminViewModel()
        {
            inicijaliziraj();
        }

        public async void inicijaliziraj() {
            Lista = await BazaPodatakaHelper.dajUposlenike();
        }
        
        public Tombola Tombola { get => tombola; set => tombola = value; }
        public ObservableCollection<Uposlenik> Lista { get => lista; set => lista = value; }
    }
}
