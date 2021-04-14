using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace OurCompanyWebsite.Controllers
{
	public class HomeController1 : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ThankYouBd() // представление спасибо
		{
			return View(); 
		}

		[HttpPost]
		public IActionResult ThankYouBd(string login, string login1, string login2)//принимает в себя данные о клиенте и заносит в базу данных
		{
			string a = login;
			string b = login1;
			string c = login2;
			SendEmailAsync(a, b, c).GetAwaiter();//вызов функции отправки письма
			return View("~/Views/Home/Index.cshtml");
		}
		[HttpPut]
		[HttpDelete]
		[HttpPost]
		public ActionResult PutDelite(string pp, string delite) // получает какие данные и изменяет с помощью данныъх что то
		{
			string Rdelite = "delitehttp";
			int Rpp;
			if (pp != null)
			{
				Rpp = Convert.ToInt32(pp) + 1;
			}
			if (delite!=null)
			{
				Rdelite = null;
			}
			return View("~/Views/Home/Index.cshtml");
		}

		private static async Task SendEmailAsync(string a, string b, string c) //отправка письма 
		{
			string text = "Добрый день " + a + " Мы получили ваш запрос: "+ c +" В ближайшее время мы свяжемся с вами по контакту: " + b;
			MailAddress from = new MailAddress("webivanivanivan@gmail.com", "ARE");
			MailAddress to = new MailAddress(b);
			MailMessage m = new MailMessage(from, to);
			m.Subject = "Тест";
			m.Body = text; // тут можно отправить данные письма html код
			SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
			smtp.Credentials = new NetworkCredential("webivanivanivan@gmail.com", "areareare");
			smtp.EnableSsl = true;
			await smtp.SendMailAsync(m);
		}

	}
}
