namespace FastFoodService.Wrappings
{
    /// <summary>
    /// Base Wrapping.
    /// </summary>
    public class Wrapping
    {
        #region Public properties

        /// <summary>
        /// Gets the Wrapping's Name.
        /// </summary>
        public string Name
        {
            get { return GetType().Name; }
        }

        #endregion
    }
}
