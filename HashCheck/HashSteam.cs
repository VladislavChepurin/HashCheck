using System.Reflection;
using System.Security.Cryptography;

namespace HashCheck
{
    internal class HashSteam
    {
        private readonly string FileLocation;
        public HashSteam(string fileLocation)
        {
            FileLocation = fileLocation;
        }

        public string HashMD5()
        {
            try
            {
                using (FileStream fStream = File.OpenRead(FileLocation))
                {
                    return GetHash<MD5>(fStream);
                };
            }
            catch (IOException)
            {
                return "Файл заблокирован или закрыт, закройте программу в которой открыт файл и попробуйте еще раз.";
            }
        }

        public string HashSHA1()
        {
            try
            {
                using (FileStream fStream = File.OpenRead(FileLocation))
                {
                    return GetHash<SHA1>(fStream);
                };
            }
            catch (IOException)
            {
                return "Файл заблокирован или закрыт, закройте программу в которой открыт файл и попробуйте еще раз.";
            }
        }

        public string HashSHA256()
        {
            try
            {
                using (FileStream fStream = File.OpenRead(FileLocation))
                {
                    return GetHash<SHA256>(fStream);
                };
            }
            catch (IOException)
            {
                return "Файл заблокирован или закрыт, закройте программу в которой открыт файл и попробуйте еще раз.";
            }
        }

        public string HashSHA384()
        {
            try
            {
                using (FileStream fStream = File.OpenRead(FileLocation))
                {
                    return GetHash<SHA384>(fStream);
                };
            }
            catch (IOException)
            {
                return "Файл заблокирован или закрыт, закройте программу в которой открыт файл и попробуйте еще раз.";
            };
        }

        public string HashSHA512()
        {
            try
            {
                using (FileStream fStream = File.OpenRead(FileLocation))
                {
                    return GetHash<SHA512>(fStream);
                };
            }
            catch (IOException)
            {
                return "Файл заблокирован или закрыт, закройте программу в которой открыт файл и попробуйте еще раз.";
            };
        }
                
        private string GetHash<T>(Stream stream) where T : HashAlgorithm
        {
            MethodInfo? create = typeof(T).GetMethod("Create", Array.Empty<Type>());
            if (create != null)
            {
                using T? crypt = create.Invoke(null, null) as T;
                byte[] hashBytes = crypt!.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
            }
            return string.Empty;
        }
    }
}
