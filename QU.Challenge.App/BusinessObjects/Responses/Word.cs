using System;
using System.Collections.Generic;
using System.Text;

namespace QU.Challenge.App.BusinessObjects
{
    public class Word_Response
    {
        private string _Value;
        private int _Count;

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public int Count {
            get { return _Count; }
            set { _Count = value; }
        }

    }
}
