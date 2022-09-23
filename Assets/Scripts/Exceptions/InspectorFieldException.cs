using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateIsland.Exceptions
{
    public class IncorrectInspectorFieldValueException : Exception
    {
        public IncorrectInspectorFieldValueException(string fieldName, string expectedValueText) 
            : base($"Incorrect value in field with name: {fieldName}! \n" + expectedValueText)
        {
        }
    }
}
