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
			Get["/stylists/{id}"] = parameter => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist SelectedStylist = Stylist.Find(parameter.id);
        List<Client> StylistClient = SelectedStylist.GetClient();
        model.Add("Stylist", SelectedStylist);
        model.Add("Client", StylistClient);
        return View["clients.cshtml", model];
      };
		}
	}
}
