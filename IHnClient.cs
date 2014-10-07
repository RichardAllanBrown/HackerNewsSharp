using System;
using System.Collections.Generic;
using HackerNewsSharp.Models;

namespace HackerNewsSharp
{
    public interface IHnClient
    {
        /// <summary>
        /// Retrieves an item from HN. An item can be a story, commnent, poll or poll option. Null is returned if it cannot be found
        /// </summary>
        /// <param name="itemId">The id of the item to retrieve</param>
        /// <returns>The item object</returns>
        HnItem GetItem(string itemId);

        /// <summary>
        /// Retrieves a user from HN, null if the user could not be retrieved
        /// </summary>
        /// <param name="userId">The id of the user to retrive</param>
        /// <returns>The user object</returns>
        HnUser GetUser(string userId);

        /// <summary>
        /// Retrieves the top 100 stories currently trending
        /// </summary>
        /// <returns>The ids of the top 100 stories</returns>
        IEnumerable<string> GetTopStories(); 
    }
}
