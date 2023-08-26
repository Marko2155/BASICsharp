using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BASICsharp {
    public class BASICsharp {
        public static void Main(string[] args) {
            Console.Clear();
            Console.Title = "BASIC# - Idle";
            Console.WriteLine("BASIC# - A little BASIC computer made in C#");
            Console.WriteLine("Press any key to start");
            Console.Read();
            Console.Clear();
            int mathresult = 0;
            bool done = false;
            bool fileopened = false;
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
                    Console.WriteLine("listdir - Lists all programs (with proprietary .bsharp extension)");
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
                        File.Create(@"./" + name.ToUpper() + ".bsharp").Dispose();
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
							using (StreamWriter w = File.AppendText(@"./" + openfile.ToUpper() + ".bsharp")) {
								w.WriteLine(code);
							}
						} catch (IOException e) {
							Console.WriteLine(e);
						}
					} else {
						Console.WriteLine("argument <COMMAND> must not be empty");
					}
					}
				} else if (basicsharpinput == "listdir") {
					string[] dir = Directory.GetFiles(".");
					foreach (string file in dir) {
						if (file.EndsWith(".bsharp")) {
							Console.WriteLine(file.ToString());
						} else {
							
						}
					}
				} else if (basicsharpinput == "del") {
					Console.Write("Enter program to delete: ");
					string prgm = Console.ReadLine();
					if (File.Exists("./" + prgm.ToUpper() + ".bsharp")) {
						if (fileopened == true && openfile == prgm) {
							fileopened = false;
							Console.WriteLine("Deleting " + prgm.ToUpper() + "...");
							File.Delete("./" + prgm.ToUpper() + ".bsharp");
							Console.WriteLine("Deleted program " + prgm.ToUpper());
						} else {
							Console.WriteLine("Deleting " + prgm.ToUpper() + "...");
							File.Delete("./" + prgm.ToUpper() + ".bsharp");
							Console.WriteLine("Deleted program " + prgm.ToUpper());
						}
					} else {
						Console.WriteLine("Program not found.");
					}
				} else if (basicsharpinput == "run") { 
					if (openfile != null && fileopened == true) {
						string[] contents = File.ReadAllLines("./" + openfile.ToUpper() + ".bsharp");
						int linenum = 1;
						foreach (string line in contents) {
							linenum += 1;
							if (line.StartsWith("input") && line.Length > 6) {
								Console.Write(line.Substring(6));
								Console.ReadLine();
							} else if (line.StartsWith("print") && line.Length > 6) {
								if (line.Substring(6) != "mathresult") {
									Console.WriteLine(line.Substring(6));
								} else {
									Console.WriteLine(mathresult.ToString());
									mathresult = 0;
								}
							} else if (line == "clear") {
								Console.Clear();
							} else if (line.StartsWith("wait") && line.Length > 5) {
								int waittime = int.Parse(line.Substring(5));
								Thread.Sleep(waittime * 1000);
								
							} else if (line.StartsWith("math") && line.Length > 5) {
								if (line.Substring(6) != "SAV") {
									int.Parse(line.Substring(6));
								} else {
									mathresult = int.Parse(line.Substring(9));
								}
							} else {
								Console.WriteLine("Error: command on line #" + linenum.ToString() + " not recognized.");
							}
						}
					} else {
						Console.WriteLine("No currently open file");
					}
				} else if (basicsharpinput == "list") {
					if (fileopened == true) {
						string[] linesofcode = File.ReadAllLines(@"./" + openfile.ToUpper() + ".bsharp");
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
                        openfile = name;
                        fileopened = true;
                    }
				} else if (basicsharpinput == "clear") {
					Console.Clear();
				} else {
					Console.WriteLine("command '" + basicsharpinput + "' not recognized");
				}
			}
		}
	}
}
