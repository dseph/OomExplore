using System;
using System.Collections.Generic;
using System.Text;

namespace OomExplore
{
    public class FolderTag
    {
        private string _StoreID = string.Empty;
        private string _EntryID = string.Empty;
        private string _DefaultMessageClass = string.Empty;

        public FolderTag(string StoreID, string EntryID, string DefaultMessageClass) 
        {
            _StoreID = StoreID;
            _EntryID = EntryID;
            _DefaultMessageClass = DefaultMessageClass;
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
            get { return _DefaultMessageClass; }
            set { _DefaultMessageClass = value; }
        }
    }
}
