using System;
using System.IO;

namespace AdventOfCode {

    public class Day5 {

        public static void Day5Function(int part) {
            string[] lines = File.ReadAllLines("Input Files/inputday5.txt");
            bool[] seats = new bool[8 * 128];

            int highestID = 0;

            for (int i = 0; i < lines.Length; i++) {
                int rowMin = 0, rowMax = 127, columnMin = 0, columnMax = 7;
                string boardingPass = lines[i];

                for (int j = 0; j < 10; j++) {
                    char currentChar = boardingPass[j];
                    switch (currentChar) {
                        case 'F':
                            rowMax = rowMin + (rowMax - rowMin + 1) / 2 - 1;
                            break;
                        case 'B':
                            rowMin += (rowMax - rowMin + 1) / 2;
                            break;
                        case 'L':
                            columnMax = columnMin + (columnMax - columnMin + 1) / 2 - 1;
                            break;
                        case 'R':
                            columnMin += (columnMax - columnMin + 1) / 2;
                            break;
                    }
                }

                int row = rowMin, column = columnMin;
                int id = row * 8 + column;
                seats[id] = true;
                if (id > highestID) highestID = id;
            }

            if (part == 1) {
                Console.WriteLine("Highest id: " + highestID);
            } else {
                for (int i = 0; i < 8 * 128; i++) {
                    if (i > 0 && i < 8 * 128 - 1) {
                        if (seats[i] == false && seats[i - 1] == true && seats[i + 1] == true) {
                            Console.WriteLine("Our seat ID: " + i);
                            return;
                        }
                    }
                }
            }
        }

    }
}
