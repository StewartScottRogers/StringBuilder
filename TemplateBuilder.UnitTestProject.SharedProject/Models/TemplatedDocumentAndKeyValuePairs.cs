using System.Collections.Generic;

namespace System.Text.TestLibrary {
    public class TemplatedDocumentAndKeyValuePairs {

        public KeyValuePair<string, string>[] KeyValuePairs = new KeyValuePair<string, string>[] { };

        public string Document { get; private set; } = "";

        public TemplatedDocumentAndKeyValuePairs(KeyValuePair<string, string>[] keyValuePairs, string document) {
            KeyValuePairs = keyValuePairs;
            Document = document;
        }

        public TemplatedDocumentAndKeyValuePairs Clone() {
            return new TemplatedDocumentAndKeyValuePairs(KeyValuePairs, Document);
        }
    }
}
