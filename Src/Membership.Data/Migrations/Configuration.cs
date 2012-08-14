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
            context.Genders.AddOrUpdate(
                new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Erkek" },
                new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Kadın" },
                 new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Unisex" },
                new Gender { CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UpdatedBy = 1, Name = "Diğer" });

            context.UserTypes.AddOrUpdate(new UserType { Name = "Müşteri", Description = string.Empty, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 });

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
            context.Countries.AddOrUpdate(countryTurkey);

            var marmara = new GeoZone { Country = countryTurkey, Name = "Marmara", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var akdeniz = new GeoZone { Country = countryTurkey, Name = "Ege", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var karadeniz = new GeoZone { Country = countryTurkey, Name = "Akdeniz", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var ege = new GeoZone { Country = countryTurkey, Name = "Karadeniz", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var icAnadolu = new GeoZone { Country = countryTurkey, Name = "Doğu Anadolu", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var doguAnadolu = new GeoZone { Country = countryTurkey, Name = "İç Anadolu", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };
            var guneydoguAnadolu = new GeoZone { Country = countryTurkey, Name = "Güneydoğu Anadolu", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 };

            context.LogEvents.AddOrUpdate(
                new LogEvent { Name = "Programatic Update", Description = "A data manipulation via code", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                new LogEvent { Name = "Admin Panel Data Update", Description = "An update, insert or delete action occured", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                new LogEvent { Name = "Password Changed", Description = "A user changed password", UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 });

            context.PointTypes.AddOrUpdate(
                new PointType { Name = "Sayfa Ziyareti", Point = 1, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                new PointType { Name = "Temsilci Takibi", Point = 5, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                new PointType { Name = "Paylaşım", Point = 10, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                new PointType { Name = "Arkadaş Daveti", Point = 5, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                new PointType { Name = "Ürün Alımı", Point = 100, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 },
                new PointType { Name = "Davet Edilen Arkadaşın Üye Olması", Point = 25, IsActive = true, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now, UpdatedBy = 1 });

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

            context.SaveChanges();

            var adana = context.Cities.First(x => x.Name == "Adana");
            var adiyaman = context.Cities.First(x => x.Name == "Adıyaman");
            var afyonKarahisar = context.Cities.First(x => x.Name == "Afyonkarahisar");
            var agri = context.Cities.First(x => x.Name == "Ağrı");
            var amasya = context.Cities.First(x => x.Name == "Amasya");
            var ankara = context.Cities.First(x => x.Name == "Ankara");
            var antalya = context.Cities.First(x => x.Name == "Antalya");
            var artvin = context.Cities.First(x => x.Name == "Artvin");
            var aydin = context.Cities.First(x => x.Name == "Aydın");
            var balikesir = context.Cities.First(x => x.Name == "Balıkesir");
            var bilecik = context.Cities.First(x => x.Name == "Bilecik");
            var bingol = context.Cities.First(x => x.Name == "Bingöl");
            var bitlis = context.Cities.First(x => x.Name == "Bitlis");
            var bolu = context.Cities.First(x => x.Name == "Bolu");
            var burdur = context.Cities.First(x => x.Name == "Burdur");
            var bursa = context.Cities.First(x => x.Name == "Bursa");
            var canakkale = context.Cities.First(x => x.Name == "Çanakkale");
            var cankiri = context.Cities.First(x => x.Name == "Çankırı");
            var corum = context.Cities.First(x => x.Name == "Çorum");
            var denizli = context.Cities.First(x => x.Name == "Denizli");
            var diyarbakir = context.Cities.First(x => x.Name == "Diyarbakır");
            var edirne = context.Cities.First(x => x.Name == "Edirne");
            var elazig = context.Cities.First(x => x.Name == "Elazığ");
            var erzincan = context.Cities.First(x => x.Name == "Erzincan");
            var erzurum = context.Cities.First(x => x.Name == "Erzurum");
            var eskisehir = context.Cities.First(x => x.Name == "Eskişehir");
            var gaziantep = context.Cities.First(x => x.Name == "Gaziantep");
            var giresun = context.Cities.First(x => x.Name == "Giresun");
            var gumushane = context.Cities.First(x => x.Name == "Gümüşhane");
            var hakkari = context.Cities.First(x => x.Name == "Hakkari");
            var hatay = context.Cities.First(x => x.Name == "Hatay");
            var isparta = context.Cities.First(x => x.Name == "Isparta");
            var mersin = context.Cities.First(x => x.Name == "Mersin");
            var istanbul = context.Cities.First(x => x.Name == "İstanbul");
            var izmir = context.Cities.First(x => x.Name == "İzmir");
            var kars = context.Cities.First(x => x.Name == "Kars");
            var kastamonu = context.Cities.First(x => x.Name == "Kastamonu");
            var kayseri = context.Cities.First(x => x.Name == "Kayseri");
            var kirklareli = context.Cities.First(x => x.Name == "Kırklareli");
            var kirsehir = context.Cities.First(x => x.Name == "Kırşehir");
            var kocaeli = context.Cities.First(x => x.Name == "Kocaeli");
            var konya = context.Cities.First(x => x.Name == "Konya");
            var kutahya = context.Cities.First(x => x.Name == "Kütahya");
            var malatya = context.Cities.First(x => x.Name == "Malatya");
            var manisa = context.Cities.First(x => x.Name == "Manisa");
            var maras = context.Cities.First(x => x.Name == "Kahramanmaraş");
            var mardin = context.Cities.First(x => x.Name == "Mardin");
            var mugla = context.Cities.First(x => x.Name == "Muğla");
            var mus = context.Cities.First(x => x.Name == "Muş");
            var nevsehir = context.Cities.First(x => x.Name == "Nevşehir");
            var nigde = context.Cities.First(x => x.Name == "Niğde");
            var ordu = context.Cities.First(x => x.Name == "Ordu");
            var rize = context.Cities.First(x => x.Name == "Rize");
            var sakarya = context.Cities.First(x => x.Name == "Sakarya");
            var samsun = context.Cities.First(x => x.Name == "Samsun");
            var siirt = context.Cities.First(x => x.Name == "Siirt");
            var sinop = context.Cities.First(x => x.Name == "Sinop");
            var sivas = context.Cities.First(x => x.Name == "Sivas");
            var tekirdag = context.Cities.First(x => x.Name == "Tekirdağ");
            var tokat = context.Cities.First(x => x.Name == "Tokat");
            var trabzon = context.Cities.First(x => x.Name == "Trabzon");
            var tunceli = context.Cities.First(x => x.Name == "Tunceli");
            var urfa = context.Cities.First(x => x.Name == "Şanlıurfa");
            var usak = context.Cities.First(x => x.Name == "Uşak");
            var van = context.Cities.First(x => x.Name == "Van");
            var yozgat = context.Cities.First(x => x.Name == "Yozgat");
            var zonguldak = context.Cities.First(x => x.Name == "Zonguldak");
            var aksaray = context.Cities.First(x => x.Name == "Aksaray");
            var bayburt = context.Cities.First(x => x.Name == "Bayburt");
            var karaman = context.Cities.First(x => x.Name == "Karaman");
            var kirikkale = context.Cities.First(x => x.Name == "Kırıkkale");
            var batman = context.Cities.First(x => x.Name == "Batman");
            var sirnak = context.Cities.First(x => x.Name == "Şırnak");
            var bartin = context.Cities.First(x => x.Name == "Bartın");
            var ardahan = context.Cities.First(x => x.Name == "Ardahan");
            var igdir = context.Cities.First(x => x.Name == "Iğdır");
            var yalova = context.Cities.First(x => x.Name == "Yalova");
            var karabuk = context.Cities.First(x => x.Name == "Karabük");
            var kilis = context.Cities.First(x => x.Name == "Kilis");
            var osmaniye = context.Cities.First(x => x.Name == "Osmaniye");
            var duzce = context.Cities.First(x => x.Name == "Düzce");

            AddCounty("ALADAG", adana, context);
            AddCounty("CEYHAN", adana, context);
            AddCounty("ÇUKUROVA", adana, context);
            AddCounty("FEKE", adana, context);
            AddCounty("IMAMOGLU", adana, context);
            AddCounty("KARAISALI", adana, context);
            AddCounty("KARATAS", adana, context);
            AddCounty("KOZAN", adana, context);
            AddCounty("POZANTI", adana, context);
            AddCounty("SAIMBEYLI", adana, context);
            AddCounty("SARIÇAM", adana, context);
            AddCounty("SEYHAN", adana, context);
            AddCounty("TUFANBEYLI", adana, context);
            AddCounty("YUMURTALIK", adana, context);
            AddCounty("YÜREGIR", adana, context);

            AddCounty("BESNI", adiyaman, context);
            AddCounty("ÇELIKHAN", adiyaman, context);
            AddCounty("GERGER", adiyaman, context);
            AddCounty("GÖLBASI", adiyaman, context);
            AddCounty("KAHTA", adiyaman, context);
            AddCounty("SAMSAT", adiyaman, context);
            AddCounty("SINCIK", adiyaman, context);
            AddCounty("TUT", adiyaman, context);

            AddCounty("BASMAKÇI", afyonKarahisar, context);
            AddCounty("BAYAT", afyonKarahisar, context);
            AddCounty("BOLVADIN", afyonKarahisar, context);
            AddCounty("ÇAY", afyonKarahisar, context);
            AddCounty("ÇOBANLAR", afyonKarahisar, context);
            AddCounty("DAZKIRI", afyonKarahisar, context);
            AddCounty("DINAR", afyonKarahisar, context);
            AddCounty("EMIRDAG", afyonKarahisar, context);
            AddCounty("EVCILER", afyonKarahisar, context);
            AddCounty("HOCALAR", afyonKarahisar, context);
            AddCounty("IHSANIYE", afyonKarahisar, context);
            AddCounty("ISCEHISAR", afyonKarahisar, context);
            AddCounty("KIZILÖREN", afyonKarahisar, context);
            AddCounty("SANDIKLI", afyonKarahisar, context);
            AddCounty("SINANPASA", afyonKarahisar, context);
            AddCounty("SULTANDAGI", afyonKarahisar, context);
            AddCounty("SUHUT", afyonKarahisar, context);

            AddCounty("Diyadin", agri, context);
            AddCounty("Doğubayazıt", agri, context);
            AddCounty("Eleskirt", agri, context);
            AddCounty("Hamur", agri, context);
            AddCounty("Patnus", agri, context);
            AddCounty("Taslıçay", agri, context);
            AddCounty("Tutak", agri, context);

            AddCounty("GÖYNÜCEK", amasya, context);
            AddCounty("GÜMÜSHACIKÖY", amasya, context);
            AddCounty("HAMAMÖZÜ", amasya, context);
            AddCounty("MERZIFON", amasya, context);
            AddCounty("SULUOVA", amasya, context);
            AddCounty("TASOVA", amasya, context);

            AddCounty("AKYURT", ankara, context);
            AddCounty("ALTINDAG", ankara, context);
            AddCounty("AYAS", ankara, context);
            AddCounty("BALA", ankara, context);
            AddCounty("BEYPAZARI", ankara, context);
            AddCounty("ÇAMLIDERE", ankara, context);
            AddCounty("ÇANKAYA", ankara, context);
            AddCounty("ÇUBUK", ankara, context);
            AddCounty("ELMADAG", ankara, context);
            AddCounty("ETIMESGUT", ankara, context);
            AddCounty("EVREN", ankara, context);
            AddCounty("GÖLBASI", ankara, context);
            AddCounty("GÜDÜL", ankara, context);
            AddCounty("HAYMANA", ankara, context);
            AddCounty("KALECIK", ankara, context);
            AddCounty("KAZAN", ankara, context);
            AddCounty("KEÇIÖREN", ankara, context);
            AddCounty("KIZILCAHAMAM", ankara, context);
            AddCounty("MAMAK", ankara, context);
            AddCounty("NALLIHAN", ankara, context);
            AddCounty("POLATLI", ankara, context);
            AddCounty("PURSAKLAR", ankara, context);
            AddCounty("SINCAN", ankara, context);
            AddCounty("SEREFLIKOÇHISAR", ankara, context);
            AddCounty("YENIMAHALLE", ankara, context);

            AddCounty("AKSEKI", antalya, context);
            AddCounty("AKSU", antalya, context);
            AddCounty("ALANYA", antalya, context);
            AddCounty("DEMRE", antalya, context);
            AddCounty("DÖSEMEALTI", antalya, context);
            AddCounty("ELMALI", antalya, context);
            AddCounty("FINIKE", antalya, context);
            AddCounty("GAZIPASA", antalya, context);
            AddCounty("GÜNDOGMUS", antalya, context);
            AddCounty("IBRADI", antalya, context);
            AddCounty("KAS", antalya, context);
            AddCounty("KEMER", antalya, context);
            AddCounty("KEPEZ", antalya, context);
            AddCounty("KONYAALTI", antalya, context);
            AddCounty("KORKUTELI", antalya, context);
            AddCounty("KUMLUCA", antalya, context);
            AddCounty("MANAVGAT", antalya, context);
            AddCounty("MURATPASA", antalya, context);
            AddCounty("SERIK", antalya, context);

            AddCounty("ARDANUÇ", artvin, context);
            AddCounty("ARHAVI", artvin, context);
            AddCounty("BORÇKA", artvin, context);
            AddCounty("HOPA", artvin, context);
            AddCounty("MURGUL", artvin, context);
            AddCounty("SAVSAT", artvin, context);
            AddCounty("YUSUFELI", artvin, context);

            AddCounty("BOZDOGAN", aydin, context);
            AddCounty("BUHARKENT", aydin, context);
            AddCounty("ÇINE", aydin, context);
            AddCounty("DIDIM", aydin, context);
            AddCounty("GERMENCIK", aydin, context);
            AddCounty("INCIRLIOVA", aydin, context);
            AddCounty("KARACASU", aydin, context);
            AddCounty("KARPUZLU", aydin, context);
            AddCounty("KOÇARLI", aydin, context);
            AddCounty("KÖSK", aydin, context);
            AddCounty("KUSADASI", aydin, context);
            AddCounty("KUYUCAK", aydin, context);
            AddCounty("NAZILLI", aydin, context);
            AddCounty("SÖKE", aydin, context);
            AddCounty("SULTANHISAR", aydin, context);
            AddCounty("YENIPAZAR", aydin, context);

            AddCounty("AYVALIK", balikesir, context);
            AddCounty("BALYA", balikesir, context);
            AddCounty("BANDIRMA", balikesir, context);
            AddCounty("BIGADIÇ", balikesir, context);
            AddCounty("BURHANIYE", balikesir, context);
            AddCounty("DURSUNBEY", balikesir, context);
            AddCounty("EDREMIT", balikesir, context);
            AddCounty("ERDEK", balikesir, context);
            AddCounty("GÖMEÇ", balikesir, context);
            AddCounty("GÖNEN", balikesir, context);
            AddCounty("HAVRAN", balikesir, context);
            AddCounty("IVRINDI", balikesir, context);
            AddCounty("KEPSUT", balikesir, context);
            AddCounty("MANYAS", balikesir, context);
            AddCounty("MARMARA", balikesir, context);
            AddCounty("SAVASTEPE", balikesir, context);
            AddCounty("SINDIRGI", balikesir, context);
            AddCounty("SUSURLUK", balikesir, context);

            AddCounty("BOZÜYÜK", bilecik, context);
            AddCounty("GÖLPAZARI", bilecik, context);
            AddCounty("INHISAR", bilecik, context);
            AddCounty("OSMANELI", bilecik, context);
            AddCounty("PAZARYERI", bilecik, context);
            AddCounty("SÖGÜT", bilecik, context);
            AddCounty("YENIPAZAR", bilecik, context);

            AddCounty("ADAKLI", bingol, context);
            AddCounty("GENÇ", bingol, context);
            AddCounty("KARLIOVA", bingol, context);
            AddCounty("KIGI", bingol, context);
            AddCounty("SOLHAN", bingol, context);
            AddCounty("YAYLADERE", bingol, context);
            AddCounty("YEDISU", bingol, context);

            AddCounty("ADILCEVAZ", bitlis, context);
            AddCounty("AHLAT", bitlis, context);
            AddCounty("GÜROYMAK", bitlis, context);
            AddCounty("HIZAN", bitlis, context);
            AddCounty("MUTKI", bitlis, context);
            AddCounty("TATVAN", bitlis, context);

            AddCounty("DÖRTDIVAN", bolu, context);
            AddCounty("GEREDE", bolu, context);
            AddCounty("GÖYNÜK", bolu, context);
            AddCounty("KIBRISCIK", bolu, context);
            AddCounty("MENGEN", bolu, context);
            AddCounty("MUDURNU", bolu, context);
            AddCounty("SEBEN", bolu, context);
            AddCounty("YENIÇAGA", bolu, context);

            AddCounty("AGLASUN", burdur, context);
            AddCounty("ALTINYAYLA", burdur, context);
            AddCounty("BUCAK", burdur, context);
            AddCounty("ÇAVDIR", burdur, context);
            AddCounty("ÇELTIKÇI", burdur, context);
            AddCounty("GÖLHISAR", burdur, context);
            AddCounty("KARAMANLI", burdur, context);
            AddCounty("KEMER", burdur, context);
            AddCounty("TEFENNI", burdur, context);
            AddCounty("YESILOVA", burdur, context);

            AddCounty("BÜYÜKORHAN", bursa, context);
            AddCounty("GEMLIK", bursa, context);
            AddCounty("GÜRSU", bursa, context);
            AddCounty("HARMANCIK", bursa, context);
            AddCounty("INEGÖL", bursa, context);
            AddCounty("IZNIK", bursa, context);
            AddCounty("KARACABEY", bursa, context);
            AddCounty("KELES", bursa, context);
            AddCounty("KESTEL", bursa, context);
            AddCounty("MUDANYA", bursa, context);
            AddCounty("MUSTAFAKEMALPASA", bursa, context);
            AddCounty("NILÜFER", bursa, context);
            AddCounty("ORHANELI", bursa, context);
            AddCounty("ORHANGAZI", bursa, context);
            AddCounty("OSMANGAZI", bursa, context);
            AddCounty("YENISEHIR", bursa, context);
            AddCounty("YILDIRIM", bursa, context);

            AddCounty("AYVACIK", canakkale, context);
            AddCounty("BAYRAMIÇ", canakkale, context);
            AddCounty("BIGA", canakkale, context);
            AddCounty("BOZCAADA", canakkale, context);
            AddCounty("ÇAN", canakkale, context);
            AddCounty("ECEABAT", canakkale, context);
            AddCounty("EZINE", canakkale, context);
            AddCounty("GELIBOLU", canakkale, context);
            AddCounty("IMROZ", canakkale, context);
            AddCounty("LAPSEKI", canakkale, context);
            AddCounty("YENICE", canakkale, context);

            AddCounty("ATKARACALAR", cankiri, context);
            AddCounty("BAYRAMÖREN", cankiri, context);
            AddCounty("ÇERKES", cankiri, context);
            AddCounty("ELDIVAN", cankiri, context);
            AddCounty("ILGAZ", cankiri, context);
            AddCounty("KIZILIRMAK", cankiri, context);
            AddCounty("KORGUN", cankiri, context);
            AddCounty("KURSUNLU", cankiri, context);
            AddCounty("ORTA", cankiri, context);
            AddCounty("SABANÖZÜ", cankiri, context);
            AddCounty("YAPRAKLI", cankiri, context);

            AddCounty("ALACA", corum, context);
            AddCounty("BAYAT", corum, context);
            AddCounty("BOGAZKALE", corum, context);
            AddCounty("DODURGA", corum, context);
            AddCounty("ISKILIP", corum, context);
            AddCounty("KARGI", corum, context);
            AddCounty("LAÇIN", corum, context);
            AddCounty("MECITÖZÜ", corum, context);
            AddCounty("OGUZLAR", corum, context);
            AddCounty("ORTAKÖY", corum, context);
            AddCounty("OSMANCIK", corum, context);
            AddCounty("SUNGURLU", corum, context);
            AddCounty("UGURLUDAG", corum, context);

            AddCounty("ACIPAYAM", denizli, context);
            AddCounty("AKKÖY", denizli, context);
            AddCounty("BABADAG", denizli, context);
            AddCounty("BAKLAN", denizli, context);
            AddCounty("BEKILLI", denizli, context);
            AddCounty("BEYAGAÇ", denizli, context);
            AddCounty("BOZKURT", denizli, context);
            AddCounty("BULDAN", denizli, context);
            AddCounty("ÇAL", denizli, context);
            AddCounty("ÇAMELI", denizli, context);
            AddCounty("ÇARDAK", denizli, context);
            AddCounty("ÇIVRIL", denizli, context);
            AddCounty("GÜNEY", denizli, context);
            AddCounty("HONAZ", denizli, context);
            AddCounty("KALE", denizli, context);
            AddCounty("SARAYKÖY", denizli, context);
            AddCounty("SERINHISAR", denizli, context);
            AddCounty("TAVAS", denizli, context);

            AddCounty("BAGLAR", diyarbakir, context);
            AddCounty("BISMIL", diyarbakir, context);
            AddCounty("ÇERMIK", diyarbakir, context);
            AddCounty("ÇINAR", diyarbakir, context);
            AddCounty("ÇÜNGÜS", diyarbakir, context);
            AddCounty("DICLE", diyarbakir, context);
            AddCounty("EGIL", diyarbakir, context);
            AddCounty("ERGANI", diyarbakir, context);
            AddCounty("HANI", diyarbakir, context);
            AddCounty("HAZRO", diyarbakir, context);
            AddCounty("KAYAPINAR", diyarbakir, context);
            AddCounty("KOCAKÖY", diyarbakir, context);
            AddCounty("KULP", diyarbakir, context);
            AddCounty("LICE", diyarbakir, context);
            AddCounty("SILVAN", diyarbakir, context);
            AddCounty("SUR", diyarbakir, context);
            AddCounty("YENISEHIR", diyarbakir, context);

            AddCounty("ENEZ", edirne, context);
            AddCounty("HAVSA", edirne, context);
            AddCounty("IPSALA", edirne, context);
            AddCounty("KESAN", edirne, context);
            AddCounty("LALAPASA", edirne, context);
            AddCounty("MERIÇ", edirne, context);
            AddCounty("SÜLOGLU", edirne, context);
            AddCounty("UZUNKÖPRÜ", edirne, context);

            AddCounty("AGIN", elazig, context);
            AddCounty("ALACAKAYA", elazig, context);
            AddCounty("ARICAK", elazig, context);
            AddCounty("BASKIL", elazig, context);
            AddCounty("KARAKOÇAN", elazig, context);
            AddCounty("KEBAN", elazig, context);
            AddCounty("KOVANCILAR", elazig, context);
            AddCounty("MADEN", elazig, context);
            AddCounty("PALU", elazig, context);
            AddCounty("SIVRICE", elazig, context);

            AddCounty("ÇAYIRLI", erzincan, context);
            AddCounty("ILIÇ", erzincan, context);
            AddCounty("KEMAH", erzincan, context);
            AddCounty("KEMALIYE", erzincan, context);
            AddCounty("OTLUKBELI", erzincan, context);
            AddCounty("REFAHIYE", erzincan, context);
            AddCounty("TERCAN", erzincan, context);
            AddCounty("ÜZÜMLÜ", erzincan, context);

            AddCounty("ASKALE", erzurum, context);
            AddCounty("AZIZIYE", erzurum, context);
            AddCounty("ÇAT", erzurum, context);
            AddCounty("HINIS", erzurum, context);
            AddCounty("HORASAN", erzurum, context);
            AddCounty("ISPIR", erzurum, context);
            AddCounty("KARAÇOBAN", erzurum, context);
            AddCounty("KARAYAZI", erzurum, context);
            AddCounty("KÖPRÜKÖY", erzurum, context);
            AddCounty("NARMAN", erzurum, context);
            AddCounty("OLTU", erzurum, context);
            AddCounty("OLUR", erzurum, context);
            AddCounty("PALANDÖKEN", erzurum, context);
            AddCounty("PASINLER", erzurum, context);
            AddCounty("PAZARYOLU", erzurum, context);
            AddCounty("SENKAYA", erzurum, context);
            AddCounty("TEKMAN", erzurum, context);
            AddCounty("TORTUM", erzurum, context);
            AddCounty("UZUNDERE", erzurum, context);
            AddCounty("YAKUTIYE", erzurum, context);

            AddCounty("ALPU", eskisehir, context);
            AddCounty("BEYLIKOVA", eskisehir, context);
            AddCounty("ÇIFTELER", eskisehir, context);
            AddCounty("GÜNYÜZÜ", eskisehir, context);
            AddCounty("HAN", eskisehir, context);
            AddCounty("INÖNÜ", eskisehir, context);
            AddCounty("MAHMUDIYE", eskisehir, context);
            AddCounty("MIHALGAZI", eskisehir, context);
            AddCounty("MIHALIÇÇIK", eskisehir, context);
            AddCounty("ODUNPAZARI", eskisehir, context);
            AddCounty("SARICAKAYA", eskisehir, context);
            AddCounty("SEYITGAZI", eskisehir, context);
            AddCounty("SIVRIHISAR", eskisehir, context);
            AddCounty("TEPEBASI", eskisehir, context);

            AddCounty("ARABAN", gaziantep, context);
            AddCounty("ISLAHIYE", gaziantep, context);
            AddCounty("KARKAMIS", gaziantep, context);
            AddCounty("NIZIP", gaziantep, context);
            AddCounty("NURDAGI", gaziantep, context);
            AddCounty("OGUZELI", gaziantep, context);
            AddCounty("SAHINBEY", gaziantep, context);
            AddCounty("SEHITKAMIL", gaziantep, context);
            AddCounty("YAVUZELI", gaziantep, context);

            AddCounty("ALUCRA", giresun, context);
            AddCounty("BULANCAK", giresun, context);
            AddCounty("ÇAMOLUK", giresun, context);
            AddCounty("ÇANAKÇI", giresun, context);
            AddCounty("DERELI", giresun, context);
            AddCounty("DOGANKENT", giresun, context);
            AddCounty("ESPIYE", giresun, context);
            AddCounty("EYNESIL", giresun, context);
            AddCounty("GÖRELE", giresun, context);
            AddCounty("GÜCE", giresun, context);
            AddCounty("KESAP", giresun, context);
            AddCounty("PIRAZIZ", giresun, context);
            AddCounty("SEBINKARAHISAR", giresun, context);
            AddCounty("TIREBOLU", giresun, context);
            AddCounty("YAGLIDERE", giresun, context);

            AddCounty("KELKIT", gumushane, context);
            AddCounty("KÖSE", gumushane, context);
            AddCounty("KÜRTÜN", gumushane, context);
            AddCounty("SIRAN", gumushane, context);
            AddCounty("TORUL", gumushane, context);

            AddCounty("ÇUKURCA", hakkari, context);
            AddCounty("SEMDINLI", hakkari, context);
            AddCounty("YÜKSEKOVA", hakkari, context);

            AddCounty("ALTINÖZÜ", hatay, context);
            AddCounty("BELEN", hatay, context);
            AddCounty("DÖRTYOL", hatay, context);
            AddCounty("ERZIN", hatay, context);
            AddCounty("HASSA", hatay, context);
            AddCounty("ISKENDERUN", hatay, context);
            AddCounty("KIRIKHAN", hatay, context);
            AddCounty("KUMLU", hatay, context);
            AddCounty("REYHANLI", hatay, context);
            AddCounty("SAMANDAG", hatay, context);
            AddCounty("YAYLADAGI", hatay, context);

            AddCounty("AKSU", isparta, context);
            AddCounty("ATABEY", isparta, context);
            AddCounty("EGIRDIR", isparta, context);
            AddCounty("GELENDOST", isparta, context);
            AddCounty("GÖNEN", isparta, context);
            AddCounty("KEÇIBORLU", isparta, context);
            AddCounty("SENIRKENT", isparta, context);
            AddCounty("SÜTÇÜLER", isparta, context);
            AddCounty("SARKIKARAAGAÇ", isparta, context);
            AddCounty("ULUBORLU", isparta, context);
            AddCounty("YALVAÇ", isparta, context);
            AddCounty("YENISARBADEMLI", isparta, context);

            AddCounty("AKDENIZ", mersin, context);
            AddCounty("ANAMUR", mersin, context);
            AddCounty("AYDINCIK", mersin, context);
            AddCounty("BOZYAZI", mersin, context);
            AddCounty("ÇAMLIYAYLA", mersin, context);
            AddCounty("ERDEMLI", mersin, context);
            AddCounty("GÜLNAR", mersin, context);
            AddCounty("MEZITLI", mersin, context);
            AddCounty("MUT", mersin, context);
            AddCounty("SILIFKE", mersin, context);
            AddCounty("TARSUS", mersin, context);
            AddCounty("TOROSLAR", mersin, context);
            AddCounty("YENISEHIR", mersin, context);

            AddCounty("ADALAR", istanbul, context);
            AddCounty("ARNAVUTKÖY", istanbul, context);
            AddCounty("ATASEHIR", istanbul, context);
            AddCounty("AVCILAR", istanbul, context);
            AddCounty("BAGCILAR", istanbul, context);
            AddCounty("BAHÇELIEVLER", istanbul, context);
            AddCounty("BAKIRKÖY", istanbul, context);
            AddCounty("BASAKSEHIR", istanbul, context);
            AddCounty("BAYRAMPASA", istanbul, context);
            AddCounty("BESIKTAS", istanbul, context);
            AddCounty("BEYKOZ", istanbul, context);
            AddCounty("BEYLIKDÜZÜ", istanbul, context);
            AddCounty("BEYOGLU", istanbul, context);
            AddCounty("BÜYÜKÇEKMECE", istanbul, context);
            AddCounty("ÇATALCA", istanbul, context);
            AddCounty("ÇEKMEKÖY", istanbul, context);
            AddCounty("ESENLER", istanbul, context);
            AddCounty("ESENYURT", istanbul, context);
            AddCounty("EYÜP", istanbul, context);
            AddCounty("FATIH", istanbul, context);
            AddCounty("GAZIOSMANPASA", istanbul, context);
            AddCounty("GÜNGÖREN", istanbul, context);
            AddCounty("KADIKÖY", istanbul, context);
            AddCounty("KAGITHANE", istanbul, context);
            AddCounty("KARTAL", istanbul, context);
            AddCounty("KÜÇÜKÇEKMECE", istanbul, context);
            AddCounty("MALTEPE", istanbul, context);
            AddCounty("PENDIK", istanbul, context);
            AddCounty("SANCAKTEPE", istanbul, context);
            AddCounty("SARIYER", istanbul, context);
            AddCounty("SILIVRI", istanbul, context);
            AddCounty("SULTANBEYLI", istanbul, context);
            AddCounty("SULTANGAZI", istanbul, context);
            AddCounty("SILE", istanbul, context);
            AddCounty("SISLI", istanbul, context);
            AddCounty("TUZLA", istanbul, context);
            AddCounty("ÜMRANIYE", istanbul, context);
            AddCounty("ÜSKÜDAR", istanbul, context);
            AddCounty("ZEYTINBURNU", istanbul, context);

            AddCounty("ALIAGA", izmir, context);
            AddCounty("BALÇOVA", izmir, context);
            AddCounty("BAYINDIR", izmir, context);
            AddCounty("BAYRAKLI", izmir, context);
            AddCounty("BERGAMA", izmir, context);
            AddCounty("BEYDAG", izmir, context);
            AddCounty("BORNOVA", izmir, context);
            AddCounty("BUCA", izmir, context);
            AddCounty("ÇESME", izmir, context);
            AddCounty("ÇIGLI", izmir, context);
            AddCounty("DIKILI", izmir, context);
            AddCounty("FOÇA", izmir, context);
            AddCounty("GAZIEMIR", izmir, context);
            AddCounty("GÜZELBAHÇE", izmir, context);
            AddCounty("KARABAGLAR", izmir, context);
            AddCounty("KARABURUN", izmir, context);
            AddCounty("KARSIYAKA", izmir, context);
            AddCounty("KEMALPASA", izmir, context);
            AddCounty("KINIK", izmir, context);
            AddCounty("KIRAZ", izmir, context);
            AddCounty("KONAK", izmir, context);
            AddCounty("MENDERES", izmir, context);
            AddCounty("MENEMEN", izmir, context);
            AddCounty("NARLIDERE", izmir, context);
            AddCounty("ÖDEMIS", izmir, context);
            AddCounty("SEFERIHISAR", izmir, context);
            AddCounty("SELÇUK", izmir, context);
            AddCounty("TIRE", izmir, context);
            AddCounty("TORBALI", izmir, context);
            AddCounty("URLA", izmir, context);

            AddCounty("AKYAKA", kars, context);
            AddCounty("ARPAÇAY", kars, context);
            AddCounty("DIGOR", kars, context);
            AddCounty("KAGIZMAN", kars, context);
            AddCounty("SARIKAMIS", kars, context);
            AddCounty("SELIM", kars, context);
            AddCounty("SUSUZ", kars, context);

            AddCounty("ABANA", kastamonu, context);
            AddCounty("AGLI", kastamonu, context);
            AddCounty("ARAÇ", kastamonu, context);
            AddCounty("AZDAVAY", kastamonu, context);
            AddCounty("BOZKURT", kastamonu, context);
            AddCounty("CIDE", kastamonu, context);
            AddCounty("ÇATALZEYTIN", kastamonu, context);
            AddCounty("DADAY", kastamonu, context);
            AddCounty("DEVREKANI", kastamonu, context);
            AddCounty("DOGANYURT", kastamonu, context);
            AddCounty("HANÖNÜ", kastamonu, context);
            AddCounty("IHSANGAZI", kastamonu, context);
            AddCounty("INEBOLU", kastamonu, context);
            AddCounty("KÜRE", kastamonu, context);
            AddCounty("PINARBASI", kastamonu, context);
            AddCounty("SEYDILER", kastamonu, context);
            AddCounty("SENPAZAR", kastamonu, context);
            AddCounty("TASKÖPRÜ", kastamonu, context);
            AddCounty("TOSYA", kastamonu, context);

            AddCounty("AKKISLA", kayseri, context);
            AddCounty("BÜNYAN", kayseri, context);
            AddCounty("DEVELI", kayseri, context);
            AddCounty("FELAHIYE", kayseri, context);
            AddCounty("HACILAR", kayseri, context);
            AddCounty("INCESU", kayseri, context);
            AddCounty("KOCASINAN", kayseri, context);
            AddCounty("MELIKGAZI", kayseri, context);
            AddCounty("ÖZVATAN", kayseri, context);
            AddCounty("PINARBASI", kayseri, context);
            AddCounty("SARIOGLAN", kayseri, context);
            AddCounty("SARIZ", kayseri, context);
            AddCounty("TALAS", kayseri, context);
            AddCounty("TOMARZA", kayseri, context);
            AddCounty("YAHYALI", kayseri, context);
            AddCounty("YESILHISAR", kayseri, context);

            AddCounty("BABAESKI", kirklareli, context);
            AddCounty("DEMIRKÖY", kirklareli, context);
            AddCounty("KOFÇAZ", kirklareli, context);
            AddCounty("LÜLEBURGAZ", kirklareli, context);
            AddCounty("PEHLIVANKÖY", kirklareli, context);
            AddCounty("PINARHISAR", kirklareli, context);
            AddCounty("VIZE", kirklareli, context);

            AddCounty("AKÇAKENT", kirsehir, context);
            AddCounty("AKPINAR", kirsehir, context);
            AddCounty("BOZTEPE", kirsehir, context);
            AddCounty("ÇIÇEKDAGI", kirsehir, context);
            AddCounty("KAMAN", kirsehir, context);
            AddCounty("MUCUR", kirsehir, context);

            AddCounty("BASISKELE", kocaeli, context);
            AddCounty("ÇAYIROVA", kocaeli, context);
            AddCounty("DARICA", kocaeli, context);
            AddCounty("DERINCE", kocaeli, context);
            AddCounty("DILOVASI", kocaeli, context);
            AddCounty("GEBZE", kocaeli, context);
            AddCounty("GÖLCÜK", kocaeli, context);
            AddCounty("IZMIT", kocaeli, context);
            AddCounty("KANDIRA", kocaeli, context);
            AddCounty("KARAMÜRSEL", kocaeli, context);
            AddCounty("KARTEPE", kocaeli, context);
            AddCounty("KÖRFEZ", kocaeli, context);

            AddCounty("AHIRLI", konya, context);
            AddCounty("AKÖREN", konya, context);
            AddCounty("AKSEHIR", konya, context);
            AddCounty("ALTINEKIN", konya, context);
            AddCounty("BEYSEHIR", konya, context);
            AddCounty("BOZKIR", konya, context);
            AddCounty("CIHANBEYLI", konya, context);
            AddCounty("ÇELTIK", konya, context);
            AddCounty("ÇUMRA", konya, context);
            AddCounty("DERBENT", konya, context);
            AddCounty("DEREBUCAK", konya, context);
            AddCounty("DOGANHISAR", konya, context);
            AddCounty("EMIRGAZI", konya, context);
            AddCounty("EREGLI", konya, context);
            AddCounty("GÜNEYSINIR", konya, context);
            AddCounty("HADIM", konya, context);
            AddCounty("HALKAPINAR", konya, context);
            AddCounty("HÜYÜK", konya, context);
            AddCounty("ILGIN", konya, context);
            AddCounty("KADINHANI", konya, context);
            AddCounty("KARAPINAR", konya, context);
            AddCounty("KARATAY", konya, context);
            AddCounty("KULU", konya, context);
            AddCounty("MERAM", konya, context);
            AddCounty("SARAYÖNÜ", konya, context);
            AddCounty("SELÇUKLU", konya, context);
            AddCounty("SEYDISEHIR", konya, context);
            AddCounty("TASKENT", konya, context);
            AddCounty("TUZLUKÇU", konya, context);
            AddCounty("YALIHÜYÜK", konya, context);
            AddCounty("YUNAK", konya, context);

            AddCounty("ALTINTAS", kutahya, context);
            AddCounty("ASLANAPA", kutahya, context);
            AddCounty("ÇAVDARHISAR", kutahya, context);
            AddCounty("DOMANIÇ", kutahya, context);
            AddCounty("DUMLUPINAR", kutahya, context);
            AddCounty("EMET", kutahya, context);
            AddCounty("GEDIZ", kutahya, context);
            AddCounty("HISARCIK", kutahya, context);
            AddCounty("PAZARLAR", kutahya, context);
            AddCounty("SIMAV", kutahya, context);
            AddCounty("SAPHANE", kutahya, context);
            AddCounty("TAVSANLI", kutahya, context);

            AddCounty("AKÇADAG", malatya, context);
            AddCounty("ARAPGIR", malatya, context);
            AddCounty("ARGUVAN", malatya, context);
            AddCounty("BATTALGAZI", malatya, context);
            AddCounty("DARENDE", malatya, context);
            AddCounty("DOGANSEHIR", malatya, context);
            AddCounty("DOGANYOL", malatya, context);
            AddCounty("HEKIMHAN", malatya, context);
            AddCounty("KALE", malatya, context);
            AddCounty("KULUNCAK", malatya, context);
            AddCounty("PÜTÜRGE", malatya, context);
            AddCounty("YAZIHAN", malatya, context);
            AddCounty("YESILYURT", malatya, context);

            AddCounty("AHMETLI", manisa, context);
            AddCounty("AKHISAR", manisa, context);
            AddCounty("ALASEHIR", manisa, context);
            AddCounty("DEMIRCI", manisa, context);
            AddCounty("GÖLMARMARA", manisa, context);
            AddCounty("GÖRDES", manisa, context);
            AddCounty("KIRKAGAÇ", manisa, context);
            AddCounty("KÖPRÜBASI", manisa, context);
            AddCounty("KULA", manisa, context);
            AddCounty("SALIHLI", manisa, context);
            AddCounty("SARIGÖL", manisa, context);
            AddCounty("SARUHANLI", manisa, context);
            AddCounty("SELENDI", manisa, context);
            AddCounty("SOMA", manisa, context);
            AddCounty("TURGUTLU", manisa, context);

            AddCounty("AFSIN", maras, context);
            AddCounty("ANDIRIN", maras, context);
            AddCounty("ÇAGLAYANCERIT", maras, context);
            AddCounty("EKINÖZÜ", maras, context);
            AddCounty("ELBISTAN", maras, context);
            AddCounty("GÖKSUN", maras, context);
            AddCounty("NURHAK", maras, context);
            AddCounty("PAZARCIK", maras, context);
            AddCounty("TÜRKOGLU", maras, context);

            AddCounty("DARGEÇIT", mardin, context);
            AddCounty("DERIK", mardin, context);
            AddCounty("KIZILTEPE", mardin, context);
            AddCounty("MAZIDAGI", mardin, context);
            AddCounty("MIDYAT", mardin, context);
            AddCounty("NUSAYBIN", mardin, context);
            AddCounty("ÖMERLI", mardin, context);
            AddCounty("SAVUR", mardin, context);
            AddCounty("YESILLI", mardin, context);

            AddCounty("BODRUM", mugla, context);
            AddCounty("DALAMAN", mugla, context);
            AddCounty("DATÇA", mugla, context);
            AddCounty("FETHIYE", mugla, context);
            AddCounty("KAVAKLIDERE", mugla, context);
            AddCounty("KÖYCEGIZ", mugla, context);
            AddCounty("MARMARIS", mugla, context);
            AddCounty("MILAS", mugla, context);
            AddCounty("ORTACA", mugla, context);
            AddCounty("ULA", mugla, context);
            AddCounty("YATAGAN", mugla, context);

            AddCounty("BULANIK", mus, context);
            AddCounty("HASKÖY", mus, context);
            AddCounty("KORKUT", mus, context);
            AddCounty("MALAZGIRT", mus, context);
            AddCounty("VARTO", mus, context);

            AddCounty("ACIGÖL", nevsehir, context);
            AddCounty("AVANOS", nevsehir, context);
            AddCounty("DERINKUYU", nevsehir, context);
            AddCounty("GÜLSEHIR", nevsehir, context);
            AddCounty("HACIBEKTAS", nevsehir, context);
            AddCounty("KOZAKLI", nevsehir, context);
            AddCounty("ÜRGÜP", nevsehir, context);

            AddCounty("ALTUNHISAR", nigde, context);
            AddCounty("BOR", nigde, context);
            AddCounty("ÇAMARDI", nigde, context);
            AddCounty("ÇIFTLIK", nigde, context);
            AddCounty("ULUKISLA", nigde, context);

            AddCounty("AKKUS", ordu, context);
            AddCounty("AYBASTI", ordu, context);
            AddCounty("ÇAMAS", ordu, context);
            AddCounty("ÇATALPINAR", ordu, context);
            AddCounty("ÇAYBASI", ordu, context);
            AddCounty("FATSA", ordu, context);
            AddCounty("GÖLKÖY", ordu, context);
            AddCounty("GÜLYALI", ordu, context);
            AddCounty("GÜRGENTEPE", ordu, context);
            AddCounty("IKIZCE", ordu, context);
            AddCounty("KABADÜZ", ordu, context);
            AddCounty("KABATAS", ordu, context);
            AddCounty("KORGAN", ordu, context);
            AddCounty("KUMRU", ordu, context);
            AddCounty("MESUDIYE", ordu, context);
            AddCounty("PERSEMBE", ordu, context);
            AddCounty("ULUBEY", ordu, context);
            AddCounty("ÜNYE", ordu, context);

            AddCounty("ARDESEN", rize, context);
            AddCounty("ÇAMLIHEMSIN", rize, context);
            AddCounty("ÇAYELI", rize, context);
            AddCounty("DEREPAZARI", rize, context);
            AddCounty("FINDIKLI", rize, context);
            AddCounty("GÜNEYSU", rize, context);
            AddCounty("HEMSIN", rize, context);
            AddCounty("IKIZDERE", rize, context);
            AddCounty("IYIDERE", rize, context);
            AddCounty("KALKANDERE", rize, context);
            AddCounty("PAZAR", rize, context);

            AddCounty("ADAPAZARI", sakarya, context);
            AddCounty("AKYAZI", sakarya, context);
            AddCounty("ARIFIYE", sakarya, context);
            AddCounty("ERENLER", sakarya, context);
            AddCounty("FERIZLI", sakarya, context);
            AddCounty("GEYVE", sakarya, context);
            AddCounty("HENDEK", sakarya, context);
            AddCounty("KARAPÜRÇEK", sakarya, context);
            AddCounty("KARASU", sakarya, context);
            AddCounty("KAYNARCA", sakarya, context);
            AddCounty("KOCAALI", sakarya, context);
            AddCounty("PAMUKOVA", sakarya, context);
            AddCounty("SAPANCA", sakarya, context);
            AddCounty("SERDIVAN", sakarya, context);
            AddCounty("SÖGÜTLÜ", sakarya, context);
            AddCounty("TARAKLI", sakarya, context);


            AddCounty("19 MAYIS", samsun, context);
            AddCounty("ALAÇAM", samsun, context);
            AddCounty("ASARCIK", samsun, context);
            AddCounty("ATAKUM", samsun, context);
            AddCounty("AYVACIK", samsun, context);
            AddCounty("BAFRA", samsun, context);
            AddCounty("CANIK", samsun, context);
            AddCounty("ÇARSAMBA", samsun, context);
            AddCounty("HAVZA", samsun, context);
            AddCounty("ILKADIM", samsun, context);
            AddCounty("KAVAK", samsun, context);
            AddCounty("LADIK", samsun, context);
            AddCounty("SALIPAZARI", samsun, context);
            AddCounty("TEKKEKÖY", samsun, context);
            AddCounty("TERME", samsun, context);
            AddCounty("VEZIRKÖPRÜ", samsun, context);
            AddCounty("YAKAKENT", samsun, context);

            AddCounty("AYDINLAR", siirt, context);
            AddCounty("BAYKAN", siirt, context);
            AddCounty("ERUH", siirt, context);
            AddCounty("KURTALAN", siirt, context);
            AddCounty("PERVARI", siirt, context);
            AddCounty("SIRVAN", siirt, context);

            AddCounty("AYANCIK", sinop, context);
            AddCounty("BOYABAT", sinop, context);
            AddCounty("DIKMEN", sinop, context);
            AddCounty("DURAGAN", sinop, context);
            AddCounty("ERFELEK", sinop, context);
            AddCounty("GERZE", sinop, context);
            AddCounty("SARAYDÜZÜ", sinop, context);
            AddCounty("TÜRKELI", sinop, context);

            AddCounty("AKINCILAR", sivas, context);
            AddCounty("ALTINYAYLA", sivas, context);
            AddCounty("DIVRIGI", sivas, context);
            AddCounty("DOGANSAR", sivas, context);
            AddCounty("GEMEREK", sivas, context);
            AddCounty("GÖLOVA", sivas, context);
            AddCounty("GÜRÜN", sivas, context);
            AddCounty("HAFIK", sivas, context);
            AddCounty("IMRANLI", sivas, context);
            AddCounty("KANGAL", sivas, context);
            AddCounty("KOYULHISAR", sivas, context);
            AddCounty("SUSEHRI", sivas, context);
            AddCounty("SARKISLA", sivas, context);
            AddCounty("ULAS", sivas, context);
            AddCounty("YILDIZELI", sivas, context);
            AddCounty("ZARA", sivas, context);

            AddCounty("ÇERKEZKÖY", tekirdag, context);
            AddCounty("ÇORLU", tekirdag, context);
            AddCounty("HAYRABOLU", tekirdag, context);
            AddCounty("MALKARA", tekirdag, context);
            AddCounty("MARMARAEREGLISI", tekirdag, context);
            AddCounty("MURATLI", tekirdag, context);
            AddCounty("SARAY", tekirdag, context);
            AddCounty("SARKÖY", tekirdag, context);

            AddCounty("ALMUS", tokat, context);
            AddCounty("ARTOVA", tokat, context);
            AddCounty("BASÇIFTLIK", tokat, context);
            AddCounty("ERBAA", tokat, context);
            AddCounty("NIKSAR", tokat, context);
            AddCounty("PAZAR", tokat, context);
            AddCounty("RESADIYE", tokat, context);
            AddCounty("SULUSARAY", tokat, context);
            AddCounty("TURHAL", tokat, context);
            AddCounty("YESILYURT", tokat, context);
            AddCounty("ZILE", tokat, context);

            AddCounty("AKÇAABAT", trabzon, context);
            AddCounty("ARAKLI", trabzon, context);
            AddCounty("ARSIN", trabzon, context);
            AddCounty("BESIKDÜZÜ", trabzon, context);
            AddCounty("ÇARSIBASI", trabzon, context);
            AddCounty("ÇAYKARA", trabzon, context);
            AddCounty("DERNEKPAZARI", trabzon, context);
            AddCounty("DÜZKÖY", trabzon, context);
            AddCounty("HAYRAT", trabzon, context);
            AddCounty("KÖPRÜBASI", trabzon, context);
            AddCounty("MAÇKA", trabzon, context);
            AddCounty("OF", trabzon, context);
            AddCounty("SÜRMENE", trabzon, context);
            AddCounty("SALPAZARI", trabzon, context);
            AddCounty("TONYA", trabzon, context);
            AddCounty("VAKFIKEBIR", trabzon, context);
            AddCounty("YOMRA", trabzon, context);

            AddCounty("ÇEMISGEZEK", tunceli, context);
            AddCounty("HOZAT", tunceli, context);
            AddCounty("MAZGIRT", tunceli, context);
            AddCounty("NAZIMIYE", tunceli, context);
            AddCounty("OVACIK", tunceli, context);
            AddCounty("PERTEK", tunceli, context);
            AddCounty("PÜLÜMÜR", tunceli, context);

            AddCounty("AKÇAKALE", urfa, context);
            AddCounty("BIRECIK", urfa, context);
            AddCounty("BOZOVA", urfa, context);
            AddCounty("CEYLANPINAR", urfa, context);
            AddCounty("HALFETI", urfa, context);
            AddCounty("HARRAN", urfa, context);
            AddCounty("HILVAN", urfa, context);
            AddCounty("SIVEREK", urfa, context);
            AddCounty("SURUÇ", urfa, context);
            AddCounty("VIRANSEHIR", urfa, context);

            AddCounty("BANAZ", usak, context);
            AddCounty("ESME", usak, context);
            AddCounty("KARAHALLI", usak, context);
            AddCounty("SIVASLI", usak, context);
            AddCounty("ULUBEY", usak, context);

            AddCounty("BAHÇESARAY", van, context);
            AddCounty("BASKALE", van, context);
            AddCounty("ÇALDIRAN", van, context);
            AddCounty("ÇATAK", van, context);
            AddCounty("EDREMIT", van, context);
            AddCounty("ERCIS", van, context);
            AddCounty("GEVAS", van, context);
            AddCounty("GÜRPINAR", van, context);
            AddCounty("MURADIYE", van, context);
            AddCounty("ÖZALP", van, context);
            AddCounty("SARAY", van, context);

            AddCounty("AKDAGMADENI", yozgat, context);
            AddCounty("AYDINCIK", yozgat, context);
            AddCounty("BOGAZLIYAN", yozgat, context);
            AddCounty("ÇANDIR", yozgat, context);
            AddCounty("ÇAYIRALAN", yozgat, context);
            AddCounty("ÇEKEREK", yozgat, context);
            AddCounty("KADISEHRI", yozgat, context);
            AddCounty("SARAYKENT", yozgat, context);
            AddCounty("SARIKAYA", yozgat, context);
            AddCounty("SORGUN", yozgat, context);
            AddCounty("SEFAATLI", yozgat, context);
            AddCounty("YENIFAKILI", yozgat, context);
            AddCounty("YERKÖY", yozgat, context);

            AddCounty("ALAPLI", zonguldak, context);
            AddCounty("ÇAYCUMA", zonguldak, context);
            AddCounty("DEVREK", zonguldak, context);
            AddCounty("EREGLI", zonguldak, context);
            AddCounty("GÖKÇEBEY", zonguldak, context);

            AddCounty("AGAÇÖREN", aksaray, context);
            AddCounty("ESKIL", aksaray, context);
            AddCounty("GÜLAGAÇ", aksaray, context);
            AddCounty("GÜZELYURT", aksaray, context);
            AddCounty("ORTAKÖY", aksaray, context);
            AddCounty("SARIYAHSI", aksaray, context);

            AddCounty("AYDINTEPE", bayburt, context);
            AddCounty("DEMIRÖZÜ", bayburt, context);

            AddCounty("AYRANCI", karaman, context);
            AddCounty("BASYAYLA", karaman, context);
            AddCounty("ERMENEK", karaman, context);
            AddCounty("KAZIMKARABEKIR", karaman, context);
            AddCounty("SARIVELILER", karaman, context);

            AddCounty("BAHSILI", kirikkale, context);
            AddCounty("BALISEYH", kirikkale, context);
            AddCounty("ÇELEBI", kirikkale, context);
            AddCounty("DELICE", kirikkale, context);
            AddCounty("KARAKEÇILI", kirikkale, context);
            AddCounty("KESKIN", kirikkale, context);
            AddCounty("SULAKYURT", kirikkale, context);
            AddCounty("YAHSIHAN", kirikkale, context);

            AddCounty("BESIRI", batman, context);
            AddCounty("GERCÜS", batman, context);
            AddCounty("HASANKEYF", batman, context);
            AddCounty("KOZLUK", batman, context);
            AddCounty("SASON", batman, context);

            AddCounty("BEYTÜSSEBAP", sirnak, context);
            AddCounty("CIZRE", sirnak, context);
            AddCounty("GÜÇLÜKONAK", sirnak, context);
            AddCounty("IDIL", sirnak, context);
            AddCounty("SILOPI", sirnak, context);
            AddCounty("ULUDERE", sirnak, context);

            AddCounty("AMASRA", bartin, context);
            AddCounty("KURUCASILE", bartin, context);
            AddCounty("ULUS", bartin, context);

            AddCounty("ÇILDIR", ardahan, context);
            AddCounty("DAMAL", ardahan, context);
            AddCounty("GÖLE", ardahan, context);
            AddCounty("HANAK", ardahan, context);
            AddCounty("POSOF", ardahan, context);

            AddCounty("ARALIK", igdir, context);
            AddCounty("KARAKOYUNLU", igdir, context);
            AddCounty("TUZLUCA", igdir, context);

            AddCounty("ALTINOVA", yalova, context);
            AddCounty("ARMUTLU", yalova, context);
            AddCounty("ÇINARCIK", yalova, context);
            AddCounty("ÇIFTLIKKÖY", yalova, context);
            AddCounty("TERMAL", yalova, context);

            AddCounty("EFLANI", karabuk, context);
            AddCounty("ESKIPAZAR", karabuk, context);
            AddCounty("OVACIK", karabuk, context);
            AddCounty("SAFRANBOLU", karabuk, context);
            AddCounty("YENICE", karabuk, context);

            AddCounty("ELBEYLI", kilis, context);
            AddCounty("MUSABEYLI", kilis, context);
            AddCounty("POLATELI", kilis, context);

            AddCounty("BAHÇE", osmaniye, context);
            AddCounty("DÜZIÇI", osmaniye, context);
            AddCounty("HASANBEYLI", osmaniye, context);
            AddCounty("KADIRLI", osmaniye, context);
            AddCounty("SUMBAS", osmaniye, context);
            AddCounty("TOPRAKKALE", osmaniye, context);

            AddCounty("AKÇAKOCA", duzce, context);
            AddCounty("CUMAYERI", duzce, context);
            AddCounty("ÇILIMLI", duzce, context);
            AddCounty("GÖLYAKA", duzce, context);
            AddCounty("Gümüşova", duzce, context);
            AddCounty("Kaynaşlı", duzce, context);
            AddCounty("Yığılca", duzce, context);
            
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

        private static void AddCounty(string name, City city, MembershipDB context)
        {
            var _name = name.Trim();

            context.Counties.AddOrUpdate(new County
            {
                Name = string.Format("{0}{1}", _name[0], _name.Substring(1).ToLower()),
                City = city,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UpdatedBy = 1
            });
        }

    }
}
