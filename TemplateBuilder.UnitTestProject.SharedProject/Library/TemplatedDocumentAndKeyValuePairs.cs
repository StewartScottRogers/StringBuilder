using System.Collections.Generic;

namespace System.Text.TestLibrary {
    public class TemplatedDocumentAndKeyValuePairs {
        public KeyValuePair<string, string>[] KeyValuePairs = new KeyValuePair<string, string>[] { };
        public ITemplatedDocument TemplatedDocument = null;

        public TemplatedDocumentAndKeyValuePairs Clone() {
            KeyValuePair<string, string>[] keyValuePairs = new KeyValuePair<string, string>[KeyValuePairs.Length];
            KeyValuePairs.CopyTo(keyValuePairs, 0);


            return new TemplatedDocumentAndKeyValuePairs() {
                KeyValuePairs = keyValuePairs,
                TemplatedDocument = TemplatedDocument.Clone()
            };
        }
    }
}
