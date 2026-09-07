using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UbaciZaposlenogSO : BaseSO
    {
        private Zaposleni z {  get; set; }
        public UbaciZaposlenogSO(Zaposleni z)
        {
            this.z = z;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(z);
        }
    }
}
