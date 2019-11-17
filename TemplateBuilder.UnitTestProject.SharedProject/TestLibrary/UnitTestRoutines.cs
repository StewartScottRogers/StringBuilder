﻿using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace System.Text.TestLibrary {
    public static class UnitTestRoutines {
        #region Members
        private static Random Random = new Random();
        private static string Characters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()abcdefghijklmnopqrstuvwxyz0123456789";
        #endregion

        #region public Methods
        public static TemplatedDocumentAndNameValuePairs CreatTestTemplatedDocumentAndTestNameValuePairs(ushort testVariableCount, FromToRange fromToRange) {
            var nameValuePairs = CreateIndexedNameValuePairs(testVariableCount).ToArray();

            var templateContent
                = nameValuePairs.BuildOutRandomizedTemplate(fromToRange);

            var templateBuilder
                = new StringBuilder(templateContent)
                    .ToTemplateBuilder();

            foreach (var nameValuePair in nameValuePairs)
                templateBuilder
                    .AddVariable(nameValuePair.Name);

            var templatedDocument
                = templateBuilder
                    .ToTemplatedDocument();

            return new TemplatedDocumentAndNameValuePairs() {
                NameValuePairs = nameValuePairs,
                TemplatedDocument = templatedDocument
            };
        }

        public static void MergeTestTemplateWithNamedValuePairsIntoADocumentAndTest(this TemplatedDocumentAndNameValuePairs templatedDocumentAndNameValuePairs, int index, bool enableTestOfMerge = false) {
            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                templatedDocumentAndNameValuePairs.TemplatedDocument
                    .ReplaceVariable(nameValuePair.Name, nameValuePair.Value);

            if (!enableTestOfMerge)
                return;

            templatedDocumentAndNameValuePairs.TemplatedDocument.ToString().Should().NotBeEmpty();

            foreach (var nameValuePair in templatedDocumentAndNameValuePairs.NameValuePairs)
                templatedDocumentAndNameValuePairs.TemplatedDocument.ToString().Should().Contain(nameValuePair.Value);
        }
        #endregion

        #region Private Methods
        private static string BuildOutRandomizedTemplate(this NameValuePair[] nameValuePairs, FromToRange fromToRange) {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendTemplateFragement("Start ");
            stringBuilder.AppendTemplateFragement(CreateRandomizedTemplateFragement(Random.Next(fromToRange.from, fromToRange.to)));

            foreach (var nameValuePair in nameValuePairs) {
                stringBuilder.AppendTemplateVariable(nameValuePair.Name);
                stringBuilder.AppendTemplateFragement(CreateRandomizedTemplateFragement(Random.Next(fromToRange.from, fromToRange.to)));
            }

            stringBuilder.AppendTemplateFragement(CreateRandomizedTemplateFragement(Random.Next(fromToRange.from, fromToRange.to)));
            stringBuilder.AppendTemplateFragement(" Completed.");
            return stringBuilder.ToString();
        }

        private static IEnumerable<NameValuePair> CreateIndexedNameValuePairs(ushort testVariableCount) {
            var indexCounter = 1;
            while (indexCounter < testVariableCount)
                yield return new NameValuePair($"[[Name_{indexCounter++:0000000000000}]]", $"<Value_{indexCounter++:0000000000000} '{Guid.NewGuid().ToString()}'>");
        }

        private static string CreateRandomizedTemplateFragement(int templateFragementLength) {
            var randomIndex = Random.Next(Characters.Length - 1);
            return new string(Enumerable.Repeat(Characters, templateFragementLength).Select(character => character[randomIndex]).ToArray());
        }
        #endregion
    }
}