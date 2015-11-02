using System;
using System.Diagnostics;

namespace SuperChef.Core.Infrastructure
{
    public class Contract
    {
        public static void Requires<TException>(bool condition, string message = "") 
            where TException : Exception, new()
        {
            if (!condition)
            {
                Debug.WriteLine(message);
                throw new TException();
            }
        }
    }
}
