using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class NenastavnoOsobljeView: ZaposleniView
    {
        public string Sektor { get; set; }
        public string StrucnaSprema { get; set; }

        public NenastavnoOsobljeView()
        {

        }

        public NenastavnoOsobljeView(NenastavnoOsoblje n)
        :base(n)
        {
            Sektor = n.Sektor;
            StrucnaSprema = n.StrucnaSprema;
        }
    }
}
