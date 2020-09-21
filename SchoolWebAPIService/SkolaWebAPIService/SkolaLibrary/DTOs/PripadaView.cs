using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class PripadaView
    {
        public int Id { get; set; }
        public SmerView ImaPredmet { get; set; }
        public PredmetView PripadaSmeru { get; set; }

        public PripadaView()
        {

        }

        public PripadaView(Pripada p)
        {
            Id = p.Id;
            ImaPredmet = new SmerView(p.ImaPredmet);
            PripadaSmeru = new PredmetView(p.PripadaSmeru);
        }
    }
}
