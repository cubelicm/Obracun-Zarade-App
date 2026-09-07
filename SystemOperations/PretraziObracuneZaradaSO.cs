
using Common.Domain;
using System.Collections.Generic;
using System.Linq;
 
namespace SystemOperations
{
    public class PretraziObracuneZaradaSO : BaseSO
    {
        public List<ObracunZarade> Result { get; set; }
        private ObracunZarade oz;

        public PretraziObracuneZaradaSO(ObracunZarade oz)
        {
            this.oz = oz;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetByConditionJoin(oz).Cast<ObracunZarade>().ToList();
        }
    }
}
