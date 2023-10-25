using StringCalculator.Model;
using System;
using System.Reflection.Metadata;

namespace StringCalculator.Persistance
{
    public class StringCalculatorHistoryHandler : Save
    {
        private HistoryStorer storer;
        public StringCalculatorHistoryHandler(string path = "history.txt")
        {
            this.storer = new HistoryStorer(path);
        }

        public int HandleRequest(string id) {

            return StringCalculatorClass.add(id);
        }

        void Save.SaveToFile(string request)
        {
            throw new NotImplementedException();
        }
    }

    public interface Save
    {

        public void SaveToFile(string request);

    }
}
