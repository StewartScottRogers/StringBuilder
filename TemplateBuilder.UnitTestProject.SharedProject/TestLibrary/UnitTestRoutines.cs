using System.Collections.Generic;
using System.Linq;

namespace System.Text.TestLibrary {
    public static class UnitTestRoutines {
        #region Members
        private static Random Random = new Random();
        private static string Characters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()abcdefghijklmnopqrstuvwxyz0123456789";
        #endregion

        #region Public Methods
        public static TemplatedDocumentAndNameValuePairs CreatTemplatedDocumentAndNameValuePairs(ushort testVariableCount, FromToRange fromToRange) {
            var nameValuePairs = CreateIndexedNameValuePairs(testVariableCount).ToArray();
            var stringBuilder = new StringBuilder(nameValuePairs.BuildOutRandomizedTemplate(fromToRange));
            var templateBuilder = stringBuilder.ToTemplateBuilder();

            foreach (var nameValuePair in nameValuePairs)
                templateBuilder
                    .AddVariable(nameValuePair.Name);

            return new TemplatedDocumentAndNameValuePairs() {
                NameValuePairs = nameValuePairs,
                StringBuilder = stringBuilder,
                TemplatedDocument = templateBuilder.ToTemplatedDocument()
            };
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
