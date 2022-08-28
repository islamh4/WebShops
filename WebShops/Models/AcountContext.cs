using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShops.Models
{
    public class AcountContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adidas> Adidases { get; set; }
        public DbSet<Fishing> Fishings { get; set; }
        public DbSet<Hunting> Huntings { get; set; }
        public DbSet<Nike> Nikes { get; set; }
        public DbSet<Pyaterochka> Pyaterochkas { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

    }
    public class DatabaseInitializer : DropCreateDatabaseAlways<AcountContext>
    {
        protected override void Seed(AcountContext db)
        {
            db.Adidases.Add(new Adidas() { Name = "Мужские кроссовки", Price = 4310, Foto = "https://spb.streetfoot.ru/wp-content/uploads/2018/12/1537ade6e.jpg" });
            db.Adidases.Add(new Adidas() { Name = "Костюм спортивный B TEAM TS", Price = 7399, Foto = "https://www.rossisport.com/cms/files/original/99242-dv2423-ind.jpg" });
            db.Adidases.Add(new Adidas() { Name = "Кроссовки GALAXY 5", Price = 4999, Foto = "https://images.sturm-shop.ru/e/31/e31fa518878694044278554b45f67981.jpg" });
            db.Adidases.Add(new Adidas() { Name = "Кроссовки FORTARUN AC K", Price = 3799, Foto = "https://cdn1.ozone.ru/multimedia/1029784794.jpg" });
            db.Adidases.Add(new Adidas() { Name = "Кеды ENTRAP", Price = 6399, Foto = "https://avatars.mds.yandex.net/i?id=2a00000179e29076817ed1ab81e61dd9558d-4078138-images-thumbs&n=13" });
            base.Seed(db);
            db.Fishings.Add(new Fishing() { Name = "Удилище Krevetka WOLF", Price = 360, Foto = "https://images.wbstatic.net/big/new/30030000/30031480-1.jpg" });
            db.Fishings.Add(new Fishing() { Name = "Катушка Stinger Innova Ultralight 2004", Price = 7490, Foto = "https://avatars.mds.yandex.net/i?id=cf9843875b5cc55c5f49bfaac6329151-5507408-images-thumbs&n=13" });
            db.Fishings.Add(new Fishing() { Name = "Ящик рыболовный трехполочный", Price = 945, Foto = "https://avatars.mds.yandex.net/i?id=e631232fa43668743e4130734f8e6b5b-5885465-images-thumbs&n=13" });
            db.Fishings.Add(new Fishing() { Name = "Эхолот Практик 8", Price = 20900, Foto = "https://avatars.mds.yandex.net/i?id=b03a2c7c5aed838dfb720e58cf55bc0f-4748118-images-thumbs&n=13" });
            db.Fishings.Add(new Fishing() { Name = "Подводная камера ЯЗЬ-52 Актив 7", Price = 26100, Foto = "https://avatars.mds.yandex.net/i?id=4e900fedc3add6a8dbe25c14a2e1601d-5116917-images-thumbs&n=13" });
            base.Seed(db);
            db.Huntings.Add(new Hunting() { Name = "Ружье Beretta Bellmonte I 12x76 Synthetic 760мм", Price = 136038, Foto = "https://avatars.mds.yandex.net/i?id=46ae968636f501d21ee638b310ae68b3-5238951-images-thumbs&n=13" });
            db.Huntings.Add(new Hunting() { Name = "Карабин Тула КО ВСС 9х39", Price = 209521, Foto = "https://avatars.mds.yandex.net/i?id=e5a1f29ae96ae7a8f0c0ed676d94f3d6-4248407-images-thumbs&n=13" });
            db.Huntings.Add(new Hunting() { Name = "Ружье Benelli M4 Super 90 12х76 550мм", Price = 384048, Foto = "https://avatars.mds.yandex.net/i?id=e2f388a12c4ba02c5cf07ce2562060c4-4518650-images-thumbs&n=13" });
            db.Huntings.Add(new Hunting() { Name = "Ружье Benelli Vinci Black 12х76 760мм", Price = 305088, Foto = "https://avatars.mds.yandex.net/i?id=2a00000179fb4f443f331c64afcf77edf41a-3193980-images-thumbs&n=13" });
            db.Huntings.Add(new Hunting() { Name = "Карабин Baikal МР 94 7,62х54 доп.ствол 12х76 725мм орех", Price = 84190, Foto = "https://avatars.mds.yandex.net/i?id=e496b316e3121dc915ae2fd47e55ef0a-4292261-images-thumbs&n=13" });
            base.Seed(db);
            db.Nikes.Add(new Nike() { Name = "Куртка Nike", Price = 10887, Foto = "https://avatars.mds.yandex.net/i?id=102586a2946fd611fb3a55dc6c22c4aa-5204758-images-thumbs&n=13" });
            db.Nikes.Add(new Nike() { Name = "Кеды Nike", Price = 2599, Foto = "https://avatars.mds.yandex.net/i?id=52969d28b8e86bf8a4871b25b7eeed95-4501055-images-thumbs&n=13" });
            db.Nikes.Add(new Nike() { Name = "Толстовка Nike", Price = 6618, Foto = "https://avatars.mds.yandex.net/i?id=151aa0ac1a606f140ec372345b495c94-6478260-images-thumbs&n=13" });
            db.Nikes.Add(new Nike() { Name = "Сумка спортивная Nike", Price = 11367, Foto = "https://avatars.mds.yandex.net/i?id=7ca8209bb15aa8884a24be4722e2ed57-5897487-images-thumbs&n=13" });
            db.Nikes.Add(new Nike() { Name = "Кросовки Nike", Price = 5252, Foto = "https://avatars.mds.yandex.net/i?id=fa7bc02dc4e6f1e025aa046c51b3f939-4824877-images-thumbs&n=13" });
            base.Seed(db);
            db.Pyaterochkas.Add(new Pyaterochka() { Name = "Яблоко", Price = 28, Foto = "https://avatars.mds.yandex.net/i?id=cb7abfcef49e1bb31f76a7d93c0f7fa4-5270397-images-thumbs&n=13" });
            db.Pyaterochkas.Add(new Pyaterochka() { Name = "Банан", Price = 25, Foto = "https://avatars.mds.yandex.net/i?id=aec76d1d9ef04fafd8216305f5c44c9f-5425024-images-thumbs&n=13" });
            db.Pyaterochkas.Add(new Pyaterochka() { Name = "Арбуз", Price = 154, Foto = "https://avatars.mds.yandex.net/i?id=be5955b8b9fb5ffbc864b81dcb9de03f-5234598-images-thumbs&n=13" });
            db.Pyaterochkas.Add(new Pyaterochka() { Name = "Дыня", Price = 168, Foto = "https://avatars.mds.yandex.net/i?id=a1fe6ee7b818dba97e58219ed4d5b94b-4233036-images-thumbs&n=13" });
            db.Pyaterochkas.Add(new Pyaterochka() { Name = "Груша", Price = 57, Foto = "https://avatars.mds.yandex.net/i?id=bcb9114d85fd8998e6f3056fe660933a-3370318-images-thumbs&n=13" });
            base.Seed(db);
        }
    }
}