using FluentAssertions;

namespace System.Text.TestLibrary {
    public static class TestTemplateBuilderFactory {
        public static void TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndNameValuePairs templatedDocumentAndNameValuePairs, int index, bool enableTestOfMerge = false) {
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                templatedDocumentAndNameValuePairs.TemplatedDocument
                    .ReplaceVariable(nameValuePair.Name, nameValuePair.Value);

            if (!enableTestOfMerge)
                return;

            var targetedTemplate = templatedDocumentAndNameValuePairs.TemplatedDocument.ToString();

            targetedTemplate.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                targetedTemplate.Should().Contain(nameValuePair.Value);
        }
    }
}
