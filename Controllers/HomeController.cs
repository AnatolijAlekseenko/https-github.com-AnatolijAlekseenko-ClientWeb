using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



namespace ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult total(string arg1, string arg2)
        {
            var client = new MyEventTimeService.EventTimeServiceSoapClient();
            try
            {
                double lat = Convert.ToDouble(arg1);
                double lng = Convert.ToDouble(arg2); ;

                var str = client.MyEventTimeService(lat, lng); //получили строку JSON

                //Присваиваем значение
                var astronomical_twilight_begin = str.results.astronomical_twilight_begin;
                //для вывода значения на страницу
                ViewBag.astronomical_twilight_begin = "Начало астрономических сумерек: " + str.results.astronomical_twilight_begin;

                var astronomical_twilight_end = str.results.astronomical_twilight_end;

                ViewBag.astronomical_twilight_end = "Конец астрономических сумерек: " + str.results.astronomical_twilight_end;

                var civil_twilight_begin = str.results.civil_twilight_begin;

                ViewBag.civil_twilight_begin = "Начало гражданских сумерек: " +
                    str.results.civil_twilight_begin;

                var civil_twilight_end = str.results.civil_twilight_end;

                ViewBag.civil_twilight_end = "Конец гражданских сумерек: "
                    + str.results.civil_twilight_end;

                var day_length = str.results.day_length;

                ViewBag.day_length = "Продолжительность дня: "
                   + str.results.day_length;

                var nautical_twilight_begin = str.results.nautical_twilight_begin;

                ViewBag.nautical_twilight_begin = "Начало морских сумерок: "
                   + str.results.nautical_twilight_begin;

                var nautical_twilight_end = str.results.nautical_twilight_end;

                ViewBag.nautical_twilight_end = "Конец морских сумерок: "
                   + str.results.nautical_twilight_end;

                var solar_noon = str.results.solar_noon;

                ViewBag.solar_noon = "Солнечный полдень: "
                   + str.results.solar_noon;

                var sunrise = str.results.sunrise;

                ViewBag.sunrise = "Восход: "
                  + str.results.sunrise;

                var sunset = str.results.sunset;

                ViewBag.sunset = "Закат: "
                + str.results.sunset;

                client.Close();
             
            } catch (Exception ex)
            {
                ViewBag.Message = ex.ToString(); // в случае ошибки, например нпереданы не цифры
             
            }

            return View("Index");
        }


       

    }

}