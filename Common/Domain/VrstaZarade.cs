using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class VrstaZarade : IEntity 
    {
        public int IdVrstaZarade { get; set; }
        public string ImeVrste { get; set; }
        public decimal ZaradaPoSatu { get; set; }
        public string Opis {  get; set; }

        public string TableName => "VrstaZarade";
        public string Values => $"'{ImeVrste}', '{ZaradaPoSatu}', '{Opis}'";
        public string Join => "";
        public string Alias => "vz";
        public string Select => "*";
        public string WhereCondition => $"{Condition}";
        public string UpdateValues => $"imeVrste='{ImeVrste}', zaradaPoSatu='{ZaradaPoSatu}', opis='{Opis}'";
        public string IdName => "idVrstaZarade";
        public object Condition { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is VrstaZarade vz && IdVrstaZarade == vz.IdVrstaZarade;
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            return new VrstaZarade
            {
                IdVrstaZarade = (int)reader["idVrstaZarade"],
                ImeVrste = (string)reader["imeVrste"],
                ZaradaPoSatu = (decimal)reader["zaradaPoSatu"],
                Opis = (string)reader["opis"]
            };
        }
       
    }
}
