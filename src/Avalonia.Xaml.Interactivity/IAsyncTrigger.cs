using System;
using System.Collections.Generic;
using System.Text;

namespace Avalonia.Xaml.Interactivity
{
    /// <summary>
    /// Interface implemented by all custom async triggers.
    /// </summary>
    public interface IAsyncTrigger
    {
        /// <summary>
        /// Gets the collection of actions associated with the behavior.
        /// </summary>
        AsyncActionCollection Actions { get; }
    }
}
