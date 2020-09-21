using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class GodinaView
    {
        public int Id { get; set; }
        public PredmetView Predmet { get; set; }
        public int godina { get; set; }

        public GodinaView()
        {

        }

        public GodinaView(Godina g)
        {
            Id = g.Id;
            godina = g.godina;
            Predmet = new PredmetView(g.Predmet);

        }
    }
}
