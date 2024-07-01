using System.Globalization;

namespace Daily_Diary
{
    class Program
    {
        static void Main(string[] args)
        {
            DailyDiary diary = new DailyDiary("data.txt");
            diary.Run();
        }
    }
}