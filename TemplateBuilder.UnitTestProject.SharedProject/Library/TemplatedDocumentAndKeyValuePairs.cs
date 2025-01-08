using System.Collections.Generic;

namespace System.Text.TestLibrary {
    public class TemplatedDocumentAndKeyValuePairs {
        public KeyValuePair<string, string>[] KeyValuePairs = new KeyValuePair<string, string>[] { };
        public ITemplatedDocument TemplatedDocument = null;

        public TemplatedDocumentAndKeyValuePairs(KeyValuePair<string, string>[] keyValuePairs, ITemplatedDocument templatedDocument) {
            KeyValuePairs = keyValuePairs;
            TemplatedDocument = templatedDocument;
        }

        public TemplatedDocumentAndKeyValuePairs Clone() {
            return new TemplatedDocumentAndKeyValuePairs(KeyValuePairs, TemplatedDocument.Clone());
        }
    }
}
