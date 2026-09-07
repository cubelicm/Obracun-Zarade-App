using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class PromeniZaposlenogSO : BaseSO
    {
        private Zaposleni z;
        
        public PromeniZaposlenogSO(Zaposleni z)
        {
            this.z = z;
        }
        protected override void ExecuteConcreteOperation()
        {
            z.Condition = $"idZaposleni={z.IdZaposleni}";
            broker.Update(z);
        }
    }
}
