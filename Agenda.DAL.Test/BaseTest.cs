using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class BaseTest
    {
        private string _script;
        private string _con;
        private string _catalogTest;

        public BaseTest()
        {
            _con = "Host=localhost;Port=5450;Database=pgsqltests;Username=pguser;Password=pgpassword;";
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            CreateDBTest();

        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {


        }

        private void CreateDBTest()
        {

        }
    }
}
