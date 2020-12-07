using System;
using System.IO;


namespace AdventOfCode.Days {

    public class Day6 {


        public static void Day6Part1() {
            string text = File.ReadAllText("Input Files/inputday6.txt");
            string[] groups = text.Split("\n\n");
            int totalCount = 0;

            for(int i = 0; i < groups.Length; i++) {
                groups[i] = groups[i].Replace("\n", "");

                string groupAnswers = groups[i];
                bool[] answered = new bool[26];
                int totalAnswered = 0;

                for(int j = 0; j < groupAnswers.Length; j++) {
                    int index = (int)groupAnswers[j] - 97;
                    if (!answered[index]) {
                        answered[index] = true;
                        totalAnswered++;
                    }

                }

                totalCount += totalAnswered;
            }

            Console.WriteLine("Total count: " + totalCount);
        }

        public static void Day6Part2() {
            string text = File.ReadAllText("Input Files/inputday6.txt");
            string[] groups = text.Split("\n\n");
            int totalCount = 0;

            for (int i = 0; i < groups.Length; i++) {
                string[] groupAnswers = groups[i].Split("\n");

                bool[] groupAnswered = new bool[26];
                for (int j = 0; j < 26; j++) groupAnswered[j] = true;

                for (int j = 0; j < groupAnswers.Length; j++) {
                    string answers = groupAnswers[j];
                    bool[] personAnswered = new bool[26];

                    if (answers == "") continue;

                    for (int k = 0; k < answers.Length; k++) {
                        int index = (int)answers[k] - 97;
                        if (!personAnswered[index]) {
                            personAnswered[index] = true;
                        }
                    }

                    for(int k = 0; k < 26; k++) {
                        if(!personAnswered[k] && groupAnswered[k]) {
                            groupAnswered[k] = false;
                        }
                    }

                }

                for (int j = 0; j < 26; j++) if (groupAnswered[j]) totalCount++;
            }

            Console.WriteLine("Total count: " + totalCount);
        }

    }

}