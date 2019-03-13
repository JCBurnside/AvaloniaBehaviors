﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Specialized;
using Avalonia.Collections;

namespace Avalonia.Xaml.Interactivity
{
    /// <summary>
    /// Represents a collection of <see cref="IAction"/>'s.
    /// </summary>
    public sealed class ActionCollection : AvaloniaList<AvaloniaObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCollection"/> class.
        /// </summary>
        public ActionCollection()
        {
            CollectionChanged += ActionCollection_CollectionChanged;
        }

        private void ActionCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
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

        private static void VerifyType(AvaloniaObject item)
        {
            if (!(item is IAction) && !(item is IAsyncAction))
            {
                throw new InvalidOperationException("Only IAction and IAsyncAction types are supported in an ActionCollection.");
            }
        }
    }
}
