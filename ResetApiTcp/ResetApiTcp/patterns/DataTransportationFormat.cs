using ResetApiTcp.Patterns;

namespace ResetApiTcp.patterns
{
    internal class DataTransportationFormat
    {

        public RequestType Request = RequestType.NULL;
        public FormatDataType DataFormat = FormatDataType.NULL;
        public string NameUser = "";
        public byte[] Data = null;

    }
}
