﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambasada.Model
{
    public class Podnosilac : Osoba
    {

        // potrebno implementirati zajedno sa website-om naknadno, ne spada u projektni zadatak 6
        protected Podnosilac(int idOsobe, string naziv, string email, DateTime datumRodjenja, string jmbg) : base(idOsobe, naziv, email, datumRodjenja, jmbg)
        {
        }
    }
}
