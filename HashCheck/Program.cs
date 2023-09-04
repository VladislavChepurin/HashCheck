namespace HashCheck
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                var hashSteam = new HashSteam(args[0]);
                switch (args[1])
                {
                    case "SHA512":
                        Console.WriteLine("Подсчет хеша SHA512:");
                        Console.WriteLine(hashSteam.HashSHA512());
                        break;

                    case "SHA384":
                        Console.WriteLine("Подсчет хеша SHA384:");
                        Console.WriteLine(hashSteam.HashSHA384());
                        break;

                    case "SHA256":
                        Console.WriteLine("Подсчет хеша SHA256:");
                        Console.WriteLine(hashSteam.HashSHA256());
                        break;

                    case "SHA1":                       
                        Console.WriteLine("Подсчет хеша SHA1:");
                        Console.WriteLine(hashSteam.HashSHA1());
                        
                        break;

                    case "MD5":                     
                        Console.WriteLine("Подсчет хеша MD5:");
                        Console.WriteLine(hashSteam.HashMD5());
                        break;

                    case "All":

                        Console.WriteLine("Подсчет хеша SHA512:");
                        Console.WriteLine(hashSteam.HashSHA512());

                        //Console.WriteLine("Подсчет хеша SHA384:");
                        //Console.WriteLine(hashSteam.HashSHA384());

                        Console.WriteLine("Подсчет хеша SHA256:");
                        Console.WriteLine(hashSteam.HashSHA256());

                        Console.WriteLine("Подсчет хеша SHA1:");
                        Console.WriteLine(hashSteam.HashSHA1());

                        Console.WriteLine("Подсчет хеша MD5:");
                        Console.WriteLine(hashSteam.HashMD5());

                        break;
                }      
            }
            if (Console.ReadLine() == "author")
            {
                Console.WriteLine("Автор: Чепурин Владислав");
                Console.ReadKey();
            }
        }      
    }
}