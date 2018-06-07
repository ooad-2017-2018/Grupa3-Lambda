using Ambasada.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.Model
{
    public class Tombola
    {
        ObservableCollection<Prijava> lista = new ObservableCollection<Prijava>();
        public Tombola() {

        }
        public async Task<ObservableCollection<Prijava>> uradiTombolu() {
            lista = await BazaPodatakaHelper.DajPotvrdjenePrijave();
            Random generator = new Random();
            ObservableCollection<Prijava> pobjednici = new ObservableCollection<Prijava>();

            for (int i = 0; i < lista.Count/3; i++) { //izvlači se 1/3 iz liste za pobjednike
                var dobio = (generator.Next()) % (lista.Count); // modulo za ograničavanje indeksa
                pobjednici.Add(lista.ElementAt(dobio));
                lista.RemoveAt(dobio);
            }
            return pobjednici;
        }
    }
}
