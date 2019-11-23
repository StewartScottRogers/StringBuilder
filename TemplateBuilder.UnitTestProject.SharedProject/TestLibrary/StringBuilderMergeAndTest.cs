using FluentAssertions;

namespace System.Text.TestLibrary {
    public static class StringBuilderMergeAndTest {
        public static void StringBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndKeyValuePairs templatedDocumentAndNameValuePairs, int index, bool enableTestOfMerge = false) {
            var targetTemplate = templatedDocumentAndNameValuePairs.StringBuilder;
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.KeyValuePairs)
                targetTemplate.Replace(nameValuePair.Key, nameValuePair.Value);

            if (!enableTestOfMerge)
                return;

            var targetedTemplate = targetTemplate.ToString();

            targetedTemplate.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.KeyValuePairs)
                targetedTemplate.Should().Contain(nameValuePair.Value);
        }
    }
}
