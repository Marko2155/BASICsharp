BASICsharp
BASIC# (had to remove the # from title because of GitHub) is a program where you can write and run code in a BASIC-like programming language called C#ASIC (pronounced CBASIC).

# How it works
C#ASIC is not a real language, it is written all in software to point to standard C# functions (hence the name C#ASIC). C#ASIC will halt if it finds a command that is not programmed in yet.
BASIC# works almost excatly like my other CLI program, .OS, but has some changes.

# How to compile
## Windows
First, install WSL and Ubuntu. Then, Install Mono and Git by typing ```sudo apt install mono-complete git```. Clone the repo using ```git clone https://github.com/Marko2155/BASICsharp.git```. Now, ```cd``` into the BASICsharp folder. Type ```mcs BASICsharp.cs```. However it will produce a .exe. You can either install Wine or do ```mono BASICsharp.exe```. (it's best to put the last two commands into a bash script for easy compiling and running.
## Linux
Install Mono and Git by typing ```sudo apt install mono-complete git```. Clone the repo using ```git clone https://github.com/Marko2155/BASICsharp.git```. Now, ```cd``` into the BASICsharp folder. Type ```mcs BASICsharp.cs```. However it will produce a .exe. You can either install Wine or do ```mono BASICsharp.exe```. (it's best to put the last two commands into a bash script for easy compiling and running.
## Mac OS X
Install Mono and Git by typing ```brew install mono``` and ```brew install git```. Clone the repo using ```git clone https://github.com/Marko2155/BASICsharp.git```. Now, ```cd``` into the BASICsharp folder. Type ```mcs BASICsharp.cs```. However it will produce a .exe. You can either install Wine or do ```mono BASICsharp.exe```. (it's best to put the last two commands into a bash script for easy compiling and running.

# Where's the commands and the How-to's?
They moved to this GitHub repo's wiki. Look over [here](https://github.com/marko2155/basicsharp/wiki).
