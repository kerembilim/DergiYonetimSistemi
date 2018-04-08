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
            
            Kabul = 1,
            Red = 2,
            Duzenlenmeli = 3
        }
       

        public string YayinBasligi { get; set; }
        public string Ozet { get; set; }
        public string Doi { get; set; }
        public string Kaynaklar { get; set; }
        public string DosyaIsmi { get; set; }
        public virtual List<AnahtarKelime> Anahtarlar { get; set; }

        public enum BicimDenetleyiciOnay
        {
            Kabul = 1,
            Red = 2
        }
        public BicimDenetleyiciOnay BicimDenetleyici { get; set; }
        public OnayDurum SekreterOnay { get; set; }
        public OnayDurum EditorOnay { get; set; }
        public OnayDurum BolumEditoruOnay { get; set; }
        public string BolumEditoruMail { get; set; }
        public string HakemMail1 { get; set; }
        public string HakemMail2 { get; set; }
        public string HakemMail3 { get; set; }
        public string HakemYorum1 { get; set; }
        public string HakemYorum2 { get; set; }
        public string HakemYorum3 { get; set; }

    }
}