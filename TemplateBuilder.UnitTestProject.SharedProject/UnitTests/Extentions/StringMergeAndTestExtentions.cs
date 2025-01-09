using FluentAssertions;
using System.Runtime.CompilerServices;

namespace System.Text.TestLibrary {
    public static class StringMergeAndTestExtentions {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string String_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndKeyValuePairs templatedDocumentAndKeyValuePairs, int index, bool enableTestOfMerge = false) {

            string document
                = templatedDocumentAndKeyValuePairs.ToString();

            foreach (var keyValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                document.Replace(keyValuePair.Key, keyValuePair.Value);

            if (!enableTestOfMerge)
                return document;

            string text = document.ToString();

            text.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                text.Should().Contain(nameValuePair.Value);

            return document;
        }
    }
}
