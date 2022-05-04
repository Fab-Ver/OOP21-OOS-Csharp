namespace Commons.Geometry
{
    /// <summary>
    /// Class used to store an image. 
    /// </summary>
    public sealed class Image
    {
        private const float testDim = 50.0f;

        /// <summary>
        /// Create a new Image
        /// </summary>
        public Image()
        {
            Width = testDim;
            Height = testDim;
        }

        public float Width { get; }
        public float Height { get; }
    }
}
