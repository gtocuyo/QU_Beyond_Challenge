using QU.Challenge.App.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QU.Challenge.App
{
    public class CommonUtils
    {
        /// <summary>
        /// Checks if every string in param list has the length
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool CheckLength(List<String> list)
        {
            bool resp = false;

            resp = list.All(x => x.Length == list.First().Length);

            return resp;
        }

        public static bool CheckQty(List<String> list)
        {
            return list.Count == list[0].Length;
        }

        /// <summary>
        /// This method is for extracting the vertical words from de matrix.
        /// </summary>
        /// <param name="wf"></param>
        public static void RotateMatrix(WordFinder_Entity wf)
        {
            var sb = new StringBuilder(string.Empty);
            var maxI = wf.Matrix.GetLength(0);
            var maxJ = wf.Matrix.GetLength(1);
            for (var i = 0; i < maxI; i++)
            {
                for (var j = 0; j < maxJ; j++)
                {
                    sb.Append($"{wf.Matrix[j, i]}");
                }
                wf.AllWordsInMatrix.Add(sb.ToString());
                sb = new StringBuilder(string.Empty);
            }
        }
    }
}
