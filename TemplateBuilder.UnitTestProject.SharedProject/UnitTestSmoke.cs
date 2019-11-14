using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Library;

namespace System.Text {
    [TestClass]
    public class UnitTestSmoke {
        [TestMethod]
        public void Smoke_Test_The_TemplateBuilder() {
            var nameValuePairs = this.CreateNameValuePairs(3);

            var templateContent = nameValuePairs.CreatePsuedoTestTemplate(30, 500);

            var templateBuilder
                = new StringBuilder(templateContent)
                    .ToTemplateBuilder();

            foreach (var nameValuePair in nameValuePairs)
                templateBuilder
                    .AddVariableName(nameValuePair.Name);

            var templatedDocument
                = templateBuilder
                    .ToTemplate()
                        .CreateTemplatedDocument();

            foreach (var nameValuePair in nameValuePairs)
                templatedDocument
                    .Replace(nameValuePair.Name, nameValuePair.Value);


            var document = templatedDocument.ToString();

            nameValuePairs.TestNameValuePairs(document);
        }
    }
}
