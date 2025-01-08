using FluentAssertions;
using System.Runtime.CompilerServices;

namespace System.Text.TestLibrary {
    public static class StringBuilderMergeAndTest {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringBuilder StringBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndKeyValuePairs templatedDocumentAndKeyValuePairs, int index, bool enableTestOfMerge = false) {

            ITemplatedDocument templatedDocument
                = templatedDocumentAndKeyValuePairs
                    .TemplatedDocument;

            StringBuilder stringBuilder
                = new StringBuilder(
                        templatedDocument
                            .ToDocument()
                );

            foreach (var nameValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                stringBuilder.Replace(nameValuePair.Key, nameValuePair.Value);

            if (!enableTestOfMerge)
                return stringBuilder;

            string text = stringBuilder.ToString();

            text.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                text.Should().Contain(nameValuePair.Value);

            return stringBuilder;
        }
    }
}
