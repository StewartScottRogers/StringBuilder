using System.Collections.Generic;

namespace System.Text.TestLibrary {
    public static class PreBuiltTestTemplates {
        private static Stack<TemplatedDocumentAndKeyValuePairs> preBuiltTemplatedDocumentAndKeyValuePairs = new Stack<TemplatedDocumentAndKeyValuePairs>();
        private static int StackDepth = (10 * 1000 * 1000);

        public static void InitStack() { }

        static PreBuiltTestTemplates() {
            TemplatedDocumentAndKeyValuePairs templatedDocumentAndKeyValuePairs
             = UnitTestRoutines
                 .CreatTemplatedDocumentAndNameValuePairs(
                     testVariableCount: 50,
                     fromToRange: new FromToRange() {
                         from = 50,
                         to = 100
                     }
                 );

            for (int i = 0; i < StackDepth; i++) {
                preBuiltTemplatedDocumentAndKeyValuePairs.Push(
                    templatedDocumentAndKeyValuePairs.Clone()
                );
            }
        }

        public static TemplatedDocumentAndKeyValuePairs PopTemplatedDocumentAndNameValuePairsStack()
            => preBuiltTemplatedDocumentAndKeyValuePairs.Pop();

    }
}
