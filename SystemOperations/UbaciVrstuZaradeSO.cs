using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UbaciVrstuZaradeSO : BaseSO
    {
        private VrstaZarade vz { get; set; }
        public UbaciVrstuZaradeSO(VrstaZarade vz){
            this.vz = vz;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(vz);
        }
    }
}
