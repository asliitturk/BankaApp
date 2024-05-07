using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Security.Principal;
using System.Threading;

namespace BankApp
{
    class Atm
    {
        public string Name { get; set; }
        public ulong Password { get; set; }
        public double Balance { get; set; }
        public Dictionary<string, double> CurrencyBalances { get; set; } // Her para birimini bakiyede tutmak için dictionary koleksiyonu oluşturulmuştr
        public Atm()
        {
            CurrencyBalances = new Dictionary<string, double>();
        }
    }
    class Program
    {
        static List<Atm> customers = new List<Atm>(); // müşteri koleksiyonu
        static string selectedLanguage = "English"; // varsayılan dil
        static Dictionary<string, Dictionary<string, string>> languageFiles = new Dictionary<string, Dictionary<string, string>>();
        // string = para birimi 
        // double = para miktarı
        static void Main(string[] args)
        {
            LanguageSelectionScreen(); // Dil seçimi ekranını çağır
            LoadLanguageFiles(); // Dil dosyasını yükle

            // Hazır kayıtlı müşteri koleksiyonu 
            customers.Add(new Atm { Name = "Aslı", Password = 10111938, Balance = 45000, CurrencyBalances = new Dictionary<string, double>() });
            customers.Add(new Atm { Name = "Şura", Password = 29012016, Balance = 7500, CurrencyBalances = new Dictionary<string, double>() });
            WelcomeScreen();
        }
        static void LanguageSelectionScreen()// müşteriye dil olanağı sunuluyor.
        {
            Console.WriteLine("Select your language : "); // dil seçiniz
            Console.WriteLine("1- English");
            Console.WriteLine("2- Türkçe");
            int languageChoice = int.Parse(Console.ReadLine());

            switch (languageChoice)
            {
                case 1:
                    selectedLanguage = "English";
                    break;
                case 2:
                    selectedLanguage = "Türkçe";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to English."); // geçersiz işlem ,  İngilizce devam edilecek.
                    selectedLanguage = "English";
                    break;
            }
        }
        static void LoadLanguageFiles()// dil verileri burada
        {
            // ingilizce dil verisi : 
            Dictionary<string, string> englishFile = new Dictionary<string, string>();
            englishFile.Add("welcome", "WELCOME");
            englishFile.Add("login", "Login");
            englishFile.Add("sign_up", "Sign Up");
            englishFile.Add("admin_login", "Admin Login");
            englishFile.Add("invalid_choice", "Invalid choice. Please make a valid choice.");
            englishFile.Add("username_prompt", "Enter your username :");
            englishFile.Add("password_prompt", "Enter your password :");
            englishFile.Add("welcome_admin", "WELCOME ADMIN");
            englishFile.Add("admin_username_prompt", "Enter admin username :");
            englishFile.Add("admin_password_prompt", "Enter admin password :");
            englishFile.Add("num_customers", "Number of customers registered in system :");
            englishFile.Add("sorting_method", "Choose sorting method :");
            englishFile.Add("sort_by_name", "Sort by Customer's Name");
            englishFile.Add("sort_by_balance", "Sort by Customer's Balance");
            englishFile.Add("customer_list", "List of customers :");
            englishFile.Add("currency_options", "Select the currency you want to add :");
            englishFile.Add("succes_regist", "Your registration has been successfully created!");
            englishFile.Add("remaining_attemps", "Invalid username or password. Remaining attempts :");
            englishFile.Add("all_attemps", "You have used all your attempts. Returning to the welcome screen.");
            englishFile.Add("default_name", "Invalid choice. Sorting by Name by default.");
            englishFile.Add("name", "Name : ");
            englishFile.Add("balance", "Balance : ");
            englishFile.Add("cbalance", "Currency Balance : ");
            englishFile.Add("invalid_admin", "Invalid admin credentials. Returning to the welcome screen.");
            englishFile.Add("create_name", "Create your customer name : ");
            englishFile.Add("create_pword", "Create your customer password : ");
            englishFile.Add("current_balance", "Current Balance : ");
            englishFile.Add("menu_balance", "Current Balance ");
            englishFile.Add("adding_focurrency", "Adding Foreign Currency");
            englishFile.Add("add_money", "Adding Money");
            englishFile.Add("withdraw_money", "Withdraw money");
            englishFile.Add("change_trans", "Foreign Exchange Transactions");
            englishFile.Add("ex", "Exit");
            englishFile.Add("action_take", "Select the action you want to take : ");
            englishFile.Add("valid_choice", "Invalid selection. Please make a valid choice.");
            englishFile.Add("interest_information", "Interest Information Screen");
            englishFile.Add("choice", "Enter your choice : ");
            englishFile.Add("enter_amount", "Enter the amount you want to add : ");
            englishFile.Add("to_your_add", "To your currency balance added.");
            englishFile.Add("invalid", "Invalid choice.");
            englishFile.Add("cc_balance", "Current Currency Balance : ");
            englishFile.Add("amount_add", "Enter the amount you want to add : ");
            englishFile.Add("amount_wdraw", "Enter the amount you want to withdraw :");
            englishFile.Add("nullorequals", "The amount desired to be withdrawn cannot be less than or equal to 0.");
            englishFile.Add("nullnotmore", "The amount requested to be withdrawn cannot be greater than the current balance.");
            englishFile.Add("select_currency", "Select your currency :");
            englishFile.Add("current_rate", "---  Current Rates  ---");
            englishFile.Add("enter_convert", "Enter the amount you want to convert : ");
            englishFile.Add("ins_balance", "Insufficient Balance.");
            englishFile.Add("see_interest", "(1000-90000) Enter the amount you want to see interest on : ");
            englishFile.Add("enter_valid_amount", "Enter a valid amount.");
            englishFile.Add("with_interest", "Amount with interest : ");
            englishFile.Add("total_allow", "Total allowance : ");
            englishFile.Add("ReturnorMenu", "'c' to return to the customer menu, 'w' to return to the welcome screen , 'e' to exit.");
            englishFile.Add("Thanks", "Thanks , for choose us. ");
            englishFile.Add("returning", "Invalid transaction. Returning to welcome screen...");
            englishFile.Add("converted", "Converted =");
            englishFile.Add("formonth", "1- 4 months old");
            englishFile.Add("eightmonth", "2- 8 months old");
            englishFile.Add("oneyear", "3- 12 months old");
            englishFile.Add("payment_plan", " --- Payment Plan ---");
            englishFile.Add("select_pplan", "Select payment plan :");
            englishFile.Add("jan", "January : ");
            englishFile.Add("feb", "February : ");
            englishFile.Add("mar", "March : ");
            englishFile.Add("apr", "April : ");
            englishFile.Add("may", "May : ");
            englishFile.Add("jun", "June : ");
            englishFile.Add("jul", "July : ");
            englishFile.Add("agus", "August : ");
            englishFile.Add("sep", "September : ");
            englishFile.Add("oct", "October : ");
            englishFile.Add("nov", "November : ");
            englishFile.Add("dec", "December : ");

            // Türkçe dil verisi
            Dictionary<string, string> turkishFile = new Dictionary<string, string>();
            turkishFile.Add("welcome", "HOŞ GELDİNİZ");
            turkishFile.Add("login", "Giriş Yap");
            turkishFile.Add("sign_up", "Kayıt Ol");
            turkishFile.Add("admin_login", "Yönetici Girişi");
            turkishFile.Add("invalid_choice", "Geçersiz seçim. Lütfen geçerli bir seçim yapın.");
            turkishFile.Add("username_prompt", "Kullanıcı adınızı giriniz :");
            turkishFile.Add("password_prompt", "Şifrenizi giriniz :");
            turkishFile.Add("welcome_admin", "Hoş geldin Yönetici");
            turkishFile.Add("admin_username_prompt", "Yönetici kullanıcı adını giriniz : ");
            turkishFile.Add("admin_password_prompt", "Yönetici şifrenizi giriniz :");
            turkishFile.Add("num_customers", "Sisteme kayıtlı müşteri sayısı :");
            turkishFile.Add("sorting_method", "Sıralama yöntemini seçin:");
            turkishFile.Add("sort_by_name", "Müşteri Adına Göre Sırala");
            turkishFile.Add("sort_by_balance", "Müşteri Bakiyesine Göre Sırala");
            turkishFile.Add("customer_list", "Müşterilerin listesi :");
            turkishFile.Add("currency_options", "Eklemek istediğiniz para birimini seçin");
            turkishFile.Add("succes_regist", "Kaydınız başarıyla oluşturuldu!");
            turkishFile.Add("remaining_attemps", "Geçersiz kullanıcı adı veya şifre. Kalan denemeler :");
            turkishFile.Add("all_attemps", "Tüm girişimlerinizi kullandınız. Hoş Geldiniz ekranına geri dönüyoruz.");
            turkishFile.Add("default_name", "Geçersiz seçim. Varsayılan olarak Ada göre sıralama.");
            turkishFile.Add("name", "Ad : ");
            turkishFile.Add("balance", " Bakiye : ");
            turkishFile.Add("cbalance", " Döviz Bakiye : ");
            turkishFile.Add("invalid_admin", "Geçersiz yönetici kimlik bilgileri. Hoş Geldiniz ekranına geri dönüyoruz.");
            turkishFile.Add("create_name", "Müşteri kullanıcı adınızı oluşturunuz : ");
            turkishFile.Add("create_pword", "Müşteri şifrenizi oluşturunuz : ");
            turkishFile.Add("current_balance", "Güncel Bakiye ");
            turkishFile.Add("adding_focurrency", "Döviz Para Yatırma");
            turkishFile.Add("add_money", "Para Yatırma");
            turkishFile.Add("menu_balance", "Bakiye Görme ");
            turkishFile.Add("withdraw_money", "Para Çekme");
            turkishFile.Add("change_trans", "Döviz İşlemleri");
            turkishFile.Add("interest_information", "Faiz Bilgi Ekranı");
            turkishFile.Add("ex", "Çıkış");
            turkishFile.Add("action_take", "Gerçekleştirmek istediğiniz eylemi seçin :");
            turkishFile.Add("valid_choice", "Geçersiz seçim. Lütfen geçerli bir seçim yapın.");
            turkishFile.Add("choice", "Seçiminizi giriniz : ");
            turkishFile.Add("enter_amount", "Eklemek istediğiniz tutarı giriniz : ");
            turkishFile.Add("to_your_add", "Döviz bakiyenize eklendi ");
            turkishFile.Add("invalid", "Geçersiz işlem.");
            turkishFile.Add("cc_balance", "Güncel Döviz Bakiyesi : ");
            turkishFile.Add("amount_add", "Eklemek istediğiniz tutarı giriniz :  ");
            turkishFile.Add("amount_wdraw", "Çekmek istediğiniz tutarı giriniz : ");
            turkishFile.Add("nullorequals", "Çekilmek istenen tutar 0'dan küçük veya 0'a eşit olamaz.");
            turkishFile.Add("nullnotmore", "Çekilmek istenen tutar mevcut bakiyeden fazla olamaz.");
            turkishFile.Add("current_rate", "--- Güncel Oranlar ---");
            turkishFile.Add("select_currency", "Para biriminizi seçin :");
            turkishFile.Add("enter_convert", "Dönüştürmek istediğiniz tutarı girin : ");
            turkishFile.Add("ins_balance", "Yetersiz Bakiye.");
            turkishFile.Add("see_interest", " (1000 - 90000) Faizini görmek istediğiniz tutarı giriniz : ");
            turkishFile.Add("enter_valid_amount", "Geçerli bir tutar giriniz.");
            turkishFile.Add("with_interest", "Faizli tutar :");
            turkishFile.Add("total_allow", "Toplam ödenek :");
            turkishFile.Add("ReturnorMenu", " Müşteri menüsüne dönmek için 'c', Hoş Geldiniz ekranına dönmek için 'w'  , Çıkış yapmak için 'e' harfini giriniz.");
            turkishFile.Add("Thanks", "Bizi tercih ettiğiniz için teşekkürler. ");
            turkishFile.Add("returning", "Geçersiz işlem. Hoş Geldiniz ekranına dönülüyor...");
            turkishFile.Add("converted", "Dönüştürüldü =");
            turkishFile.Add("formonth", "1- 4 aylık");
            turkishFile.Add("eightmonth", "2- 8 Aylık");
            turkishFile.Add("oneyear", "3- 12 Aylık");
            turkishFile.Add("payment_plan", " --- Ödeme Planı ---");
            turkishFile.Add("select_pplan", "Ödeme Planı Seçiniz :");
            turkishFile.Add("jan", "Ocak :");
            turkishFile.Add("feb", "Şubat : ");
            turkishFile.Add("mar", "Mart : ");
            turkishFile.Add("apr", "Nisan : ");
            turkishFile.Add("may", "Mayıs : ");
            turkishFile.Add("jun", "Haziran : ");
            turkishFile.Add("jul", "Temmuz : ");
            turkishFile.Add("agus", "Ağustos : ");
            turkishFile.Add("sep", "Eylül : ");
            turkishFile.Add("oct", "Ekim : ");
            turkishFile.Add("nov", "Kasım : ");
            turkishFile.Add("dec", "Aralık : ");
            if (selectedLanguage == "English")
            {
                // İngilizce dil 
                languageFiles["English"] = englishFile;
            }
            else if (selectedLanguage == "Türkçe")
            {
                // Türkçe dil 
                languageFiles["Türkçe"] = turkishFile;
            }
            else
            {
                // Seçilen dil geçersiz olduğu için varsayılan dil ingilizce kullanılacak.
                Console.WriteLine("Invalid language choice. Defaulting to English.");
                languageFiles["English"] = englishFile;
            }
        }
        static void WelcomeScreen() // HOŞ GELDİNİZ EKRANI
        {
            Console.WriteLine("\t\t\t\t\t\t  " + languageFiles[selectedLanguage]["welcome"]); // hoş geldiniz
            Console.WriteLine("1- " + languageFiles[selectedLanguage]["login"]); // giriş yap
            Console.WriteLine("2- " + languageFiles[selectedLanguage]["sign_up"]); // kayıt ol
            Console.WriteLine("3- " + languageFiles[selectedLanguage]["admin_login"]); // admin girişi
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    SignUp();
                    break;
                case 3:
                    AdminScreen();
                    break;
                default:
                    Console.WriteLine("\t ** " + languageFiles[selectedLanguage]["invalid_choice"]);
                    Thread.Sleep(3000);
                    Console.Clear();
                    WelcomeScreen();
                    break;
            }
        }
        static void Login() // GİRİŞ YAP
        {
            // Müşteri 3 hakka sahip.
            // Her giriş yapamadığı durumda hakkı azalacaktır.
            // Hakkı bittiğinde ise ekran temizlenip hoş geldiniz ekranına dönücek,
            // Giriş yapabildiği takdirde MüşteriMenüsüne geçiş sağlayabilcektir.
            int sayac = 3; // Kalan deneme hakkı
            bool basariliGiris = false; // Başarılı giriş kontrolü

            for (int i = 1; i <= 3; i++)
            {
                Console.Write(languageFiles[selectedLanguage]["username_prompt"]); // Kullanıcı adı giriniz
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.Write(languageFiles[selectedLanguage]["password_prompt"]); // Şifrenizi giriniz
                ulong password = Convert.ToUInt64(Console.ReadLine());

                if (name == "admin" && password == 15987) // ADMIN girişi <<<<<<
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t\t " + languageFiles[selectedLanguage]["welcome_admin"]); // hoş geldin admin
                    Console.WriteLine($"{languageFiles[selectedLanguage]["num_customers"]} {customers.Count}"); // Kayıtlı olan müşteri sayisi
                    basariliGiris = true; // Başarılı giriş yapıldığında döngüden çıkacak
                    Thread.Sleep(5000);
                    Console.Clear();
                    WelcomeScreen();
                    break;
                }
                else
                {
                    Atm customer = FindCustomer(name, password); // listedeki müşterileri arar
                    if (customer != null) // customer listesindeki kullanıcı adı ve şifreleri arar , null değilse > MÜŞTERİ menüsü
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t\t " + languageFiles[selectedLanguage]["welcome"]);
                        CustomerMenu(customer);
                        basariliGiris = true; // Başarılı giriş yapıldığında döngüden çıkacak
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        sayac--; // Her hatalı girişte kalan deneme hakkı 1'er azalacak
                        Console.WriteLine($"{languageFiles[selectedLanguage]["remaining_attemps"]} {sayac}"); // Kullanıcı adı veya şifre mevcut değil & kalan hak : 
                    }
                }
            }
            if (!basariliGiris)
            {
                Console.WriteLine(languageFiles[selectedLanguage]["all_attemps"]); // Hakkınız bitmiştir >  hoşgeldiniz ekranı 
                Thread.Sleep(2000);
                Console.Clear();
                WelcomeScreen(); // Giriş ekranına geri dön
            }
        }
        static void AdminScreen() // ADMIN EKRANI
        {
            Console.Write(languageFiles[selectedLanguage]["admin_username_prompt"]);
            string adminName = Console.ReadLine();
            Console.Write(languageFiles[selectedLanguage]["admin_password_prompt"]);
            ulong adminPassword = Convert.ToUInt64(Console.ReadLine());

            if (adminName == "admin" && adminPassword == 15987)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t  " + languageFiles[selectedLanguage]["welcome_admin"]); ;
                Console.WriteLine($"{languageFiles[selectedLanguage]["num_customers"]} {customers.Count}");
                Console.WriteLine();
                Console.WriteLine(languageFiles[selectedLanguage]["sorting_method"]);
                Console.WriteLine("1-" + languageFiles[selectedLanguage]["sort_by_name"]); // ad'a göre sıralama
                Console.WriteLine("2-" + languageFiles[selectedLanguage]["sort_by_balance"]); // bakiyeye göre sıralama
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        customers.Sort((x, y) => string.Compare(x.Name, y.Name));
                        break;
                    case 2:
                        customers.Sort((x, y) => x.Balance.CompareTo(y.Balance));
                        break;
                    default:
                        Console.WriteLine(languageFiles[selectedLanguage]["default_name"]);
                        customers.Sort((x, y) => string.Compare(x.Name, y.Name));
                        break;
                }
                Console.WriteLine(languageFiles[selectedLanguage]["sort_by_name"]); // müşterilerin listesi
                foreach (var customer in customers)
                {
                    Console.WriteLine($"{languageFiles[selectedLanguage]["name"]} {customer.Name} {languageFiles[selectedLanguage]["balance"]} {customer.Balance}");

                    // Her müşterinin para birimi & bakiyelerini göster
                    Console.WriteLine(languageFiles[selectedLanguage]["cbalance"]);
                    foreach (var balance in customer.CurrencyBalances)
                    {
                        Console.WriteLine($"*{balance.Value}{balance.Key}");
                    }
                    Console.WriteLine();
                }
                WelcomeScreen();
                Thread.Sleep(2500);
                Console.Clear();
            }
            else
            {
                Console.WriteLine(languageFiles[selectedLanguage]["invalid_admin"]);
                WelcomeScreen();
            }
        }
        static Atm FindCustomer(string name, ulong password)
        {
            // >> Login foksiyonunda girilen name ve password parametreleri listeye kayıt olduktan sonra
            //  parametreleri listede arar ve parametreler eşleşirse kullanıcıyı MüşteriMenüsü 'ne yönlendirir;
            //  şayet eğer parametreler bulunamazsa sonuç null dönücektir. (return)
            return customers.Find(customer => customer.Name == name && customer.Password == password);
        }
        static void SignUp() // KAYIT OL
        {
            Console.WriteLine(languageFiles[selectedLanguage]["create_name"]); // Müşteri kullanıcı adınızı oluşturun
            string name = Console.ReadLine();

            Console.WriteLine(languageFiles[selectedLanguage]["create_pword"]); // Müşteri şifrenizi oluşturun
            ulong password = Convert.ToUInt64(Console.ReadLine());

            Atm newCustomer = new Atm { Name = name, Password = password, Balance = 0 }; // yeni müşteri ekleme
            customers.Add(newCustomer);

            Console.WriteLine(languageFiles[selectedLanguage]["succes_regist"]); // Başarıyla  kayıt oluşturuldu
            Thread.Sleep(2000);
            Console.Clear();
            WelcomeScreen();
        }
        static void CustomerMenu(Atm customer) // MÜŞTERİ MENÜSÜ
        {
            Console.WriteLine("1-" + languageFiles[selectedLanguage]["menu_balance"]); // güncel bakiye
            Console.WriteLine("2-" + languageFiles[selectedLanguage]["adding_focurrency"]); // döviz ekleme
            Console.WriteLine("3-" + languageFiles[selectedLanguage]["add_money"]); // para ekleme
            Console.WriteLine("4-" + languageFiles[selectedLanguage]["withdraw_money"]); // para çekme
            Console.WriteLine("5-" + languageFiles[selectedLanguage]["change_trans"]); // döviz kur 
            Console.WriteLine("6-" + languageFiles[selectedLanguage]["interest_information"]); // faiz bilgi
            Console.WriteLine("7-" + languageFiles[selectedLanguage]["ex"]); // çıkış

            Console.WriteLine("\t\t" + languageFiles[selectedLanguage]["action_take"]); // yapmak istenilen işlem
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CurrentBalance(customer);
                    break;
                case 2:
                    AddCurrency(customer);
                    break;
                case 3:
                    AddMoney(customer);
                    break;
                case 4:
                    WithdrawMoney(customer);
                    break;
                case 5:
                    ForeignExchange(customer);
                    break;
                case 6:
                    InterestRateScreen(customer);
                    break;
                case 7:
                    Console.WriteLine(languageFiles[selectedLanguage]["Thanks"]);
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(languageFiles[selectedLanguage]["valid_choice"]); // geçersiz işlem 
                    break;
            }
        }
        static void CurrentBalance(Atm customer) // GÜNCEL TUTAR
        {
            Console.Clear();
            Console.WriteLine($"{languageFiles[selectedLanguage]["balance"]}  {customer.Balance} TL");

            // Her müşterinin para birimi bakiyelerini göster
            Console.WriteLine(languageFiles[selectedLanguage]["cbalance"]);
            foreach (var balance in customer.CurrencyBalances)
            {
                Console.Write($"*{balance.Value}{balance.Key}");
            }
            Console.WriteLine();
            Thread.Sleep(2000);
            ReturnorMenu(customer);
        }
        static void AddCurrency(Atm customer) // YABANCI PARA EKLEME
        {
            Console.Clear();
            Console.WriteLine("\t" + languageFiles[selectedLanguage]["currency_options"]);
            Console.WriteLine("1. USD - US Dollar");
            Console.WriteLine("2. EUR - Euro");
            Console.WriteLine("3. GBP - British Pound");
            Console.WriteLine("4. JPY - Japanese Yen");
            Console.WriteLine("5. KRW - South Korean Won");
            Console.Write(languageFiles[selectedLanguage]["choice"]);
            int choice = int.Parse(Console.ReadLine());

            // Kullanıcıdan eklenecek miktarı iste
            Console.Write(languageFiles[selectedLanguage]["enter_amount"]);
            double amount = Convert.ToDouble(Console.ReadLine());

            string currencyName = ""; // para birimi için kullanılıyor

            // Seçilen para birimine göre bakiyeye ekle & para birimi adını ayarlayacak
            switch (choice)
            {
                case 1:
                    currencyName = "USD";
                    break;
                case 2:
                    currencyName = "EUR";
                    break;
                case 3:
                    currencyName = "GBP";
                    break;
                case 4:
                    currencyName = "JPY";
                    break;
                case 5:
                    currencyName = "KRW";
                    break;
                default:
                    Console.WriteLine(languageFiles[selectedLanguage]["invalid"]); // Geçersiz seçim 
                    break;
            }
            // müşterinin para birimini eksiltilip-azaltılmaya göre değişecektir.
            if (!string.IsNullOrEmpty(currencyName))
            {
                if (customer.CurrencyBalances.ContainsKey(currencyName))
                {
                    customer.CurrencyBalances[currencyName] += amount;
                }
                else
                {
                    customer.CurrencyBalances.Add(currencyName, amount);
                }

                Console.WriteLine($"{amount} {currencyName} {languageFiles[selectedLanguage]["to_your_add"]}");
                foreach (var balance in customer.CurrencyBalances)
                {
                    Console.Write($"*{balance.Value}{balance.Key}");
                }
            }
            Console.WriteLine();
            Thread.Sleep(2000);
            ReturnorMenu(customer);
        }
        static void AddMoney(Atm customer) // PARA YATIRMA İŞLEMİ
        {
            Console.Clear();
            Console.Write(languageFiles[selectedLanguage]["amount_add"]); // eklemek istediğiniz miktar
            double amount = double.Parse(Console.ReadLine());

            customer.Balance += amount; // ilgili müşterinin bakiyesine miktar eklendi
            Console.WriteLine($"{languageFiles[selectedLanguage]["current_balance"]} {customer.Balance} "); // Güncel bakiye
            Thread.Sleep(2000);
            ReturnorMenu(customer);
        }
        static void WithdrawMoney(Atm customer) // PARA ÇEKME İŞLEMİ
        {
            Console.Clear();
            Console.Write(languageFiles[selectedLanguage]["amount_wdraw"]); // çekilmek istediğiniz miktar
            double amount = double.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine(languageFiles[selectedLanguage]["nullorequals"]); // Çekilmek istenen miktar 0'dan küçük & eşit olamaz
            }
            else if (amount > customer.Balance)
            {
                Console.WriteLine(languageFiles[selectedLanguage]["nullnotmore"]); // Çekilmek istenen miktar bakiyeden fazla olamaz
            }
            else
            {
                customer.Balance -= amount; // ilgili müşterinin bakiyesinden girilen miktar eksiltildi
                Console.WriteLine($" {languageFiles[selectedLanguage]["current_balance"]} {customer.Balance} "); // Güncel bakiye
            }
            Thread.Sleep(2000);
            ReturnorMenu(customer);
        }
        static void ForeignExchange(Atm customer) // DÖVİZ İŞLEMLERİ
        {
            Console.Clear();
            Console.WriteLine($" {languageFiles[selectedLanguage]["current_balance"]} {customer.Balance} ");
            Console.Write(languageFiles[selectedLanguage]["enter_convert"]); // Çevirmek istediğiniz tutarı girin
            double tlAmount = double.Parse(Console.ReadLine());

            if (tlAmount > customer.Balance)
            {
                Console.WriteLine(languageFiles[selectedLanguage]["ins_balance"]); // Yetersiz Bakiye 
                Thread.Sleep(2000);
                ReturnorMenu(customer);
                return;
            }
            Console.WriteLine(languageFiles[selectedLanguage]["current_rate"]);
            Console.WriteLine("\t1. USD - US Dollar: 11.25"); // Amerikan Doları
            Console.WriteLine("\t2. EUR - Euro: 12.25"); // Euro
            Console.WriteLine("\t3. GBP - British Pound: 13.50"); // İngiliz Sterlini
            Console.WriteLine("\t4. JPY - Japanese Yen: 10.10"); // Japon Yeni
            Console.WriteLine("\t5. KRW - South Korean Won: 9.50"); // Güney Kore Wonu
            Console.WriteLine();
            Console.Write(languageFiles[selectedLanguage]["select_currency"]); // dönüştüreceği para birimini  seçice
            char choice = char.Parse(Console.ReadLine());

            double dolar = 10.20, euro = 12.20, sterlin = 15.50, yen = 12.10, won = 12.50;
            double currencyRate = 0; // Seçilen döviz cinsinin döviz kuru
            string currencyName = ""; // Seçilen döviz cinsinin adı

            switch (choice)
            {
                case '1':
                    currencyRate = dolar;
                    currencyName = "USD";
                    break;
                case '2':
                    currencyRate = euro;
                    currencyName = "EUR";
                    break;
                case '3':
                    currencyRate = sterlin;
                    currencyName = "GBP";
                    break;
                case '4':
                    currencyRate = yen;
                    currencyName = "JPY";
                    break;
                case '5':
                    currencyRate = won;
                    currencyName = "KRW";
                    break;
                default:
                    Console.WriteLine(languageFiles[selectedLanguage]["invalid"]); // Geçersiz seçenek
                    Thread.Sleep(2000);
                    ReturnorMenu(customer);
                    return;
            }
            double convertedAmount = tlAmount / currencyRate;

            // Müşterinin para birimi bakiyesini güncelle
            if (customer.CurrencyBalances.ContainsKey(currencyName))
            {
                customer.CurrencyBalances[currencyName] += convertedAmount;
            }
            else
            {
                customer.CurrencyBalances.Add(currencyName, convertedAmount);
            }

            Console.WriteLine($"{tlAmount} Tl {languageFiles[selectedLanguage]["converted"]} {convertedAmount} {currencyName} ");

            // Müşterinin güncel TL bakiyesinden dönüştürdüğü tutar eksiltilecek
            customer.Balance -= tlAmount;

            Console.WriteLine($"{languageFiles[selectedLanguage]["cc_balance"]}");
            foreach (var balance in customer.CurrencyBalances)
            {
                Console.Write($"*{balance.Value}{balance.Key}");
            }
            Thread.Sleep(2000);
            Console.WriteLine();
            ReturnorMenu(customer);
        }
        static void InterestRateScreen(Atm customer)// FAİZ HESAPLAMA 
        {
            Console.Clear();
            Console.Write(languageFiles[selectedLanguage]["see_interest"]); // faizini görmek istediği tutar girilecek.
            double amount = Convert.ToDouble(Console.ReadLine());

            double amountWithInterest = 0; // faizli tutar
            double totalAllowance = 0; // faiz + girilen tutar = toplam ödenek

            if (1000 <= amount && amount <= 5000)
            {
                amountWithInterest = CalculateInterest(amount, 0.20);
            }
            else if (5000 < amount && amount <= 10000)
            {
                amountWithInterest = CalculateInterest(amount, 0.50);
            }
            else if (10000 < amount && amount <= 30000)
            {
                amountWithInterest = CalculateInterest(amount, 1.75);
            }
            else if (30000 < amount && amount <= 50000)
            {
                amountWithInterest = CalculateInterest(amount, 3.75);
            }
            else if (50000 < amount && amount <= 70000)
            {
                amountWithInterest = CalculateInterest(amount, 5.75);
            }
            else if (70000 < amount && amount <= 90000)
            {
                amountWithInterest = CalculateInterest(amount, 7.75);
            }
            else
            {
                Console.WriteLine(languageFiles[selectedLanguage]["enter_valid_amount"]); // Geçerli bir tutar girilmesi isteniyor
                Thread.Sleep(3000); // 3 saniye sonra ekran sıfırlanacak > Faiz Oranı Ekranı
                Console.Clear();
                InterestRateScreen(customer);
                return;
            }
            totalAllowance = amount + amountWithInterest;
            Console.WriteLine($"{languageFiles[selectedLanguage]["with_interest"]}{amountWithInterest}\n{languageFiles[selectedLanguage]["total_allow"]} {totalAllowance}");
            // sırasıyla >> faizli miktar:         toplam ödenek:
            Console.WriteLine();
            Console.WriteLine(languageFiles[selectedLanguage]["payment_plan"]);
            Console.WriteLine(languageFiles[selectedLanguage]["formonth"]);
            Console.WriteLine(languageFiles[selectedLanguage]["eightmonth"]);
            Console.WriteLine(languageFiles[selectedLanguage]["oneyear"]);
            Console.WriteLine();
            Console.WriteLine(languageFiles[selectedLanguage]["select_pplan"]);
            int time = int.Parse(Console.ReadLine());
            int months;

            switch (time)
            {
                case 1:
                    months = 4;
                    break;
                case 2:
                    months = 8;
                    break;
                case 3:
                    months = 12;
                    break;
                default:
                    months = 0; // hata 
                    break;
            }
            PaymentPlan(amount, totalAllowance, months);
            Thread.Sleep(2000);
            ReturnorMenu(customer);
        }
        static void PaymentPlan(double amount, double totalAllowance, int months)// Faizli Tutarın Ödeme Tarihleri  ve Tutarını gösterir 
        {
            double monthlyPayment = totalAllowance / months;
            if (months == 4)
            {
                Console.WriteLine($"{languageFiles[selectedLanguage]["jan"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["feb"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["mar"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["apr"]} {monthlyPayment}");
            }
            else if (months == 8)
            {
                Console.WriteLine($"{languageFiles[selectedLanguage]["jan"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["feb"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["mar"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["apr"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["may"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["jun"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["jul"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["agus"]} {monthlyPayment}");
            }
            else if (months == 12)
            {
                Console.WriteLine($"{languageFiles[selectedLanguage]["jan"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["feb"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["mar"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["apr"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["may"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["jun"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["jul"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["agus"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["sep"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["oct"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["nov"]} {monthlyPayment}");
                Console.WriteLine($"{languageFiles[selectedLanguage]["dec"]} {monthlyPayment}");
            }
        }
        static double CalculateInterest(double amount, double interestRate) // İşlemlerde ki yinelemeyi önlemek için geri değer döndüren fonksiyon.
        {
            // oran belirlemesi şu şekildedir : 
            // miktarlar arasında 10k (dahil) üstünde her değer aralığında 10K'DA BİR ORAN 1.0 YÜKSELMİŞTİR. (1k-9k arası değerler istisnadır)
            // Yani 50k-30k = 20k >> 20/10=2 >> 2.0+ ORANDA ARTIŞ SAĞLANACAKTIR

            return amount * interestRate;  //Miktar ve FaizOranını çarpma işlemi burda tanımlanmıştır.
        }
        static void ReturnorMenu(Atm customer) // İşlemlerde ki yinelemeyi önlemek için kullanılan fonksiyon.
        {
            Console.WriteLine(languageFiles[selectedLanguage]["ReturnorMenu"]);
            string userChoice = Console.ReadLine().ToLower(); // Kullanıcının girdisi küçük harfe çeviriliyor
            Thread.Sleep(2000);
            if (userChoice == "c")
            {
                Console.Clear();
                // Müşteri menüsüne  
                CustomerMenu(customer);
            }
            else if (userChoice == "e")
            {
                // Çıkış 
                Console.WriteLine(languageFiles[selectedLanguage]["Thanks"]);
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else if (userChoice == "w")
            {
                Console.Clear();
                WelcomeScreen();
            }
            else
            {
                Console.WriteLine(languageFiles[selectedLanguage]["returning"]);
                Thread.Sleep(2000);
                Console.Clear();
                CustomerMenu(customer);
            }
        }
    }
}