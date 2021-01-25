using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Entities;
using Tasinmaz.Services;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KullaniciController : ControllerBase
    {
        [HttpPost]
        public bool Add(Kullanici kullanici)
        {
            try
            {
                KullaniciService kullaniciServis = new KullaniciService();
                kullaniciServis.Add(kullanici);
                return true;
            }
            catch
            {
                return false;
            }

        }

        [HttpGet]
        public string Getir(){
            return "test 1 2 3 45";
        }
    }
}