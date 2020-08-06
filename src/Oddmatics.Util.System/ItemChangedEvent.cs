/**
 * ItemChangedEvent.cs - Item Changed Event
 * 
 * This source-code is part of the Oddmatics utility classes:
 * <<https://www.oddmatics.uk>>
 * 
 * Author(s): Rory Fewell <rory.fewell@oddmatics.uk>
 */

using System;

namespace Oddmatics.Util.System
{
    /// <summary>
    /// Represents the method that will handle events for items being added, changed,
    /// or removed in a collection.
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Type"/> of the item.
    /// </typeparam>
    /// <param name="sender">
    /// The source of the event.
    /// </param>
    /// <param name="e">
    /// A <see cref="ItemChangedEventArgs{T}"/> object that contains event data.
    /// </param>
    public delegate void ItemChangedEventHandler<T>(
        object sender,
        ItemChangedEventArgs<T> e
    );


    /// <summary>
    /// Provides data for events for items being added, changed, or removed in a
    /// collection.
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="Type"/> of the item.
    /// </typeparam>
    public class ItemChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Gets or sets the item changed.
        /// </summary>
        public T ItemChanged { get; private set; }

        /// <summary>
        /// Gets or sets the index of the item that was changed.
        /// </summary>
        public int ItemIndex { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ItemChangedEventArgs{T}"/>
        /// class.
        /// </summary>
        /// <param name="itemChanged">
        /// The changed item.
        /// </param>
        /// <param name="itemIndex">
        /// The index of the item that was changed.
        /// </param>
        public ItemChangedEventArgs(
            T   itemChanged,
            int itemIndex
        )
        {
            ItemChanged = itemChanged;
            ItemIndex   = itemIndex;
        }
    }
}
