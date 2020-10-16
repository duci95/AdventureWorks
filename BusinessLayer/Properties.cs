using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL17DusanKrsmanovic2816.BusinessLayer
{
   public abstract class Properties
    { }
    public class EmpInfo :Properties
    {
        public int ID { get; set; }
        public string ImePrezime { get; set; }
    }
    public class EmpInfoPlus : Properties
    {
        public int ID { get; set; }
        public string Posao { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public decimal Rata { get; set; }
        public short UčestalostIsplate { get; set; }
        public int? Odmor { get; set; }
        public int? Bolovanje { get; set; }
        public string ImeOdeljenja { get; set; }
        public string ImeGrupe { get; set; }
    }
    public class EmpInfoJob : Properties
    {
        public int ID { get; set; }
        public string  Email { get; set; }
        public string Smena { get; set; }
        public TimeSpan Početak { get; set; }
        public TimeSpan Kraj { get; set; }
        public string Telefon { get; set; }
        public string TipTelefona { get; set; }
    }
    public class CustomerInfo : Properties
    {
       public string Ime { get; set; }
       public string Prezime { get; set; }
       public string KreditnaKartica { get; set; }
        public string TipKartice { get; set; }
    }
    public class CustomerInfo1:Properties
    {
        public int? ID { get; set; }
        public string ImePrezime { get; set; }
    }
    public class CustomerInfoCredit : Properties
    {
        public int? ID { get; set; }
        public string KreditnaKartica { get; set; }
        public string TipKartice { get; set; }
    }
    public class CustomerInfoCredit2 : Properties
    {
        public int? ID { get; set; }
        public string Store { get; set; }
        public string Demografija { get; set; }
    }
}
