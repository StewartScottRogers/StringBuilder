using FluentAssertions;
using System.Runtime.CompilerServices;

namespace System.Text.TestLibrary {
    public static class StringMergeAndTest {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void String_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndKeyValuePairs templatedDocumentAndKeyValuePairs, int index, bool enableTestOfMerge = false) {
            var targetTemplate = templatedDocumentAndKeyValuePairs.StringBuilder.ToString();
            foreach (var keyValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                targetTemplate.Replace(keyValuePair.Key, keyValuePair.Value);

            if (!enableTestOfMerge)
                return;

            var targetedTemplate = targetTemplate.ToString();

            targetedTemplate.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                targetedTemplate.Should().Contain(nameValuePair.Value);
        }
    }
}
