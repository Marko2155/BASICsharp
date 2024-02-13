# BASICsharp
BASIC# (had to remove the # from title because of GitHub) is a program where you can write and run code in a BASIC-like programming language called C#ASIC (pronounced CBASIC).

# ---WARNING---
This branch is only used for development purposes, as it might have unfinished+broken commands. This branch is used for transfering from one collaborator to another. Any code submitted here must never be built by consumers, only collaborators.

# How it works
C#BASIC is not a real language, it is written all in software to point to standard C# functions (hence the name C#ASIC). C#BASIC will halt if it finds a command that is not programmed in yet.
BASIC# works almost excatly like my other CLI program, .OS, but has some changes.

# How to compile
## Windows
First, install WSL and Ubuntu. Then, Install Mono and Git by typing ```sudo apt install mono-complete git```. Clone the repo using ```git clone https://github.com/Marko2155/BASICsharp.git```. Now, ```cd``` into the BASICsharp folder. Type ```mcs BASICsharp.cs```. However it will produce a .exe. You can either install Wine or do ```mono BASICsharp.exe```. (it's best to put the last two commands into a bash script for easy compiling and running.
## Linux
Install Mono and Git by typing ```sudo apt install mono-complete git```. Clone the repo using ```git clone https://github.com/Marko2155/BASICsharp.git```. Now, ```cd``` into the BASICsharp folder. Type ```mcs BASICsharp.cs```. However it will produce a .exe. You can either install Wine or do ```mono BASICsharp.exe```. (it's best to put the last two commands into a bash script for easy compiling and running.
## Mac OS X
Install Mono and Git by typing ```brew install mono``` and ```brew install git```. Clone the repo using ```git clone https://github.com/Marko2155/BASICsharp.git```. Now, ```cd``` into the BASICsharp folder. Type ```mcs BASICsharp.cs```. However it will produce a .exe. You can either install Wine or do ```mono BASICsharp.exe```. (it's best to put the last two commands into a bash script for easy compiling and running.

# Commands
print - Prints - Example ```print test```.

input - Prompts user - Example ```input test```

clear - Clears screen - Example ```clear``` 

math  - Solves math equations - Example ```math 1+1```

wait - Pauses - Example ```wait 5```

# How-to Command
```print``` just... prints. If you enter mathresult into ```print```, it will get the result of the last math calculation, if you didn't do any calculations, it will return 0.

```input``` prompts the user. Required to add string after ```input```. Saves to variable. If you want to see the user input, just type ```print !inputresult!```.

```math``` does a math calculation. Just do something like ```math 1+1``` and ```print !mathresult!``` and it should print 2.

```wait``` adds a delay before the next function. The format must be seconds.

```clear``` clears the screen.
