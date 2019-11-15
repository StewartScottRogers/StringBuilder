using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Library;

namespace System.Text {
    [TestClass]
    public class UnitTestSmoke {
        [TestMethod]
        public void Smoke_Test_The_TemplateBuilder() {
            var templatedDocumentAndNameValuePairs = NameValuePairExtentions.CreatTemplatedDocumentAndNameValuePairs(3, 30, 500);

            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                templatedDocumentAndNameValuePairs.TemplatedDocument
                    .Replace(nameValuePair.Name, nameValuePair.Value);

            NameValuePairExtentions.TestTemplatedDocumentAndNameValuePairs(templatedDocumentAndNameValuePairs.NameValuePairs, templatedDocumentAndNameValuePairs.TemplatedDocument.ToString());
        }
    }
}
