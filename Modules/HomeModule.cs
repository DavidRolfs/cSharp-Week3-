using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
	{
    public HomeModule()
		{
      Get["/"] = _ => {
        return View["root.cshtml"];
      };
			Get["/stylists/add"] = _ => {
				return View["add-stylists.cshtml"];
			};
			Get["/stylists/all"] = _ => {
				List<Stylist> allStylists = Stylist.GetAll();
				return View["all-stylists", allStylists];
			};
			Post["stylists/all"] = _ => {
				Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
				newStylist.Save();
				List<Stylist> allStylists = Stylist.GetAll();
				return View["all-stylists", allStylists];
			};
		}
	}
}
