using System;
using System.Collections.Generic;
using System.Text;

namespace Avalonia.Xaml.Interactivity
{
    /// <inheritdoc/>
    /// <typeparam name="T">The object type to attach to</typeparam>
    public abstract class AsyncTriggerOfT<T> : AsyncTrigger where T : AvaloniaObject
    {
        /// <inheritdoc/>
        public new T AssociatedObject => base.AssociatedObject as T;

        /// <inheiritdoc/>
        protected override void OnAttached()
        {
            base.OnAttached();

            if(AssociatedObject == null)
            {
                string actualType = base.AssociatedObject.GetType().FullName;
                string expectedType = typeof(T).FullName;
                string message = string.Format("AssociatedObject is of type {0} but should be of type {1}.", actualType, expectedType);
                throw new InvalidOperationException(message);
            }
        }
    }
}
