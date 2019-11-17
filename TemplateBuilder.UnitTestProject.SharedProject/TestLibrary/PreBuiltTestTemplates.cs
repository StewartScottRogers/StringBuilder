namespace System.Text.TestLibrary {
    public static class PreBuiltTestTemplates {
        public static TemplatedDocumentAndNameValuePairs TemplatedDocumentAndNameValuePairs { get; private set; }
            = UnitTestRoutines.CreatTemplatedDocumentAndNameValuePairs(testVariableCount: 50, fromToRange: new FromToRange() { from = 50, to = 100 });
    }
}
