using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

namespace BASICsharp {
    public class BASICsharp {
		static double EvaluateExpression(string expression)
    	{
        	char[] separators = { '+', '-', '*', '/' };
        	string[] parts = expression.Split(separators);

        	double operand1 = Convert.ToDouble(parts[0].Trim());
        	double operand2 = Convert.ToDouble(parts[1].Trim());
        	char operation = expression[parts[0].Length];

        	switch (operation)
        	{
        	    case '+':
        	        return operand1 + operand2;
        	    case '-':
        	        return operand1 - operand2;
        	    case '*':
        	        return operand1 * operand2;
        	    case '/':
        	        if (operand2 == 0)
        	        {
        	            throw new DivideByZeroException("Cannot divide by zero.");
        	        }
        	        return operand1 / operand2;
        	    default:
        	        throw new ArgumentException("Invalid operation.");
        	}
    }
        public static void Main(string[] args) {
            Console.Clear();
            Console.Title = "BASIC# - Idle";
            Console.WriteLine("BASIC# - A little BASIC computer made in C#");
            Console.WriteLine("Press any key to start");
            Console.Read();
            Console.Clear();
            double mathresult = 0;
			string[] memory = {"", "", "", "", "", "", "", "", "", ""};
            bool done = false;
            bool fileopened = false;
			string inputresult = "";
            string openfile = "";
            while(done == false) {
                Console.Title = "BASIC# - Running";
                Console.Write("BASIC#>");
                string basicsharpinput = Console.ReadLine();
                if (basicsharpinput == "help") {
                    Console.WriteLine("help - Displays this block of text");
                    Console.WriteLine("new <FILE> - Starts a new program");
                    Console.WriteLine("run - Runs a program");
                    Console.WriteLine("com - Writes a command to open file");
                    Console.WriteLine("end - Ends file editing");
                    Console.WriteLine("list - Shows all lines of code in open file");
                    Console.WriteLine("ls - Lists all programs made with BASIC#");
                    Console.WriteLine("del - Deletes a program.");
                    Console.WriteLine("open - Just like new, but instead of creating a file it just opens it (hence the name).");
                    Console.WriteLine("exit - Exits BASIC#");
                } else if (basicsharpinput == "new") {
					Console.Write("Enter name of program: ");
					string name = Console.ReadLine();
                    if (name == "") {
                        Console.WriteLine("argument 'FILE' must not be empty");
                    } else {
                        openfile = name;
                        File.Create(@"./" + name.ToUpper() + ".cb").Dispose();
                        fileopened = true;
                    }
				} else if (basicsharpinput == "exit") {
					Console.Title = "BASIC# - Done";
					fileopened = false;
					System.Threading.Thread.Sleep(2000);
					Console.Clear();
					done = true;
				} else if (basicsharpinput == "end") {
					if (openfile != null && fileopened == true) {
							Console.WriteLine("Ending editing of file '" + openfile.ToString() + "'");
						openfile = "";
						fileopened = false;
					} else {
						Console.WriteLine("No file currently open");
					}
				} else if (basicsharpinput == "com") {
					if (fileopened == false) {
						Console.WriteLine("No file currently open");
					} else {
											Console.Write("Enter command: ");
					string code = Console.ReadLine();
					if (code != null) {
						try {
							using (StreamWriter w = File.AppendText(@"./" + openfile.ToUpper() + ".cb")) {
								w.WriteLine(code);
							}
						} catch (IOException e) {
							Console.WriteLine(e);
						}
					} else {
						Console.WriteLine("argument <COMMAND> must not be empty");
					}
					}
				} else if (basicsharpinput == "ls") {
					string[] dir = Directory.GetFiles(".");
					Console.WriteLine("List of C#ASIC programs in this directory:");
					foreach (string literalFile in dir) {
						string file = literalFile.ToString();
						if (file.EndsWith(".cb")) {
							file = file.Substring(2, file.Length-5);
							Console.WriteLine(file);
						} else {
							
						}
					}
				} else if (basicsharpinput == "del") {
					Console.Write("Enter program to delete: ");
					string prgm = Console.ReadLine();
					if (File.Exists("./" + prgm.ToUpper() + ".cb")) {
						if (fileopened == true && openfile == prgm) {
							fileopened = false;
							Console.WriteLine("Deleting " + prgm.ToUpper() + "...");
							File.Delete("./" + prgm.ToUpper() + ".cb");
							Console.WriteLine("Deleted program " + prgm.ToUpper());
						} else {
							Console.WriteLine("Deleting " + prgm.ToUpper() + "...");
							File.Delete("./" + prgm.ToUpper() + ".cb");
							Console.WriteLine("Deleted program " + prgm.ToUpper());
						}
					} else {
						Console.WriteLine("Program not found.");
					}
				} else if (basicsharpinput == "run") { 
					if (openfile != null && fileopened == true) {
						string[] contents = File.ReadAllLines("./" + openfile.ToUpper() + ".cb");
						int linenum = 1;
						foreach (string line in contents) {
							if (line.StartsWith("input")) {
								if (line.Length > 6) {
									if (line.Substring(6).StartsWith("$")) {
										int index = int.Parse(line.Substring(7, 2));
										Console.Write(memory[index] + "> ");
									} else {
										Console.Write(line.Substring(6) + "> ");
									}
								} else {
									Console.WriteLine("input>");
								}
								inputresult = Console.ReadLine();
							} else if (line.StartsWith("print") && line.Length > 6) {
								if (line.Substring(6) == "!inputresult!") {
									Console.WriteLine(inputresult);
								} else if (line.Substring(6) == "!mathresult!") {
									Console.WriteLine(mathresult);
								} else if (line.Substring(6).StartsWith("$")) {
									int index = int.Parse(line.Substring(7, 2));
									if (index <= 10 && index >= 1) {
										Console.WriteLine(memory[index]);
									}
								} else {
									Console.WriteLine(line.Substring(6));
								}
							} else if (line == "clear") {
								Console.Clear();
							} else if (line.StartsWith("wait") && line.Length > 5) {
								int waittime;
								if (line.Substring(5).StartsWith("$")) { 
									int index = int.Parse(line.Substring(6, 2));
									waittime = int.Parse(memory[index]);
								} else {
									waittime = int.Parse(line.Substring(5));
								}
								Thread.Sleep(waittime * 1000);
							} else if (line.StartsWith("math") && line.Length > 5) {
								double equation = 0;
								int index = int.Parse(line.Substring(6, 2));
								equation = EvaluateExpression(memory[index]);
								mathresult = equation;
							} else if (line.StartsWith("--")) {
								continue;
							} else if (line.StartsWith("$") && line.Length >= 3) {
								if (line.Length == 3 && line.Length < 4) {
									int index = int.Parse(line.Substring(1, 2));
									if (index <= 10 && index >= 1) {
										Console.WriteLine(memory[index]);
									}
								} else if (line.Length >= 4) {
									int index = int.Parse(line.Substring(1,2));
									string value = line.Substring(4);
									memory[index] = value;
								}
							} else {
								Console.WriteLine("Error: command on line #" + linenum.ToString() + " not recognized or is incomplete (2). Halting.");
								break;
							}
							linenum += 1;
						}
					} else {
						Console.WriteLine("No currently open file");
					}
				} else if (basicsharpinput == "list") {
					if (fileopened == true) {
						string[] linesofcode = File.ReadAllLines(@"./" + openfile.ToUpper() + ".cb");
						foreach (string lineofcode in linesofcode) {
							Console.WriteLine(lineofcode);
						}
					} else {
						Console.WriteLine("No file currently open");
					}
				} else if (basicsharpinput == "open") {
					Console.Write("Enter name of program: ");
					string name = Console.ReadLine();
                    if (name == "") {
                        Console.WriteLine("argument 'FILE' must not be empty");
                    } else {
						if (File.Exists("./" + name + ".cb")) {
                        	openfile = name;
                        	fileopened = true;
						} else {
							Console.WriteLine("argument <FILE> does not exist");
						}
                    }
				} else if (basicsharpinput == "clear") {
					Console.Clear();
				} else if (basicsharpinput.StartsWith("$") && basicsharpinput.Length >= 3) {
								if (basicsharpinput.Length == 3) {
									int index = int.Parse(basicsharpinput.Substring(1, 2));
									if (index <= 10 && index >= 1) {
										Console.WriteLine(memory[index]);
									}
								} else if (basicsharpinput.Length >= 4 && basicsharpinput.Substring(3,1) == "=") {
									int index = int.Parse(basicsharpinput.Substring(1,2));
									string value = basicsharpinput.Substring(4);
									memory[index] = value;
								}
				} else {
					Console.WriteLine("Error: command '" + basicsharpinput + "' not recognized (1).");
				}
			}
		}
	}
}
