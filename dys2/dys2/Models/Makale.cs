using dys2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dys2.Models
{
    public class Makale
    {
        public Makale()
        {
            Anahtarlar = new List<AnahtarKelime>(); // Object Initializer
            
        }
        public int Id { get; set; }
        public enum OnayDurum
        {
            OnayBekliyor = 1,
            Kabul = 2,
            Red = 3,
            Duzenlenmeli = 4
        }
       

        public string YayinBasligi { get; set; }
        public string Ozet { get; set; }
        public string Doi { get; set; }
        public string Kaynaklar { get; set; }
        public string DosyaIsmi { get; set; }
        public virtual List<AnahtarKelime> Anahtarlar { get; set; }

        //public HttpPostedFileBase MakaleDosyasi { get; set; }
        public OnayDurum SekreterOnay { get; set; }
        public OnayDurum EditorOnay { get; set; }
        public OnayDurum BolumEditoruOnay { get; set; }
        public string HakemYorum { get; set; }
    }
}