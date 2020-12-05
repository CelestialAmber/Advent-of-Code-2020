using System;
using System.IO;
using System.Linq;

namespace AdventOfCode {

    public class Day4 {


        public static void Day4Part1() {
            string text = File.ReadAllText("Input Files/inputday4.txt");
            string[] passportsText = text.Split("\n\n");
            int validPassports = 0;

            foreach (string passport in passportsText) {
                if (passport.Contains("ecl") && passport.Contains("pid") && passport.Contains("eyr") && passport.Contains("hcl") && passport.Contains("byr") && passport.Contains("iyr") && passport.Contains("hgt")) {
                    validPassports++;
                }
            }

            Console.WriteLine(validPassports + " valid passports total");
        }

        public static void Day4Part2() {
            string text = File.ReadAllText("Input Files/inputday4.txt");
            string[] passportsText = text.Split("\n\n");
            string[] eyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            int validPassports = 0;

            foreach (string passport in passportsText) {
                string[] passportFields = passport.Replace("\n", " ").Split(" ");
                int validFields = 0;

                for (int i = 0; i < passportFields.Length; i++) {
                    string field = passportFields[i];

                    if (field.Contains("hgt") && (field.Contains("cm") || field.Contains("in"))) {
                        field = field.Substring(4);
                        int height = int.Parse(field.Substring(0, field.Length - 2));
                        if (field.EndsWith("cm") && height >= 150 && height <= 193) validFields++;
                        else if (field.EndsWith("in") && height >= 59 && height <= 76) validFields++;
                    } else if (field.Contains("byr")) {
                        int birthYear = int.Parse(field.Substring(4));
                        if (birthYear >= 1920 && birthYear <= 2002) validFields++;
                    } else if (field.Contains("iyr")) {
                        int issueYear = int.Parse(field.Substring(4));
                        if (issueYear >= 2010 && issueYear <= 2020) validFields++;
                    } else if (field.Contains("eyr")) {
                        int expirationYear = int.Parse(field.Substring(4));
                        if (expirationYear >= 2020 && expirationYear <= 2030) validFields++;
                    } else if (field.Contains("hcl")) {
                        field = field.Substring(4);
                        if (field.StartsWith("#")) {
                            field = field.Replace("#", "");
                            int value;
                            if (Int32.TryParse(field, System.Globalization.NumberStyles.HexNumber, null, out value)) validFields++;
                        }
                    } else if (field.Contains("ecl")) {
                        string eyeColor = field.Substring(4);
                        if (eyeColors.Contains(eyeColor)) validFields++;
                    } else if (field.Contains("pid")) {
                        string passportId = field.Substring(4);
                        int value;
                        if (int.TryParse(passportId, out value) && passportId.Length == 9) validFields++;
                    }
                }

                if (validFields == 7) {
                    validPassports++;
                }
            }

            Console.WriteLine(validPassports + " valid passports total");
        }

    }
}
