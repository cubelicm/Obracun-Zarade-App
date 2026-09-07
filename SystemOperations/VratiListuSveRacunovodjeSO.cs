using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class VratiListuSveRacunovodjeSO: BaseSO
    {
        public List<Racunovodja> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Racunovodja()).Cast<Racunovodja>().ToList();
        }
    }
}
