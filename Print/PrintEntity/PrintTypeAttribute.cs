using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintEntity
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class PrintTypeAttribute : Attribute
    {
        public PrintTypes PrintType { get; set; }
        public PrintTypeAttribute(PrintTypes pt)
        {
            this.PrintType = pt;
        }
    }

    public enum PrintTypes
    {
        String,
        Image
    } 
}
