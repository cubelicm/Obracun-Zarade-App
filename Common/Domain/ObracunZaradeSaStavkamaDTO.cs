using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class ObracunZaradeSaStavkamaDTO
    {
        public ObracunZarade ObracunZarade { get; set; }
        public List<StavkaObracunaZarade> Stavke { get; set; }
    }
}
