using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class VratiZaposleneSO: BaseSO
    {
        public List<Zaposleni> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Zaposleni()).Cast<Zaposleni>().ToList();
        }
    }
}
