using StringCalculator.Model;
using System;
using System.Reflection.Metadata;

namespace StringCalculator.Persistance
{
    public class StringCalculatorHistoryHandler
    {
        private HistoryStorer storer;
        public StringCalculatorHistoryHandler(string path = "history.txt")
        {
            this.storer = new HistoryStorer(path);
        }

        public int HandleRequest(string id) {

            return StringCalculatorClass.add(id);
        }
    }
}
