/**
 * ChangeTrackingEx.cs - Change Tracking Interface
 * 
 * This source-code is part of the Oddmatics utility classes:
 * <<https://www.oddmatics.uk>>
 * 
 * Author(s): Rory Fewell <rory.fewell@oddmatics.uk>
 */

using System;
using System.ComponentModel;

namespace Oddmatics.Util.System
{
    /// <summary>
    /// Base class for tracking changes to an object.
    /// </summary>
    public abstract class ChangeTrackingEx : IChangeTracking
    {
        /// <inheritdoc />
        public bool IsChanged
        {
            get { return _IsChanged; }
            set
            {
                _IsChanged = value;

                if (_IsChanged)
                {
                    Invalidated?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    ChangesAccepted?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private bool _IsChanged;

        /// <summary>
        /// Occurs when changes have been accepted on the object.
        /// </summary>
        public event EventHandler ChangesAccepted;

        /// <summary>
        /// Occurs when the object has been changed.
        /// </summary>
        public event EventHandler Invalidated;


        /// <inheritdoc />
        public abstract void AcceptChanges();
    }
}
