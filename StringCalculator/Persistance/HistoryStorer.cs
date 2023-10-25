using System.IO;
using System;

namespace StringCalculator.Persistance
{
    public class HistoryStorer : Save
    {
        private string histaryAddres;

        public HistoryStorer(string histaryAddres)
        {
            this.histaryAddres = histaryAddres;
        }

        public void StoreData(string data) {

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

    }

    public interface Save
    {
        public void StoreData(string request);

    }
}
