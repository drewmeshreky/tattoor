using InstaSharp;
using InstaSharp.Endpoints;
using InstaSharp.Models.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tattoor.Models;

namespace Tattoor.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Request
        public async Task<ActionResult> Index(string id)
        {
            ViewBag.MenuItmes = new Dictionary<string, string>
            {
                ["Home"] = "#header",
                ["Appointment Request"] = "#apptRequest",
                ["photos"] = "#photos",
                ["Location"] = "#location",
            };

            var instagramConfig = new InstagramConfig("2551176810b7497ebe94e79fa551ea06", "2551176810b7497ebe94e79fa551ea06");

            OAuthResponse oAuthResponse = new OAuthResponse();
            oAuthResponse.User = null;
            oAuthResponse.AccessToken = "8915529.2551176.b8c936bdabf74276a2844e4a29394b34";

            var users = new Users(instagramConfig, oAuthResponse);
            UsersResponse usersResponse = await users.Search("tattoor.co", 1);
            var user = usersResponse.Data.First();

            ViewBag.Image = user.ProfilePicture;
            ViewBag.FullName = user.FullName;
            ViewBag.Header = user.Bio; // "Get an appointment request page (just like this one) for yourself! For free!";

            var recent = await users.Recent(user.Id, string.Empty, string.Empty, 8, null, null);
            ViewBag.Media = recent.Data.Select(media => media.Images.StandardResolution.Url).ToList();

            ViewBag.FAQs = new List<FAQ>
            {
                new FAQ
                {
                    
                    Question = "How much do you charge?",
                    Answer = "Appointment request pages (just like this one) are free! Get one for yourself!"
                },
                new FAQ
                {

                    Question = "If this is free, how do you make money?",
                    Answer = "In order to generate revenue, we'll be offering other services in the future"
                },
            };


            ViewBag.Locations = new List<Location>
            {
                new Location
                {
                    Name = "Tattoor Office",
                    Address1 = "1631 Camino De Salmon St",
                    City = "Corona",
                    State = "CA",
                    PostalCode = "92881"
                },
            };

            return View();
        }
    }
}