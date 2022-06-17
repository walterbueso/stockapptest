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
            Console.WriteLine("Going to try to call the api via three methods.");
            Console.WriteLine("(Y/N)Would you like to change the default URL of: " + URL);
            var response = Console.ReadKey();
            Console.WriteLine();
            if(response.KeyChar == 'y')
            {
                Console.WriteLine("Enter new URL: ");
                URL = Console.ReadLine();
            }
            Console.WriteLine("First Method HttpClient.");
            //GetStocksViaHttpClient(URL);
            GetStocksViaRestsharp(URL);
            //Console.WriteLine("Second method, Headless chrome.");
            //GetStocksViaHeadless(URL);
            //Console.WriteLine("Third Method, PuppeteerSharp");
            //GetStocksViaPuppeteerAsync(URL);
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }

        private static async Task GetStocksViaPuppeteerAsync(string uRL)
        {
            var options = new LaunchOptions()
            {
                Headless = true,
                ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
                Product = Product.Chrome
            };
            var browser = await Puppeteer.LaunchAsync(options);
            var page = await browser.NewPageAsync();
            Console.WriteLine("Using puppeteer to go to: " + uRL);
            await page.GoToAsync(uRL);
        }

        private static void GetStocksViaHeadless(string uRL)
        {
            var options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            };
            options.AddArguments(new List<string>() { "headless", "disable-gpu" });

            var browser = new ChromeDriver(options);
            browser.Navigate().GoToUrl(uRL);
            Console.WriteLine("Trying to connect with selenium. Browser title: " + browser.Title);
        }


        private static void GetStocksViaHttpClient(string uRL)
        {
            var response = CallUrl(uRL).Result;
            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Success getting response: " + response);
                return;
            }
        }
        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.26.8");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            var response = await client.GetStringAsync(fullUrl);
            return response;
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
