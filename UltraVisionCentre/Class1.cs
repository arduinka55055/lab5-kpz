using System.Globalization;
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
         Console.WriteLine("ПЗ було ліцензовано!");
      }
   }
}
