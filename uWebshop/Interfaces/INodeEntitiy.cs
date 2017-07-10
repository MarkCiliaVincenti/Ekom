﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uWebshop.Interfaces
{
    public interface INodeEntitiy
    {
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        int Id { get; }

        /// <summary>
        /// Gets the unique key identifier.
        /// </summary>
        /// <value>
        /// The unique key identifier.
        /// </value>
        Guid Key { get; }

        /// <summary>
        /// Gets the name or alias for the type. (NodeTypeAlias/ContentTypeAlias in Umbraco)
        /// </summary>
        /// <value>
        /// The type alias.
        /// </value>
        string ContentTypeAlias { get; }

        /// <summary>
        /// Gets the created date
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        DateTime CreateDate { get; }

        /// <summary>
        /// Gets the update date
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        DateTime UpdateDate { get; }

        /// <summary>
        /// SortOrder for the node
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        int SortOrder { get; }

        /// <summary>
        /// Level for the node
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        int Level { get; }

        /// <summary>
        /// Path for the node
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        string Path { get; }
    }

    public interface INodeEntitiyWithUrl : INodeEntitiy
    {
        /// <summary>
        /// Urls for the node
        /// </summary>
        /// <value>
        /// The urls.
        /// </value>
        IEnumerable<string> Urls { get; }

        /// <summary>
        /// The url for the node
        /// </summary>
        /// <value>
        /// The url.
        /// </value>
        string Url { get; }
    }
}