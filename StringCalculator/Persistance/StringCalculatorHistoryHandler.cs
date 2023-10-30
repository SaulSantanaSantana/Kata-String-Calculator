using StringCalculator.Model;
using System;

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

            storer.StoreData(id, result.ToString());

            return result;
        }

    }
}
