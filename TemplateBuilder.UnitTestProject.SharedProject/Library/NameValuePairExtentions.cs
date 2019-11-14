using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Text.Library {
    public static class NameValuePairExtentions {
        #region public Methods
        public static NameValuePair[] CreateNameValuePairs(this object anyObject, ushort requestedVariableCount) {
            return anyObject.Create(requestedVariableCount).ToArray();
        }

        public static void TestNameValuePairs(this NameValuePair[] nameValuePairs, string document) {
            document.Should().NotBeEmpty();

            foreach (var nameValuePair in nameValuePairs)
                document.Should().Contain(nameValuePair.Value);
        }

        public static string CreatePsuedoTestTemplate(this NameValuePair[] nameValuePairs, int fromFragmentlength, int toFragmentlength) {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Start ");
            stringBuilder.Append(CreateTemplateFragement(RandomSizeWithin(fromFragmentlength, toFragmentlength)));

            foreach (var nameValuePair in nameValuePairs) {
                stringBuilder.Append(nameValuePair.Name);
                stringBuilder.Append(CreateTemplateFragement(RandomSizeWithin(fromFragmentlength, toFragmentlength)));
            }

            stringBuilder.Append(CreateTemplateFragement(RandomSizeWithin(fromFragmentlength, toFragmentlength)));
            stringBuilder.Append(" Completed.");
            return stringBuilder.ToString();
        }
        #endregion

        #region Private Methods
        private static string CreateTemplateFragement(int templateFragementLength) {
            return RandomString(templateFragementLength);
        }

        private static IEnumerable<NameValuePair> Create(this object anyObject, ushort requestedVariableCount) {
            var indexCounter = 1;
            while (indexCounter < requestedVariableCount)
                yield return new NameValuePair($"[[Name_{indexCounter++:0000000000000}]]", $"<Value_{indexCounter++:0000000000000} {Guid.NewGuid().ToString()}...>]");
        }

        private static Random random = new Random();
        private static string RandomString(int length) {
            const string chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static int RandomSizeWithin(int from, int to) {

            return random.Next(from, to); ;
        }
        #endregion
    }

}
