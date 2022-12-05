namespace kartişlem
{
    class ATM
    {
        
        static void Main(string[] args)
        {
            
                 List<KartSahibi> _kartsahibi = new List<KartSahibi>();
                _kartsahibi.Add(new KartSahibi("8493293242839939", 3849, "Pınar", "Topuz", 29399,21));
                _kartsahibi.Add(new KartSahibi("5943493459440950", 9122, "Nevin", "Topuz", 84300.72));
                _kartsahibi.Add(new KartSahibi("1525489177462812", 8144, "Orhan", "Topuz", 18000.05));
                _kartsahibi.add(new KartSahibi("3122132356585877", 3113, "Ahsen", "Topuz", 1293,13));
               
                Console.WriteLine("ATM uygulamasına hoş geldiniz. :)");
                Console.WriteLine("Sizlere daha iyi hizmet etmek için güncelleme yaptık");
                Console.WriteLine("Lütfen Kart Numaranızı Giriniz: ");
                string debitCardNum = "";
                KartSahibi currentUser;

                while(true)
                {
                    try
                    {
                        debitCardNum = Console.ReadLine();
                        currentUser = _kartsahibi.FirstOrDefault(a => a.getNum() == debitCardNum);
                        if(currentUser != null) 
                        {
                            
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Kart numarası bulunamadı...:");
                            Console.WriteLine("Lütfen kart numaranızı giriniz:");
                            throw new Exception("Kart numarası yanlış girildi.");
                        }
                    }
                    catch(Exception e)
                    {
                       File.AppendAllText("log.txt", Environment.UserName);
                       File.AppendAllText("log.txt", Environment.NewLine);
                       File.AppendAllText("log.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                       File.AppendAllText("log.txt", "\r\n");
                       File.AppendAllText("log.txt", e.Message);
                       File.AppendAllText("log.txt", Environment.UserName);
                       File.AppendAllText("log.txt", e.StackTrace);
                       File.AppendAllText("log.txt", Environment.NewLine+"**********"+Environment.NewLine);
                    }
                }

                Console.WriteLine("Lütfen Şifrenizi Giriniz: ");
                int userPin = 0;

                 while(true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());
                        if(currentUser.getPin() == userPin) 
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Şifre yanlış girildi...");
                            Console.WriteLine("Lütfen şifrenizi giriniz:");
                            throw new Exception("Şifre yanlış girildi.");
                        }
                    }
                    catch(Exception e)
                    {
                        File.AppendAllText("log.txt", Environment.UserName);
                        File.AppendAllText("log.txt", Environment.NewLine);
                        File.AppendAllText("log.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                        File.AppendAllText("log.txt", "\r\n");
                        File.AppendAllText("log.txt", e.Message);
                        File.AppendAllText("log.txt", Environment.UserName);
                        File.AppendAllText("log.txt", e.StackTrace);
                        File.AppendAllText("log.txt", Environment.NewLine+"**********"+Environment.NewLine);
                    }
                }

                Console.WriteLine("Hoş geldiniz " + currentUser.getFirstName());
                int option =0;

                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch {}
                    if(option == 1) { deposit(currentUser); }
                    else if(option == 2){ withdraw(currentUser); }
                    else if(option == 3){ balance(currentUser); }
                    else if(option == 4){ break; }
                    

                }
                while(option != 4);
                Console.WriteLine("Teşekkürler, iyi günler dileriz.");


        }

        private static object CreateHostBuilder(string[] args)
        {
            throw new NotImplementedException();
        }

        private static void printOptions()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz...");
            Console.WriteLine("1. Para Yatırma");
            Console.WriteLine("2. Para Çekme");
            Console.WriteLine("3. Bakiye Görüntüleme");
            Console.WriteLine("4. Çıkış");
        }

        private static void balance(KartSahibi currentUser)
        {
            try
            {
                Console.WriteLine("Kullanılabilir Bakiyeniz: " + currentUser.getBalance());
                throw new Exception("Bakiye görüntülendi.");
            }
            catch(Exception e)
            {
                File.AppendAllText("log.txt", Environment.UserName);
                File.AppendAllText("log.txt", Environment.NewLine);
                File.AppendAllText("log.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                File.AppendAllText("log.txt", "\r\n");
                File.AppendAllText("log.txt", e.Message);
                File.AppendAllText("log.txt", Environment.UserName);
                File.AppendAllText("log.txt", e.StackTrace);
                File.AppendAllText("log.txt", Environment.NewLine+"**********"+Environment.NewLine);
            }
            
        }

        private static void withdraw(KartSahibi currentUser)
        {
            Console.WriteLine("Çekmek istediğiniz tutarı giriniz: ");
            double withdraw = Double.Parse(Console.ReadLine());

            try
            {
                 if (currentUser.getBalance() < withdraw)
                {
                    Console.WriteLine("Yetersiz Bakiye.");
                    throw new Exception("İşlem red edildi. (Bakiye yetersiz)");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdraw);
                    Console.WriteLine("İşleminiz tamamlanmıştır. İyi günler dileriz");
                    throw new Exception("Para çekme işlemi yapıldı.");
                
                }
            }
            catch(Exception e)
            {
                File.AppendAllText("log.txt", Environment.UserName);
                File.AppendAllText("log.txt", Environment.NewLine);
                File.AppendAllText("log.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                File.AppendAllText("log.txt", "\r\n");
                File.AppendAllText("log.txt", e.Message);
                File.AppendAllText("log.txt", Environment.UserName);
                File.AppendAllText("log.txt", e.StackTrace);
                File.AppendAllText("log.txt", Environment.NewLine+"**********"+Environment.NewLine);
            }
           
        }

        private static void deposit(KartSahibi currentUser)
        {
            try
            {
                Console.WriteLine("Yatırmak istediğiniz tutarı giriniz: ");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("İşleminiz tamamlanmıştır. Yeni bakiyeniz: " + currentUser.getBalance());
                throw new Exception("Para yatırma işemi yapıldı.");
            }
            catch(Exception e)
            {
                File.AppendAllText("log.txt", Environment.UserName);
                File.AppendAllText("log.txt", Environment.NewLine);
                File.AppendAllText("log.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                File.AppendAllText("log.txt", "\r\n");
                File.AppendAllText("log.txt", e.Message);
                File.AppendAllText("log.txt", Environment.UserName);
                File.AppendAllText("log.txt", e.StackTrace);
                File.AppendAllText("log.txt", Environment.NewLine+"**********"+Environment.NewLine);
            }
            
        }


    }
}