using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.TestLibrary;

namespace System.Text {

    [TestClass]
    public class TemplateBuilderTest {
        [TestMethod]
        public void Merge_A_Test_Template_With_Test_KeyValuePairs_Into_0000001_A_Test_Document_In_Order_To_Warmup_UnitTest() {
            foreach (var index in Enumerable.Range(1, 1))
                PreBuiltTestTemplates.TemplatedDocumentAndNameValuePairs.TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_KeyValuePairs_Into_0000001_Test_Document() {
            foreach (var index in Enumerable.Range(1, 1))
                PreBuiltTestTemplates.TemplatedDocumentAndNameValuePairs.TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(0);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_KeyValuePairs_Into_0000010_Test_Document() {
            foreach (var index in Enumerable.Range(1, 10))
                PreBuiltTestTemplates.TemplatedDocumentAndNameValuePairs.TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_KeyValuePairs_Into_0000100_Test_Document() {
            foreach (var index in Enumerable.Range(1, 100))
                PreBuiltTestTemplates.TemplatedDocumentAndNameValuePairs.TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_KeyValuePairs_Into_0001000_Test_Document() {
            foreach (var index in Enumerable.Range(1, 1000))
                PreBuiltTestTemplates.TemplatedDocumentAndNameValuePairs.TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_KeyValuePairs_Into_0010000_Test_Document() {
            foreach (var index in Enumerable.Range(1, 10000))
                PreBuiltTestTemplates.TemplatedDocumentAndNameValuePairs.TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }
    }
}
