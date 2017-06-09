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
		public void Dispose()
    {
      Client.DeleteAll();
    }
	}
}
