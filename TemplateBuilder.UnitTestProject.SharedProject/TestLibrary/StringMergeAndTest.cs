using FluentAssertions;

namespace System.Text.TestLibrary {
    public static class StringMergeAndTest {
        public static void String_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndNameValuePairs templatedDocumentAndNameValuePairs, int index, bool enableTestOfMerge = false) {
            var targetTemplate = templatedDocumentAndNameValuePairs.StringBuilder.ToString();
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                targetTemplate.Replace(nameValuePair.Name, nameValuePair.Value);

            if (!enableTestOfMerge)
                return;

            var targetedTemplate = targetTemplate.ToString();

            targetedTemplate.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                targetedTemplate.Should().Contain(nameValuePair.Value);
        }
    }
}
