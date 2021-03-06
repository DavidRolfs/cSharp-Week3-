using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("hair_salon")]
  public class StylistTest : IDisposable
  {
   public StylistTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmpty()
    {

      int result = Stylist.GetAll().Count;


        Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {

      Stylist firstStylist = new Stylist("Sam");
      Stylist secondStylist = new Stylist("Sam");


      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {

      Stylist testStylist = new Stylist("Sam");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};


      Assert.Equal(testList, result);
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    [Fact]
    public void Test_Find_FindsStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Sam");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }
    [Fact]
    public void Test_GetClients_RetrievesAllClientsWithinStylist()
    {
      Stylist testStylist = new Stylist("Sam");
      testStylist.Save();

      Client firstClient = new Client("Sam", testStylist.GetId());
      Client secondClient = new Client("Sam", testStylist.GetId());

      firstClient.Save();
      secondClient.Save();

      List<Client> testClientList = new List<Client>{firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClient();
    }

    [Fact]
    public void Test_Update_UpdatesStylistInDatabase()
    {
      string name = "Joe";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();
      string newName = "Paul";

      testStylist.Update(newName);

      string result = testStylist.GetName();

      Assert.Equal(newName, result);
    }

		[Fact]
    public void Test_Delete_DeletesStylistFromDatabase()
    {

      Stylist testStylist1 = new Stylist("Paul");
      testStylist1.Save();

      Stylist testStylist2 = new Stylist("Jack");
      testStylist2.Save();

      testStylist1.Delete();

      List<Stylist> resultStylist = Stylist.GetAll();
      List<Stylist> testStylist = new List<Stylist>{testStylist2};

      Assert.Equal(testStylist, resultStylist);
    }
  }
}
