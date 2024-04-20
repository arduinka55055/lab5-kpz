using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace UltraVisionCentre
{
    public class SoftwareCenter
    {
        private string SourceCode { get; set; }
        private string LicenseID { get; set; }

        public SoftwareCenter(string licenseID)
        {
            LicenseID = licenseID;

            //підрубаємо милозвучну
            Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
            Console.OutputEncoding = Encoding.UTF8;
        }

        public void DownloadCode()
        {
            Console.WriteLine("Код було завантажено!");
        }
        public void LicenseCode()
        {
            //check sha256 
            string checksum = "AC6DC248A495107C6B1379D213E47E59C16D897EB1929A37D716D75F9A72F901";
            string license_hash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(LicenseID))).Replace("-", string.Empty);

            if (checksum != license_hash)
            {
                Console.WriteLine("Помилка ліцензування!");
                //exit
                Environment.Exit(-1);
            }
            Console.WriteLine("ПЗ було ліцензовано!");
        }
    }
}
