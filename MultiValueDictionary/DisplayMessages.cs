using System;

namespace MultiValueDictionary
{

    public class DisplayMessages
    {
        public const string Added = "Added";
        public const string Removed = "Removed";
        public const string Cleared = "Cleared";
        public const string Updated = "Updated";
        public const string EmptySet = "(empty set)";
        public const string True = "true";
        public const string False = "false";
        public const string CommandPrompt = ">";

        public static void ErrorMessage(string errorMessage)
        {
            Console.WriteLine($" ) ERROR, {errorMessage} ");
        }

        public static void Message(string message)
        {
            Console.WriteLine($" ) {message} ");
        }
    }
}


