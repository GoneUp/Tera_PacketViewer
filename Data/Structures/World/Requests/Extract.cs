using Data.Enums;

namespace Data.Structures.World.Requests
{
    /// <summary>
    /// When player requests to extract an item.
    /// </summary>
    public class Extract : Request
    {
        /// <summary>
        /// Type of extraction.
        /// </summary>
        public int ExtractType;

        /// <summary>
        /// Create new extraction request.
        /// </summary>
        /// <param name="extractType">Type of extraction</param>
        public Extract(int extractType) : base(RequestType.Extraction, false)
        {
            ExtractType = extractType;
        }

        public override bool IsValid()
        {
            // validation of ExtractType value should go here
            return true;
        }
    }
}
