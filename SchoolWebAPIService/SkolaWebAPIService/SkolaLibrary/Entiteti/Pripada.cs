using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaLibrary.Entiteti
{
   public class Pripada
    {
        public virtual int Id { get;  set; }
        public virtual Smer ImaPredmet { get; set; }
        public virtual Predmet PripadaSmeru { get; set; }
    }
}
