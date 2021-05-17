using Newtonsoft.Json;
using QU.Challenge.App.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QU.Challenge.App.BusinessActions
{
    public class WordFinder : IWordFinder
    {

        private char[,] _Matrix;

        private int topN = 10;

        public char[,] Matrix
        {
            get { return _Matrix; }
            set { _Matrix = value; }
        }

        public WordFinder_Entity BuildFinder(IEnumerable<String> words)
        {
            WordFinder_Entity wFinder = new WordFinder_Entity();

            List<string> list = words.ToList();

            if (list.Count > 0)
            {
                _Matrix = new char[list.Count, list.Count];

                bool checkList = CommonUtils.CheckLength(list);

                bool checkQty = CommonUtils.CheckQty(list);

                if (!checkQty)
                {
                    throw new Exception("Couldn't build a square matrix, the words qty must be the same of each word length!");
                }
                else
                {
                    if (checkList)
                    {

                        for (int i = 0; i < list.Count; i++)
                        {
                            char[] tempAtrr = list[i].ToCharArray();

                            for (int j = 0; j < tempAtrr.Length; j++)
                            {
                                _Matrix[i, j] = tempAtrr[j];
                            }
                        }
                    }
                    else
                        throw new Exception("All the words must have the same lenght!");
                }
            }
            else
            {
                throw new Exception("The words input param is empty!");
            }

            wFinder.Matrix = _Matrix;
            wFinder.AllWordsInMatrix = words.ToList();
            return wFinder;
        }

        /// <summary>
        /// Performs the search of the words in the stream all over the matrix and returns a list of the TOP N most repeated findings. 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public FindResult_Response Find(WordFinder_Entity wf)
        {
            FindResult_Response results = new FindResult_Response();
            results.Words = new List<Word_Response>();

            string[] wordsFromMatrix;

            //Because repeated words from stream should be searched and counted as one:
            List<string> filteredWordStream = wf.WordsForSearch.Distinct().ToList();

            CommonUtils.RotateMatrix(wf);
            
            for(int i = 0; i < filteredWordStream.Count; i++)
            {
                Word_Response wordToFind = new Word_Response();
                wordToFind.Value = filteredWordStream[i];

                wordToFind.Count = wf.AllWordsInMatrix.Where(x => x.Contains(wordToFind.Value)).Count();

                if(wordToFind.Count > 0)
                    results.Words.Add(wordToFind);

            }

            results.Words = results.Words.OrderByDescending(x => x.Count).Take(topN).ToList();

            return results;
        }

    }
}
