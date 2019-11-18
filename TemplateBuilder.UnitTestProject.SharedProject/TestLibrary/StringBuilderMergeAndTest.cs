using FluentAssertions;

namespace System.Text.TestLibrary {
    public static class StringBuilderMergeAndTest {
        public static void StringBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndNameValuePairs templatedDocumentAndNameValuePairs, int index, bool enableTestOfMerge = false) {
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                templatedDocumentAndNameValuePairs.TemplatedDocument
                    .ReplaceVariable(nameValuePair.Name, nameValuePair.Value);

            if (!enableTestOfMerge)
                return;

            templatedDocumentAndNameValuePairs.TemplatedDocument.ToString().Should().NotBeEmpty();

            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                templatedDocumentAndNameValuePairs.TemplatedDocument.ToString().Should().Contain(nameValuePair.Value);
        }
    }
}
