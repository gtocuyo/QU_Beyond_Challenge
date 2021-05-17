using QU.Challenge.App.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace QU.Challenge.App.Presentation
{
    public interface ILayoutService
    {
        public int PrintFirstBlock();
        public List<string> PrintSecondBlock(int wordLength);
        public List<string> PrintThirdBlock();
        public void PrintMatrix(char[,] matrix);
        public void PrintWordsForSearch(IEnumerable<string> words);
        public void PrintFindings(FindResult_Response result);
        public void PrintExceptionMsg(string msg);

    }
}
