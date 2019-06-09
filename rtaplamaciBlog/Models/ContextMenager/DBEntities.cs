namespace rtaplamaciBlog.Models.ContextMenager
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBEntities : DbContext
    {

        public DBEntities()
            : base("name=DBEntities")
        {
            Database.SetInitializer<DBEntities>(new Olusturucu());
        }
        public DbSet<AnasayfaAyar> AnasayfaAyarlar { get; set; }
        public DbSet<IletisimAyar> IletisimAyarlar { get; set; }
        public DbSet<BlogYazilari> BlogYazilari { get; set; }
        public DbSet<LGorselAciklamaAyar> LGorselAciklamaAyarlari { get; set; }
        public DbSet<SosyalMedyaAyar> SosyalMedyaAyarlari { get; set; }
        public DbSet<MenuAyar> MenuAyarlari { get; set; }
        public DbSet<FotterAciklamaAyar> FotterAciklamaAyarlari { get; set; }
        public DbSet<FaydaliLinklerAyar> FaydaliLinklerAyarlari { get; set; }
        public DbSet<BlogPanelAyar> BlogPanelAyarlari { get; set; }
        public DbSet<KullaniciAyar> KullaniciAyarlari { get; set; }
    }

    public class Olusturucu : CreateDatabaseIfNotExists<DBEntities>
    {
        protected override void Seed(DBEntities context)
        {
            AnasayfaAyar anasayfaAyar = new AnasayfaAyar();
            anasayfaAyar.MDescripton = "Burada sayfa a��klamas� olacak";
            anasayfaAyar.MAuthor = "Burada sayfa yazar� olacak";
            anasayfaAyar.MUrl = "Burada sayfa urli olacak";
            anasayfaAyar.MKeywords = "Burada sayfa keyworleri olacak";
            anasayfaAyar.STitle = "Burada sayfa ba�l��� olacak";
            anasayfaAyar.GDizin = "logo.png";
            anasayfaAyar.GAlt = "Burada g�rsel a��klamas� olacak";
            anasayfaAyar.BBaslik = "Burada birinci ba�l�k olacak";
            anasayfaAyar.IBaslik = "Burada ikinci ba�l�k olacak";
            anasayfaAyar.SBaslik = "Burada sub ba�l�k olacak";
            anasayfaAyar.Icerik = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum </ p > ";
            context.AnasayfaAyarlar.Add(anasayfaAyar);
            context.SaveChanges();

            IletisimAyar iletisimAyar = new IletisimAyar();
            iletisimAyar.MDescripton = "Burada sayfa a��klamas� olacak";
            iletisimAyar.MAuthor = "Burada sayfa yazar� olacak";
            iletisimAyar.MUrl = "Burada sayfa urli olacak";
            iletisimAyar.MKeywords = "Burada sayfa keyworleri olacak";
            iletisimAyar.STitle = "Burada sayfa ba�l��� olacak";
            iletisimAyar.Baslik = "Burada sub ba�l�k olacak";
            iletisimAyar.Icerik = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum </ p > ";
            context.IletisimAyarlar.Add(iletisimAyar);
            context.SaveChanges();

            BlogPanelAyar blogPanelAyar = new BlogPanelAyar();
            blogPanelAyar.MDescripton = "Burada sayfa a��klamas� olacak";
            blogPanelAyar.MAuthor = "Burada sayfa yazar� olacak";
            blogPanelAyar.MUrl = "Burada sayfa urli olacak";
            blogPanelAyar.MKeywords = "Burada sayfa keyworleri olacak";
            blogPanelAyar.STitle = "Burada sayfa ba�l��� olacak";
            context.BlogPanelAyarlari.Add(blogPanelAyar);
            context.SaveChanges();

            BlogYazilari blogYazilari = new BlogYazilari();
            blogYazilari.YayinlansinMi = true;
            blogYazilari.MDescripton = "Burada sayfa a��klamas� olacak";
            blogYazilari.MAuthor = "Burada sayfa yazar� olacak";
            blogYazilari.MUrl = "Burada sayfa urli olacak";
            blogYazilari.MKeywords = "Burada sayfa keyworleri olacak";
            blogYazilari.STitle = "Burada sayfa ba�l��� olacak";
            blogYazilari.MGDizin = "MG.jpg";
            blogYazilari.MGAlt = "Gorsel A��klamas�";
            blogYazilari.NGDizin = "NG.jpg";
            blogYazilari.NGAlt = "Gorsel A��klamas�";
            blogYazilari.Baslik = "Ramazan Taplamac� - Yaz�l�m Geli�tirici";
            blogYazilari.Tarih = DateTime.Now;
            blogYazilari.Aciklama = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. </ p > ";
            blogYazilari.Icerik = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum </ p > ";
            context.BlogYazilari.Add(blogYazilari);
            context.SaveChanges();
            BlogYazilari blogYazilari2 = new BlogYazilari();
            blogYazilari2.YayinlansinMi = true;
            blogYazilari2.MDescripton = "Burada sayfa a��klamas� olacak";
            blogYazilari2.MAuthor = "Burada sayfa yazar� olacak";
            blogYazilari2.MUrl = "Burada sayfa urli olacak";
            blogYazilari2.MKeywords = "Burada sayfa keyworleri olacak";
            blogYazilari2.STitle = "Burada sayfa ba�l��� olacak";
            blogYazilari2.MGDizin = "MG.jpg";
            blogYazilari2.MGAlt = "Gorsel A��klamas�";
            blogYazilari2.NGDizin = "NG.jpg";
            blogYazilari2.NGAlt = "Gorsel A��klamas�";
            blogYazilari2.Baslik = "#2 Ramazan Taplamac� - Yaz�l�m Geli�tirici";
            blogYazilari2.Tarih = DateTime.Now;
            blogYazilari2.Aciklama = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. </ p > ";
            blogYazilari2.Icerik = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum </ p > ";
            context.BlogYazilari.Add(blogYazilari2);
            context.SaveChanges();

            LGorselAciklamaAyar lGorselAciklamaAyar = new LGorselAciklamaAyar();
            lGorselAciklamaAyar.GDizin = "profile.jpg";
            lGorselAciklamaAyar.GAlt = "G�rsel a��klamas�";
            lGorselAciklamaAyar.Aciklama = "<p>Ramazan Taplamac� </br> Yaz�l�m Geli�tirici </ p >";
            lGorselAciklamaAyar.MAciklama = "<p>Ramazan Taplamac�</p>";
            context.LGorselAciklamaAyarlari.Add(lGorselAciklamaAyar);
            context.SaveChanges();

            SosyalMedyaAyar sosyalMedyaAyar = new SosyalMedyaAyar();
            sosyalMedyaAyar.Icon = "fa fa-twitter";
            sosyalMedyaAyar.Sira = 1;
            sosyalMedyaAyar.Url = "https://twitter.com/rtaplamaci";
            context.SosyalMedyaAyarlari.Add(sosyalMedyaAyar);
            context.SaveChanges();

            SosyalMedyaAyar sosyalMedyaAyar2 = new SosyalMedyaAyar();
            sosyalMedyaAyar2.Icon = "fa fa-instagram";
            sosyalMedyaAyar2.Sira = 2;
            sosyalMedyaAyar2.Url = "https://www.instagram.com/rtaplamaci";
            context.SosyalMedyaAyarlari.Add(sosyalMedyaAyar2);
            context.SaveChanges();

            MenuAyar menuAyar = new MenuAyar();
            menuAyar.Adi = "ANASAYFA";
            menuAyar.Sira = 1;
            menuAyar.Url = "rtaplamaci.com";
            context.MenuAyarlari.Add(menuAyar);
            context.SaveChanges();

            MenuAyar menuAyar2 = new MenuAyar();
            menuAyar2.Adi = "�LET���M";
            menuAyar2.Sira = 2;
            menuAyar2.Url = "/Iletisim";
            context.MenuAyarlari.Add(menuAyar2);
            context.SaveChanges();

            MenuAyar menuAyar3 = new MenuAyar();
            menuAyar3.Adi = "BLOG";
            menuAyar3.Sira = 3;
            menuAyar3.Url = "/Blog";
            context.MenuAyarlari.Add(menuAyar3);
            context.SaveChanges();

            FotterAciklamaAyar fotterAciklamaAyar = new FotterAciklamaAyar();
            fotterAciklamaAyar.Baslik = "Ramazan Taplamac�";
            fotterAciklamaAyar.Aciklama = "Kendisini her konuda geli�tirmek i�in gayret sarfeden bir Yaz�l�m Geli�tiricisi...";
            context.FotterAciklamaAyarlari.Add(fotterAciklamaAyar);
            context.SaveChanges();

            FaydaliLinklerAyar faydaliLinklerAyar = new FaydaliLinklerAyar();
            faydaliLinklerAyar.Adi = "ANASAYFA";
            faydaliLinklerAyar.Sira = 1;
            faydaliLinklerAyar.Url = "rtaplamaci.com";
            context.FaydaliLinklerAyarlari.Add(faydaliLinklerAyar);
            context.SaveChanges();

            FaydaliLinklerAyar faydaliLinklerAyar2 = new FaydaliLinklerAyar();
            faydaliLinklerAyar2.Adi = "�LET���M";
            faydaliLinklerAyar2.Sira = 2;
            faydaliLinklerAyar2.Url = "/Iletisim";
            context.FaydaliLinklerAyarlari.Add(faydaliLinklerAyar2);
            context.SaveChanges();

            FaydaliLinklerAyar faydaliLinklerAyar3 = new FaydaliLinklerAyar();
            faydaliLinklerAyar3.Adi = "BLOG";
            faydaliLinklerAyar3.Sira = 3;
            faydaliLinklerAyar3.Url = "/Blog";
            context.FaydaliLinklerAyarlari.Add(faydaliLinklerAyar3);
            context.SaveChanges();

            KullaniciAyar kullaniciAyar = new KullaniciAyar();
            kullaniciAyar.KullaniciAdi = "21232f297a57a5a743894a0e4a801fc3";
            kullaniciAyar.Sifre = "21232f297a57a5a743894a0e4a801fc3";
            kullaniciAyar.Email = "mail@mail.ccc";
            kullaniciAyar.EmailSifre = "EmailSifresi";
            context.KullaniciAyarlari.Add(kullaniciAyar);
            context.SaveChanges();
        }
    }
}
