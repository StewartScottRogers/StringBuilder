using FluentAssertions;

namespace System.Text.TestLibrary {
    public static class TestTemplateBuilderFactory {
        public static void TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndKeyValuePairs templatedDocumentAndNameValuePairs, int index, bool enableTestOfMerge = false) {
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.KeyValuePairs)
                templatedDocumentAndNameValuePairs.TemplatedDocument
                    .ReplaceVariable(nameValuePair.Key, nameValuePair.Value);

            if (!enableTestOfMerge)
                return;

            var targetedTemplate = templatedDocumentAndNameValuePairs.TemplatedDocument.ToString();

            targetedTemplate.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.KeyValuePairs)
                targetedTemplate.Should().Contain(nameValuePair.Value);
        }
    }
}
