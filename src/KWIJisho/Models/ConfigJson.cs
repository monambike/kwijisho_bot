﻿using Newtonsoft.Json;

namespace KWIJisho
{
    internal struct ConfigJson
    {
        // Those properties are for easier data manipulation since instances are not necessary,
        // because there's only one config.json file.
        internal static string ConfigJsonToken { get; set; }
        internal static string ConfigJsonPrefix { get; set; }
        internal static string ConfigJsonActivity { get; set; }
        // Even thought we don't need instances because there's only one config.json file, deserializing
        // needs a new instance object. Those properties are for handling those deserializing values
        [JsonProperty("token")]
        internal string Token { get; set; }
        [JsonProperty("prefix")]
        internal string Prefix { get; set; }
        [JsonProperty("activity")]
        internal string Activity { get; set; }

        /// <summary>
        /// Set values from current instance for static properties of the same class.
        /// </summary>
        internal void SetThisToStaticProperties()
        {
            ConfigJsonToken = Token;
            ConfigJsonPrefix = Prefix;
            ConfigJsonActivity = Activity;
        }
    }
}
