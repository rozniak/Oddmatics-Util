/**
 * ValidationPredicate.cs - Item Validation Predicate
 * 
 * This source-code is part of the Oddmatics utility classes:
 * <<https://www.oddmatics.uk>>
 * 
 * Author(s): Rory Fewell <rory.fewell@oddmatics.uk>
 */

using System;
using System.Collections.Generic;

namespace Oddmatics.Util.System
{
    /// <summary>
    /// Defines a predicate for validating an individual item, or an item within a
    /// collection.
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Type"/> of the item.
    /// </typeparam>
    /// <param name="item">
    /// The item.
    /// </param>
    /// <param name="collection">
    /// The collection in which the item resides, null if the item is not a member of a
    /// collection.
    /// </param>
    /// <param name="reason">
    /// If the item was determined to be invalid, contains the reason for the failure.
    /// </param>
    /// <returns>
    /// True if the item is valid.
    /// </returns>
    public delegate bool ValidationPredicate<T>(
        T              item,
        IEnumerable<T> collection,
        out string     reason
    );
}
