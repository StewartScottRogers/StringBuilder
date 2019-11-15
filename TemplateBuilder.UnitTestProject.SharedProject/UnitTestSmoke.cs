using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Library;

namespace System.Text {

    [TestClass]
    public class UnitTestSmoke {
        private TemplatedDocumentAndNameValuePairs TemplatedDocumentAndNameValuePairs = null;

        [TestInitialize]
        public void TestInitialize() {
            TemplatedDocumentAndNameValuePairs = UnitTestRoutines.CreatTestTemplatedDocumentAndTestNameValuePairs(testVariableCount: 3, fromToRange: new FromToRange() { from = 30, to = 300 });
        }

        [TestMethod]
        public void Merge_A_Test_Template_With_Test_NamedValuePairs_Into_A_Test_Document() {
            TemplatedDocumentAndNameValuePairs.MergeTestTemplateWithNamedValuePairsIntoADocumentAndTest();
        }
    }
}
