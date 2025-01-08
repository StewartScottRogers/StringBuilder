using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Text.TestLibrary {
    public static class UnitTestRoutines {
        #region Members
        private static Random Random = new Random();
        private static string Characters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()abcdefghijklmnopqrstuvwxyz0123456789";
        #endregion

        #region Public Methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TemplatedDocumentAndKeyValuePairs CreatTemplatedDocumentAndNameValuePairs(ushort testVariableCount, FromToRange fromToRange) {
            KeyValuePair<string, string>[] keyValuePairs 
                = CreateIndexedNameValuePairs(testVariableCount)
                    .ToArray();

            StringBuilder stringBuilder = 
                new StringBuilder(
                    keyValuePairs
                        .BuildOutRandomizedTemplate(fromToRange)
                );

            ITemplateBuilder templateBuilder 
                = stringBuilder
                    .ToTemplateBuilder();

            foreach (var keyValuePair in keyValuePairs)
                templateBuilder
                    .AddVariable(keyValuePair.Key);

            return new TemplatedDocumentAndKeyValuePairs() {
                KeyValuePairs = keyValuePairs,
                TemplatedDocument = templateBuilder.ToTemplatedDocument()
            };
        }
        #endregion

        #region Private Methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string BuildOutRandomizedTemplate(this KeyValuePair<string, string>[] keyValuePairs, FromToRange fromToRange) {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendTemplateFragement("Start ");
            stringBuilder.AppendTemplateFragement(CreateRandomizedTemplateFragement(Random.Next(fromToRange.from, fromToRange.to)));

            foreach (var keyValuePair in keyValuePairs) {
                stringBuilder.AppendTemplateVariable(keyValuePair.Key);
                stringBuilder.AppendTemplateFragement(CreateRandomizedTemplateFragement(Random.Next(fromToRange.from, fromToRange.to)));
            }

            stringBuilder.AppendTemplateFragement(CreateRandomizedTemplateFragement(Random.Next(fromToRange.from, fromToRange.to)));
            stringBuilder.AppendTemplateFragement(" Completed.");
            return stringBuilder.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IEnumerable<KeyValuePair<string, string>> CreateIndexedNameValuePairs(ushort testVariableCount) {
            var indexCounter = 1;
            while (indexCounter < testVariableCount)
                yield return new KeyValuePair<string, string>($"[[Key_{indexCounter++:0000000000000}]]", $"<Value_{indexCounter++:0000000000000} '{Guid.NewGuid().ToString()}'>");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string CreateRandomizedTemplateFragement(int templateFragementLength) {
            var randomIndex = Random.Next(Characters.Length - 1);
            return new string(Enumerable.Repeat(Characters, templateFragementLength).Select(character => character[randomIndex]).ToArray());
        }
        #endregion
    }
}
