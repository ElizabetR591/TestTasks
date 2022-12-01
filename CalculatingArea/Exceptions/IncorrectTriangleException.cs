using System;
using System.Runtime.Serialization;

namespace CalculatingArea.Exceptions
{
    [Serializable]
    public class IncorrectTriangleException : Exception
    {
        public IncorrectTriangleException(double sideA, double sideB, double sideC) : base($"The triangle with sides {sideA}, {sideB}, {sideC} is incorrect") { }

        /// <summary>
        /// ISerializable constructor
        /// </summary>
        protected IncorrectTriangleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
