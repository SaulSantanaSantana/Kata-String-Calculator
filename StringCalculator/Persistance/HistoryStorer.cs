using System.IO;
using System;

namespace StringCalculator.Persistance
{
    public class HistoryStorer : Save
    {
        private string histaryAddres;
        private TimePicker timePicker;

        public HistoryStorer(string histaryAddres, TimePicker timePicker)
        {
            this.histaryAddres = histaryAddres;
            this.timePicker = timePicker;
        }

        public void StoreData(string id, string result) {

            var request = ConvertDataToRequest(id, result);
            SaveToFile(request);
        }
        public void SaveToFile(string data)
        {
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

        private string ConvertDataToRequest(string id, string result)
        {
            return timePicker.GetDate() + " " + id + " " + result + "\n";
        }

    }
}
