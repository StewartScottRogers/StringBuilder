﻿using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Library {
    public struct NameValuePair {
        public NameValuePair(string name, string value) {
            Name = name;
            Value = value;
        }
        public string Name;
        public string Value;
    }
}