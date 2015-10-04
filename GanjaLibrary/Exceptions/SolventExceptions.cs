using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Exceptions
{
    [Serializable]
    public class NotEnoughSolventException : Exception
    {
        public NotEnoughSolventException() { }

        public NotEnoughSolventException(IChemical chemical): base(chemical.ToString()) { }

        public NotEnoughSolventException(string message) : base(message) { }
        public NotEnoughSolventException(string message, Exception inner) : base(message, inner) { }
        protected NotEnoughSolventException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
