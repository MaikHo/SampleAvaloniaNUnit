using System;
using System.Collections.Generic;

namespace SampleAvaloniaNUnit.Services
{
    /// <summary>
    /// Sample domain service: parses Key=Value;Key=Value...
    /// </summary>
    public sealed class ParserService
    {
        /// <summary>
        /// Parses a simple key/value format: "A=1;B=2" -> Dictionary{A:1, B:2}.
        /// Trims whitespace around keys and values.
        /// </summary>
        public IDictionary<string, string> Parse(string input)
        {
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (string.IsNullOrWhiteSpace(input))
                return result;

            var pairs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var kv = pair.Split('=', 2, StringSplitOptions.TrimEntries);
                if (kv.Length != 2) continue; // resilient to "A=1;B;C=3"
                var key = kv[0].Trim();
                var val = kv[1].Trim();
                if (key.Length == 0) continue;
                result[key] = val;
            }

            return result;
        }
    }
}
