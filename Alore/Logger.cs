namespace Alore
{
    using System;

    public static class Logger<TClass>
    {

        //TODO: Make the prefix optional + customizable.
        private static readonly string prefix = "[Alore] [" + typeof(TClass).Name + "] ";

        public static void Error(Exception ex) =>
            Error(ex.ToString());

        public static void Error(object error) =>
            Console.WriteLine($"{prefix} [ERROR] {error}");

        public static void Info(object info) =>
            Console.WriteLine($"{prefix} [INFO] {info}");

    }
}