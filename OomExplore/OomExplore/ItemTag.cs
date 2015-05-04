using System;
using System.Collections.Generic;
using System.Text;

namespace OomExplore
{
    public class ItemTag
    {
        private string _StoreID = string.Empty;
        private string _EntryID = string.Empty;
        private string _MessageClass = string.Empty;

        public ItemTag(string StoreID, string EntryID, string MessageClass)
        {
            _StoreID = StoreID;
            _EntryID = EntryID;
            _MessageClass = MessageClass;
        }

        public string StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }
        public string EntryID
        {
            get { return _EntryID; }
            set { _EntryID = value; }
        }
        public string DefaultMessageClass
        {
            get { return _MessageClass; }
            set { _MessageClass = value; }
        }
    }
}
