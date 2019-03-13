using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Metadata;

namespace Avalonia.Xaml.Interactivity
{
    /// <summary>
    /// A base class for async behaviors, implementing the basic plumbing of <seealso cref="IAsyncTrigger"/>.
    /// </summary>
    public abstract class AsyncTrigger : Behavior, IAsyncTrigger
    {
        /// <summary>
        /// Identifies the <seealso cref="Actions"/> avalonia property.
        /// </summary>
        public static readonly AvaloniaProperty<AsyncActionCollection> ActionsProperty =
            AvaloniaProperty.RegisterDirect<AsyncTrigger, AsyncActionCollection>(nameof(Actions), t => t.Actions);

        private AsyncActionCollection _actions;

        /// <summary>
        /// Gets the collection of actions associated with the behavior. This is a avalonia property.
        /// </summary>
        [Content]
        public AsyncActionCollection Actions
        {
            get
            {
                if (_actions == null)
                    _actions = new AsyncActionCollection();
                return _actions;
            }
        }
    }
}
