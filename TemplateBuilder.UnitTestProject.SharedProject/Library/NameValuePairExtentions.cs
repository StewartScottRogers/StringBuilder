using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Text.Library {
    public static class NameValuePairExtentions {
        public static NameValuePair[] CreateNameValuePairs(this object obj) {
            return obj.Create().ToArray();
        }

        private static IEnumerable<NameValuePair> Create(this object obj) {
            yield return new NameValuePair(@"[Name", @"<Value...>]" + Guid.NewGuid().ToString());

        }

        public static void TestNameValurPairs(this NameValuePair[] nameValuePairs, string document) {
            document.Should().NotBeEmpty();

            foreach (var nameValuePair in nameValuePairs)
                document.Should().Contain(nameValuePair.Value);
        }
    }

}
