using HashCheck.Extension;
using System.Reflection;
using System.Text;

namespace HashCheck
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                var hashSteam = new HashSteam(args[0]);

                Console.WriteLine(GetFileInfo(args[0]));

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
          
            switch (Console.ReadLine())
            {               
                case "info":
                    Console.WriteLine(String.Format("Продукт: {0}", AssemblyProduct));
                    Console.WriteLine(String.Format("Версия: {0}", AssemblyVersion));
                    Console.WriteLine(String.Format("Авторские права: {0}", AssemblyCopyright));
                    break;

                default:
                    Console.ReadKey();
                    break;
            }    
        }

        #region Методы доступа к атрибутам сборки

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private static string GetFileInfo (string path)
        {   
            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                var builder = new StringBuilder();

                builder.Append("Название файла: ");
                builder.AppendLine(fileInfo.Name);

                builder.Append("Размер файла: ");
                builder.AppendLine(GetConvertByte(fileInfo.Length));

                builder.Append("Дата создания файла: ");
                builder.AppendLine(fileInfo.CreationTime.ToString());

                builder.Append("Дата изменения файла: ");
                builder.AppendLine(fileInfo.LastWriteTime.ToString());
                                
                return builder.ToString();
            }
            return "Файл отсутствует!";
        }

        private static string GetConvertByte(long value)
        {
            const long OneKB = 1024;
            const long OneMB = OneKB * OneKB;
            const long OneGB = OneMB * OneKB;
            const long OneTB = OneGB * OneKB;

            return value switch
            {
                (< OneKB) => $"{value}B",
                (>= OneKB) and (< OneMB) => $"{value.ToSize(ConvertByte.SizeUnits.KB)}KB",
                (>= OneMB) and (< OneGB) => $"{value.ToSize(ConvertByte.SizeUnits.MB)}MB",
                (>= OneGB) and (< OneTB) => $"{value.ToSize(ConvertByte.SizeUnits.GB)}GB",
                (>= OneTB) => $"{value.ToSize(ConvertByte.SizeUnits.TB)}"
            };
        }
    }
}