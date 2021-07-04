using System;
namespace app.api.Core
{
    public static class ThrowIf
    {
        public static class Argument
        {
            /// <summary>
            /// Argument Null Checking
            /// </summary>
            /// <param name="argument">The argument to check.</param>
            /// <param name="argumentName">The argument's name.</param>
            public static void IsNull(object argument, string argumentName)
            {
                if (argument == null)
                    throw new ArgumentNullException(argumentName);
            }

            /// <summary>
            /// Argument Null or WhiteSpace Checking
            /// </summary>
            /// <param name="argument">The argument to check.</param>
            /// <param name="argumentName">The argument's name.</param>
            public static void IsNullOrWhiteSpace(string argument, string argumentName)
            {
                if (string.IsNullOrWhiteSpace(argument))
                    throw new ArgumentException("Argument should not be null or white space", argumentName);
            }
        }
    }
}