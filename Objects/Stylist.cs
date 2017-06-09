using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
	public class Stylist
  {
    private int _id;
    private string _name;

    public Stylist(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }
		public override bool Equals(System.Object otherStylist)
	  {
		  if (!(otherStylist is Stylist))
		  {
			  return false;
		  }
		  else
		  {
			  Stylist newStylist = (Stylist) otherStylist;
			  bool idEquality = (this.GetId() == newStylist.GetId());
			  bool nameEquality = (this.GetName() == newStylist.GetName());
			  return (idEquality && nameEquality);
		  }
	  }
		// GETTERS------
    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

// SETTERS------
    public void SetName(string name)
    {
      _name = name;
    }
		public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);

        allStylists.Add(newStylist);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allStylists;
    }

	}
}
