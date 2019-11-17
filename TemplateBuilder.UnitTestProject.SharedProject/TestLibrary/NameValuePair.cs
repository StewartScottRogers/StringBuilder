﻿namespace System.Text.TestLibrary {
    public struct NameValuePair {
        public NameValuePair(string name, string value) {
            Name = name;
            Value = value;
        }
        public string Name;
        public string Value;
    }
}