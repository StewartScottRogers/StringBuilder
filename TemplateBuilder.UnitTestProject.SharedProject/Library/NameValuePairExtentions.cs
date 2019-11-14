using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Text.Library {
    public static class NameValuePairExtentions {
        public static NameValuePair[] CreateNameValuePairs(this object anyObject, ushort requestedVariableCount) {
            return anyObject.Create(requestedVariableCount).ToArray();
        }

        private static IEnumerable<NameValuePair> Create(this object anyObject, ushort requestedVariableCount) {
            var indexCounter = 1;
            while(indexCounter< requestedVariableCount)
            yield return new NameValuePair($"[[Name_{indexCounter++:0000000000000}]]", $"<Value_{indexCounter++:0000000000000} {Guid.NewGuid().ToString()}...>]");

        }

        public static void TestNameValurPairs(this NameValuePair[] nameValuePairs, string document) {
            document.Should().NotBeEmpty();

            foreach (var nameValuePair in nameValuePairs)
                document.Should().Contain(nameValuePair.Value);
        }
    }

}
