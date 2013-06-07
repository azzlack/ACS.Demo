namespace ACS.BusinessLogic.Extensions
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Converts the legacy NameValueCollection into a strongly-typed KeyValuePair sequence.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>A list of Key/Value pairs.</returns>
        public static IEnumerable<KeyValuePair<string, string>> AsKeyValuePairs(this NameValueCollection collection)
        {
            foreach (var key in collection.AllKeys)
            {
                yield return new KeyValuePair<string, string>(key, collection.Get(key));
            }
        }
    }
}