using StringCalculator.Model;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace StringCalculator.Persistance
{
    public class StringCalculatorHistoryHandler
    {
        private Save storer;
        public DateTime lastRequestMade { get; set; }
        public StringCalculatorHistoryHandler(Save storer)
        {
            this.storer = storer;
        }

        public int HandleRequest(string id) {
            var result = StringCalculatorClass.add(id);
            var request = ConvertDataToRequest(id, result.ToString());

            SaveToFile(request);

            return result;
        }

        public void SaveToFile(string request)
        {
            storer.StoreData(request);
        }

        private string ConvertDataToRequest(string id, string result){
            lastRequestMade = DateTime.Now;
            return lastRequestMade + " " + id + " " + result + "\n";
        }
    }
}
