using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelException
{
    public class GetDataException : Exception
    {
        public string Description { get; set; }

        public GetDataException() : base("Error attempting retrieving data")
        {
        }

        public GetDataException(string message) : base(message)
        {
        }
        public GetDataException(string message, string description) : base(message)
        {
            Description = description;
        }
    }
}
