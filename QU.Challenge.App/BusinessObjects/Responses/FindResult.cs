using System;
using System.Collections.Generic;
using System.Text;

namespace QU.Challenge.App.BusinessObjects
{
    public class FindResult_Response
    {
        private List<Word_Response> _Words;

        public List<Word_Response> Words
        {
            get { return _Words; }
            set { _Words = value; }
        }

    }
}
