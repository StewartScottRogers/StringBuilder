using System.Collections.ObjectModel;
using System.Linq;

namespace System.Text {
    public static class StringBuilderExtentions {
        private static readonly string Deliniator = Guid.NewGuid().ToString();

        public static ITemplateBuilder ToTemplateBuilder(this StringBuilder stringBuilder) => new TemplateBuilder(stringBuilder.ToString());



        private class TemplateBuilder : ITemplateBuilder {
            private readonly StringBuilder TheStringBuilder;

            public TemplateBuilder(String value) => this.TheStringBuilder = new StringBuilder(value);

            public ITemplateBuilder AddVariableName(string variableName) {
                TheStringBuilder.Replace(variableName, $"{Deliniator}{variableName}{Deliniator}");
                return this;
            }

            public ITemplate ToTemplate() => new Template(TheStringBuilder.ToString());

            public override string ToString() => TheStringBuilder.ToString();

            private class Template : ITemplate {
                private readonly int TemplateSize;
                private readonly string[] TemplateTokens;

                public Template(String value) {
                    TemplateSize = value.Length;
                    TemplateTokens = value.Split(new string[] { Deliniator }, StringSplitOptions.None);
                }

                public ITemplatedDocument CreateTemplatedDocument() => new TemplatedDocument(TemplateTokens, TemplateSize);

                private class TemplatedDocument : ITemplatedDocument {
                    private readonly Collection<VariableNameValuePair> variableNameValuePairCollection = new Collection<VariableNameValuePair>();
                    private readonly string[] TemplateTokens;
                    private readonly int TemplateSize;

                    public TemplatedDocument(string[] templateTokens, int templateSize) { TemplateTokens = templateTokens; TemplateSize = templateSize + (templateSize / 10); }

                    public ITemplatedDocument Replace(string variableName, string variableValue) { variableNameValuePairCollection.Add(new VariableNameValuePair(variableName, variableValue)); return this; }

                    public override string ToString() {
                        var nameValuePairList = variableNameValuePairCollection.ToList();

                        var stringBuilder = new StringBuilder(TemplateSize);

                        foreach (var TemplateToken in TemplateTokens)
                            foreach (var variableNameValuePair in nameValuePairList.ToArray())
                                if (TemplateToken == variableNameValuePair.Name) {
                                    stringBuilder.Append(variableNameValuePair.Value);
                                    variableNameValuePairCollection.Remove(variableNameValuePair);
                                } else
                                    stringBuilder.Append(TemplateToken);

                        return stringBuilder.ToString();
                    }

                    private struct VariableNameValuePair {
                        public VariableNameValuePair(string name, string value) {
                            Name = name;
                            Value = value;
                        }
                        public string Name;
                        public string Value;
                    }
                }
            }
        }



        public interface ITemplateBuilder {
            ITemplateBuilder AddVariableName(string variableName);
            ITemplate ToTemplate();
        }

        public interface ITemplate {
            ITemplatedDocument CreateTemplatedDocument();
        }

        public interface ITemplatedDocument {
            ITemplatedDocument Replace(string variableName, string variableValue);
        }
    }
}
