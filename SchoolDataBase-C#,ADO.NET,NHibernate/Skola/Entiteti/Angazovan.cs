using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Entiteti
{
   public class Angazovan
    {
        public virtual int Id { get; set; }

        public virtual NastavnoOsoblje Nastavnik { get; set; }
        public virtual Predmet Predmet { get; set; }

        public virtual DateTime DatumAngazovanja { get; set; }
    }
}
