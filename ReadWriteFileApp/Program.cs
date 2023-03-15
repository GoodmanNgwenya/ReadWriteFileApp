using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace ReadWriteFileApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nameAndSurname = new List<string>();

            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] lines = File.ReadAllLines(filePath + "/Data.csv");

            string[] firstname = new string[lines.Length - 3];
            string[] lastname = new string[lines.Length - 3];
            string[] address = new string[lines.Length - 3];
            string[] phone = new string[lines.Length - 3];

            for (int i = 1; i < lines.Length - 2; i++)
            {
                string[] lineArray = lines[i].Split(',');
                firstname[i - 1] = lineArray[0];
                lastname[i - 1] = lineArray[1];
                address[i - 1] = lineArray[2];
                phone[i - 1] = lineArray[3];
            }

            //show the frequency of the first and last names ordered by frequency descending and then alphabetically  ascending
            FrequencyOfFirstAndLastname(firstname, filePath);

            //For the list of names:
            nameAndSurname = NameAndSurnameList(lines, firstname, lastname);

            //The second should show the addresses sorted alphabetically by street name.
            SortAddressAlphabetically(address, nameAndSurname);

        }

        public static void FrequencyOfFirstAndLastname(string[] firstname,string filePath)
        {
            var FrequencyFirstLastnameList = new List<string>();
            var dict = new Dictionary<string, int>();

            foreach (var value in firstname)
            {
                if (dict.ContainsKey(value)) dict[value]++;
                else dict[value] = 1;
            }
            var ordered = dict.OrderBy(x => x.Key).ThenByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var pair in ordered)
                FrequencyFirstLastnameList.Add(pair.Key + "," + pair.Value);

            var fileName = "firstFile.txt";
            var fullPath = filePath + "/" + fileName;

            //Write to text file
            File.WriteAllLines(fullPath, FrequencyFirstLastnameList);
        }

        public static List<string> NameAndSurnameList(string[] readline, string[] firstname, string[] lastname)
        {
            var nameAndSurnameList = new List<string>();

            for (int i = 0; i < readline.Length - 3; i++)
            {
                nameAndSurnameList.Add(firstname[i] + " " + lastname[i]);
            }
            return nameAndSurnameList;
             
        }
        public static void SortAddressAlphabetically(string[] address, List<string> nameAndSurnameList)
        {
            var dict = new Dictionary<string, int>();
            var addressSortedList = new List<string>();

            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            
            foreach (var value in address)
            {
                if (dict.ContainsKey(value)) dict[value]++;
                else dict[value] = 1;
            }

            var ordered = dict.OrderBy(x => x.Key.Substring(x.Key.IndexOf(' '))).ToDictionary(x => x.Key);

            foreach (var pair in ordered)
                addressSortedList.Add(pair.Key);

            addressSortedList.Add("");
            addressSortedList.AddRange(nameAndSurnameList);

            var fileName = "secondFile.txt";
            var fullPath = filePath + "/" + fileName;
            File.WriteAllLines(fullPath, addressSortedList);
        }
    }
}
