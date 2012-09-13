namespace Membership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Membership.Data.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<MembershipDB>
    {
        protected override void Seed(MembershipDB context)
        {

            #region Genders

            if (!context.Genders.Any(x => x.Name == "Erkek"))
            {
                context.Genders.AddOrUpdate(
                    new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Erkek" },
                    new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Kadın" },
                    new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Unisex" },
                    new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Diğer" });

                context.SaveChanges();
            }

            #endregion

            #region UserTypes

            if (!context.UserTypes.Any(x => x.Name == "Müşteri"))
            {
                context.UserTypes.AddOrUpdate(new UserType { Name = "Müşteri", Description = string.Empty, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 });

                context.SaveChanges();
            }

            #endregion

            #region Countries

            var countryTurkey = new Country
            {
                Id = 90,
                CountryCode = "TR",
                Name = "Türkiye Cumhuriyeti",
                ShortName = "Türkiye",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                UpdatedBy = 1
            };

            if (!context.Countries.Any(x => x.ShortName == "Türkiye"))
            {
                context.Countries.AddOrUpdate(countryTurkey);
                context.SaveChanges();
            }

            #endregion

            #region GeoZones

            var marmara = new GeoZone { Country = countryTurkey, Name = "Marmara", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var akdeniz = new GeoZone { Country = countryTurkey, Name = "Ege", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var karadeniz = new GeoZone { Country = countryTurkey, Name = "Akdeniz", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var ege = new GeoZone { Country = countryTurkey, Name = "Karadeniz", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var icAnadolu = new GeoZone { Country = countryTurkey, Name = "Doğu Anadolu", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var doguAnadolu = new GeoZone { Country = countryTurkey, Name = "İç Anadolu", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var guneydoguAnadolu = new GeoZone { Country = countryTurkey, Name = "Güneydoğu Anadolu", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };

            if (!context.GeoZones.Any(x => x.Name == "Marmara"))
            {
                context.GeoZones.AddOrUpdate(marmara, akdeniz, karadeniz, ege, icAnadolu, doguAnadolu, guneydoguAnadolu);

                context.SaveChanges();
            }

            #endregion

            #region LogEvents

            if (!context.LogEvents.Any(x => x.Name == "Programatic Update"))
            {
                context.LogEvents.AddOrUpdate(
                        new LogEvent { Name = "Programatic Update", Description = "A data manipulation via code", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                        new LogEvent { Name = "Admin Panel Data Update", Description = "An update, insert or delete action occured", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                        new LogEvent { Name = "Password Changed", Description = "A user changed password", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 });

                context.SaveChanges();
            }

            #endregion

            #region PointEvents

            if (!context.PointTypes.Any(x => x.Name == "Sayfa Ziyareti"))
            {
                context.PointTypes.AddOrUpdate(
                    new PointType { Name = "Sayfa Ziyareti", Point = 1, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                    new PointType { Name = "Temsilci Takibi", Point = 5, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                    new PointType { Name = "Paylaşım", Point = 10, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                    new PointType { Name = "Arkadaş Daveti", Point = 5, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                    new PointType { Name = "Ürün Alımı", Point = 100, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                    new PointType { Name = "Davet Edilen Arkadaşın Üye Olması", Point = 25, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 });

                context.SaveChanges();
            }

            #endregion

            #region Cities

            if (!context.Cities.Any(x => x.Name == "Adana"))
            {
                AddCity(01, "Adana", akdeniz, context);
                AddCity(02, "Adıyaman", guneydoguAnadolu, context);
                AddCity(03, "Afyonkarahisar", ege, context);
                AddCity(04, "Ağrı", doguAnadolu, context);
                AddCity(05, "Amasya", karadeniz, context);
                AddCity(06, "Ankara", icAnadolu, context);
                AddCity(07, "Antalya", akdeniz, context);
                AddCity(08, "Artvin", karadeniz, context);
                AddCity(09, "Aydın", ege, context);
                AddCity(10, "Balıkesir", marmara, context);
                AddCity(11, "Bilecik", marmara, context);
                AddCity(12, "Bingöl", doguAnadolu, context);
                AddCity(13, "Bitlis", doguAnadolu, context);
                AddCity(14, "Bolu", karadeniz, context);
                AddCity(15, "Burdur", akdeniz, context);
                AddCity(16, "Bursa", marmara, context);
                AddCity(17, "Çanakkale", marmara, context);
                AddCity(18, "Çankırı", icAnadolu, context);
                AddCity(19, "Çorum", karadeniz, context);
                AddCity(20, "Denizli", ege, context);
                AddCity(21, "Diyarbakır", guneydoguAnadolu, context);
                AddCity(22, "Edirne", marmara, context);
                AddCity(23, "Elazığ", doguAnadolu, context);
                AddCity(24, "Erzincan", doguAnadolu, context);
                AddCity(25, "Erzurum", doguAnadolu, context);
                AddCity(26, "Eskişehir", icAnadolu, context);
                AddCity(27, "Gaziantep", guneydoguAnadolu, context);
                AddCity(28, "Giresun", karadeniz, context);
                AddCity(29, "Gümüşhane", karadeniz, context);
                AddCity(30, "Hakkari", doguAnadolu, context);
                AddCity(31, "Hatay", akdeniz, context);
                AddCity(32, "Isparta", akdeniz, context);
                AddCity(33, "Mersin", akdeniz, context);
                AddCity(34, "İstanbul", marmara, context);
                AddCity(35, "İzmir", ege, context);
                AddCity(36, "Kars", doguAnadolu, context);
                AddCity(37, "Kastamonu", karadeniz, context);
                AddCity(38, "Kayseri", icAnadolu, context);
                AddCity(39, "Kırklareli", marmara, context);
                AddCity(40, "Kırşehir", icAnadolu, context);
                AddCity(41, "Kocaeli", marmara, context);
                AddCity(42, "Konya", icAnadolu, context);
                AddCity(43, "Kütahya", ege, context);
                AddCity(44, "Malatya", doguAnadolu, context);
                AddCity(45, "Manisa", ege, context);
                AddCity(46, "Kahramanmaraş", akdeniz, context);
                AddCity(47, "Mardin", guneydoguAnadolu, context);
                AddCity(48, "Muğla", ege, context);
                AddCity(49, "Muş", doguAnadolu, context);
                AddCity(50, "Nevşehir", icAnadolu, context);
                AddCity(51, "Niğde", icAnadolu, context);
                AddCity(52, "Ordu", karadeniz, context);
                AddCity(53, "Rize", karadeniz, context);
                AddCity(54, "Sakarya", marmara, context);
                AddCity(55, "Samsun", karadeniz, context);
                AddCity(56, "Siirt", guneydoguAnadolu, context);
                AddCity(57, "Sinop", karadeniz, context);
                AddCity(58, "Sivas", icAnadolu, context);
                AddCity(59, "Tekirdağ", marmara, context);
                AddCity(60, "Tokat", icAnadolu, context);
                AddCity(61, "Trabzon", karadeniz, context);
                AddCity(62, "Tunceli", doguAnadolu, context);
                AddCity(63, "Şanlıurfa", guneydoguAnadolu, context);
                AddCity(64, "Uşak", ege, context);
                AddCity(65, "Van", doguAnadolu, context);
                AddCity(66, "Yozgat", icAnadolu, context);
                AddCity(67, "Zonguldak", karadeniz, context);
                AddCity(68, "Aksaray", icAnadolu, context);
                AddCity(69, "Bayburt", karadeniz, context);
                AddCity(70, "Karaman", icAnadolu, context);
                AddCity(71, "Kırıkkale", icAnadolu, context);
                AddCity(72, "Batman", guneydoguAnadolu, context);
                AddCity(73, "Şırnak", doguAnadolu, context);
                AddCity(74, "Bartın", karadeniz, context);
                AddCity(75, "Ardahan", doguAnadolu, context);
                AddCity(76, "Iğdır", doguAnadolu, context);
                AddCity(77, "Yalova", marmara, context);
                AddCity(78, "Karabük", karadeniz, context);
                AddCity(79, "Kilis", guneydoguAnadolu, context);
                AddCity(80, "Osmaniye", akdeniz, context);
                AddCity(81, "Düzce", karadeniz, context);
            }

            context.SaveChanges();

            #endregion

            #region Counties

            if (!context.Counties.Any(x => x.Name == "Aladağ"))
            {
                AddCounty("Seyhan", 1, context);
                AddCounty("Ceyhan", 1, context);
                AddCounty("Feke", 1, context);
                AddCounty("Karaisalı", 1, context);
                AddCounty("Karataş", 1, context);
                AddCounty("Kozan", 1, context);
                AddCounty("Pozantı", 1, context);
                AddCounty("Saimbeyli", 1, context);
                AddCounty("Tufanbeyli", 1, context);
                AddCounty("Yumurtalık", 1, context);
                AddCounty("Yüreğir", 1, context);
                AddCounty("Aladağ", 1, context);
                AddCounty("İmamoğlu", 1, context);
                AddCounty("Sarıçam", 1, context);
                AddCounty("Çukurova", 1, context);
                AddCounty("Merkez", 1, context);
                AddCounty("Sincik", 2, context);
                AddCounty("Tut", 2, context);
                AddCounty("Samsat", 2, context);
                AddCounty("Kahta", 2, context);
                AddCounty("Gerger", 2, context);
                AddCounty("Gölbaşı", 2, context);
                AddCounty("Çelikhan", 2, context);
                AddCounty("Besni", 2, context);
                AddCounty("Merkez", 2, context);
                AddCounty("Merkez", 3, context);
                AddCounty("Bolvadin", 3, context);
                AddCounty("Çay", 3, context);
                AddCounty("Dazkırı", 3, context);
                AddCounty("Dinar", 3, context);
                AddCounty("Emirdağ", 3, context);
                AddCounty("İhsaniye", 3, context);
                AddCounty("Sandıklı", 3, context);
                AddCounty("Sinanpaşa", 3, context);
                AddCounty("Sultandağı", 3, context);
                AddCounty("Şuhut", 3, context);
                AddCounty("Kızılören", 3, context);
                AddCounty("İscehisar", 3, context);
                AddCounty("Başmakçı", 3, context);
                AddCounty("Bayat", 3, context);
                AddCounty("Çobanlar", 3, context);
                AddCounty("Evciler", 3, context);
                AddCounty("Hocalar", 3, context);
                AddCounty("Tutak", 4, context);
                AddCounty("Taşlıçay", 4, context);
                AddCounty("Patnos", 4, context);
                AddCounty("Eleşkirt", 4, context);
                AddCounty("Diyadin", 4, context);
                AddCounty("Doğubayazıt", 4, context);
                AddCounty("Hamur", 4, context);
                AddCounty("Merkez", 4, context);
                AddCounty("Merkez", 5, context);
                AddCounty("Göynücek", 5, context);
                AddCounty("Gümüşhacıköy", 5, context);
                AddCounty("Taşova", 5, context);
                AddCounty("Suluova", 5, context);
                AddCounty("Merzifon", 5, context);
                AddCounty("Hamamözü", 5, context);
                AddCounty("Evren", 6, context);
                AddCounty("Etimesgut", 6, context);
                AddCounty("Akyurt", 6, context);
                AddCounty("Gölbaşı", 6, context);
                AddCounty("Keçiören", 6, context);
                AddCounty("Mamak", 6, context);
                AddCounty("Sincan", 6, context);
                AddCounty("Yenimahalle", 6, context);
                AddCounty("Kazan", 6, context);
                AddCounty("Cebeci", 6, context);
                AddCounty("Anıttepe", 6, context);
                AddCounty("Pursaklar", 6, context);
                AddCounty("Kızılcahamam", 6, context);
                AddCounty("Kalecik", 6, context);
                AddCounty("Şereflikoçhisar", 6, context);
                AddCounty("Polatlı", 6, context);
                AddCounty("Nallıhan", 6, context);
                AddCounty("Güdül", 6, context);
                AddCounty("Haymana", 6, context);
                AddCounty("Elmadağ", 6, context);
                AddCounty("Çubuk", 6, context);
                AddCounty("Ayaş", 6, context);
                AddCounty("Bala", 6, context);
                AddCounty("Altındağ", 6, context);
                AddCounty("Çankaya", 6, context);
                AddCounty("Çamlıdere", 6, context);
                AddCounty("Beypazarı", 6, context);
                AddCounty("Merkez", 7, context);
                AddCounty("Akseki", 7, context);
                AddCounty("Alanya", 7, context);
                AddCounty("Elmalı", 7, context);
                AddCounty("Gündoğmuş", 7, context);
                AddCounty("Finike", 7, context);
                AddCounty("Gazipaşa", 7, context);
                AddCounty("Serik", 7, context);
                AddCounty("Kaş", 7, context);
                AddCounty("Korkuteli", 7, context);
                AddCounty("Kumluca", 7, context);
                AddCounty("Manavgat", 7, context);
                AddCounty("Döşemealtı", 7, context);
                AddCounty("Kepez", 7, context);
                AddCounty("Konyaaltı", 7, context);
                AddCounty("Muratpaşa", 7, context);
                AddCounty("Aksu", 7, context);
                AddCounty("Belek", 7, context);
                AddCounty("Kemer", 7, context);
                AddCounty("Demre", 7, context);
                AddCounty("İbradı", 7, context);
                AddCounty("Murgul", 8, context);
                AddCounty("Yusufeli", 8, context);
                AddCounty("Hopa", 8, context);
                AddCounty("Şavşat", 8, context);
                AddCounty("Merkez", 8, context);
                AddCounty("Ardanuç", 8, context);
                AddCounty("Arhavi", 8, context);
                AddCounty("Borçka", 8, context);
                AddCounty("Bozdoğan", 9, context);
                AddCounty("Merkez", 9, context);
                AddCounty("Germencik", 9, context);
                AddCounty("Çine", 9, context);
                AddCounty("Sultanhisar", 9, context);
                AddCounty("Söke", 9, context);
                AddCounty("Nazilli", 9, context);
                AddCounty("Karacasu", 9, context);
                AddCounty("Kuşadası", 9, context);
                AddCounty("Kuyucak", 9, context);
                AddCounty("Koçarlı", 9, context);
                AddCounty("Yenipazar", 9, context);
                AddCounty("İncirliova", 9, context);
                AddCounty("Buharkent", 9, context);
                AddCounty("Karpuzlu", 9, context);
                AddCounty("Köşk", 9, context);
                AddCounty("Didim (Yenihisar)", 9, context);
                AddCounty("Marmara", 10, context);
                AddCounty("Gömeç", 10, context);
                AddCounty("Manyas", 10, context);
                AddCounty("Kepsut", 10, context);
                AddCounty("İvrindi", 10, context);
                AddCounty("Sındırgı", 10, context);
                AddCounty("Savaştepe", 10, context);
                AddCounty("Susurluk", 10, context);
                AddCounty("Erdek", 10, context);
                AddCounty("Dursunbey", 10, context);
                AddCounty("Edremit", 10, context);
                AddCounty("Havran", 10, context);
                AddCounty("Gönen", 10, context);
                AddCounty("Ayvalık", 10, context);
                AddCounty("Merkez", 10, context);
                AddCounty("Balya", 10, context);
                AddCounty("Bandırma", 10, context);
                AddCounty("Bigadiç", 10, context);
                AddCounty("Burhaniye", 10, context);
                AddCounty("Merkez", 11, context);
                AddCounty("Bozüyük", 11, context);
                AddCounty("Gölpazarı", 11, context);
                AddCounty("Söğüt", 11, context);
                AddCounty("Osmaneli", 11, context);
                AddCounty("Pazaryeri", 11, context);
                AddCounty("İnhisar", 11, context);
                AddCounty("Yenipazar", 11, context);
                AddCounty("Yayladere", 12, context);
                AddCounty("Adaklı", 12, context);
                AddCounty("Yedisu", 12, context);
                AddCounty("Solhan", 12, context);
                AddCounty("Karlıova", 12, context);
                AddCounty("Kiğı", 12, context);
                AddCounty("Genç", 12, context);
                AddCounty("Merkez", 12, context);
                AddCounty("Merkez", 13, context);
                AddCounty("Ahlat", 13, context);
                AddCounty("Adilcevaz", 13, context);
                AddCounty("Hizan", 13, context);
                AddCounty("Tatvan", 13, context);
                AddCounty("Mutki", 13, context);
                AddCounty("Güroymak", 13, context);
                AddCounty("Dörtdivan", 14, context);
                AddCounty("Yeniçağa", 14, context);
                AddCounty("Seben", 14, context);
                AddCounty("Kıbrıscık", 14, context);
                AddCounty("Mengen", 14, context);
                AddCounty("Mudurnu", 14, context);
                AddCounty("Merkez", 14, context);
                AddCounty("Gerede", 14, context);
                AddCounty("Göynük", 14, context);
                AddCounty("Gölhisar", 15, context);
                AddCounty("Bucak", 15, context);
                AddCounty("Merkez", 15, context);
                AddCounty("Ağlasun", 15, context);
                AddCounty("Tefenni", 15, context);
                AddCounty("Çeltikçi", 15, context);
                AddCounty("Çavdır", 15, context);
                AddCounty("Altınyayla", 15, context);
                AddCounty("Karamanlı", 15, context);
                AddCounty("Kemer", 15, context);
                AddCounty("Yeşilova", 15, context);
                AddCounty("Yenişehir", 16, context);
                AddCounty("Harmancık", 16, context);
                AddCounty("Büyükorhan", 16, context);
                AddCounty("Nilüfer", 16, context);
                AddCounty("Osmangazi", 16, context);
                AddCounty("Yıldırım", 16, context);
                AddCounty("Gürsu", 16, context);
                AddCounty("Kestel", 16, context);
                AddCounty("Mustafa K.Paşa", 16, context);
                AddCounty("Orhaneli", 16, context);
                AddCounty("Orhangazi", 16, context);
                AddCounty("Mudanya", 16, context);
                AddCounty("İnegöl", 16, context);
                AddCounty("İznik", 16, context);
                AddCounty("Keles", 16, context);
                AddCounty("Karacabey", 16, context);
                AddCounty("Gemlik", 16, context);
                AddCounty("Gelibolu", 17, context);
                AddCounty("Ezine", 17, context);
                AddCounty("Eceabat", 17, context);
                AddCounty("Ayvacık", 17, context);
                AddCounty("Çan", 17, context);
                AddCounty("Merkez", 17, context);
                AddCounty("Bozcaada", 17, context);
                AddCounty("Biga", 17, context);
                AddCounty("Bayramiç", 17, context);
                AddCounty("Gökçeada", 17, context);
                AddCounty("Lapseki", 17, context);
                AddCounty("Yenice", 17, context);
                AddCounty("Yapraklı", 18, context);
                AddCounty("Kızılırmak", 18, context);
                AddCounty("Atkaracalar", 18, context);
                AddCounty("Bayramören", 18, context);
                AddCounty("Korgun", 18, context);
                AddCounty("Kurşunlu", 18, context);
                AddCounty("Ilgaz", 18, context);
                AddCounty("Orta", 18, context);
                AddCounty("Şabanözü", 18, context);
                AddCounty("Merkez", 18, context);
                AddCounty("Eldivan", 18, context);
                AddCounty("Çerkeş", 18, context);
                AddCounty("Merkez", 19, context);
                AddCounty("Bayat", 19, context);
                AddCounty("Alaca", 19, context);
                AddCounty("Sungurlu", 19, context);
                AddCounty("Ortaköy", 19, context);
                AddCounty("Osmancık", 19, context);
                AddCounty("İskilip", 19, context);
                AddCounty("Kargı", 19, context);
                AddCounty("Mecitözü", 19, context);
                AddCounty("Laçin", 19, context);
                AddCounty("Oğuzlar", 19, context);
                AddCounty("Dodurga", 19, context);
                AddCounty("Uğurludağ", 19, context);
                AddCounty("Boğazkale", 19, context);
                AddCounty("Bekilli", 20, context);
                AddCounty("Babadağ", 20, context);
                AddCounty("Honaz", 20, context);
                AddCounty("Serinhisar", 20, context);
                AddCounty("Akköy", 20, context);
                AddCounty("Baklan", 20, context);
                AddCounty("Beyağaç", 20, context);
                AddCounty("Bozkurt", 20, context);
                AddCounty("Kale", 20, context);
                AddCounty("Sarayköy", 20, context);
                AddCounty("Tavas", 20, context);
                AddCounty("Acıpayam", 20, context);
                AddCounty("Çardak", 20, context);
                AddCounty("Çal", 20, context);
                AddCounty("Buldan", 20, context);
                AddCounty("Merkez", 20, context);
                AddCounty("Çameli", 20, context);
                AddCounty("Çivril", 20, context);
                AddCounty("Güney", 20, context);
                AddCounty("Hani", 21, context);
                AddCounty("Ergani", 21, context);
                AddCounty("Çüngüş", 21, context);
                AddCounty("Çınar", 21, context);
                AddCounty("Çermik", 21, context);
                AddCounty("Dicle", 21, context);
                AddCounty("Merkez", 21, context);
                AddCounty("Bismil", 21, context);
                AddCounty("Silvan", 21, context);
                AddCounty("Hazro", 21, context);
                AddCounty("Lice", 21, context);
                AddCounty("Kulp", 21, context);
                AddCounty("Eğil", 21, context);
                AddCounty("Kocaköy", 21, context);
                AddCounty("Yenişehir", 21, context);
                AddCounty("Bağlar", 21, context);
                AddCounty("Kayapınar", 21, context);
                AddCounty("Sur", 21, context);
                AddCounty("Süloğlu", 22, context);
                AddCounty("Uzunköprü", 22, context);
                AddCounty("Keşan", 22, context);
                AddCounty("Lalapaşa", 22, context);
                AddCounty("Meriç", 22, context);
                AddCounty("İpsala", 22, context);
                AddCounty("Merkez", 22, context);
                AddCounty("Enez", 22, context);
                AddCounty("Havsa", 22, context);
                AddCounty("Merkez", 23, context);
                AddCounty("Ağın", 23, context);
                AddCounty("Baskil", 23, context);
                AddCounty("Karakoçan", 23, context);
                AddCounty("Keban", 23, context);
                AddCounty("Maden", 23, context);
                AddCounty("Sivrice", 23, context);
                AddCounty("Palu", 23, context);
                AddCounty("Arıcak", 23, context);
                AddCounty("Alacakaya", 23, context);
                AddCounty("Kovancılar", 23, context);
                AddCounty("Üzümlü", 24, context);
                AddCounty("Otlukbeli", 24, context);
                AddCounty("Refahiye", 24, context);
                AddCounty("Tercan", 24, context);
                AddCounty("Kemah", 24, context);
                AddCounty("Kemaliye", 24, context);
                AddCounty("İliç", 24, context);
                AddCounty("Çayırlı", 24, context);
                AddCounty("Merkez", 24, context);
                AddCounty("Merkez", 25, context);
                AddCounty("Çat", 25, context);
                AddCounty("Aşkale", 25, context);
                AddCounty("Hınıs", 25, context);
                AddCounty("Horasan", 25, context);
                AddCounty("İspir", 25, context);
                AddCounty("Karayazı", 25, context);
                AddCounty("Şenkaya", 25, context);
                AddCounty("Pasinler", 25, context);
                AddCounty("Oltu", 25, context);
                AddCounty("Olur", 25, context);
                AddCounty("Narman", 25, context);
                AddCounty("Köprüköy", 25, context);
                AddCounty("Aziziye", 25, context);
                AddCounty("Plandöken", 25, context);
                AddCounty("Yakutiye", 25, context);
                AddCounty("Pazaryolu", 25, context);
                AddCounty("Uzundere", 25, context);
                AddCounty("Ilıca", 25, context);
                AddCounty("Karaçoban", 25, context);
                AddCounty("Tekman", 25, context);
                AddCounty("Tortum", 25, context);
                AddCounty("İnönü", 26, context);
                AddCounty("Alpu", 26, context);
                AddCounty("Beylikova", 26, context);
                AddCounty("Günyüzü", 26, context);
                AddCounty("Han", 26, context);
                AddCounty("Odunpazarı", 26, context);
                AddCounty("Tepebaşı", 26, context);
                AddCounty("Mihalgazi", 26, context);
                AddCounty("Sarıcakaya", 26, context);
                AddCounty("Sivrihisar", 26, context);
                AddCounty("Seyitgazi", 26, context);
                AddCounty("Mahmudiye", 26, context);
                AddCounty("Mihalıççık", 26, context);
                AddCounty("Merkez", 26, context);
                AddCounty("Çifteler", 26, context);
                AddCounty("Araban", 27, context);
                AddCounty("İslahiye", 27, context);
                AddCounty("Nizip", 27, context);
                AddCounty("Oğuzeli", 27, context);
                AddCounty("Nurdağı", 27, context);
                AddCounty("Karkamış", 27, context);
                AddCounty("Şehitkamil", 27, context);
                AddCounty("Şahinbey", 27, context);
                AddCounty("Yavuzeli", 27, context);
                AddCounty("Tirebolu", 28, context);
                AddCounty("Piraziz", 28, context);
                AddCounty("Yağlıdere", 28, context);
                AddCounty("Güce", 28, context);
                AddCounty("Çamoluk", 28, context);
                AddCounty("Çanakçı", 28, context);
                AddCounty("Doğankent", 28, context);
                AddCounty("Şebinkarahisar", 28, context);
                AddCounty("Keşap", 28, context);
                AddCounty("Alucra", 28, context);
                AddCounty("Bulancak", 28, context);
                AddCounty("Dereli", 28, context);
                AddCounty("Espiye", 28, context);
                AddCounty("Eynesil", 28, context);
                AddCounty("Merkez", 28, context);
                AddCounty("Görele", 28, context);
                AddCounty("Merkez", 29, context);
                AddCounty("Kelkit", 29, context);
                AddCounty("Şiran", 29, context);
                AddCounty("Köse", 29, context);
                AddCounty("Torul", 29, context);
                AddCounty("Kürtün", 29, context);
                AddCounty("Yüksekova", 30, context);
                AddCounty("Şemdinli", 30, context);
                AddCounty("Merkez", 30, context);
                AddCounty("Çukurca", 30, context);
                AddCounty("Dörtyol", 31, context);
                AddCounty("Hassa", 31, context);
                AddCounty("Merkez", 31, context);
                AddCounty("Altınözü", 31, context);
                AddCounty("Samandağı", 31, context);
                AddCounty("Reyhanlı", 31, context);
                AddCounty("İskenderun", 31, context);
                AddCounty("Kırıkhan", 31, context);
                AddCounty("Yayladağ", 31, context);
                AddCounty("Erzin", 31, context);
                AddCounty("Belen", 31, context);
                AddCounty("Kumlu", 31, context);
                AddCounty("Yenişarbademli", 32, context);
                AddCounty("Gönen", 32, context);
                AddCounty("Aksu", 32, context);
                AddCounty("Yalvaç", 32, context);
                AddCounty("Uluborlu", 32, context);
                AddCounty("Merkez", 32, context);
                AddCounty("Keçiborlu", 32, context);
                AddCounty("Senirkent", 32, context);
                AddCounty("Şarkikaraağaç", 32, context);
                AddCounty("Sütçüler", 32, context);
                AddCounty("Atabey", 32, context);
                AddCounty("Gelendost", 32, context);
                AddCounty("Eğirdir", 32, context);
                AddCounty("Erdemli", 33, context);
                AddCounty("Gülnar", 33, context);
                AddCounty("Anamur", 33, context);
                AddCounty("Tarsus", 33, context);
                AddCounty("Silifke", 33, context);
                AddCounty("Mut", 33, context);
                AddCounty("Merkez", 33, context);
                AddCounty("Bozyazı", 33, context);
                AddCounty("Aydıncık", 33, context);
                AddCounty("Çamlıyayla", 33, context);
                AddCounty("Mezitli", 33, context);
                AddCounty("Yenişehir", 33, context);
                AddCounty("Bahçeşehir", 34, context);
                AddCounty("Maltepe", 34, context);
                AddCounty("Arnavutköy", 34, context);
                AddCounty("Ataşehir", 34, context);
                AddCounty("Başakşehir", 34, context);
                AddCounty("Beylikdüzü", 34, context);
                AddCounty("Sultangazi", 34, context);
                AddCounty("Esenyurt", 34, context);
                AddCounty("Sancaktepe", 34, context);
                AddCounty("Çekmeköy", 34, context);
                AddCounty("Avcılar", 34, context);
                AddCounty("Bağcılar", 34, context);
                AddCounty("Bahçelievler", 34, context);
                AddCounty("Güngören", 34, context);
                AddCounty("Sultanbeyli", 34, context);
                AddCounty("Tuzla", 34, context);
                AddCounty("Esenler", 34, context);
                AddCounty("Bayrampaşa", 34, context);
                AddCounty("Küçükçekmece", 34, context);
                AddCounty("Pendik", 34, context);
                AddCounty("Ümraniye", 34, context);
                AddCounty("Büyükçekmece", 34, context);
                AddCounty("Kağıthane", 34, context);
                AddCounty("Üsküdar", 34, context);
                AddCounty("Zeytinburnu", 34, context);
                AddCounty("Kadıköy", 34, context);
                AddCounty("Kartal", 34, context);
                AddCounty("Sarıyer", 34, context);
                AddCounty("Silivri", 34, context);
                AddCounty("Şişli", 34, context);
                AddCounty("Şile", 34, context);
                AddCounty("Bakırköy", 34, context);
                AddCounty("Adalar", 34, context);
                AddCounty("Beşiktaş", 34, context);
                AddCounty("Beykoz", 34, context);
                AddCounty("Beyoğlu", 34, context);
                AddCounty("Çatalca", 34, context);
                AddCounty("Gaziosmanpaşa", 34, context);
                AddCounty("Eyüp", 34, context);
                AddCounty("Fatih", 34, context);
                AddCounty("Eminönü", 34, context);
                AddCounty("Dikili", 35, context);
                AddCounty("Çeşme", 35, context);
                AddCounty("Foça", 35, context);
                AddCounty("Bergama", 35, context);
                AddCounty("Bayındır", 35, context);
                AddCounty("Bornova", 35, context);
                AddCounty("Aliağa", 35, context);
                AddCounty("Seferihisar", 35, context);
                AddCounty("Selçuk", 35, context);
                AddCounty("Ödemiş", 35, context);
                AddCounty("Karşıyaka", 35, context);
                AddCounty("Kemalpaşa", 35, context);
                AddCounty("Karaburun", 35, context);
                AddCounty("Kınık", 35, context);
                AddCounty("Kiraz", 35, context);
                AddCounty("Menemen", 35, context);
                AddCounty("Urla", 35, context);
                AddCounty("Torbalı", 35, context);
                AddCounty("Tire", 35, context);
                AddCounty("Buca", 35, context);
                AddCounty("Beydağ", 35, context);
                AddCounty("Konak", 35, context);
                AddCounty("Menderes", 35, context);
                AddCounty("Güzelbahçe", 35, context);
                AddCounty("Gaziemir", 35, context);
                AddCounty("Balçova", 35, context);
                AddCounty("Çiğli", 35, context);
                AddCounty("Bayraklı", 35, context);
                AddCounty("Karabağlar", 35, context);
                AddCounty("Narlıdere", 35, context);
                AddCounty("Akyaka", 36, context);
                AddCounty("Merkez", 36, context);
                AddCounty("Kağızman", 36, context);
                AddCounty("Sarıkamış", 36, context);
                AddCounty("Selim", 36, context);
                AddCounty("Susuz", 36, context);
                AddCounty("Arpaçay", 36, context);
                AddCounty("Digor", 36, context);
                AddCounty("Devrekani", 37, context);
                AddCounty("Daday", 37, context);
                AddCounty("Azdavay", 37, context);
                AddCounty("Araç", 37, context);
                AddCounty("Abana", 37, context);
                AddCounty("Çatalzeytin", 37, context);
                AddCounty("Bozkurt", 37, context);
                AddCounty("Cide", 37, context);
                AddCounty("Taşköprü", 37, context);
                AddCounty("İnebolu", 37, context);
                AddCounty("Merkez", 37, context);
                AddCounty("Küre", 37, context);
                AddCounty("İhsangazi", 37, context);
                AddCounty("Tosya", 37, context);
                AddCounty("Şenpazar", 37, context);
                AddCounty("Pınarbaşı", 37, context);
                AddCounty("Ağlı", 37, context);
                AddCounty("Doğanyurt", 37, context);
                AddCounty("Hanönü", 37, context);
                AddCounty("Seydiler", 37, context);
                AddCounty("Özvatan", 38, context);
                AddCounty("Hacılar", 38, context);
                AddCounty("Kocasinan", 38, context);
                AddCounty("Melikgazi", 38, context);
                AddCounty("Talas", 38, context);
                AddCounty("Tomarza", 38, context);
                AddCounty("Yahyalı", 38, context);
                AddCounty("Yeşilhisar", 38, context);
                AddCounty("Akkışla", 38, context);
                AddCounty("İncesu", 38, context);
                AddCounty("Sarıoğlan", 38, context);
                AddCounty("Sarız", 38, context);
                AddCounty("Pınarbaşı", 38, context);
                AddCounty("Bünyan", 38, context);
                AddCounty("Develi", 38, context);
                AddCounty("Felahiye", 38, context);
                AddCounty("Demirköy", 39, context);
                AddCounty("Babaeski", 39, context);
                AddCounty("Pınarhisar", 39, context);
                AddCounty("Pehlivanköy", 39, context);
                AddCounty("Kofçaz", 39, context);
                AddCounty("Merkez", 39, context);
                AddCounty("Lüleburgaz", 39, context);
                AddCounty("Vize", 39, context);
                AddCounty("Akpınar", 40, context);
                AddCounty("Akçakent", 40, context);
                AddCounty("Boztepe", 40, context);
                AddCounty("Mucur", 40, context);
                AddCounty("Merkez", 40, context);
                AddCounty("Kaman", 40, context);
                AddCounty("Çiçekdağı", 40, context);
                AddCounty("Gebze", 41, context);
                AddCounty("Gölcük", 41, context);
                AddCounty("Kandıra", 41, context);
                AddCounty("Karamürsel", 41, context);
                AddCounty("Merkez", 41, context);
                AddCounty("Körfez", 41, context);
                AddCounty("Derince", 41, context);
                AddCounty("Başiskele", 41, context);
                AddCounty("Çayırova", 41, context);
                AddCounty("Darıca", 41, context);
                AddCounty("Dilovası", 41, context);
                AddCounty("Kartepe", 41, context);
                AddCounty("Tuzlukçu", 42, context);
                AddCounty("Yalıhüyük", 42, context);
                AddCounty("Karatay", 42, context);
                AddCounty("Meram", 42, context);
                AddCounty("Taşkent", 42, context);
                AddCounty("Selçuklu", 42, context);
                AddCounty("Ahırlı", 42, context);
                AddCounty("Çeltik", 42, context);
                AddCounty("Emirgazi", 42, context);
                AddCounty("Derbent", 42, context);
                AddCounty("Halkapınar", 42, context);
                AddCounty("Güneysınır", 42, context);
                AddCounty("Altınekin", 42, context);
                AddCounty("Akören", 42, context);
                AddCounty("Hüyük", 42, context);
                AddCounty("Derebucak", 42, context);
                AddCounty("Yunak", 42, context);
                AddCounty("Kulu", 42, context);
                AddCounty("Karapınar", 42, context);
                AddCounty("Kadınhanı", 42, context);
                AddCounty("Ilgın", 42, context);
                AddCounty("Sarayönü", 42, context);
                AddCounty("Seydişehir", 42, context);
                AddCounty("Hadim", 42, context);
                AddCounty("Çumra", 42, context);
                AddCounty("Doğanhisar", 42, context);
                AddCounty("Ereğli", 42, context);
                AddCounty("Akşehir", 42, context);
                AddCounty("Cihanbeyli", 42, context);
                AddCounty("Bozkır", 42, context);
                AddCounty("Beyşehir", 42, context);
                AddCounty("Altıntaş", 43, context);
                AddCounty("Emet", 43, context);
                AddCounty("Domaniç", 43, context);
                AddCounty("Gediz", 43, context);
                AddCounty("Simav", 43, context);
                AddCounty("Tavşanlı", 43, context);
                AddCounty("Merkez", 43, context);
                AddCounty("Dumlupınar", 43, context);
                AddCounty("Hisarcık", 43, context);
                AddCounty("Aslanapa", 43, context);
                AddCounty("Çavdarhisar", 43, context);
                AddCounty("Şaphane", 43, context);
                AddCounty("Pazarlar", 43, context);
                AddCounty("Kuluncak", 44, context);
                AddCounty("Yazıhan", 44, context);
                AddCounty("Doğanyol", 44, context);
                AddCounty("Kale", 44, context);
                AddCounty("Battalgazi", 44, context);
                AddCounty("Yeşilyurt", 44, context);
                AddCounty("Merkez", 44, context);
                AddCounty("Hekimhan", 44, context);
                AddCounty("Pütürge", 44, context);
                AddCounty("Doğanşehir", 44, context);
                AddCounty("Darende", 44, context);
                AddCounty("Akçadağ", 44, context);
                AddCounty("Arapgir", 44, context);
                AddCounty("Arguvan", 44, context);
                AddCounty("Akhisar", 45, context);
                AddCounty("Alaşehir", 45, context);
                AddCounty("Demirci", 45, context);
                AddCounty("Gördes", 45, context);
                AddCounty("Salihli", 45, context);
                AddCounty("Saruhanlı", 45, context);
                AddCounty("Sarıgöl", 45, context);
                AddCounty("Soma", 45, context);
                AddCounty("Selendi", 45, context);
                AddCounty("Merkez", 45, context);
                AddCounty("Kırkağaç", 45, context);
                AddCounty("Kula", 45, context);
                AddCounty("Turgutlu", 45, context);
                AddCounty("Ahmetli", 45, context);
                AddCounty("Gölmarmara", 45, context);
                AddCounty("Köprübaşı", 45, context);
                AddCounty("Nurhak", 46, context);
                AddCounty("Çağlıyancerit", 46, context);
                AddCounty("Türkoğlu", 46, context);
                AddCounty("Ekinözü", 46, context);
                AddCounty("Merkez", 46, context);
                AddCounty("Pazarcık", 46, context);
                AddCounty("Göksun", 46, context);
                AddCounty("Elbistan", 46, context);
                AddCounty("Afşin", 46, context);
                AddCounty("Andırın", 46, context);
                AddCounty("Derik", 47, context);
                AddCounty("Ömerli", 47, context);
                AddCounty("Nusaybin", 47, context);
                AddCounty("Savur", 47, context);
                AddCounty("Merkez", 47, context);
                AddCounty("Midyat", 47, context);
                AddCounty("Mazıdağı", 47, context);
                AddCounty("Kızıltepe", 47, context);
                AddCounty("Dargeçit", 47, context);
                AddCounty("Yeşilli", 47, context);
                AddCounty("Kavaklıdere", 48, context);
                AddCounty("Ula", 48, context);
                AddCounty("Dalaman", 48, context);
                AddCounty("Yatağan", 48, context);
                AddCounty("Ortaca", 48, context);
                AddCounty("Köyceğiz", 48, context);
                AddCounty("Milas", 48, context);
                AddCounty("Merkez", 48, context);
                AddCounty("Marmaris", 48, context);
                AddCounty("Datça", 48, context);
                AddCounty("Fethiye", 48, context);
                AddCounty("Bodrum", 48, context);
                AddCounty("Bulanık", 49, context);
                AddCounty("Malazgirt", 49, context);
                AddCounty("Merkez", 49, context);
                AddCounty("Varto", 49, context);
                AddCounty("Hasköy", 49, context);
                AddCounty("Korkut", 49, context);
                AddCounty("Acıgöl", 50, context);
                AddCounty("Ürgüp", 50, context);
                AddCounty("Kozaklı", 50, context);
                AddCounty("Merkez", 50, context);
                AddCounty("Avanos", 50, context);
                AddCounty("Gülşehir", 50, context);
                AddCounty("Hacıbektaş", 50, context);
                AddCounty("Derinkuyu", 50, context);
                AddCounty("Bor", 51, context);
                AddCounty("Çamardı", 51, context);
                AddCounty("Merkez", 51, context);
                AddCounty("Ulukışla", 51, context);
                AddCounty("Altunhisar", 51, context);
                AddCounty("Çiftlik", 51, context);
                AddCounty("Çaybaşı", 52, context);
                AddCounty("Çatalpınar", 52, context);
                AddCounty("Çamaş", 52, context);
                AddCounty("Kabadüz", 52, context);
                AddCounty("Kabataş", 52, context);
                AddCounty("İkizce", 52, context);
                AddCounty("Ulubey", 52, context);
                AddCounty("Ünye", 52, context);
                AddCounty("Gürgentepe", 52, context);
                AddCounty("Gülyalı", 52, context);
                AddCounty("Perşembe", 52, context);
                AddCounty("Merkez", 52, context);
                AddCounty("Kumru", 52, context);
                AddCounty("Korgan", 52, context);
                AddCounty("Mesudiye", 52, context);
                AddCounty("Aybastı", 52, context);
                AddCounty("Akkuş", 52, context);
                AddCounty("Gölköy", 52, context);
                AddCounty("Fatsa", 52, context);
                AddCounty("Fındıklı", 53, context);
                AddCounty("Ardeşen", 53, context);
                AddCounty("Çamlıhemşin", 53, context);
                AddCounty("Çayeli", 53, context);
                AddCounty("İkizdere", 53, context);
                AddCounty("Kalkandere", 53, context);
                AddCounty("Pazar", 53, context);
                AddCounty("Merkez", 53, context);
                AddCounty("Güneysu", 53, context);
                AddCounty("İyidere", 53, context);
                AddCounty("Hemşin", 53, context);
                AddCounty("Derepazarı", 53, context);
                AddCounty("Karapürçek", 54, context);
                AddCounty("Ferizli", 54, context);
                AddCounty("Pamukova", 54, context);
                AddCounty("Taraklı", 54, context);
                AddCounty("Kocaali", 54, context);
                AddCounty("Söğütlü", 54, context);
                AddCounty("Arifiye", 54, context);
                AddCounty("Serdivan", 54, context);
                AddCounty("Erenler", 54, context);
                AddCounty("Merkez", 54, context);
                AddCounty("Sapanca", 54, context);
                AddCounty("Karasu", 54, context);
                AddCounty("Kaynarca", 54, context);
                AddCounty("Hendek", 54, context);
                AddCounty("Akyazı", 54, context);
                AddCounty("Geyve", 54, context);
                AddCounty("Havza", 55, context);
                AddCounty("Alaçam", 55, context);
                AddCounty("Bafra", 55, context);
                AddCounty("Çarşamba", 55, context);
                AddCounty("Kavak", 55, context);
                AddCounty("Ladik", 55, context);
                AddCounty("Merkez", 55, context);
                AddCounty("Terme", 55, context);
                AddCounty("Atakum", 55, context);
                AddCounty("Yakakent", 55, context);
                AddCounty("Asarcık", 55, context);
                AddCounty("Vezirköprü", 55, context);
                AddCounty("Tekkeköy", 55, context);
                AddCounty("Salıpazarı", 55, context);
                AddCounty("Ondokuzmayıs", 55, context);
                AddCounty("Ayvacık", 55, context);
                AddCounty("Aydınlar", 56, context);
                AddCounty("Şirvan", 56, context);
                AddCounty("Merkez", 56, context);
                AddCounty("Pervari", 56, context);
                AddCounty("Kurtalan", 56, context);
                AddCounty("Baykan", 56, context);
                AddCounty("Eruh", 56, context);
                AddCounty("Gerze", 57, context);
                AddCounty("Durağan", 57, context);
                AddCounty("Erfelek", 57, context);
                AddCounty("Boyabat", 57, context);
                AddCounty("Ayancık", 57, context);
                AddCounty("Merkez", 57, context);
                AddCounty("Dikmen", 57, context);
                AddCounty("Türkeli", 57, context);
                AddCounty("Saraydüzü", 57, context);
                AddCounty("Ulaş", 58, context);
                AddCounty("Yıldızeli", 58, context);
                AddCounty("Zara", 58, context);
                AddCounty("Doğanşar", 58, context);
                AddCounty("Gölova", 58, context);
                AddCounty("Altınyayla", 58, context);
                AddCounty("Akıncılar", 58, context);
                AddCounty("Merkez", 58, context);
                AddCounty("Suşehri", 58, context);
                AddCounty("Şarkışla", 58, context);
                AddCounty("Koyulhisar", 58, context);
                AddCounty("Kangal", 58, context);
                AddCounty("İmranlı", 58, context);
                AddCounty("Divriği", 58, context);
                AddCounty("Gemerek", 58, context);
                AddCounty("Gürün", 58, context);
                AddCounty("Hafik", 58, context);
                AddCounty("Hayrabolu", 59, context);
                AddCounty("Çorlu", 59, context);
                AddCounty("Çerkezköy", 59, context);
                AddCounty("Malkara", 59, context);
                AddCounty("Şarköy", 59, context);
                AddCounty("Merkez", 59, context);
                AddCounty("Saray", 59, context);
                AddCounty("Muratlı", 59, context);
                AddCounty("Marmaraereğlisi", 59, context);
                AddCounty("Pazar", 60, context);
                AddCounty("Başçiftlik", 60, context);
                AddCounty("Yeşilyurt", 60, context);
                AddCounty("Zile", 60, context);
                AddCounty("Turhal", 60, context);
                AddCounty("Merkez", 60, context);
                AddCounty("Sulusaray", 60, context);
                AddCounty("Niksar", 60, context);
                AddCounty("Reşadiye", 60, context);
                AddCounty("Erbaa", 60, context);
                AddCounty("Artova", 60, context);
                AddCounty("Almus", 60, context);
                AddCounty("Araklı", 61, context);
                AddCounty("Akçaabat", 61, context);
                AddCounty("Arsin", 61, context);
                AddCounty("Çaykara", 61, context);
                AddCounty("Of", 61, context);
                AddCounty("Sürmene", 61, context);
                AddCounty("Maçka", 61, context);
                AddCounty("Köprübaşı", 61, context);
                AddCounty("Merkez", 61, context);
                AddCounty("Tonya", 61, context);
                AddCounty("Vakfıkebir", 61, context);
                AddCounty("Yomra", 61, context);
                AddCounty("Beşikdüzü", 61, context);
                AddCounty("Şalpazarı", 61, context);
                AddCounty("Hayrat", 61, context);
                AddCounty("Dernekpazarı", 61, context);
                AddCounty("Düzköy", 61, context);
                AddCounty("Çarşıbaşı", 61, context);
                AddCounty("Merkez", 62, context);
                AddCounty("Mazgirt", 62, context);
                AddCounty("Hozat", 62, context);
                AddCounty("Nazımiye", 62, context);
                AddCounty("Ovacık", 62, context);
                AddCounty("Pertek", 62, context);
                AddCounty("Pülümür", 62, context);
                AddCounty("Çemişgezek", 62, context);
                AddCounty("Ceylanpınar", 63, context);
                AddCounty("Bozova", 63, context);
                AddCounty("Birecik", 63, context);
                AddCounty("Akçakale", 63, context);
                AddCounty("Halfeti", 63, context);
                AddCounty("Suruç", 63, context);
                AddCounty("Siverek", 63, context);
                AddCounty("Hilvan", 63, context);
                AddCounty("Merkez", 63, context);
                AddCounty("Viranşehir", 63, context);
                AddCounty("Harran", 63, context);
                AddCounty("Merkez", 64, context);
                AddCounty("Ulubey", 64, context);
                AddCounty("Karahallı", 64, context);
                AddCounty("Sivaslı", 64, context);
                AddCounty("Eşme", 64, context);
                AddCounty("Banaz", 64, context);
                AddCounty("Başkale", 65, context);
                AddCounty("Çatak", 65, context);
                AddCounty("Gevaş", 65, context);
                AddCounty("Gürpınar", 65, context);
                AddCounty("Erciş", 65, context);
                AddCounty("Özalp", 65, context);
                AddCounty("Muradiye", 65, context);
                AddCounty("Merkez", 65, context);
                AddCounty("Çaldıran", 65, context);
                AddCounty("Bahçesaray", 65, context);
                AddCounty("Edremit", 65, context);
                AddCounty("Saray", 65, context);
                AddCounty("Saraykent", 66, context);
                AddCounty("Yenifakılı", 66, context);
                AddCounty("Çandır", 66, context);
                AddCounty("Kadışehri", 66, context);
                AddCounty("Aydıncık", 66, context);
                AddCounty("Yerköy", 66, context);
                AddCounty("Merkez", 66, context);
                AddCounty("Sarıkaya", 66, context);
                AddCounty("Sorgun", 66, context);
                AddCounty("Şefaatli", 66, context);
                AddCounty("Çekerek", 66, context);
                AddCounty("Çayıralan", 66, context);
                AddCounty("Boğazlıyan", 66, context);
                AddCounty("Akdağmadeni", 66, context);
                AddCounty("Çaycuma", 67, context);
                AddCounty("Ereğli", 67, context);
                AddCounty("Devrek", 67, context);
                AddCounty("Merkez", 67, context);
                AddCounty("Alaplı", 67, context);
                AddCounty("Gökçebey", 67, context);
                AddCounty("Gülağaç", 68, context);
                AddCounty("Eskil", 68, context);
                AddCounty("Sarıyahşi", 68, context);
                AddCounty("Ağaçören", 68, context);
                AddCounty("Güzelyurt", 68, context);
                AddCounty("Merkez", 68, context);
                AddCounty("Ortaköy", 68, context);
                AddCounty("Merkez", 69, context);
                AddCounty("Aydıntepe", 69, context);
                AddCounty("Demirözü", 69, context);
                AddCounty("Ayrancı", 70, context);
                AddCounty("Kazımkarabekir", 70, context);
                AddCounty("Başyayla", 70, context);
                AddCounty("Sarıveliler", 70, context);
                AddCounty("Ermenek", 70, context);
                AddCounty("Merkez", 70, context);
                AddCounty("Keskin", 71, context);
                AddCounty("Merkez", 71, context);
                AddCounty("Sulakyurt", 71, context);
                AddCounty("Delice", 71, context);
                AddCounty("Yahşihan", 71, context);
                AddCounty("Balışeyh", 71, context);
                AddCounty("Bahşili", 71, context);
                AddCounty("Çelebi", 71, context);
                AddCounty("Karakeçili", 71, context);
                AddCounty("Hasankeyf", 72, context);
                AddCounty("Gercüş", 72, context);
                AddCounty("Beşiri", 72, context);
                AddCounty("Merkez", 72, context);
                AddCounty("Sason", 72, context);
                AddCounty("Kozluk", 72, context);
                AddCounty("İdil", 73, context);
                AddCounty("Silopi", 73, context);
                AddCounty("Merkez", 73, context);
                AddCounty("Beytüşşebap", 73, context);
                AddCounty("Cizre", 73, context);
                AddCounty("Güçlükonak", 73, context);
                AddCounty("Uludere", 73, context);
                AddCounty("Ulus", 74, context);
                AddCounty("Amasra", 74, context);
                AddCounty("Merkez", 74, context);
                AddCounty("Kurucaşile", 74, context);
                AddCounty("Posof", 75, context);
                AddCounty("Merkez", 75, context);
                AddCounty("Hanak", 75, context);
                AddCounty("Göle", 75, context);
                AddCounty("Çıldır", 75, context);
                AddCounty("Damal", 75, context);
                AddCounty("Karakoyunlu", 76, context);
                AddCounty("Tuzluca", 76, context);
                AddCounty("Aralık", 76, context);
                AddCounty("Merkez", 76, context);
                AddCounty("Merkez", 77, context);
                AddCounty("Altınova", 77, context);
                AddCounty("Armutlu", 77, context);
                AddCounty("Çınarcık", 77, context);
                AddCounty("Çiftlikköy", 77, context);
                AddCounty("Termal", 77, context);
                AddCounty("Yenice", 78, context);
                AddCounty("Merkez", 78, context);
                AddCounty("Safranbolu", 78, context);
                AddCounty("Ovacık", 78, context);
                AddCounty("Eflani", 78, context);
                AddCounty("Eskipazar", 78, context);
                AddCounty("Merkez", 79, context);
                AddCounty("Elbeyli", 79, context);
                AddCounty("Musabeyli", 79, context);
                AddCounty("Polateli", 79, context);
                AddCounty("Hasanbeyli", 80, context);
                AddCounty("Sumbas", 80, context);
                AddCounty("Toprakkale", 80, context);
                AddCounty("Düziçi", 80, context);
                AddCounty("Kadirli", 80, context);
                AddCounty("Merkez", 80, context);
                AddCounty("Bahçe", 80, context);
                AddCounty("Akçakoca", 81, context);
                AddCounty("Merkez", 81, context);
                AddCounty("Yığılca", 81, context);
                AddCounty("Cumayeri", 81, context);
                AddCounty("Gölyaka", 81, context);
                AddCounty("Çilimli", 81, context);
                AddCounty("Gümüşova", 81, context);
                AddCounty("Kaynaşlı", 81, context);

            }
            context.SaveChanges();

            #endregion

            #region Users

            if (!context.Users.Any(x => x.Email == "admin@mail.com"))
            {
                context.Users.AddOrUpdate(new User
                {
                    UserTypeId = 1, // Müşteri
                    GenderId = 4, // Diğer
                    Email = "admin@mail.com",
                    PasswordHash = "passwordhash",
                    Names = "Programatic Admin",
                    FirstName = "Programatic",
                    LastName = "Admin",
                    PreferredName = "Programatic",
                    IsActive = true,
                    IsMailingActive = true,
                    IsOtherMailingActive = true,
                    Point = 0,
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    UpdatedBy = 1
                });

                context.SaveChanges();
            }

            #endregion

        }

        private static void AddCity(int id, string name, GeoZone geozone, MembershipDB context)
        {
            context.Cities.AddOrUpdate(new City
            {
                Name = name,
                Id = id,
                GeoZone = geozone,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = 1
            });
        }

        private static void AddCounty(string name, int cityId, MembershipDB context)
        {
            var _name = name.Trim();

            context.Counties.AddOrUpdate(new County
            {
                Name = string.Format("{0}{1}", _name[0], _name.Substring(1).ToLower()),
                City = context.Cities.First(x => x.Id==cityId),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = 1
            });
        }

    }
}
