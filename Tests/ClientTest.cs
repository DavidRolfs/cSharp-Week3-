using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("hair_salon")]
  public class ClientTest : IDisposable
	{
		public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
		[Fact]
    public void Test_DatabaseEmpty_True()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
		[Fact]
    public void Test_NamesAreTheSame_True()
    {
      //Arrange, Act
      Client firstClient = new Client("Joe", 1);
      Client secondClient = new Client("Joe", 1);

      //Assert
      Assert.Equal(firstClient, secondClient);
    }
		[Fact]
    public void Test_SavesToDatabase_True()
    {
      //Arrange
      Client testClient = new Client("Joe", 1);
      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      Assert.Equal(testList, result);
    }

		[Fact]
    public void Test_Find_FindsClientInDatabase()
    {
      //Arrange
      Client testClient = new Client("Joe", 1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.Equal(testClient, foundClient);
    }


		[Fact]
    public void Test_Update_UpdatesCategoryInDatabase()
    {
      string name = "Joe";
      Client testClient = new Client(name, 1);
      testClient.Save();
      string newName = "Paul";

      testClient.Update(newName);

      string result = testClient.GetName();

      Assert.Equal(newName, result);
    }

		[Fact]
    public void Test_Delete_DeletesCategoryFromDatabase()
    {
      //Arrange
      Client testClient1 = new Client("Paul", 1);
      testClient1.Save();

      Client testClient2 = new Client("Jack", 2);
      testClient2.Save();
      //Act
      testClient1.Delete();

      List<Client> resultClientList = Client.GetAll();
      List<Client> testClientList = new List<Client>{testClient2};
      //Assert
      Assert.Equal(testClientList, resultClientList);
    }


		public void Dispose()
    {
      Client.DeleteAll();
    }
	}
}
