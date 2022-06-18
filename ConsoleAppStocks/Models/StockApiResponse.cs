using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStocks.Models
{
    public class StockApiResponse
    {
        public Data data { get; set; }
        public object message { get; set; }
        public Status status { get; set; }
    }

    public class Data
    {
        public object filters { get; set; }
        public Table table { get; set; }
        public int totalrecords { get; set; }
        public string asof { get; set; }
    }

    public class Table
    {
        public Headers headers { get; set; }
        public Row[] rows { get; set; }
    }

    public class Headers
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string lastsale { get; set; }
        public string netchange { get; set; }
        public string pctchange { get; set; }
        public string marketCap { get; set; }
    }

    public class Row
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string lastsale { get; set; }
        public string netchange { get; set; }
        public string pctchange { get; set; }
        public string marketCap { get; set; }
        public string url { get; set; }
    }

    public class Status
    {
        public int rCode { get; set; }
        public object bCodeMessage { get; set; }
        public object developerMessage { get; set; }
    }
}
