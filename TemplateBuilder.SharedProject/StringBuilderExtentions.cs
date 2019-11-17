using System.Collections.ObjectModel;
using System.Linq;

namespace System.Text {
    public static class StringBuilderExtentions {
        private static readonly string Deliniator = Guid.NewGuid().ToString();

        public static StringBuilder AppendTemplateVariable(this StringBuilder stringBuilder, String value) => stringBuilder.Append(value);

        public static StringBuilder AppendTemplateFragement(this StringBuilder stringBuilder, String value) => stringBuilder.Append(value);

        public static ITemplateBuilder ToTemplateBuilder(this StringBuilder stringBuilder) => new TemplateBuilder(stringBuilder.ToString());

        private class TemplateBuilder : ITemplateBuilder {
            private readonly StringBuilder StringBuilder;

            public TemplateBuilder(String value) => this.StringBuilder = new StringBuilder(value);

            public ITemplateBuilder AddVariable(string variableName) {
                StringBuilder.Replace(variableName, $"{Deliniator}{variableName}{Deliniator}");
                return this;
            }

            public ITemplatedDocument ToTemplatedDocument() {
                var template = StringBuilder.ToString();
                return new TemplatedDocument(
                    template.Split(new string[] { Deliniator }, StringSplitOptions.None),
                    template.Length
                );
            }

            public override string ToString() => StringBuilder.ToString();

            private class TemplatedDocument : ITemplatedDocument {
                private readonly Collection<VariableNameValuePair> variableNameValuePairCollection = new Collection<VariableNameValuePair>();
                private readonly string[] TemplateTokens;
                private readonly int TemplateSize;

                public TemplatedDocument(string[] templateTokens, int templateSize) { TemplateTokens = templateTokens; TemplateSize = templateSize + (templateSize / 10); }

                public ITemplatedDocument ReplaceVariable(string variableName, string variableValue) { variableNameValuePairCollection.Add(new VariableNameValuePair(variableName, variableValue)); return this; }

                public string ToDocument() {

                    var nameValuePairList = variableNameValuePairCollection.ToList();

                    var stringBuilder = new StringBuilder(TemplateSize);

                    foreach (var TemplateToken in TemplateTokens)
                        foreach (var variableNameValuePair in nameValuePairList.ToArray())
                            if (TemplateToken == variableNameValuePair.Name) {
                                stringBuilder.Append(variableNameValuePair.Value);
                                nameValuePairList.Remove(variableNameValuePair);
                            } else
                                stringBuilder.Append(TemplateToken);

                    return stringBuilder.ToString();
                }

                public override string ToString() => ToDocument();
            }

            private struct VariableNameValuePair {
                public VariableNameValuePair(string name, string value) { Name = name; Value = value; }
                public string Name;
                public string Value;
            }
        }
    }

    public interface ITemplateBuilder {
        ITemplateBuilder AddVariable(string variableName);
        ITemplatedDocument ToTemplatedDocument();
    }

    public interface ITemplatedDocument {
        ITemplatedDocument ReplaceVariable(string variableName, string variableValue);
        string ToDocument();
    }
}
