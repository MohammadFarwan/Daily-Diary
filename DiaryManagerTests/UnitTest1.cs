//using Daily-Diary;

using Daily_Diary;

namespace DiaryManagerTests
{
    //public class UnitTest1
    public class DailyDiaryTests : IDisposable
    {
        private const string TestFilePath = "testData.txt";

        public DailyDiaryTests()
        {
            // Ensure a clean test environment
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [Fact]
        public void ReadDiaryFile_FileExists_ReturnsContent()
        {
            // Arrange
            string expectedContent = "2024-07-01\nTest entry\n\n";
            File.WriteAllText(TestFilePath, expectedContent);
            var dailyDiary = new DailyDiary(TestFilePath);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                dailyDiary.ReadDiaryFile();

                // Assert
                string result = sw.ToString().Trim();
                Assert.Equal(expectedContent.Trim(), result);
            }
        }

        [Fact]
        public void ReadDiaryFile_FileDoesNotExist_ReturnsFileNotFoundMessage()
        {
            // Arrange
            var dailyDiary = new DailyDiary(TestFilePath);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                dailyDiary.ReadDiaryFile();

                // Assert
                string result = sw.ToString().Trim();
                Assert.Equal("Diary file not found.", result);
            }
        }

        public void Dispose()
        {
            // Clean up test environment
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }
    }

    public class DiaryManagerTests : IDisposable
    {
        private const string TestFilePath = "testData.txt";

        public DiaryManagerTests()
        {
            // Ensure a clean test environment
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        public void Dispose()
        {
            // Clean up test environment
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }
    }
}