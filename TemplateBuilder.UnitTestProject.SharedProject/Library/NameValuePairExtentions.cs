using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using static System.Text.StringBuilderExtentions;

namespace System.Text.Library {
    public static class NameValuePairExtentions {
        #region Members
        private static Random Random = new Random();
        private static string Characters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()abcdefghijklmnopqrstuvwxyz0123456789";
        #endregion

        #region public Methods
        public static (NameValuePair[] NameValuePairs, ITemplatedDocument TemplatedDocument) CreatTemplatedDocumentAndNameValuePairs(ushort requestedVariableCount, int fromFragmentlength, int toFragmentlength) {
            var nameValuePairs = CreateNameValuePairs(3).ToArray();

            var templateContent
                = nameValuePairs.CreatePsuedoTestTemplate(30, 500);

            var templatedDocument
                = nameValuePairs.ToTemplatedDocument(templateContent);

            return (NameValuePairs: nameValuePairs, TemplatedDocument: templatedDocument);
        }

        public static void TestTemplatedDocumentAndNameValuePairs(NameValuePair[] nameValuePairs, string document) {
            document.Should().NotBeEmpty();
            foreach (var nameValuePair in nameValuePairs)
                document.Should().Contain(nameValuePair.Value);
        }
        #endregion

        #region Private Methods
        private static string CreatePsuedoTestTemplate(this NameValuePair[] nameValuePairs, int fromFragmentlength, int toFragmentlength) {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Start ");
            stringBuilder.Append(CreateTemplateFragement(Random.Next(fromFragmentlength, toFragmentlength)));

            foreach (var nameValuePair in nameValuePairs) {
                stringBuilder.Append(nameValuePair.Name);
                stringBuilder.Append(CreateTemplateFragement(Random.Next(fromFragmentlength, toFragmentlength)));
            }

            stringBuilder.Append(CreateTemplateFragement(Random.Next(fromFragmentlength, toFragmentlength)));
            stringBuilder.Append(" Completed.");
            return stringBuilder.ToString();
        }

        private static ITemplatedDocument ToTemplatedDocument(this NameValuePair[] nameValuePairs, string templateContent) {
            var templateBuilder
                = new StringBuilder(templateContent)
                    .ToTemplateBuilder();

            foreach (var nameValuePair in nameValuePairs)
                templateBuilder
                    .AddVariableName(nameValuePair.Name);

            var templatedDocument
                = templateBuilder
                    .ToTemplate()
                        .CreateTemplatedDocument();

            return templatedDocument;
        }

        private static IEnumerable<NameValuePair> CreateNameValuePairs(ushort requestedVariableCount) {
            var indexCounter = 1;
            while (indexCounter < requestedVariableCount)
                yield return new NameValuePair($"[[Name_{indexCounter++:0000000000000}]]", $"<Value_{indexCounter++:0000000000000} {Guid.NewGuid().ToString()}...>]");
        }

        private static string CreateTemplateFragement(int templateFragementLength) {
            var randomIndex = Random.Next(Characters.Length - 1);
            return new string(Enumerable.Repeat(Characters, templateFragementLength).Select(character => character[randomIndex]).ToArray());
        }
        #endregion
    }
}
