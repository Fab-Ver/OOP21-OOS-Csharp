namespace Commons.Geometry
{
    /// <summary>
    /// Class used to store an image. 
    /// </summary>
    public sealed class Image
    {
        private const float TestDim = 50.0f;

        /// <summary>
        /// Create a new Image
        /// </summary>
        public Image()
        {
            Width = TestDim;
            Height = TestDim;
        }

        public float Width { get; }
        public float Height { get; }
    }
}
