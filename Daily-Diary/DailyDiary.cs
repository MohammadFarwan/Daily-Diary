using Daily_Diary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public class DailyDiary
    {
        private readonly string _filePath;

        public DailyDiary(string filePath)
        {
            _filePath = filePath;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Daily Diary Manager");
                Console.WriteLine("1. Read diary");
                Console.WriteLine("2. Add entry");
                Console.WriteLine("3. Delete entry");
                Console.WriteLine("4. Count entries");
                Console.WriteLine("5. Read entries by date");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ReadDiaryFile();
                        break;
                    case "2":
                        AddEntry();
                        break;
                    case "3":
                        DeleteEntry();
                        break;
                    case "4":
                        CountEntries();
                        break;
                    case "5":
                        ReadEntriesByDate();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public void ReadDiaryFile()
        {
            if (File.Exists(_filePath))
            {
                string content = File.ReadAllText(_filePath);
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
        }

        public void AddEntry()
        {
            Console.Write("Enter the date (YYYY-MM-DD): ");
            string date = Console.ReadLine();
            Console.Write("Enter the content: ");
            string content = Console.ReadLine();

            string entry = $"{date}\n{content}\n\n";

            File.AppendAllText(_filePath, entry);
            Console.WriteLine("Entry added.");
        }

        public void DeleteEntry()
        {
            Console.Write("Enter the date (YYYY-MM-DD) of the entry to delete: ");
            string date = Console.ReadLine();

            if (File.Exists(_filePath))
            {
                List<string> lines = File.ReadAllLines(_filePath).ToList();
                bool entryFound = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i] == date)
                    {
                        entryFound = true;
                        lines.RemoveAt(i);
                        if (i < lines.Count && !string.IsNullOrWhiteSpace(lines[i]))
                        {
                            lines.RemoveAt(i);
                        }
                        break;
                    }
                }

                if (entryFound)
                {
                    File.WriteAllLines(_filePath, lines);
                    Console.WriteLine("Entry deleted.");
                }
                else
                {
                    Console.WriteLine("Entry not found.");
                }
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
        }

        public void CountEntries()
        {
            if (File.Exists(_filePath))
            {
                int lineCount = File.ReadAllLines(_filePath).Length;
                Console.WriteLine($"Total number of lines: {lineCount / 3}");
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
        }

        public void ReadEntriesByDate()
        {
            Console.Write("Enter the date (YYYY-MM-DD) to retrieve data: ");
            string date = Console.ReadLine();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                bool entryFound = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == date)
                    {
                        entryFound = true;
                        Console.WriteLine(lines[i]);
                        if (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
                        {
                            Console.WriteLine(lines[i + 1]);
                        }
                    }
                }

                if (!entryFound)
                {
                    Console.WriteLine("No entries found for the given date.");
                }
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
        }
    }
}