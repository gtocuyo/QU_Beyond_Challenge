using QU.Challenge.App.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace QU.Challenge.App.BusinessActions
{
    public interface IWordFinder
    {
        public WordFinder_Entity BuildFinder(IEnumerable<String> words);

        public FindResult_Response Find(WordFinder_Entity wf);
    }

}
