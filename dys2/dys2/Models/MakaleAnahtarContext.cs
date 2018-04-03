using dys2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dys2.Models
{
    //2 tane context sınıfı oluşturmuşsun ben bunlardan birini sildim IdentityContext
    //den türeyen sınıf zaten bir dbcontext'dir.
    public class MakaleAnahtarContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AnahtarKelime> AnahtarKelimeler { get; set; }
        public DbSet<Makale> Makaleler { get; set; }

        //Yazar tablosunu ayrı hazırla. Identity tablosu üye bilgilerini tutsun. 
        //ancak yazar bilgileri ayrı bir tabloda olsun.
       

        public MakaleAnahtarContext() : base("MakaleVeri")
        {
            Database.SetInitializer(new MakaleAnahtarInitializer());
        }
    }
}