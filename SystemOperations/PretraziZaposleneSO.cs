using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class PretraziZaposleneSO: BaseSO
    {
        public List<Zaposleni> Result { get; set; }
        Zaposleni z;

        public PretraziZaposleneSO(Zaposleni zaposleni)
        {
            z = zaposleni;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetByConditionJoin(z).Cast<Zaposleni>().ToList();
        }
    }
}
