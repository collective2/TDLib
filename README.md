This repo contains source code and examples for using the TDAmeritrade API with Collective2 so you can publish your live TDAmeritrade trades to a Collective2 strategy which you can then sell as a subscription to followers.


The TDAmeritrade developer web site is located at https://developer.tdameritrade.com

The Collective2 web site is at https://collective2.com 


The library TDLib is written in C# for .net version 4.7.2. Using the API requires 5 different values that you retrieve in different ways. Read the file GettingTheKeys.pdf to see a discussion and walkthrough. Getting all of the keys together requires some effort, different logins and copying and pasting values around. But once it's done you're good to go.


The HelloWorld program is a short console app that will pull the latest quote for the SPY. Running this successfully means that you've configured the keys in appkeys.json correctly. 


TradingExamples is a console program that runs (guess what?) some trading examples:
 - buy/sell at market
 - buy/sell limit for day
 - buy/sell limit GTC
 - One triggers another: buy, then sell
 - One triggers another: sell, then buy
