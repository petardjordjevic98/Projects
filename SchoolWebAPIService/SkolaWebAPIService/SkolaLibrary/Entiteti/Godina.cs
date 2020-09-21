using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaLibrary.Entiteti
{
    public class Godina
    {
        public virtual int Id { get; set; }
        public virtual Predmet Predmet { get; set; }
        public virtual int godina { get; set; }
    }
}
