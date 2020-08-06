/**
 * ValidationFailureException.cs - Validation Failure Exception
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
    /// The exception that is thrown when required validation fails.
    /// </summary>
    public class ValidationFailureException : Exception
    {
        /// <summary>
        /// Gets or sets the item that failed validation.
        /// </summary>
        public object Item { get; private set; }

        /// <summary>
        /// Gets or sets the reason for the validation failure.
        /// </summary>
        public string Reason { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFailureException"/>
        /// class.
        /// </summary>
        /// <param name="item">
        /// The item that failed validation.
        /// </param>
        /// <param name="reason">
        /// The reason for the validation failure.
        /// </param>
        public ValidationFailureException(
            object item,
            string reason
        )
        {
            Item   = item;
            Reason = reason;
        }
    }
}
