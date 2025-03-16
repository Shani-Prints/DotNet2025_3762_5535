using System.IO;
namespace Tools
{

    public static class LogManager
    {
        private static readonly string logDirectory = "Log";

        // פונקציה לקבלת ניתוב התיקיה הנוכחית
        public static string GetDirectoryPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logDirectory);
        }
        public static string GetCurrentDirectoryPath()
        {
            string fileName = $"{DateTime.Now:yyyy-MM}.log";
            return Path.Combine(GetDirectoryPath(), fileName);
        }


        // פונקציה לקבלת ניתוב הקובץ הנוכחי
        public static string GetCurrentFilePath()
        {
            string fileName = $"{DateTime.Now:yyyy-MM-dd}.log";
            return Path.Combine(GetCurrentDirectoryPath(), fileName);
        }


        public static void WriteLog(string project, string funcName, string message)
        {
            //קביעת הנתיב לתקיית הלוגים
            string logDirectoryPath = GetCurrentDirectoryPath();

            //קביעת הנתיב לוג
            string logFilePath = GetCurrentFilePath();

            // יצירת התיקייה אם היא לא קיימת
            if (!Directory.Exists(logDirectoryPath))
                Directory.CreateDirectory(logDirectoryPath);

            // יצירת הקובץ אם הוא לא קיימת
            if (!File.Exists(logFilePath))
                File.Create(logFilePath);

            // יצירת התוכן שיכתב ללוג
            string logEntry = $"{DateTime.Now}\t{project}.{funcName}:\t{message}";

            //הוספת התוכן לקובץ
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);

        }
        public static void CleanOldDirectories()
        {
            var directories = Directory.GetDirectories(GetDirectoryPath());
            foreach (var d in directories)
               if (Directory.GetCreationTime(d) < DateTime.Now.AddMonths(-2))
                    Directory.Delete(d, true);

        }

    }
}