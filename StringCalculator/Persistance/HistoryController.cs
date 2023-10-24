using System.IO;
using System;

namespace StringCalculator.Persistance
{
    public static class HistoryController
    {
        private static string histaryAddres = "history.txt";
        public static void StoreDataInHistory(string data) {

            try
            {
                using (StreamWriter writer = new StreamWriter(histaryAddres, true))
                {
                    writer.Write(data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("history update failed:" + ex.Message);
            }

        }

        public static string GetLastEntry() {
            string targetLine = null;
            try
            {
                using (StreamReader reader = new StreamReader(histaryAddres))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        targetLine = line;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("history read failed:" + ex.Message);
            }

            return targetLine;
        }

        public static string gethistaryAddres() { return histaryAddres; }

    }
}
