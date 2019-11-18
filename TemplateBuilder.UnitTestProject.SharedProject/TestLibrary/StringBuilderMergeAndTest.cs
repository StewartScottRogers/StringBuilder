﻿using FluentAssertions;

namespace System.Text.TestLibrary {
    public static class StringBuilderMergeAndTest {
        public static void StringBuilder_MergeTemplateWithNamedValuePairsIntoADocumentAndOptionalyTest(this TemplatedDocumentAndNameValuePairs templatedDocumentAndNameValuePairs, int index, bool enableTestOfMerge = false) {
            var targetTemplate = templatedDocumentAndNameValuePairs.StringBuilder;
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
