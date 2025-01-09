using FluentAssertions;
using System.Runtime.CompilerServices;

namespace System.Text.TestLibrary {
    public static class TemplateBuilderMergeAndTestExtentions {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ITemplatedDocument TemplateBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndKeyValuePairs templatedDocumentAndKeyValuePairs, int index, bool enableTestOfMerge = false) {

            StringBuilder stringBuilder
              = new StringBuilder(
                      templatedDocumentAndKeyValuePairs
                          .Document
              );

            ITemplateBuilder templateBuilder
                = stringBuilder
                    .ToTemplateBuilder();

            ITemplatedDocument templatedDocument
                = templateBuilder
                    .ToTemplatedDocument();


            foreach (var nameValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                templatedDocument
                    .ReplaceVariable(nameValuePair.Key, nameValuePair.Value);

            if (!enableTestOfMerge)
                return templatedDocument;

            string text
                = templatedDocument.ToString();

            text.Should().NotBeEmpty();
            foreach (var nameValuePair in templatedDocumentAndKeyValuePairs.KeyValuePairs)
                text.Should().Contain(nameValuePair.Value);

            return templatedDocument;
        }
    }
}
