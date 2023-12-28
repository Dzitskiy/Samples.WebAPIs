using System;
using System.Web.Services;

namespace AsmxService
{
    /// <summary>
    /// Summary description for TestWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World!";
        }

        [WebMethod]
        public int Add(int a, int b) => a + b;

        [WebMethod]
        public System.Single Subtract(System.Single A, System.Single B) => A - B;

        [WebMethod]
        public System.Single Multiply(System.Single A, System.Single B) => A * B;

        [WebMethod]
        public System.Single Divide(System.Single A, System.Single B)
        {
            if (B == 0) return -1;
            return Convert.ToSingle(A / B);
        }

        [WebMethod]
        public User GetTestObject(User individual)
        {
            return individual;
        }
    }
}
