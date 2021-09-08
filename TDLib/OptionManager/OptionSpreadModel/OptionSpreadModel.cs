
using System;
using System.Dynamic;
using TDLib;

public class OptionSpreadModel
{
    public string symbol { get; set; }
    public string status { get; set; }
    public object underlying { get; set; }
    public string strategy { get; set; }
    public float interval { get; set; }
    public bool isDelayed { get; set; }
    public bool isIndex { get; set; }
    public float interestRate { get; set; }
    public float underlyingPrice { get; set; }
    public float volatility { get; set; }
    public float daysToExpiration { get; set; }
    public int numberOfContracts { get; set; }
    public float[] intervals { get; set; }
    public Monthlystrategylist[] monthlyStrategyList { get; set; }
}


public class Monthlystrategylist
{
    public string month { get; set; }
    public int year { get; set; }
    public int day { get; set; }
    public int daysToExp { get; set; }
    public string secondaryMonth { get; set; }
    public int secondaryYear { get; set; }
    public int secondaryDay { get; set; }
    public int secondaryDaysToExp { get; set; }
    public string type { get; set; }
    public string secondaryType { get; set; }
    public bool leap { get; set; }
    public Optionstrategylist[] optionStrategyList { get; set; }
    public bool secondaryLeap { get; set; }
}

public class Optionstrategylist
{
    public OptionLeg primaryLeg { get; set; }
    public OptionLeg secondaryLeg { get; set; }
    public string strategyStrike { get; set; }
    public decimal strategyBid { get; set; }
    public decimal strategyAsk { get; set; }
}

public class OptionLeg
{
    public string symbol { get; set; }
    public string putCallInd { get; set; }
    public string description { get; set; }
    public decimal bid { get; set; }
    public decimal ask { get; set; }
    public string range { get; set; }
    public decimal strikePrice { get; set; }
    public float totalVolume { get; set; }

    public int DaysToExpiration
    {
        get
        {
            string[] components = symbol.Split("_".ToCharArray());
            if (components.Length != 2) throw new Exception($"Invalid option ticker {symbol} ");

            string dt = components[1];

            int mm = Convert.ToInt32(dt.Substring(0, 2));
            int dd = Convert.ToInt32(dt.Substring(2, 2));
            int yy = 2000 + Convert.ToInt32(dt.Substring(4, 2));

            DateTime ExpirationDate = new DateTime(yy, mm, dd);

            return (int)(ExpirationDate - System.DateTime.Today).TotalDays;
        }

    }

}

public class Secondaryleg
    {
        public string symbol { get; set; }
        public string putCallInd { get; set; }
        public string description { get; set; }
        public float bid { get; set; }
        public float ask { get; set; }
        public string range { get; set; }
        public decimal strikePrice { get; set; }
        public float totalVolume { get; set; }

        public int DaysToExpiration
        {
            get
            {
                string[] components = symbol.Split("_".ToCharArray());
                if (components.Length != 2) throw new Exception($"Invalid option ticker {symbol} ");

                string dt = components[1];

                int mm = Convert.ToInt32(dt.Substring(0, 2));
                int dd = Convert.ToInt32(dt.Substring(2, 2));
                int yy = 2000 + Convert.ToInt32(dt.Substring(4, 2));

                DateTime ExpirationDate = new DateTime(yy, mm, dd);

                return (int)(ExpirationDate - System.DateTime.Today).TotalDays;
            }
        }
    }

