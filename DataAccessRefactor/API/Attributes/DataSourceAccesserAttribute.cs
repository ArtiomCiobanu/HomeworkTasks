using System;
using ConsoleApp1.API.Enums;

namespace ConsoleApp1.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataSourceAccesserAttribute : Attribute
    {
        public AccesserType AccesserType { get; private set; }

        public DataSourceAccesserAttribute(AccesserType accesserType)
        {
            AccesserType = accesserType;
        }
    }
}