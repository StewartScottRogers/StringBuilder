using FluentAssertions;
using System.Runtime.CompilerServices;

namespace System.Text.TestLibrary {
    public static class StringMergeAndTest {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string String_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndKeyValuePairs templatedDocumentAndKeyValuePairs, int index, bool enableTestOfMerge = false) {

            ITemplatedDocument templatedDocument
                = templatedDocumentAndKeyValuePairs
                    .TemplatedDocument;

            string targetTemplateCopy 
                = templatedDocument
                    .ToDocument();

            foreach (var keyValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                targetTemplateCopy.Replace(keyValuePair.Key, keyValuePair.Value);

            if (!enableTestOfMerge)
                return targetTemplateCopy;

            string text = targetTemplateCopy.ToString();

            text.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                text.Should().Contain(nameValuePair.Value);

            return targetTemplateCopy;
        }
    }
}
