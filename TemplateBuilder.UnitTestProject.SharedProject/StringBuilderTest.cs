using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.TestLibrary;

namespace System.Text {

    [TestClass]
    public class StringBuilderTest {
        private static TemplatedDocumentAndNameValuePairs TemplatedDocumentAndNameValuePairs 
            = UnitTestRoutines
                .CreatTemplatedDocumentAndNameValuePairs(testVariableCount: 50, fromToRange: new FromToRange() { from = 50, to = 100 });

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_0000001_A_Test_Document_In_Order_To_Warmup_UnitTest() {
            foreach (var index in Enumerable.Range(1, 1))
                TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_0000001_Test_Document() {
            TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(0);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_0000010_Test_Document() {
            foreach (var index in Enumerable.Range(1, 10))
                TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_0000100_Test_Document() {
            foreach (var index in Enumerable.Range(1, 100))
                TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_0001000_Test_Document() {
            foreach (var index in Enumerable.Range(1, 1000))
                TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_0010000_Test_Document() {
            foreach (var index in Enumerable.Range(1, 10000))
                TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_0100000_Test_Document() {
            foreach (var index in Enumerable.Range(1, 100000))
                TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_1000000_Test_Document() {
            foreach (var index in Enumerable.Range(1, 1000000))
                TemplatedDocumentAndNameValuePairs.MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(index);
        }
    }
}
