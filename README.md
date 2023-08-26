# BASICsharp
BASIC# (had to remove the # from title because of GitHub) is a program where you can write and run code in a BASIC-like programming language called C#ASIC (pronounced CBASIC).

# ---WARNING---
This branch is only used for development purposes, as it has unfinished+broken commands. This branch is used for transfering from one collaborator to another. Any code submitted here must never be built by consumers, only collaborators.

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

math ##BROKEN## - Solves math equations - Example ```math SAV 1+1```

wait ##BROKEN## - Pauses (in miliseconds) - Example ```wait 5000```

load + endload ##BROKEN## - ```load``` loads a program and ```endload``` ends the load-open session. - Example x2 -TEST1.bsharp ```load test2``` - TEST2.bsharp ```endload```

# How-to Command
```print``` just... prints. If you enter mathresult into ```print```, it will get the result of the last math calculation, if you didn't do any calculations, it will return 0.

```input``` prompts the user. Saving to variable is not supported yet. It is required to add a piece of text after the command.

```math``` does a math calculation. Must add option (either "SAV" (all uppercase, stands for "save") or "PRT" (all uppercase, stands for "print")) or else error.

```wait``` adds a delay before the next function. The format must be miliseconds.

```clear``` clears the screen.

```load``` + ```endload``` - ```load``` loads a program and ```endload``` ends the load-open session. Make sure to add ```endload``` at the end of the file you loaded or else when you type ```com``` to add a command it'll write to the program loaded by ```load```, not the program you opened by using ```open``` or ```new```!
