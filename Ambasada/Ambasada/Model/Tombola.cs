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
        public async void uradiTombolu() {
            lista = await BazaPodatakaHelper.dajPotvrdjenePrijave();
            Random generator = new Random();
            ObservableCollection<Prijava> pobjednici = new ObservableCollection<Prijava>();
            for (int i = 0; i < 5; i++) { //izvlači se po 5 pobjednika
                var dobio = (generator.Next()) % (lista.Count); // modulo za ograničavanje indeksa
                pobjednici.Add(lista.ElementAt(dobio));
                lista.RemoveAt(dobio);
            }
        }
    }
}
