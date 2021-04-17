﻿using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MutableStringLibrary.Api;
using MutableStringLibrary.Comparers;

namespace MutableStringLibrary
{
    public class MutableString
    {
        private string? _value;
        private bool _autoTrim;

        public bool IgnoreCase { get; set; }
        public bool DefaultsToNull { get; set; }
        public Analyze Analyze { get; }
        public Modify Modify { get; }

        public IEqualityComparer? EqualityComparer { get; set; }
        public ISubsetComparer? SubsetComparer { get; set; }

        public MutableString() : this("", true, false, true)
        {
        }

        public MutableString(bool defaultsToNull) : this(defaultsToNull ? null : "", true, defaultsToNull, true)
        {
        }

        public MutableString(string value) : this(value, true, false, true)
        {
        }

        public MutableString(string? value, bool ignoreCase, bool defaultsToNull, bool autoTrim)
        {
            IgnoreCase = ignoreCase;
            DefaultsToNull = defaultsToNull;
            AutoTrim = autoTrim;
            Analyze = new Analyze(this);
            Modify = new Modify(this);
            Value = value;
        }

        public MutableString Copy(string? newValue) =>
            new(newValue, IgnoreCase, DefaultsToNull, AutoTrim)
            {
                EqualityComparer = EqualityComparer,
                SubsetComparer = SubsetComparer
            };
        
        public string? Value
        {
            get => _value;
            set
            {
                if (DefaultsToNull && value == null)
                {
                    _value = null;
                    return;
                }

                _value = AutoTrim
                    ? value!.Trim()
                    : value;
            }
        }

        public bool AutoTrim
        {
            get => _autoTrim;
            set
            {
                _autoTrim = value;
                if (_autoTrim)
                    _value = _value?.Trim();
            }
        }

        public string? DefaultValue =>
            DefaultsToNull ? null : "";
    }
}