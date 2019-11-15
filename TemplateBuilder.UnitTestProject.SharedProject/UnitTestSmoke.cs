using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Library;

namespace System.Text {

    [TestClass]
    public class UnitTestSmoke {
        [TestMethod]
        public void Smoke_Test_The_TemplateBuilder() {
            var templatedDocumentAndNameValuePairs = NameValuePairExtentions.CreatTemplatedDocumentAndNameValuePairs(requestedVariableCount: 3, fromFragmentlength: 30, toFragmentlength: 500);
            MergeTemplate(templatedDocumentAndNameValuePairs.NameValuePairs, templatedDocumentAndNameValuePairs.TemplatedDocument);
        }

        #region Private Methods
        private static void MergeTemplate(NameValuePair[] nameValuePairs, ITemplatedDocument templatedDocument) {
            foreach (var nameValuePair in nameValuePairs)
                templatedDocument
                    .Replace(nameValuePair.Name, nameValuePair.Value);

            NameValuePairExtentions.TestTemplatedDocumentAndNameValuePairs(nameValuePairs, templatedDocument.ToString());
        }
        #endregion
    }
}
