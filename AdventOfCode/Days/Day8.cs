using System;
using System.IO;

namespace AdventOfCode.Days {

    public class Day8 {

        public static void Day8Part1() {
            string[] lines = File.ReadAllLines("Input Files/inputday8.txt");
            bool[] passed = new bool[lines.Length];
            int accumulator = 0;
            int pc = 0;

            while(pc < lines.Length) {
                passed[pc] = true;
                string[] instructionParts = lines[pc].Split(" ");
                string instruction = instructionParts[0];
                string numberString = instructionParts[1];
                char sign = numberString[0];
                int number = int.Parse(numberString.Substring(1)) * (sign == '+' ? 1 : -1);
                switch (instruction) {
                    case "acc":
                    accumulator += number;
                    pc++;
                    break;
                    case "jmp":
                    pc += number;
                    if (passed[pc]) {
                        Console.WriteLine(accumulator);
                        return;
                    }
                    break;
                    case "nop":
                    pc++;
                    break;

                }
            }


        }

        //Improved version:
        public static void Day8Part2() {
            string[] lines = File.ReadAllLines("Input Files/inputday8.txt");
            bool[] passed = new bool[lines.Length];
            int accumulator = 0;
            int pc = 0;

            for (int i = 0; i < lines.Length; i++) {
                accumulator = 0;
                pc = 0;
                passed = new bool[lines.Length];
                string oldLine = lines[i];

                if (lines[i].Contains("nop")) lines[i] = lines[i].Replace("nop", "jmp");
                else if (lines[i].Contains("jmp")) lines[i] = lines[i].Replace("jmp", "nop");
                else continue;

                bool checkNext = false;

                while (pc < lines.Length) {
                    if (pc < lines.Length && passed[pc]) {
                        checkNext = true;
                        break;
                    }
                    passed[pc] = true;
                    string[] instructionParts = lines[pc].Split(" ");
                    string instruction = instructionParts[0];
                    int number = int.Parse(instructionParts[1]);

                    switch (instruction) {
                        case "acc":
                        accumulator += number;
                        pc++;
                        break;
                        case "jmp":
                        pc += number;
                        break;
                        case "nop":
                        pc++;
                        break;

                    }
                }

                if (!checkNext) {
                    Console.WriteLine("Changed instruction index: " + i);
                    break;
                }

                lines[i] = oldLine;
            }

            Console.WriteLine(accumulator);
        }

        /*
        Original version:
        public static void Day8Part2() {
            string[] lines = File.ReadAllLines("Input Files/inputday8.txt");
            bool[] passed = new bool[lines.Length];
            int accumulator = 0;
            int pc = 0;

            for (int i = 0; i < lines.Length; i++) {
                accumulator = 0;
                pc = 0;
                passed = new bool[lines.Length];
                if (lines[i].Contains("acc")) continue;
                bool checkNext = false;

                while (pc < lines.Length) {
                    passed[pc] = true;
                    string[] instructionParts = lines[pc].Split(" ");
                    string instruction = instructionParts[0];
                    string numberString = instructionParts[1];
                    char sign = numberString[0];
                    int number = int.Parse(numberString.Substring(1)) * (sign == '+' ? 1 : -1);

                    switch (instruction) {
                        case "acc":
                        accumulator += number;
                        pc++;
                        break;
                        case "jmp":
                        if (pc == i) {
                            pc++;
                        } else {
                            pc += number;
                            if (pc < lines.Length && passed[pc]) {
                                checkNext = true;
                            }
                        }
                        break;
                        case "nop":
                        if (pc != i) {
                            pc++;
                        } else {
                            pc += number;
                            if (pc < lines.Length && passed[pc]) {
                                checkNext = true;
                            }
                        }
                        break;

                    }

                    if (checkNext) break;
                }

                if (!checkNext) {
                    Console.WriteLine("Changed instruction index: " + i);
                    break;
                }
            }

            Console.WriteLine(accumulator);
        }
        */

    }
}
