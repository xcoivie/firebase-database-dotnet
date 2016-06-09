namespace Firebase.Database.Query
{
    /// <summary>
    /// Firebase query which references the child of current node.
    /// </summary>
    public class ChildQuery : FirebaseQuery
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildQuery"/> class.
        /// </summary>
        /// <param name="path"> The path to the child node. </param>
        /// <param name="parent"> The parent. </param>
        public ChildQuery(string path, FirebaseQuery parent)
            : base(parent)
        {
            this.path = path;

            if (!this.path.EndsWith("/"))
            {
                this.path += "/";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildQuery"/> class.
        /// </summary>
        /// <param name="path"> The path to the child node. </param>
        public ChildQuery(string path)
            : this(path, null)
        {
        }

        /// <summary>
        /// Build the url segment of this child.
        /// </summary>
        /// <param name="child"> The child of this child. </param>
        /// <returns> The <see cref="string"/>. </returns>
        protected override string BuildUrlSegment(FirebaseQuery child)
        {
            if (!(child is ChildQuery))
            {
                return this.path + ".json";
            }

            return this.path;
        }
    }
}
