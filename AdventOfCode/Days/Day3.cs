using System;
using System.IO;

namespace AdventOfCode {

    public class Day3 {

        public static void Day3Part1() {
            string[] lines = File.ReadAllLines("Input Files/inputday3.txt");
            int trees = CheckSlopeTrees(lines, 3, 1);
            Console.WriteLine("Total trees encountered: " + trees);
        }

        public static void Day3Part2() {
            string[] lines = File.ReadAllLines("Input Files/inputday3.txt");
            long[] values = new long[5];
            values[0] = CheckSlopeTrees(lines, 1, 1);
            values[1] = CheckSlopeTrees(lines, 3, 1);
            values[2] = CheckSlopeTrees(lines, 5, 1);
            values[3] = CheckSlopeTrees(lines, 7, 1);
            values[4] = CheckSlopeTrees(lines, 1, 2);

            Console.WriteLine(values[0] * values[1] * values[2] * values[3] * values[4]);
        }

        public static int CheckSlopeTrees(string[] rows, int slopeX, int slopeY) {
            int x = 0, y = 0;
            int trees = 0;
            int height = rows.Length;
            int width = rows[0].Length;

            while (y < height - 1) {
                x += slopeX;
                y += slopeY;
                if (rows[y][x % width] == '#') trees++;
            }

            return trees;
        }

    }
}
