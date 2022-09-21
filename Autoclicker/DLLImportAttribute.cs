using System;

namespace Autoclicker
{
    internal class DLLImportAttribute : Attribute
    {
        private string v;

        public DLLImportAttribute(string v)
        {
            this.v = v;
        }
    }
}