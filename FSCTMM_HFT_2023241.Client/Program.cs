using System;
using System.Linq;
using System.Net;

namespace FSCTMM_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true; //Ezt az SSL exceptionok miatt


            RestService rest = new RestService("http://localhost:18364/", "name");

        }
    }
}
