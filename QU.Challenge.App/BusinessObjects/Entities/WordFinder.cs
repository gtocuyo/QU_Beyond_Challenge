using System;
using System.Collections.Generic;
using System.Text;

namespace QU.Challenge.App.BusinessObjects
{
    public partial class WordFinder_Entity
    {
        #region fields

        private IEnumerable<String> _WordsForSearch;
        private List<string> _AllWordsInMatrix;
        private char[,] _Matrix;

        #endregion

        #region Properties 

        public IEnumerable<String> WordsForSearch
        {
            get { return _WordsForSearch; }
            set { _WordsForSearch = value; }
        }

        public List<string> AllWordsInMatrix
        {
            get { return _AllWordsInMatrix; }
            set { _AllWordsInMatrix = value; }
        }

        public char[,] Matrix
        {
            get { return _Matrix; }
            set { _Matrix = value; }
        }

        #endregion

    }
}
