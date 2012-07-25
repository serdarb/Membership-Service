using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Membership.Utils;

namespace Membership.Data
{
    public static class MetaInit
    {
        public static void InsertCountryTurkeyAndGeoZones(MembershipDB context)
        {
            var countryTurkey = new Country
            {
                Id = 90,
                CountryCode = "tr",
                Name = "Türkiye Cumhuriyeti",
                ShortName = "Türkiye",
                Comment = string.Empty,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            };
            context.Countries.Add(countryTurkey);
            context.SaveChanges();

            AddGeoZone("Marmara", countryTurkey, context);
            AddGeoZone("Ege", countryTurkey, context);
            AddGeoZone("Akdeniz", countryTurkey, context);
            AddGeoZone("Karadeniz", countryTurkey, context);
            AddGeoZone("Doğu Anadolu", countryTurkey, context);
            AddGeoZone("İç Anadolu", countryTurkey, context);
            AddGeoZone("Güneydoğu Anadolu", countryTurkey, context);

            context.SaveChanges();
        }

        private static void AddGeoZone(string name, Country country, MembershipDB context)
        {
            context.GeoZones.Add(new GeoZone
            {
                Country = country,
                Name = name.Trim(),
                Comment = string.Empty,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertGender(MembershipDB context)
        {
            AddGender("Woman", context);
            AddGender("Man", context);
            AddGender("Other", context);

            context.SaveChanges();
        }

        private static void AddGender(string name, MembershipDB context)
        {
            context.Genders.Add(new Gender
            {
                Name = name.Trim(),
                Comment = string.Empty,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertLogEvent(MembershipDB context)
        {
            AddLogEvent("Programatic Update", "A data manipulation via code", context);
            AddLogEvent("Admin Panel Data Update", "An update, insert or delete action occured", context);

            context.SaveChanges();
        }

        private static void AddLogEvent(string name, string description, MembershipDB context)
        {
            context.LogEvents.Add(new LogEvent
            {
                Name = name.Trim(),
                Description = description.Trim(),
                Comment = string.Empty,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertUserType(MembershipDB context)
        {
            AddUserType("Client", context);
            AddUserType("Silver Client", context);
            AddUserType("Gold Client", context);

            context.SaveChanges();
        }

        private static void AddUserType(string name, MembershipDB context)
        {
            context.UserTypes.Add(new UserType
            {
                Name = name.Trim(),
                Description = string.Empty,
                Comment = string.Empty,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertCity(MembershipDB context)
        {
            var marmara = context.GeoZones.First(x => x.Name == "Marmara");
            var akdeniz = context.GeoZones.First(x => x.Name == "Akdeniz");
            var karadeniz = context.GeoZones.First(x => x.Name == "Karadeniz");
            var ege = context.GeoZones.First(x => x.Name == "Ege");
            var icAnadolu = context.GeoZones.First(x => x.Name == "İç Anadolu");
            var doguAnadolu = context.GeoZones.First(x => x.Name == "Doğu Anadolu");
            var guneydoguAnadolu = context.GeoZones.First(x => x.Name == "Güneydoğu Anadolu");

            AddCity(01, "ADANA", akdeniz, context);
            AddCity(02, "ADIYAMAN", guneydoguAnadolu, context);
            AddCity(03, "AFYONKARAHİSAR", ege, context);
            AddCity(04, "AĞRI", doguAnadolu, context);
            AddCity(05, "AMASYA", karadeniz, context);
            AddCity(06, "ANKARA", icAnadolu, context);
            AddCity(07, "ANTALYA", akdeniz, context);
            AddCity(08, "ARTVİN", karadeniz, context);
            AddCity(09, "AYDIN", ege, context);
            AddCity(10, "BALIKESİR", marmara, context);
            AddCity(11, "BİLECİK", marmara, context);
            AddCity(12, "BİNGÖL", doguAnadolu, context);
            AddCity(13, "BİTLİS", doguAnadolu, context);
            AddCity(14, "BOLU", karadeniz, context);
            AddCity(15, "BURDUR", akdeniz, context);
            AddCity(16, "BURSA", marmara, context);
            AddCity(17, "ÇANAKKALE", marmara, context);
            AddCity(18, "ÇANKIRI", icAnadolu, context);
            AddCity(19, "ÇORUM", karadeniz, context);
            AddCity(20, "DENİZLİ", ege, context);
            AddCity(21, "DİYARBAKIR", guneydoguAnadolu, context);
            AddCity(22, "EDİRNE", marmara, context);
            AddCity(23, "ELAZIĞ", doguAnadolu, context);
            AddCity(24, "ERZİNCAN", doguAnadolu, context);
            AddCity(25, "ERZURUM", doguAnadolu, context);
            AddCity(26, "ESKİŞEHİR", icAnadolu, context);
            AddCity(27, "GAZİANTEP", guneydoguAnadolu, context);
            AddCity(28, "GİRESUN", karadeniz, context);
            AddCity(29, "GÜMÜŞHANE", karadeniz, context);
            AddCity(30, "HAKKARİ", doguAnadolu, context);
            AddCity(31, "HATAY", akdeniz, context);
            AddCity(32, "ISPARTA", akdeniz, context);
            AddCity(33, "MERSİN", akdeniz, context);
            AddCity(34, "İSTANBUL", marmara, context);
            AddCity(35, "İZMİR", ege, context);
            AddCity(36, "KARS", doguAnadolu, context);
            AddCity(37, "KASTAMONU", karadeniz, context);
            AddCity(38, "KAYSERİ", icAnadolu, context);
            AddCity(39, "KIRKLARELİ", marmara, context);
            AddCity(40, "KIRŞEHİR", icAnadolu, context);
            AddCity(41, "KOCAELİ", marmara, context);
            AddCity(42, "KONYA", icAnadolu, context);
            AddCity(43, "KÜTAHYA", ege, context);
            AddCity(44, "MALATYA", doguAnadolu, context);
            AddCity(45, "MANİSA", ege, context);
            AddCity(46, "KAHRAMANMARAŞ", akdeniz, context);
            AddCity(47, "MARDİN", guneydoguAnadolu, context);
            AddCity(48, "MUĞLA", ege, context);
            AddCity(49, "MUŞ", doguAnadolu, context);
            AddCity(50, "NEVŞEHİR", icAnadolu, context);
            AddCity(51, "NİĞDE", icAnadolu, context);
            AddCity(52, "ORDU", karadeniz, context);
            AddCity(53, "RİZE", karadeniz, context);
            AddCity(54, "SAKARYA", marmara, context);
            AddCity(55, "SAMSUN", karadeniz, context);
            AddCity(56, "SİİRT", guneydoguAnadolu, context);
            AddCity(57, "SİNOP", karadeniz, context);
            AddCity(58, "SİVAS", icAnadolu, context);
            AddCity(59, "TEKİRDAĞ", marmara, context);
            AddCity(60, "TOKAT", icAnadolu, context);
            AddCity(61, "TRABZON", karadeniz, context);
            AddCity(62, "TUNCELİ", doguAnadolu, context);
            AddCity(63, "ŞANLIURFA", guneydoguAnadolu, context);
            AddCity(64, "UŞAK", ege, context);
            AddCity(65, "VAN", doguAnadolu, context);
            AddCity(66, "YOZGAT", icAnadolu, context);
            AddCity(67, "ZONGULDAK", karadeniz, context);
            AddCity(68, "AKSARAY", icAnadolu, context);
            AddCity(69, "BAYBURT", karadeniz, context);
            AddCity(70, "KARAMAN", icAnadolu, context);
            AddCity(71, "KIRIKKALE", icAnadolu, context);
            AddCity(72, "BATMAN", guneydoguAnadolu, context);
            AddCity(73, "ŞIRNAK", doguAnadolu, context);
            AddCity(74, "BARTIN", karadeniz, context);
            AddCity(75, "ARDAHAN", doguAnadolu, context);
            AddCity(76, "IĞDIR", doguAnadolu, context);
            AddCity(77, "YALOVA", marmara, context);
            AddCity(78, "KARABÜK", karadeniz, context);
            AddCity(79, "KİLİS", guneydoguAnadolu, context);
            AddCity(80, "OSMANİYE", akdeniz, context);
            AddCity(81, "DÜZCE", karadeniz, context);

            context.SaveChanges();
        }

        private static void AddCity(int id, string name, GeoZone geozone, MembershipDB context)
        {
            var _name = name.Trim();

            context.Cities.Add(new City
            {
                Name = string.Format("{0}{1}", _name[0], _name.Substring(1).ToLower()),
                Id = id,
                GeoZone = geozone,
                Comment = string.Empty,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertCounty(MembershipDB context)
        {
            var adana = context.Cities.First(x => x.Name == "Adana");
            var adiyaman = context.Cities.First(x => x.Name == "Adıyaman");
            var afyonKarahisar = context.Cities.First(x => x.Name == "AfyonKarahisar");
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

            AddCounty("ALADAĞ", adana, context);
            AddCounty("CEYHAN", adana, context);
            AddCounty("ÇUKUROVA", adana, context);
            AddCounty("FEKE", adana, context);
            AddCounty("İMAMOĞLU", adana, context);
            AddCounty("KARAİSALI", adana, context);
            AddCounty("KARATAŞ", adana, context);
            AddCounty("KOZAN", adana, context);
            AddCounty("POZANTI", adana, context);
            AddCounty("SAİMBEYLİ", adana, context);
            AddCounty("SARIÇAM", adana, context);
            AddCounty("SEYHAN", adana, context);
            AddCounty("TUFANBEYLİ", adana, context);
            AddCounty("YUMURTALIK", adana, context);
            AddCounty("YÜREĞİR", adana, context);

            AddCounty("BESNİ", adiyaman, context);
            AddCounty("ÇELİKHAN", adiyaman, context);
            AddCounty("GERGER", adiyaman, context);
            AddCounty("GÖLBAŞI", adiyaman, context);
            AddCounty("KAHTA", adiyaman, context);
            AddCounty("SAMSAT", adiyaman, context);
            AddCounty("SİNCİK", adiyaman, context);
            AddCounty("TUT", adiyaman, context);

            AddCounty("BAŞMAKÇI", afyonKarahisar, context);
            AddCounty("BAYAT", afyonKarahisar, context);
            AddCounty("BOLVADİN", afyonKarahisar, context);
            AddCounty("ÇAY", afyonKarahisar, context);
            AddCounty("ÇOBANLAR", afyonKarahisar, context);
            AddCounty("DAZKIRI", afyonKarahisar, context);
            AddCounty("DİNAR", afyonKarahisar, context);
            AddCounty("EMİRDAĞ", afyonKarahisar, context);
            AddCounty("EVCİLER", afyonKarahisar, context);
            AddCounty("HOCALAR", afyonKarahisar, context);
            AddCounty("İHSANİYE", afyonKarahisar, context);
            AddCounty("İSCEHİSAR", afyonKarahisar, context);
            AddCounty("KIZILÖREN", afyonKarahisar, context);
            AddCounty("SANDIKLI", afyonKarahisar, context);
            AddCounty("SİNANPAŞA", afyonKarahisar, context);
            AddCounty("SULTANDAĞI", afyonKarahisar, context);
            AddCounty("ŞUHUT", afyonKarahisar, context);

            AddCounty("DİYADİN", agri, context);
            AddCounty("DOĞUBAYAZIT", agri, context);
            AddCounty("ELEŞKİRT", agri, context);
            AddCounty("HAMUR", agri, context);
            AddCounty("PATNOS", agri, context);
            AddCounty("TAŞLIÇAY", agri, context);
            AddCounty("TUTAK", agri, context);

            AddCounty("GÖYNÜCEK", amasya, context);
            AddCounty("GÜMÜŞHACIKÖY", amasya, context);
            AddCounty("HAMAMÖZÜ", amasya, context);
            AddCounty("MERZİFON", amasya, context);
            AddCounty("SULUOVA", amasya, context);
            AddCounty("TAŞOVA", amasya, context);

            AddCounty("AKYURT", ankara, context);
            AddCounty("ALTINDAĞ", ankara, context);
            AddCounty("AYAŞ", ankara, context);
            AddCounty("BALA", ankara, context);
            AddCounty("BEYPAZARI", ankara, context);
            AddCounty("ÇAMLIDERE", ankara, context);
            AddCounty("ÇANKAYA", ankara, context);
            AddCounty("ÇUBUK", ankara, context);
            AddCounty("ELMADAĞ", ankara, context);
            AddCounty("ETİMESGUT", ankara, context);
            AddCounty("EVREN", ankara, context);
            AddCounty("GÖLBAŞI", ankara, context);
            AddCounty("GÜDÜL", ankara, context);
            AddCounty("HAYMANA", ankara, context);
            AddCounty("KALECİK", ankara, context);
            AddCounty("KAZAN", ankara, context);
            AddCounty("KEÇİÖREN", ankara, context);
            AddCounty("KIZILCAHAMAM", ankara, context);
            AddCounty("MAMAK", ankara, context);
            AddCounty("NALLIHAN", ankara, context);
            AddCounty("POLATLI", ankara, context);
            AddCounty("PURSAKLAR", ankara, context);
            AddCounty("SİNCAN", ankara, context);
            AddCounty("ŞEREFLİKOÇHİSAR", ankara, context);
            AddCounty("YENİMAHALLE", ankara, context);

            AddCounty("AKSEKİ", antalya, context);
            AddCounty("AKSU", antalya, context);
            AddCounty("ALANYA", antalya, context);
            AddCounty("DEMRE", antalya, context);
            AddCounty("DÖŞEMEALTI", antalya, context);
            AddCounty("ELMALI", antalya, context);
            AddCounty("FİNİKE", antalya, context);
            AddCounty("GAZİPAŞA", antalya, context);
            AddCounty("GÜNDOĞMUŞ", antalya, context);
            AddCounty("İBRADI", antalya, context);
            AddCounty("KAŞ", antalya, context);
            AddCounty("KEMER", antalya, context);
            AddCounty("KEPEZ", antalya, context);
            AddCounty("KONYAALTI", antalya, context);
            AddCounty("KORKUTELİ", antalya, context);
            AddCounty("KUMLUCA", antalya, context);
            AddCounty("MANAVGAT", antalya, context);
            AddCounty("MURATPAŞA", antalya, context);
            AddCounty("SERİK", antalya, context);

            AddCounty("ARDANUÇ", artvin, context);
            AddCounty("ARHAVİ", artvin, context);
            AddCounty("BORÇKA", artvin, context);
            AddCounty("HOPA", artvin, context);
            AddCounty("MURGUL", artvin, context);
            AddCounty("ŞAVŞAT", artvin, context);
            AddCounty("YUSUFELİ", artvin, context);

            AddCounty("BOZDOĞAN", aydin, context);
            AddCounty("BUHARKENT", aydin, context);
            AddCounty("ÇİNE", aydin, context);
            AddCounty("DİDİM", aydin, context);
            AddCounty("GERMENCİK", aydin, context);
            AddCounty("İNCİRLİOVA", aydin, context);
            AddCounty("KARACASU", aydin, context);
            AddCounty("KARPUZLU", aydin, context);
            AddCounty("KOÇARLI", aydin, context);
            AddCounty("KÖŞK", aydin, context);
            AddCounty("KUŞADASI", aydin, context);
            AddCounty("KUYUCAK", aydin, context);
            AddCounty("NAZİLLİ", aydin, context);
            AddCounty("SÖKE", aydin, context);
            AddCounty("SULTANHİSAR", aydin, context);
            AddCounty("YENİPAZAR", aydin, context);

            AddCounty("AYVALIK", balikesir, context);
            AddCounty("BALYA", balikesir, context);
            AddCounty("BANDIRMA", balikesir, context);
            AddCounty("BİGADİÇ", balikesir, context);
            AddCounty("BURHANİYE", balikesir, context);
            AddCounty("DURSUNBEY", balikesir, context);
            AddCounty("EDREMİT", balikesir, context);
            AddCounty("ERDEK", balikesir, context);
            AddCounty("GÖMEÇ", balikesir, context);
            AddCounty("GÖNEN", balikesir, context);
            AddCounty("HAVRAN", balikesir, context);
            AddCounty("İVRİNDİ", balikesir, context);
            AddCounty("KEPSUT", balikesir, context);
            AddCounty("MANYAS", balikesir, context);
            AddCounty("MARMARA", balikesir, context);
            AddCounty("SAVAŞTEPE", balikesir, context);
            AddCounty("SINDIRGI", balikesir, context);
            AddCounty("SUSURLUK", balikesir, context);

            AddCounty("BOZÜYÜK", bilecik, context);
            AddCounty("GÖLPAZARI", bilecik, context);
            AddCounty("İNHİSAR", bilecik, context);
            AddCounty("OSMANELİ", bilecik, context);
            AddCounty("PAZARYERİ", bilecik, context);
            AddCounty("SÖĞÜT", bilecik, context);
            AddCounty("YENİPAZAR", bilecik, context);

            AddCounty("ADAKLI", bingol, context);
            AddCounty("GENÇ", bingol, context);
            AddCounty("KARLIOVA", bingol, context);
            AddCounty("KİĞI", bingol, context);
            AddCounty("SOLHAN", bingol, context);
            AddCounty("YAYLADERE", bingol, context);
            AddCounty("YEDİSU", bingol, context);

            AddCounty("ADİLCEVAZ", bitlis, context);
            AddCounty("AHLAT", bitlis, context);
            AddCounty("GÜROYMAK", bitlis, context);
            AddCounty("HİZAN", bitlis, context);
            AddCounty("MUTKİ", bitlis, context);
            AddCounty("TATVAN", bitlis, context);

            AddCounty("DÖRTDİVAN", bolu, context);
            AddCounty("GEREDE", bolu, context);
            AddCounty("GÖYNÜK", bolu, context);
            AddCounty("KIBRISCIK", bolu, context);
            AddCounty("MENGEN", bolu, context);
            AddCounty("MUDURNU", bolu, context);
            AddCounty("SEBEN", bolu, context);
            AddCounty("YENİÇAĞA", bolu, context);

            AddCounty("AĞLASUN", burdur, context);
            AddCounty("ALTINYAYLA", burdur, context);
            AddCounty("BUCAK", burdur, context);
            AddCounty("ÇAVDIR", burdur, context);
            AddCounty("ÇELTİKÇİ", burdur, context);
            AddCounty("GÖLHİSAR", burdur, context);
            AddCounty("KARAMANLI", burdur, context);
            AddCounty("KEMER", burdur, context);
            AddCounty("TEFENNİ", burdur, context);
            AddCounty("YEŞİLOVA", burdur, context);

            AddCounty("BÜYÜKORHAN", bursa, context);
            AddCounty("GEMLİK", bursa, context);
            AddCounty("GÜRSU", bursa, context);
            AddCounty("HARMANCIK", bursa, context);
            AddCounty("İNEGÖL", bursa, context);
            AddCounty("İZNİK", bursa, context);
            AddCounty("KARACABEY", bursa, context);
            AddCounty("KELES", bursa, context);
            AddCounty("KESTEL", bursa, context);
            AddCounty("MUDANYA", bursa, context);
            AddCounty("MUSTAFAKEMALPAŞA", bursa, context);
            AddCounty("NİLÜFER", bursa, context);
            AddCounty("ORHANELİ", bursa, context);
            AddCounty("ORHANGAZİ", bursa, context);
            AddCounty("OSMANGAZİ", bursa, context);
            AddCounty("YENİŞEHİR", bursa, context);
            AddCounty("YILDIRIM", bursa, context);

            AddCounty("AYVACIK", canakkale, context);
            AddCounty("BAYRAMİÇ", canakkale, context);
            AddCounty("BİGA", canakkale, context);
            AddCounty("BOZCAADA", canakkale, context);
            AddCounty("ÇAN", canakkale, context);
            AddCounty("ECEABAT", canakkale, context);
            AddCounty("EZİNE", canakkale, context);
            AddCounty("GELİBOLU", canakkale, context);
            AddCounty("İMROZ", canakkale, context);
            AddCounty("LAPSEKİ", canakkale, context);
            AddCounty("YENİCE", canakkale, context);

            AddCounty("ATKARACALAR", cankiri, context);
            AddCounty("BAYRAMÖREN", cankiri, context);
            AddCounty("ÇERKEŞ", cankiri, context);
            AddCounty("ELDİVAN", cankiri, context);
            AddCounty("ILGAZ", cankiri, context);
            AddCounty("KIZILIRMAK", cankiri, context);
            AddCounty("KORGUN", cankiri, context);
            AddCounty("KURŞUNLU", cankiri, context);
            AddCounty("ORTA", cankiri, context);
            AddCounty("ŞABANÖZÜ", cankiri, context);
            AddCounty("YAPRAKLI", cankiri, context);

            AddCounty("ALACA", corum, context);
            AddCounty("BAYAT", corum, context);
            AddCounty("BOĞAZKALE", corum, context);
            AddCounty("DODURGA", corum, context);
            AddCounty("İSKİLİP", corum, context);
            AddCounty("KARGI", corum, context);
            AddCounty("LAÇİN", corum, context);
            AddCounty("MECİTÖZÜ", corum, context);
            AddCounty("OĞUZLAR", corum, context);
            AddCounty("ORTAKÖY", corum, context);
            AddCounty("OSMANCIK", corum, context);
            AddCounty("SUNGURLU", corum, context);
            AddCounty("UĞURLUDAĞ", corum, context);

            AddCounty("ACIPAYAM", denizli, context);
            AddCounty("AKKÖY", denizli, context);
            AddCounty("BABADAĞ", denizli, context);
            AddCounty("BAKLAN", denizli, context);
            AddCounty("BEKİLLİ", denizli, context);
            AddCounty("BEYAĞAÇ", denizli, context);
            AddCounty("BOZKURT", denizli, context);
            AddCounty("BULDAN", denizli, context);
            AddCounty("ÇAL", denizli, context);
            AddCounty("ÇAMELİ", denizli, context);
            AddCounty("ÇARDAK", denizli, context);
            AddCounty("ÇİVRİL", denizli, context);
            AddCounty("GÜNEY", denizli, context);
            AddCounty("HONAZ", denizli, context);
            AddCounty("KALE", denizli, context);
            AddCounty("SARAYKÖY", denizli, context);
            AddCounty("SERİNHİSAR", denizli, context);
            AddCounty("TAVAS", denizli, context);

            AddCounty("BAĞLAR", diyarbakir, context);
            AddCounty("BİSMİL", diyarbakir, context);
            AddCounty("ÇERMİK", diyarbakir, context);
            AddCounty("ÇINAR", diyarbakir, context);
            AddCounty("ÇÜNGÜŞ", diyarbakir, context);
            AddCounty("DİCLE", diyarbakir, context);
            AddCounty("EĞİL", diyarbakir, context);
            AddCounty("ERGANİ", diyarbakir, context);
            AddCounty("HANİ", diyarbakir, context);
            AddCounty("HAZRO", diyarbakir, context);
            AddCounty("KAYAPINAR", diyarbakir, context);
            AddCounty("KOCAKÖY", diyarbakir, context);
            AddCounty("KULP", diyarbakir, context);
            AddCounty("LİCE", diyarbakir, context);
            AddCounty("SİLVAN", diyarbakir, context);
            AddCounty("SUR", diyarbakir, context);
            AddCounty("YENİŞEHİR", diyarbakir, context);

            AddCounty("ENEZ", edirne, context);
            AddCounty("HAVSA", edirne, context);
            AddCounty("İPSALA", edirne, context);
            AddCounty("KEŞAN", edirne, context);
            AddCounty("LALAPAŞA", edirne, context);
            AddCounty("MERİÇ", edirne, context);
            AddCounty("SÜLOĞLU", edirne, context);
            AddCounty("UZUNKÖPRÜ", edirne, context);

            AddCounty("AĞIN", elazig, context);
            AddCounty("ALACAKAYA", elazig, context);
            AddCounty("ARICAK", elazig, context);
            AddCounty("BASKİL", elazig, context);
            AddCounty("KARAKOÇAN", elazig, context);
            AddCounty("KEBAN", elazig, context);
            AddCounty("KOVANCILAR", elazig, context);
            AddCounty("MADEN", elazig, context);
            AddCounty("PALU", elazig, context);
            AddCounty("SİVRİCE", elazig, context);

            AddCounty("ÇAYIRLI", erzincan, context);
            AddCounty("İLİÇ", erzincan, context);
            AddCounty("KEMAH", erzincan, context);
            AddCounty("KEMALİYE", erzincan, context);
            AddCounty("OTLUKBELİ", erzincan, context);
            AddCounty("REFAHİYE", erzincan, context);
            AddCounty("TERCAN", erzincan, context);
            AddCounty("ÜZÜMLÜ", erzincan, context);

            AddCounty("AŞKALE", erzurum, context);
            AddCounty("AZİZİYE", erzurum, context);
            AddCounty("ÇAT", erzurum, context);
            AddCounty("HINIS", erzurum, context);
            AddCounty("HORASAN", erzurum, context);
            AddCounty("İSPİR", erzurum, context);
            AddCounty("KARAÇOBAN", erzurum, context);
            AddCounty("KARAYAZI", erzurum, context);
            AddCounty("KÖPRÜKÖY", erzurum, context);
            AddCounty("NARMAN", erzurum, context);
            AddCounty("OLTU", erzurum, context);
            AddCounty("OLUR", erzurum, context);
            AddCounty("PALANDÖKEN", erzurum, context);
            AddCounty("PASİNLER", erzurum, context);
            AddCounty("PAZARYOLU", erzurum, context);
            AddCounty("ŞENKAYA", erzurum, context);
            AddCounty("TEKMAN", erzurum, context);
            AddCounty("TORTUM", erzurum, context);
            AddCounty("UZUNDERE", erzurum, context);
            AddCounty("YAKUTİYE", erzurum, context);

            AddCounty("ALPU", eskisehir, context);
            AddCounty("BEYLİKOVA", eskisehir, context);
            AddCounty("ÇİFTELER", eskisehir, context);
            AddCounty("GÜNYÜZÜ", eskisehir, context);
            AddCounty("HAN", eskisehir, context);
            AddCounty("İNÖNÜ", eskisehir, context);
            AddCounty("MAHMUDİYE", eskisehir, context);
            AddCounty("MİHALGAZİ", eskisehir, context);
            AddCounty("MİHALIÇÇIK", eskisehir, context);
            AddCounty("ODUNPAZARI", eskisehir, context);
            AddCounty("SARICAKAYA", eskisehir, context);
            AddCounty("SEYİTGAZİ", eskisehir, context);
            AddCounty("SİVRİHİSAR", eskisehir, context);
            AddCounty("TEPEBAŞI", eskisehir, context);

            AddCounty("ARABAN", gaziantep, context);
            AddCounty("İSLAHİYE", gaziantep, context);
            AddCounty("KARKAMIŞ", gaziantep, context);
            AddCounty("NİZİP", gaziantep, context);
            AddCounty("NURDAĞI", gaziantep, context);
            AddCounty("OĞUZELİ", gaziantep, context);
            AddCounty("ŞAHİNBEY", gaziantep, context);
            AddCounty("ŞEHİTKAMİL", gaziantep, context);
            AddCounty("YAVUZELİ", gaziantep, context);

            AddCounty("ALUCRA", giresun, context);
            AddCounty("BULANCAK", giresun, context);
            AddCounty("ÇAMOLUK", giresun, context);
            AddCounty("ÇANAKÇI", giresun, context);
            AddCounty("DERELİ", giresun, context);
            AddCounty("DOĞANKENT", giresun, context);
            AddCounty("ESPİYE", giresun, context);
            AddCounty("EYNESİL", giresun, context);
            AddCounty("GÖRELE", giresun, context);
            AddCounty("GÜCE", giresun, context);
            AddCounty("KEŞAP", giresun, context);
            AddCounty("PİRAZİZ", giresun, context);
            AddCounty("ŞEBİNKARAHİSAR", giresun, context);
            AddCounty("TİREBOLU", giresun, context);
            AddCounty("YAĞLIDERE", giresun, context);

            AddCounty("KELKİT", gumushane, context);
            AddCounty("KÖSE", gumushane, context);
            AddCounty("KÜRTÜN", gumushane, context);
            AddCounty("ŞİRAN", gumushane, context);
            AddCounty("TORUL", gumushane, context);

            AddCounty("ÇUKURCA", hakkari, context);
            AddCounty("ŞEMDİNLİ", hakkari, context);
            AddCounty("YÜKSEKOVA", hakkari, context);

            AddCounty("ALTINÖZÜ", hatay, context);
            AddCounty("BELEN", hatay, context);
            AddCounty("DÖRTYOL", hatay, context);
            AddCounty("ERZİN", hatay, context);
            AddCounty("HASSA", hatay, context);
            AddCounty("İSKENDERUN", hatay, context);
            AddCounty("KIRIKHAN", hatay, context);
            AddCounty("KUMLU", hatay, context);
            AddCounty("REYHANLI", hatay, context);
            AddCounty("SAMANDAĞ", hatay, context);
            AddCounty("YAYLADAĞI", hatay, context);

            AddCounty("AKSU", isparta, context);
            AddCounty("ATABEY", isparta, context);
            AddCounty("EĞİRDİR", isparta, context);
            AddCounty("GELENDOST", isparta, context);
            AddCounty("GÖNEN", isparta, context);
            AddCounty("KEÇİBORLU", isparta, context);
            AddCounty("SENİRKENT", isparta, context);
            AddCounty("SÜTÇÜLER", isparta, context);
            AddCounty("ŞARKİKARAAĞAÇ", isparta, context);
            AddCounty("ULUBORLU", isparta, context);
            AddCounty("YALVAÇ", isparta, context);
            AddCounty("YENİŞARBADEMLİ", isparta, context);

            AddCounty("AKDENİZ", mersin, context);
            AddCounty("ANAMUR", mersin, context);
            AddCounty("AYDINCIK", mersin, context);
            AddCounty("BOZYAZI", mersin, context);
            AddCounty("ÇAMLIYAYLA", mersin, context);
            AddCounty("ERDEMLİ", mersin, context);
            AddCounty("GÜLNAR", mersin, context);
            AddCounty("MEZİTLİ", mersin, context);
            AddCounty("MUT", mersin, context);
            AddCounty("SİLİFKE", mersin, context);
            AddCounty("TARSUS", mersin, context);
            AddCounty("TOROSLAR", mersin, context);
            AddCounty("YENİŞEHİR", mersin, context);

            AddCounty("ADALAR", istanbul, context);
            AddCounty("ARNAVUTKÖY", istanbul, context);
            AddCounty("ATAŞEHİR", istanbul, context);
            AddCounty("AVCILAR", istanbul, context);
            AddCounty("BAĞCILAR", istanbul, context);
            AddCounty("BAHÇELİEVLER", istanbul, context);
            AddCounty("BAKIRKÖY", istanbul, context);
            AddCounty("BAŞAKŞEHİR", istanbul, context);
            AddCounty("BAYRAMPAŞA", istanbul, context);
            AddCounty("BEŞİKTAŞ", istanbul, context);
            AddCounty("BEYKOZ", istanbul, context);
            AddCounty("BEYLİKDÜZÜ", istanbul, context);
            AddCounty("BEYOĞLU", istanbul, context);
            AddCounty("BÜYÜKÇEKMECE", istanbul, context);
            AddCounty("ÇATALCA", istanbul, context);
            AddCounty("ÇEKMEKÖY", istanbul, context);
            AddCounty("ESENLER", istanbul, context);
            AddCounty("ESENYURT", istanbul, context);
            AddCounty("EYÜP", istanbul, context);
            AddCounty("FATİH", istanbul, context);
            AddCounty("GAZİOSMANPAŞA", istanbul, context);
            AddCounty("GÜNGÖREN", istanbul, context);
            AddCounty("KADIKÖY", istanbul, context);
            AddCounty("KAĞITHANE", istanbul, context);
            AddCounty("KARTAL", istanbul, context);
            AddCounty("KÜÇÜKÇEKMECE", istanbul, context);
            AddCounty("MALTEPE", istanbul, context);
            AddCounty("PENDİK", istanbul, context);
            AddCounty("SANCAKTEPE", istanbul, context);
            AddCounty("SARIYER", istanbul, context);
            AddCounty("SİLİVRİ", istanbul, context);
            AddCounty("SULTANBEYLİ", istanbul, context);
            AddCounty("SULTANGAZİ", istanbul, context);
            AddCounty("ŞİLE", istanbul, context);
            AddCounty("ŞİŞLİ", istanbul, context);
            AddCounty("TUZLA", istanbul, context);
            AddCounty("ÜMRANİYE", istanbul, context);
            AddCounty("ÜSKÜDAR", istanbul, context);
            AddCounty("ZEYTİNBURNU", istanbul, context);

            AddCounty("ALİAĞA", izmir, context);
            AddCounty("BALÇOVA", izmir, context);
            AddCounty("BAYINDIR", izmir, context);
            AddCounty("BAYRAKLI", izmir, context);
            AddCounty("BERGAMA", izmir, context);
            AddCounty("BEYDAĞ", izmir, context);
            AddCounty("BORNOVA", izmir, context);
            AddCounty("BUCA", izmir, context);
            AddCounty("ÇEŞME", izmir, context);
            AddCounty("ÇİĞLİ", izmir, context);
            AddCounty("DİKİLİ", izmir, context);
            AddCounty("FOÇA", izmir, context);
            AddCounty("GAZİEMİR", izmir, context);
            AddCounty("GÜZELBAHÇE", izmir, context);
            AddCounty("KARABAĞLAR", izmir, context);
            AddCounty("KARABURUN", izmir, context);
            AddCounty("KARŞIYAKA", izmir, context);
            AddCounty("KEMALPAŞA", izmir, context);
            AddCounty("KINIK", izmir, context);
            AddCounty("KİRAZ", izmir, context);
            AddCounty("KONAK", izmir, context);
            AddCounty("MENDERES", izmir, context);
            AddCounty("MENEMEN", izmir, context);
            AddCounty("NARLIDERE", izmir, context);
            AddCounty("ÖDEMİŞ", izmir, context);
            AddCounty("SEFERİHİSAR", izmir, context);
            AddCounty("SELÇUK", izmir, context);
            AddCounty("TİRE", izmir, context);
            AddCounty("TORBALI", izmir, context);
            AddCounty("URLA", izmir, context);

            AddCounty("AKYAKA", kars, context);
            AddCounty("ARPAÇAY", kars, context);
            AddCounty("DİGOR", kars, context);
            AddCounty("KAĞIZMAN", kars, context);
            AddCounty("SARIKAMIŞ", kars, context);
            AddCounty("SELİM", kars, context);
            AddCounty("SUSUZ", kars, context);

            AddCounty("ABANA", kastamonu, context);
            AddCounty("AĞLI", kastamonu, context);
            AddCounty("ARAÇ", kastamonu, context);
            AddCounty("AZDAVAY", kastamonu, context);
            AddCounty("BOZKURT", kastamonu, context);
            AddCounty("CİDE", kastamonu, context);
            AddCounty("ÇATALZEYTİN", kastamonu, context);
            AddCounty("DADAY", kastamonu, context);
            AddCounty("DEVREKANİ", kastamonu, context);
            AddCounty("DOĞANYURT", kastamonu, context);
            AddCounty("HANÖNÜ", kastamonu, context);
            AddCounty("İHSANGAZİ", kastamonu, context);
            AddCounty("İNEBOLU", kastamonu, context);
            AddCounty("KÜRE", kastamonu, context);
            AddCounty("PINARBAŞI", kastamonu, context);
            AddCounty("SEYDİLER", kastamonu, context);
            AddCounty("ŞENPAZAR", kastamonu, context);
            AddCounty("TAŞKÖPRÜ", kastamonu, context);
            AddCounty("TOSYA", kastamonu, context);

            AddCounty("AKKIŞLA", kayseri, context);
            AddCounty("BÜNYAN", kayseri, context);
            AddCounty("DEVELİ", kayseri, context);
            AddCounty("FELAHİYE", kayseri, context);
            AddCounty("HACILAR", kayseri, context);
            AddCounty("İNCESU", kayseri, context);
            AddCounty("KOCASİNAN", kayseri, context);
            AddCounty("MELİKGAZİ", kayseri, context);
            AddCounty("ÖZVATAN", kayseri, context);
            AddCounty("PINARBAŞI", kayseri, context);
            AddCounty("SARIOĞLAN", kayseri, context);
            AddCounty("SARIZ", kayseri, context);
            AddCounty("TALAS", kayseri, context);
            AddCounty("TOMARZA", kayseri, context);
            AddCounty("YAHYALI", kayseri, context);
            AddCounty("YEŞİLHİSAR", kayseri, context);

            AddCounty("BABAESKİ", kirklareli, context);
            AddCounty("DEMİRKÖY", kirklareli, context);
            AddCounty("KOFÇAZ", kirklareli, context);
            AddCounty("LÜLEBURGAZ", kirklareli, context);
            AddCounty("PEHLİVANKÖY", kirklareli, context);
            AddCounty("PINARHİSAR", kirklareli, context);
            AddCounty("VİZE", kirklareli, context);

            AddCounty("AKÇAKENT", kirsehir, context);
            AddCounty("AKPINAR", kirsehir, context);
            AddCounty("BOZTEPE", kirsehir, context);
            AddCounty("ÇİÇEKDAĞI", kirsehir, context);
            AddCounty("KAMAN", kirsehir, context);
            AddCounty("MUCUR", kirsehir, context);

            AddCounty("BAŞİSKELE", kocaeli, context);
            AddCounty("ÇAYIROVA", kocaeli, context);
            AddCounty("DARICA", kocaeli, context);
            AddCounty("DERİNCE", kocaeli, context);
            AddCounty("DİLOVASI", kocaeli, context);
            AddCounty("GEBZE", kocaeli, context);
            AddCounty("GÖLCÜK", kocaeli, context);
            AddCounty("İZMİT", kocaeli, context);
            AddCounty("KANDIRA", kocaeli, context);
            AddCounty("KARAMÜRSEL", kocaeli, context);
            AddCounty("KARTEPE", kocaeli, context);
            AddCounty("KÖRFEZ", kocaeli, context);

            AddCounty("AHIRLI", konya, context);
            AddCounty("AKÖREN", konya, context);
            AddCounty("AKŞEHİR", konya, context);
            AddCounty("ALTINEKİN", konya, context);
            AddCounty("BEYŞEHİR", konya, context);
            AddCounty("BOZKIR", konya, context);
            AddCounty("CİHANBEYLİ", konya, context);
            AddCounty("ÇELTİK", konya, context);
            AddCounty("ÇUMRA", konya, context);
            AddCounty("DERBENT", konya, context);
            AddCounty("DEREBUCAK", konya, context);
            AddCounty("DOĞANHİSAR", konya, context);
            AddCounty("EMİRGAZİ", konya, context);
            AddCounty("EREĞLİ", konya, context);
            AddCounty("GÜNEYSINIR", konya, context);
            AddCounty("HADİM", konya, context);
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
            AddCounty("SEYDİŞEHİR", konya, context);
            AddCounty("TAŞKENT", konya, context);
            AddCounty("TUZLUKÇU", konya, context);
            AddCounty("YALIHÜYÜK", konya, context);
            AddCounty("YUNAK", konya, context);

            AddCounty("ALTINTAŞ", kutahya, context);
            AddCounty("ASLANAPA", kutahya, context);
            AddCounty("ÇAVDARHİSAR", kutahya, context);
            AddCounty("DOMANİÇ", kutahya, context);
            AddCounty("DUMLUPINAR", kutahya, context);
            AddCounty("EMET", kutahya, context);
            AddCounty("GEDİZ", kutahya, context);
            AddCounty("HİSARCIK", kutahya, context);
            AddCounty("PAZARLAR", kutahya, context);
            AddCounty("SİMAV", kutahya, context);
            AddCounty("ŞAPHANE", kutahya, context);
            AddCounty("TAVŞANLI", kutahya, context);

            AddCounty("AKÇADAĞ", malatya, context);
            AddCounty("ARAPGİR", malatya, context);
            AddCounty("ARGUVAN", malatya, context);
            AddCounty("BATTALGAZİ", malatya, context);
            AddCounty("DARENDE", malatya, context);
            AddCounty("DOĞANŞEHİR", malatya, context);
            AddCounty("DOĞANYOL", malatya, context);
            AddCounty("HEKİMHAN", malatya, context);
            AddCounty("KALE", malatya, context);
            AddCounty("KULUNCAK", malatya, context);
            AddCounty("PÜTÜRGE", malatya, context);
            AddCounty("YAZIHAN", malatya, context);
            AddCounty("YEŞİLYURT", malatya, context);

            AddCounty("AHMETLİ", manisa, context);
            AddCounty("AKHİSAR", manisa, context);
            AddCounty("ALAŞEHİR", manisa, context);
            AddCounty("DEMİRCİ", manisa, context);
            AddCounty("GÖLMARMARA", manisa, context);
            AddCounty("GÖRDES", manisa, context);
            AddCounty("KIRKAĞAÇ", manisa, context);
            AddCounty("KÖPRÜBAŞI", manisa, context);
            AddCounty("KULA", manisa, context);
            AddCounty("SALİHLİ", manisa, context);
            AddCounty("SARIGÖL", manisa, context);
            AddCounty("SARUHANLI", manisa, context);
            AddCounty("SELENDİ", manisa, context);
            AddCounty("SOMA", manisa, context);
            AddCounty("TURGUTLU", manisa, context);

            AddCounty("AFŞİN", maras, context);
            AddCounty("ANDIRIN", maras, context);
            AddCounty("ÇAĞLAYANCERİT", maras, context);
            AddCounty("EKİNÖZÜ", maras, context);
            AddCounty("ELBİSTAN", maras, context);
            AddCounty("GÖKSUN", maras, context);
            AddCounty("NURHAK", maras, context);
            AddCounty("PAZARCIK", maras, context);
            AddCounty("TÜRKOĞLU", maras, context);

            AddCounty("DARGEÇİT", mardin, context);
            AddCounty("DERİK", mardin, context);
            AddCounty("KIZILTEPE", mardin, context);
            AddCounty("MAZIDAĞI", mardin, context);
            AddCounty("MİDYAT", mardin, context);
            AddCounty("NUSAYBİN", mardin, context);
            AddCounty("ÖMERLİ", mardin, context);
            AddCounty("SAVUR", mardin, context);
            AddCounty("YEŞİLLİ", mardin, context);

            AddCounty("BODRUM", mugla, context);
            AddCounty("DALAMAN", mugla, context);
            AddCounty("DATÇA", mugla, context);
            AddCounty("FETHİYE", mugla, context);
            AddCounty("KAVAKLIDERE", mugla, context);
            AddCounty("KÖYCEĞİZ", mugla, context);
            AddCounty("MARMARİS", mugla, context);
            AddCounty("MİLAS", mugla, context);
            AddCounty("ORTACA", mugla, context);
            AddCounty("ULA", mugla, context);
            AddCounty("YATAĞAN", mugla, context);

            AddCounty("BULANIK", mus, context);
            AddCounty("HASKÖY", mus, context);
            AddCounty("KORKUT", mus, context);
            AddCounty("MALAZGİRT", mus, context);
            AddCounty("VARTO", mus, context);

            AddCounty("ACIGÖL", nevsehir, context);
            AddCounty("AVANOS", nevsehir, context);
            AddCounty("DERİNKUYU", nevsehir, context);
            AddCounty("GÜLŞEHİR", nevsehir, context);
            AddCounty("HACIBEKTAŞ", nevsehir, context);
            AddCounty("KOZAKLI", nevsehir, context);
            AddCounty("ÜRGÜP", nevsehir, context);

            AddCounty("ALTUNHİSAR", nigde, context);
            AddCounty("BOR", nigde, context);
            AddCounty("ÇAMARDI", nigde, context);
            AddCounty("ÇİFTLİK", nigde, context);
            AddCounty("ULUKIŞLA", nigde, context);

            AddCounty("AKKUŞ", ordu, context);
            AddCounty("AYBASTI", ordu, context);
            AddCounty("ÇAMAŞ", ordu, context);
            AddCounty("ÇATALPINAR", ordu, context);
            AddCounty("ÇAYBAŞI", ordu, context);
            AddCounty("FATSA", ordu, context);
            AddCounty("GÖLKÖY", ordu, context);
            AddCounty("GÜLYALI", ordu, context);
            AddCounty("GÜRGENTEPE", ordu, context);
            AddCounty("İKİZCE", ordu, context);
            AddCounty("KABADÜZ", ordu, context);
            AddCounty("KABATAŞ", ordu, context);
            AddCounty("KORGAN", ordu, context);
            AddCounty("KUMRU", ordu, context);
            AddCounty("MESUDİYE", ordu, context);
            AddCounty("PERŞEMBE", ordu, context);
            AddCounty("ULUBEY", ordu, context);
            AddCounty("ÜNYE", ordu, context);

            AddCounty("ARDEŞEN", rize, context);
            AddCounty("ÇAMLIHEMŞİN", rize, context);
            AddCounty("ÇAYELİ", rize, context);
            AddCounty("DEREPAZARI", rize, context);
            AddCounty("FINDIKLI", rize, context);
            AddCounty("GÜNEYSU", rize, context);
            AddCounty("HEMŞİN", rize, context);
            AddCounty("İKİZDERE", rize, context);
            AddCounty("İYİDERE", rize, context);
            AddCounty("KALKANDERE", rize, context);
            AddCounty("PAZAR", rize, context);

            AddCounty("ADAPAZARI", sakarya, context);
            AddCounty("AKYAZI", sakarya, context);
            AddCounty("ARİFİYE", sakarya, context);
            AddCounty("ERENLER", sakarya, context);
            AddCounty("FERİZLİ", sakarya, context);
            AddCounty("GEYVE", sakarya, context);
            AddCounty("HENDEK", sakarya, context);
            AddCounty("KARAPÜRÇEK", sakarya, context);
            AddCounty("KARASU", sakarya, context);
            AddCounty("KAYNARCA", sakarya, context);
            AddCounty("KOCAALİ", sakarya, context);
            AddCounty("PAMUKOVA", sakarya, context);
            AddCounty("SAPANCA", sakarya, context);
            AddCounty("SERDİVAN", sakarya, context);
            AddCounty("SÖĞÜTLÜ", sakarya, context);
            AddCounty("TARAKLI", sakarya, context);


            AddCounty("19 MAYIS", samsun, context);
            AddCounty("ALAÇAM", samsun, context);
            AddCounty("ASARCIK", samsun, context);
            AddCounty("ATAKUM", samsun, context);
            AddCounty("AYVACIK", samsun, context);
            AddCounty("BAFRA", samsun, context);
            AddCounty("CANİK", samsun, context);
            AddCounty("ÇARŞAMBA", samsun, context);
            AddCounty("HAVZA", samsun, context);
            AddCounty("İLKADIM", samsun, context);
            AddCounty("KAVAK", samsun, context);
            AddCounty("LADİK", samsun, context);
            AddCounty("SALIPAZARI", samsun, context);
            AddCounty("TEKKEKÖY", samsun, context);
            AddCounty("TERME", samsun, context);
            AddCounty("VEZİRKÖPRÜ", samsun, context);
            AddCounty("YAKAKENT", samsun, context);

            AddCounty("AYDINLAR", siirt, context);
            AddCounty("BAYKAN", siirt, context);
            AddCounty("ERUH", siirt, context);
            AddCounty("KURTALAN", siirt, context);
            AddCounty("PERVARİ", siirt, context);
            AddCounty("ŞİRVAN", siirt, context);

            AddCounty("AYANCIK", sinop, context);
            AddCounty("BOYABAT", sinop, context);
            AddCounty("DİKMEN", sinop, context);
            AddCounty("DURAĞAN", sinop, context);
            AddCounty("ERFELEK", sinop, context);
            AddCounty("GERZE", sinop, context);
            AddCounty("SARAYDÜZÜ", sinop, context);
            AddCounty("TÜRKELİ", sinop, context);

            AddCounty("AKINCILAR", sivas, context);
            AddCounty("ALTINYAYLA", sivas, context);
            AddCounty("DİVRİĞİ", sivas, context);
            AddCounty("DOĞANŞAR", sivas, context);
            AddCounty("GEMEREK", sivas, context);
            AddCounty("GÖLOVA", sivas, context);
            AddCounty("GÜRÜN", sivas, context);
            AddCounty("HAFİK", sivas, context);
            AddCounty("İMRANLI", sivas, context);
            AddCounty("KANGAL", sivas, context);
            AddCounty("KOYULHİSAR", sivas, context);
            AddCounty("SUŞEHRİ", sivas, context);
            AddCounty("ŞARKIŞLA", sivas, context);
            AddCounty("ULAŞ", sivas, context);
            AddCounty("YILDIZELİ", sivas, context);
            AddCounty("ZARA", sivas, context);

            AddCounty("ÇERKEZKÖY", tekirdag, context);
            AddCounty("ÇORLU", tekirdag, context);
            AddCounty("HAYRABOLU", tekirdag, context);
            AddCounty("MALKARA", tekirdag, context);
            AddCounty("MARMARAEREĞLİSİ", tekirdag, context);
            AddCounty("MURATLI", tekirdag, context);
            AddCounty("SARAY", tekirdag, context);
            AddCounty("ŞARKÖY", tekirdag, context);

            AddCounty("ALMUS", tokat, context);
            AddCounty("ARTOVA", tokat, context);
            AddCounty("BAŞÇİFTLİK", tokat, context);
            AddCounty("ERBAA", tokat, context);
            AddCounty("NİKSAR", tokat, context);
            AddCounty("PAZAR", tokat, context);
            AddCounty("REŞADİYE", tokat, context);
            AddCounty("SULUSARAY", tokat, context);
            AddCounty("TURHAL", tokat, context);
            AddCounty("YEŞİLYURT", tokat, context);
            AddCounty("ZİLE", tokat, context);

            AddCounty("AKÇAABAT", trabzon, context);
            AddCounty("ARAKLI", trabzon, context);
            AddCounty("ARSİN", trabzon, context);
            AddCounty("BEŞİKDÜZÜ", trabzon, context);
            AddCounty("ÇARŞIBAŞI", trabzon, context);
            AddCounty("ÇAYKARA", trabzon, context);
            AddCounty("DERNEKPAZARI", trabzon, context);
            AddCounty("DÜZKÖY", trabzon, context);
            AddCounty("HAYRAT", trabzon, context);
            AddCounty("KÖPRÜBAŞI", trabzon, context);
            AddCounty("MAÇKA", trabzon, context);
            AddCounty("OF", trabzon, context);
            AddCounty("SÜRMENE", trabzon, context);
            AddCounty("ŞALPAZARI", trabzon, context);
            AddCounty("TONYA", trabzon, context);
            AddCounty("VAKFIKEBİR", trabzon, context);
            AddCounty("YOMRA", trabzon, context);

            AddCounty("ÇEMİŞGEZEK", tunceli, context);
            AddCounty("HOZAT", tunceli, context);
            AddCounty("MAZGİRT", tunceli, context);
            AddCounty("NAZIMİYE", tunceli, context);
            AddCounty("OVACIK", tunceli, context);
            AddCounty("PERTEK", tunceli, context);
            AddCounty("PÜLÜMÜR", tunceli, context);

            AddCounty("AKÇAKALE", urfa, context);
            AddCounty("BİRECİK", urfa, context);
            AddCounty("BOZOVA", urfa, context);
            AddCounty("CEYLANPINAR", urfa, context);
            AddCounty("HALFETİ", urfa, context);
            AddCounty("HARRAN", urfa, context);
            AddCounty("HİLVAN", urfa, context);
            AddCounty("SİVEREK", urfa, context);
            AddCounty("SURUÇ", urfa, context);
            AddCounty("VİRANŞEHİR", urfa, context);

            AddCounty("BANAZ", usak, context);
            AddCounty("EŞME", usak, context);
            AddCounty("KARAHALLI", usak, context);
            AddCounty("SİVASLI", usak, context);
            AddCounty("ULUBEY", usak, context);

            AddCounty("BAHÇESARAY", van, context);
            AddCounty("BAŞKALE", van, context);
            AddCounty("ÇALDIRAN", van, context);
            AddCounty("ÇATAK", van, context);
            AddCounty("EDREMİT", van, context);
            AddCounty("ERCİŞ", van, context);
            AddCounty("GEVAŞ", van, context);
            AddCounty("GÜRPINAR", van, context);
            AddCounty("MURADİYE", van, context);
            AddCounty("ÖZALP", van, context);
            AddCounty("SARAY", van, context);

            AddCounty("AKDAĞMADENİ", yozgat, context);
            AddCounty("AYDINCIK", yozgat, context);
            AddCounty("BOĞAZLIYAN", yozgat, context);
            AddCounty("ÇANDIR", yozgat, context);
            AddCounty("ÇAYIRALAN", yozgat, context);
            AddCounty("ÇEKEREK", yozgat, context);
            AddCounty("KADIŞEHRİ", yozgat, context);
            AddCounty("SARAYKENT", yozgat, context);
            AddCounty("SARIKAYA", yozgat, context);
            AddCounty("SORGUN", yozgat, context);
            AddCounty("ŞEFAATLİ", yozgat, context);
            AddCounty("YENİFAKILI", yozgat, context);
            AddCounty("YERKÖY", yozgat, context);

            AddCounty("ALAPLI", zonguldak, context);
            AddCounty("ÇAYCUMA", zonguldak, context);
            AddCounty("DEVREK", zonguldak, context);
            AddCounty("EREĞLİ", zonguldak, context);
            AddCounty("GÖKÇEBEY", zonguldak, context);

            AddCounty("AĞAÇÖREN", aksaray, context);
            AddCounty("ESKİL", aksaray, context);
            AddCounty("GÜLAĞAÇ", aksaray, context);
            AddCounty("GÜZELYURT", aksaray, context);
            AddCounty("ORTAKÖY", aksaray, context);
            AddCounty("SARIYAHŞİ", aksaray, context);

            AddCounty("AYDINTEPE", bayburt, context);
            AddCounty("DEMİRÖZÜ", bayburt, context);

            AddCounty("AYRANCI", karaman, context);
            AddCounty("BAŞYAYLA", karaman, context);
            AddCounty("ERMENEK", karaman, context);
            AddCounty("KAZIMKARABEKİR", karaman, context);
            AddCounty("SARIVELİLER", karaman, context);

            AddCounty("BAHŞİLİ", kirikkale, context);
            AddCounty("BALIŞEYH", kirikkale, context);
            AddCounty("ÇELEBİ", kirikkale, context);
            AddCounty("DELİCE", kirikkale, context);
            AddCounty("KARAKEÇİLİ", kirikkale, context);
            AddCounty("KESKİN", kirikkale, context);
            AddCounty("SULAKYURT", kirikkale, context);
            AddCounty("YAHŞİHAN", kirikkale, context);

            AddCounty("BEŞİRİ", batman, context);
            AddCounty("GERCÜŞ", batman, context);
            AddCounty("HASANKEYF", batman, context);
            AddCounty("KOZLUK", batman, context);
            AddCounty("SASON", batman, context);

            AddCounty("BEYTÜŞŞEBAP", sirnak, context);
            AddCounty("CİZRE", sirnak, context);
            AddCounty("GÜÇLÜKONAK", sirnak, context);
            AddCounty("İDİL", sirnak, context);
            AddCounty("SİLOPİ", sirnak, context);
            AddCounty("ULUDERE", sirnak, context);

            AddCounty("AMASRA", bartin, context);
            AddCounty("KURUCAŞİLE", bartin, context);
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
            AddCounty("ÇİFTLİKKÖY", yalova, context);
            AddCounty("TERMAL", yalova, context);

            AddCounty("EFLANİ", karabuk, context);
            AddCounty("ESKİPAZAR", karabuk, context);
            AddCounty("OVACIK", karabuk, context);
            AddCounty("SAFRANBOLU", karabuk, context);
            AddCounty("YENİCE", karabuk, context);

            AddCounty("ELBEYLİ", kilis, context);
            AddCounty("MUSABEYLİ", kilis, context);
            AddCounty("POLATELİ", kilis, context);

            AddCounty("BAHÇE", osmaniye, context);
            AddCounty("DÜZİÇİ", osmaniye, context);
            AddCounty("HASANBEYLİ", osmaniye, context);
            AddCounty("KADİRLİ", osmaniye, context);
            AddCounty("SUMBAS", osmaniye, context);
            AddCounty("TOPRAKKALE", osmaniye, context);

            AddCounty("AKÇAKOCA", duzce, context);
            AddCounty("CUMAYERİ", duzce, context);
            AddCounty("ÇİLİMLİ", duzce, context);
            AddCounty("GÖLYAKA", duzce, context);
            AddCounty("GÜMÜŞOVA", duzce, context);
            AddCounty("KAYNAŞLI", duzce, context);
            AddCounty("YIĞILCA", duzce, context);

            context.SaveChanges();
        }

        private static void AddCounty(string name, City city, MembershipDB context)
        {
            var _name = name.Trim();

            context.Counties.Add(new County
            {
                Name = string.Format("{0}{1}", _name[0], _name.Substring(1).ToLower()),
                City = city,
                Comment = string.Empty,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertUsers(MembershipDB context)
        {
            AddUser("Programatic", "Admin", "admin@admin.com", "password", DateTime.Now, "Man", true, context);
            AddUser("Hüseyin Serdar", "Büyüktemiz", "hserdarb@gmail.com", "password", new DateTime(1982, 8, 2), "Man", true, context);

            for (int i = 1; i < 1001; i++)
            {
                AddUser(string.Format("test{0}", i), "user", string.Format("test{0}@test.com", i), "password", DateTime.Now, "Man", true, context);
            }

            context.SaveChanges();
        }

        private static void AddUser(string preferredName, string surname, string email, string password, DateTime birthday, string gender, bool isActive, MembershipDB context)
        {
            var chyptographyHelper = new CryptographyHelper();
            var passhwordHash = chyptographyHelper.SHA256Hasher(password);

            context.Users.Add(new User
            {
                UserType = context.UserTypes.First(x => x.Name == "Client"),
                Gender = context.Genders.First(x => x.Name == gender.Trim()),
                Email = email.Trim(),
                PasswordHash = passhwordHash,
                Names = string.Format("{0} {1}", preferredName, surname),
                LastName = surname.Trim(),
                PreferredName = preferredName.Trim(),
                IsActive = isActive,
                Birthday = birthday,
                Comment = string.Empty,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertMenuItems(MembershipDB context)
        {
            const string MIG_GENERAL = "General";
            AddMenuItemGroup(string.Empty, MIG_GENERAL, null, 1, context);
            context.SaveChanges();

            var migGeneral = context.AdminMenuItemGroups.First(x => x.Name == MIG_GENERAL);
            AddMenuItem("Admin/Setting", "Settings", migGeneral, context);
            AddMenuItem("Admin/Log", "Logs", migGeneral, context);
            AddMenuItem("Admin/Supplier", "Suppliers", migGeneral, context);

            context.SaveChanges();
        }

        private static void AddMenuItemGroup(string navigateUrl, string name, AdminMenuItemGroup parentMenuItemGroup, int displayOrder, MembershipDB context)
        {
            context.AdminMenuItemGroups.Add(new AdminMenuItemGroup
            {
                DisplayOrder = displayOrder,
                ParentAdminMenuItemGroup = parentMenuItemGroup,
                Name = name.Trim(),
                NavigateUrl = navigateUrl.Trim(),
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        private static void AddMenuItem(string navigateUrl, string name, AdminMenuItemGroup menuItemGroup, MembershipDB context)
        {
            context.AdminMenuItems.Add(new AdminMenuItem
            {
                NavigateUrl = navigateUrl.Trim(),
                Name = name.Trim(),
                AdminMenuItemGroup = menuItemGroup,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }

        public static void InsertRole(MembershipDB context)
        {
            AddAdminRole("Admin", "Has full permision", context);
            AddAdminRole("IT", "Can edit settings.", context);

            context.SaveChanges();
        }

        private static void AddAdminRole(string name, string description, MembershipDB context)
        {
            context.AdminRoles.Add(new AdminRole
            {
                Name = name.Trim(),
                Description = description.Trim(),
                Comment = string.Empty,
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                LastUpdatedBy = 1
            });
        }
    }
}