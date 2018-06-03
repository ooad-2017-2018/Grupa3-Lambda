using Ambasada.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.ViewModel
{
    class UposlenikViewModel
    {
        // potrebno implementirati zajedno sa website-om naknadno, ne spada u projektni zadatak 6
        ObservableCollection<Prijava> listaPrijava;
        public UposlenikViewModel() {
            inicijaliziraj();
        }
        public async void inicijaliziraj() {
            listaPrijava = await BazaPodatakaHelper.dajPrijave();
        }
    }
}
