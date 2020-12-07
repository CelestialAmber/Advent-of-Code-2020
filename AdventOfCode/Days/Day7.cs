using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace AdventOfCode.Days {

    public class Day7 {


        public static void Day7Part1() {
            string[] rules = File.ReadAllLines("Input Files/inputday7.txt");
            int bags = 0;
            List<string> bagsChecked = new List<string>();
            string[] bagsToFind = new string[]{"shiny gold bag"};

            while (bagsToFind.Length != 0) {
                List<string> newBagsToFind = new List<string>();

                for (int i = 0; i < rules.Length; i++) {
                    string bagName = rules[i].Substring(0, rules[i].IndexOf("contain") - 2); //Make all bag names singular so no bags get missed
                    string bagsContainedString = rules[i].Substring(rules[i].IndexOf("contain"));

                    foreach (string bag in bagsToFind) {
                        if (bagsContainedString.Contains(bag)) {
                            if (!bagsChecked.Contains(bagName)) {
                                newBagsToFind.Add(bagName);
                                bagsChecked.Add(bagName);
                                bags++;
                            }
                            break;
                        }
                    }
                }

                bagsToFind = newBagsToFind.ToArray();
            }

            Console.WriteLine(bags);
        }

        public static List<string> rules;

        public static void Day7Part2() {
            rules = File.ReadAllLines("Input Files/inputday7.txt").ToList();
            int startIndex = rules.FindIndex(x => x.StartsWith("shiny gold bags"));

            Console.WriteLine(FindBagsInsideStart(startIndex));
        }

        public static int FindBagsInsideStart(int startIndex) {
            string bagRule = rules[startIndex];
            string bagsContainedString = bagRule.Substring(bagRule.IndexOf("contain") + 8).Replace(".", "").Replace("bags", "bag"); //Make all bag names singular so no bags get missed
            string[] bagsInside = bagsContainedString.Split(", ");
            return FindBagsInsideRecursive(bagsInside);
        }


        public static int FindBagsInsideRecursive(string[] bags){
            int total = 0;

            foreach(string bag in bags) {
                int amount = int.Parse(bag.Substring(0, bag.IndexOf(" ") + 1));
                string name = bag.Substring(bag.IndexOf(" ") + 1);
                int bagIndex = rules.FindIndex(x => x.StartsWith(name));
                string bagRule = rules[bagIndex];
                bagRule = bagRule.Substring(bagRule.IndexOf("contain") + 8);
                total += amount;

                if (bagRule != "no other bags.") {
                    string bagsContainedString = bagRule.Replace(".", "").Replace("bags", "bag"); //Make all bag names singular so no bags get missed
                    string[] bagsInside = bagsContainedString.Split(", ");
                    total += amount * FindBagsInsideRecursive(bagsInside);
                }
            }

            return total;
        }

    }
}