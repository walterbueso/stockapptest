using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using System;
using PuppeteerSharp;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

namespace ConsoleAppStocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var URL = "https://api.nasdaq.com/api/screener/stocks?tableonly=true&limit=25&exchange=NASDAQ&country=united_states|usa";
            Console.WriteLine("Stock radar app");
            Console.WriteLine("(Y/N)Would you like to change the default URL of: " + URL);
            var response = Console.ReadKey();
            Console.WriteLine();
            if(response.KeyChar == 'y')
            {
                Console.WriteLine("Enter new URL: ");
                URL = Console.ReadLine();
            }
            Console.WriteLine("Trying to get stock data via restsharp.");
            GetStocksViaRestsharp(URL);
        }
        private static void GetStocksViaRestsharp(string url)
        {
            var options = new RestClientOptions(url)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 30000
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddHeader("User-Agent", "PostmanRuntime/7.26.8");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Postman-Token", "2aefab72-047a-4b5e-afd7-9790318bf7f6");
            request.AddHeader("Host", "api.nasdaq.com");
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Connection", "keep-alive");
            var response = client.Get(request);
        }
    }
}
