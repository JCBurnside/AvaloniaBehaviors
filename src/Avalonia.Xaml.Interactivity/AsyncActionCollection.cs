using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Avalonia.Xaml.Interactivity
{
    /// <summary>
    /// Represents a collection of <see cref="IAction"/>'s or <see cref="IAsyncAction"/>'s.
    /// </summary>
    public sealed class AsyncActionCollection : Collections.AvaloniaList<AvaloniaObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncActionCollection"/> class.
        /// </summary>
        public AsyncActionCollection()
        {
            this.CollectionChanged += AsyncActionCollection_CollectionChanged;
        }

        private void AsyncActionCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            NotifyCollectionChangedAction collectionChange = eventArgs.Action;

            if (collectionChange == NotifyCollectionChangedAction.Reset)
            {
                foreach (AvaloniaObject item in this)
                {
                    VerifyType(item);
                }
            }
            else if (collectionChange == NotifyCollectionChangedAction.Add || collectionChange == NotifyCollectionChangedAction.Replace)
            {
                AvaloniaObject changedItem = (AvaloniaObject)eventArgs.NewItems[0];
                VerifyType(changedItem);
            }
        }

        private void VerifyType(AvaloniaObject avaloniaObject)
        {
            if(!(avaloniaObject is IAsyncAction || avaloniaObject is IAction))
            {
                throw new InvalidOperationException("Only IAction and IAsyncAction types are supported in an ActionCollection.");
            }
        }
    }
}
