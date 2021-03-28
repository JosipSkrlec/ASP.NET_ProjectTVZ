using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class PitanjaIOdgovori
    {
        public List<PitanjaIOdgovori> Lista { get; set; }
        public PitanjaIOdgovori()
        {
            Lista = new List<PitanjaIOdgovori>();
        }

        public string Pitanje { get; set; }
        public string Odgovor { get; set; }


    }




}
