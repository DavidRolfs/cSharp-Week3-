using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("hair_salon")]
  public class StylistTest
  // : IDisposable
  {
   public StylistTest()
   {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmpty()
    {
      //ARRANGE, application
      int result = Stylist.GetAll().Count;

      //ASSERT
        Assert.Equal(0, result);
    }
  }
}
