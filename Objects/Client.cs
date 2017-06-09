using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
	public class Client
	{
		private int _id;
		    private string _name;
		    private int _stylistId;

    public Client(string Name, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _stylistId = StylistId;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (idEquality && nameEquality && stylistEquality);
      }
    }

//  GETTERS------
    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

//  SETTERS------
    public void SetClientName(string newName)
    {
      _name = newName;
    }
    public void SetStylistId(int newId)
    {
      _stylistId = newId;
    }

//GetAll
		public static List<Client> GetAll()
	  {
		 List<Client> allClient = new List<Client>{};

		 SqlConnection conn = DB.Connection();
		 conn.Open();

		 SqlCommand cmd = new SqlCommand("SELECT * FROM clients", conn);
		 SqlDataReader rdr = cmd.ExecuteReader();

		while(rdr.Read())
		{
			int clientId = rdr.GetInt32(0);
			string clientName = rdr.GetString(1);
			int clientStylistId = rdr.GetInt32(2);

			Client newClient = new Client(clientName, clientStylistId, clientId);
			allClient.Add(newClient);

		}

		if (rdr != null)
		{
			rdr.Close();
		}
		if (conn != null)
		{
			conn.Close();
		}
		return allClient;
		}

//Save Method
		public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_Id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientStylistId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@ClientStylistId";
      stylistIdParameter.Value = this.GetStylistId();

      cmd.Parameters.Add(stylistIdParameter);
      cmd.Parameters.Add(nameParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {

        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }


		public static void DeleteAll()
		{
		 SqlConnection conn = DB.Connection();
		 conn.Open();
		 SqlCommand cmd = new SqlCommand("DELETE FROM clients", conn);
		 cmd.ExecuteNonQuery();
		 conn.Close();
		}
	}
}
