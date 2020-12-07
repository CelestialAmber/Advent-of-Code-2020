using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {

    public class Day1 {


        public static void Day1Part1() {
            string[] lines = File.ReadAllLines("Input Files/inputday1.txt");
            int[] numbers = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++) {
                numbers[i] = int.Parse(lines[i]);
            }

            for (int i = 0; i < numbers.Length; i++) {
                int a = numbers[i];
                int b = 2020 - a;
                if (numbers.Contains(b)) {
                    Console.WriteLine("The numbers are " + a + " and " + b + ", result: " + a * b);
                    return;
                }
            }
        }

        public static void Day1Part2() {
            string[] lines = File.ReadAllLines("Input Files/inputday1.txt");
            int[] numbers = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++) {
                numbers[i] = int.Parse(lines[i]);
            }

            for (int i = 0; i < numbers.Length; i++) {
                int a = numbers[i];
                int b = 2020 - a;
                int c = 0;
                bool foundThirdNumber = false;

                for (int j = 0; j < numbers.Length; j++) {
                    c = b - numbers[j];

                    if (numbers.Contains(c)) {
                        b = numbers[j];
                        foundThirdNumber = true;
                        break;
                    }
                }

                if (foundThirdNumber) {
                    Console.WriteLine("The numbers are " + a + ", " + b + ", and " + c + ", result: " + a * b * c);
                    return;
                }
            }
        }

    }
}
