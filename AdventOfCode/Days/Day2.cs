using System;
using System.IO;

namespace AdventOfCode.Days {

    public class Day2 {


        public static void Day2Part1() {
            string[] lines = File.ReadAllLines("Input Files/inputday2.txt");

            int validPasswords = 0;

            foreach (string line in lines) {
                string[] parts = line.Split(": ");
                string conditionString = parts[0];
                string password = parts[1];
                int letterMin, letterMax;
                char letter = conditionString[conditionString.Length - 1];
                conditionString = conditionString.Substring(0, conditionString.Length - 2);
                string[] numStrings = conditionString.Split("-");
                letterMin = int.Parse(numStrings[0]);
                letterMax = int.Parse(numStrings[1]);
                int letterAmount = 0;
                bool isValid = false;

                for (int i = 0; i < password.Length; i++) {
                    if (password[i] == letter) letterAmount++;
                }

                if (letterAmount >= letterMin && letterAmount <= letterMax) isValid = true;

                if (isValid) {
                    Console.WriteLine("The password " + line + " is valid.");
                    validPasswords++;
                }
            }

            Console.WriteLine("Valid passwords: " + validPasswords);
        }

        public static void Day2Part2() {
            string[] lines = File.ReadAllLines("Input Files/inputday2.txt");

            int validPasswords = 0;

            foreach (string line in lines) {
                string[] parts = line.Split(": ");
                string conditionString = parts[0];
                string password = parts[1];
                int firstPos, secondPos;
                char letter = conditionString[conditionString.Length - 1];
                conditionString = conditionString.Substring(0, conditionString.Length - 2);
                string[] numStrings = conditionString.Split("-");
                firstPos = int.Parse(numStrings[0]);
                secondPos = int.Parse(numStrings[1]);
                int letterAmount = 0;
                bool isValid = false;

                for (int i = 0; i < password.Length; i++) {
                    if (password[i] == letter && (i == firstPos - 1 || i == secondPos - 1)) letterAmount++;
                }

                if (letterAmount == 1) isValid = true;

                if (isValid) {
                    Console.WriteLine("The password " + line + " is valid.");
                    validPasswords++;
                }
            }

            Console.WriteLine("Valid passwords: " + validPasswords);
        }

    }
}
