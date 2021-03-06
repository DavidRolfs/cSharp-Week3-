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
				return View["all-stylists.cshtml", allStylists];
			};
			Post["stylists/all"] = _ => {
				Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
				newStylist.Save();
				List<Stylist> allStylists = Stylist.GetAll();
				return View["all-stylists.cshtml", allStylists];
			};
			Get["/stylists/{id}"] = parameter => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist SelectedStylist = Stylist.Find(parameter.id);
        List<Client> StylistClient = SelectedStylist.GetClient();
        model.Add("Stylist", SelectedStylist);
        model.Add("Client", StylistClient);
        return View["clients.cshtml", model];
      };
			Post["/stylists/delete"] = _ => {
        Stylist.DeleteAll();
        return View["deleteAll-confirm.cshtml"];
      };
			Get["/clients/add"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["add-client.cshtml", allStylists];
      };
			Post["/clients/all"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["client-id"]);
        newClient.Save();
        return View["root.cshtml"];
      };
			Get["client/edit/{id}"] = parameter => {
        Client SelectedClient = Client.Find(parameter.id);
        return View["edit-client.cshtml", SelectedClient];
      };
			Patch["client/edit/{id}"] = parameter => {
        Client SelectedClient = Client.Find(parameter.id);
        SelectedClient.Update(Request.Form["edit-client"]);
        List<Client> allClients = Client.GetAll();
        return View["root.cshtml", allClients];
      };
			Get["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client-delete.cshtml", SelectedClient];
      };
			Delete["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Delete();
        return View["root.cshtml"];
      };

      
      Get["stylist/edit/{id}"] = parameter => {
      	Stylist SelectedStylist = Stylist.Find(parameter.id);
      	return View["edit-stylist.cshtml", SelectedStylist];
      };
      Patch["stylist/edit/{id}"] = parameter => {
      	Stylist SelectedStylist = Stylist.Find(parameter.id);
      	SelectedStylist.Update(Request.Form["edit-stylist"]);
      	List<Stylist> allStylists = Stylist.GetAll();
      	return View["root.cshtml", allStylists];
      };
      Get["stylist/delete/{id}"] = parameters => {
      	Stylist SelectedStylist = Stylist.Find(parameters.id);
      	return View["stylist-delete.cshtml", SelectedStylist];
      };
      Delete["stylist/delete/{id}"] = parameters => {
      	Stylist SelectedStylist = Stylist.Find(parameters.id);
      	SelectedStylist.Delete();
      	return View["root.cshtml"];
      };
		}
	}
}
