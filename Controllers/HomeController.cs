using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            var request = new DomainBusPayAtAllCreateRequest();
            request.ActionUrl = "https://gateway2.payatall.com/paynow";
            request.MID = "615";
            request.ServiceId = "01";
            request.InviceNo = "ABC";
            request.Description = "Product of invoice no " + request.InviceNo;
            request.CustomerName = "aaaa aaaa";
            request.CustomerEmail = "ddd@ddd.ddd";
            request.CustomerPhone = "0000000021";
            request.Amount = 100;
            request.CurrencyType = "THB";
            request.ResponseUrlBack = "https://dev.fairfair.co.th/success";
            request.ResponseUrlCancel = "https://dev.fairfair.co.th";
            request.ResponseUrlConfirm = "https://dev.fairfair.co.th/confirm";
            request.Language = "TH";
            request.ExpiredDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd HH:mm", new CultureInfo("en-US"));
            request.MessageSlip1 = "";
            request.MessageSlip2 = "";
            request.Channel = "02";

            //1.นำ String Parameter มาเชื่อมต่อกัน ตามลาดับที่ระบุในบทที่ 3
            var plainText = string.Format(
                    "mid={0}," +
                    "serviceid={1}," +
                    "inv={2}," +
                    "desp={3}," +
                    "customer_name={4}," +
                    "customer_email={5}," +
                    "customer_phone={6}," +
                    "amt={7}," +
                    "curr_type={8}," +
                    "resp_url_back={9}," +
                    "resp_url_cancel={10}," +
                    "resp_url_confirm={11}," +
                    "language={12}," +
                    "expired_date={13},",
                    "channel={14}",
                    request.MID,
                    request.ServiceId,
                    request.InviceNo,
                    request.Description,
                    request.CustomerName,
                    request.CustomerEmail,
                    request.CustomerPhone,
                    request.Amount,
                    request.CurrencyType,
                    request.ResponseUrlBack,
                    request.ResponseUrlCancel,
                    request.ResponseUrlConfirm,
                    request.Language,
                    request.ExpiredDate,
                    request.Channel);

            Encoding ascii = Encoding.ASCII;

            //2. นาข้อมูลมาทาการ แปลงค่า HMAC แบบ SHA256 ด้วย Secret Key ที่ระบบทาการออกให้
            HMACSHA256 hmac = new HMACSHA256(ascii.GetBytes("FirAeme"));
            var compute = hmac.ComputeHash(ascii.GetBytes(plainText));

            //3.นาข้อมูลจากข้อที่ 2ไปทาการ Encode ด้วย Base64 อีกครั้ง
            String calc_sig = Convert.ToBase64String(compute);

            request.CheckData = calc_sig;

            return View(request);
        }
    }
}