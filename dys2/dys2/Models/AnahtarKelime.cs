using dys2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dys2.Models { 
    public class AnahtarKelime
    {
        public AnahtarKelime()
        {
            Makaleler = new List<Makale>(); // Object Initializer
        }

        public int Id { get; set; }
        public string Kelime { get; set; }
        public virtual List<Makale> Makaleler { get; set; }
    }
}