﻿using System.Text;
using System.Collections.Generic;
using January_2017_GCDNUG_Demo.Helpers;
using January_2017_GCDNUG_Demo.Misc;

// Static usings
using static System.Reflection.MethodBase;
using static System.Environment;

namespace January_2017_GCDNUG_Demo.Demos
{
    public class NameOfDemo : AbstractDemo
    {
        #region Properties

        public User User { get; set; }

        #endregion Properties

        #region Contructors

        public NameOfDemo(string input)
        {
            Input = input;
            User = new User(input);
        }

        #endregion Contructors

        #region Public Methods

        public override string GetMessageInternal()
        {
            return $"{GetUserDetailsWithLiteralStrings()}{NewLine}{GetUserDetailsWithNameOf()}";
        }

        #endregion Public Methods

        #region Private Methods

        private string GetUserDetailsWithLiteralStrings()
        {
            // Old dictionary initializer
            var userPropertyDictionary = new Dictionary<string, string>()
            {
                { "Nmae", User.Name },
                { "usergUid", User.UserGuid.ToString() },
                { "Speceis", User.Species }
            };

            return $"{GetCurrentMethod().MethodSignature()}{NewLine}{GetMessageFromDictionary(userPropertyDictionary)}";
        }

        /// <summary>
        /// Two birds with one stone here. Shows off 'nameof' as well as new Dictionary initializer
        /// </summary>
        /// <returns></returns>
        private string GetUserDetailsWithNameOf()
        {
            // New dictionary initializer
            var userPropertyDictionary = new Dictionary<string, string>()
            {
                // nameof instead of literal strings
                [nameof(User.Name)] = User.Name,
                [nameof(User.UserGuid)] = User.UserGuid.ToString(),
                [nameof(User.Species)] = User.Species
            };

            return $"{GetCurrentMethod().MethodSignature()}{NewLine}{GetMessageFromDictionary(userPropertyDictionary)}";
        }

        private static string GetMessageFromDictionary(Dictionary<string, string> dict)
        {
            var sb = new StringBuilder();

            foreach (KeyValuePair<string, string> pair in dict)
            {
                sb.AppendLine($"{pair.Key} = {pair.Value}");
            }

            return sb.ToString();
        }

        #endregion Private Methods 
    }
}
