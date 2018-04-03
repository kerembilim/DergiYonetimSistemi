using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dys2.Models
{
    public class MakaleAnahtarInitializer : DropCreateDatabaseIfModelChanges<MakaleAnahtarContext>
    {
        protected override void Seed(MakaleAnahtarContext context)
        {
            List<AnahtarKelime> AnahtarKelimeler = new List<AnahtarKelime>()
            {
                new AnahtarKelime(){Kelime="sıkıştırma"},
                new AnahtarKelime(){Kelime="çözme"}

            };
            foreach (var item in AnahtarKelimeler)
            {
                context.AnahtarKelimeler.Add(item);
            }
            context.SaveChanges();

            List<Makale> makaleler = new List<Makale>()
            {
                new Makale(){YayinBasligi="yayın basligi veri yapıları",Ozet="veri yap...",Doi="123",Kaynaklar="evdeki kitaplar",SekreterOnay=Makale.OnayDurum.Kabul,BolumEditoruOnay=Makale.OnayDurum.Kabul,EditorOnay=Makale.OnayDurum.Kabul,HakemYorum="abc" },

            };
            foreach (var item in makaleler)
            {
                context.Makaleler.Add(item);
            }
            context.SaveChanges();



            base.Seed(context);
        }
    }
}