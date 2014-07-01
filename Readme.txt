
Lab4 - C# Socket Programming - CICS 525 
________________________________________________

--------------------------|-----------------------|
	Name			Student ID
--------------------------|-----------------------|
Aaron Cheng
--------------------------|-----------------------|
YeHua Deng			89668131
--------------------------|-----------------------|
Alex Yip
--------------------------|-----------------------|
Arimarajan Parasuraman		87474136
--------------------------|-----------------------|




***************************************************************************************


***************************************************************************************
Zipped Folder Contains the source code of Part2 and Part3 inside the following folders

Part2 - A Client-Server Application - Simple Stock Trading System
____________________________________________________________________

Folder Name : SynchronousTrading

	Source Code 
	--------------

	- Server (..\SynchronousTrading\StockServer\StockServer.cs )
	- ViewStock (..\SynchronousTrading\ViewStock\ViewStock.cs )
	- Stocks (.. \SynchronousTrading\Stocks\UpdateStock.cs )

	To Execute 
	--------------

	- Step1: Open the command prompt and change the path to "..\SynchronousTrading\StockServer\bin\Debug"
	- Step2: Type "StockServer" and press enter (now the Server is started)
	- Step3: Open another command prompt and change the path to "..\SynchronousTrading\Stocks\bin\Debug"
	- Step4: Type "Stocks" and press enter -- (This will allow user to enter a new stock name and its price or allow an existing stock price to get updated)
	- Step5: Open another command prompt and change the path to "..\SynchronousTrading\ViewStock\bin\Debug"
	- Step6: Type "ViewStock" in the command prompt -- (This will allow user to view the already existing stock details)

***************************************************************************************


***************************************************************************************


Part3 - A Multithreaded Client-Server Application for Stock Trading
____________________________________________________________________

Folder Name : StockTrading


	Source Code 
	--------------
	
	-Server (..\StockTrading\Server\Stock.cs)
	-Server (..\StockTrading\Server\Client.cs)
	-Server (..\StockTrading\Server\Program.cs)
	-Client (..\StockTrading\Client\Program.cs)	

	To Execute
	----------------

	- Step1: Open the command prompt and change the path to "..\StockTrading\Server\bin\Debug"
	- Step2: Type "Server" and press enter (now the Server is started)
	- Step3: Open another command prompt and change the path to "..\StockTrading\Client\bin\Debug"
	- Step4: Type "Client" and press enter (now the client will be connected to the Server with the mentioned socket) and responds to the user input action


***************************************************************************************


***************************************************************************************


1. how you came up with your implementation ?

	- For Part2 used Synchronous method so that same server responds to two different clients
	- For Part3 we have used multiple client requesting response from a single server. Used Multi-thread to implement this logic. That for each client a new thread instant will be created so that more than one client can be connected at the same time. The communication between the each client to the server is made independent. In the same way the Server creates a separate thread for each Client's Communication.


2. what are the limitations of your program ?
	- since we used windows console applicaiton not much user friendly.
	- the client program will be asking the user input in loops that is user has to keep on giving the input..


3. how can you extend it in the near future ?
	- control the loops based on required input

