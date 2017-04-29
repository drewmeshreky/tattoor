﻿using InstaSharp;
using InstaSharp.Endpoints;
using InstaSharp.Models.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tattoor.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Request
        public async Task<ActionResult> Index(string id)
        {
            ViewBag.MenuItmes = new Dictionary<string, string>
            {
                ["Appointment Request"] = "#apptRequest",
                ["photos"] = "#photos",
                ["Location"] = "#location",
            };

            ViewBag.FirstName = "Drew";
            ViewBag.LastName = "Meshreky";
            ViewBag.Header = "Get an appointment requests page like this for yourself! For free!";

            var instagramConfig = new InstagramConfig("2551176810b7497ebe94e79fa551ea06", "2551176810b7497ebe94e79fa551ea06");

            OAuthResponse oAuthResponse = new OAuthResponse();
            oAuthResponse.User = null;
            oAuthResponse.AccessToken = "8915529.2551176.b8c936bdabf74276a2844e4a29394b34";

            var users = new Users(instagramConfig, oAuthResponse);
            UsersResponse usersResponse = await users.Search("tattoor.co", 1);
            var user = usersResponse.Data.First();

            var recent = await users.Recent(user.Id, string.Empty, string.Empty, 8, null, null);
            ViewBag.Media = recent.Data.Select(media => media.Images.StandardResolution.Url).ToList();

            ViewBag.LocationTitle = "Meshreky Residence";

            return View();
        }
    }
}