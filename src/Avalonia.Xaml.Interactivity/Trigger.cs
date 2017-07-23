﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Avalonia.Metadata;

namespace Avalonia.Xaml.Interactivity
{
    /// <summary>
    /// A base class for behaviors, implementing the basic plumbing of <seealso cref="ITrigger"/>.
    /// </summary>
    public abstract class Trigger : Behavior, ITrigger
    {
        /// <summary>
        /// Identifies the <seealso cref="Actions"/> avalonia property.
        /// </summary>
        public static readonly DirectProperty<Trigger, ActionCollection> ActionsProperty =
            AvaloniaProperty.RegisterDirect<Trigger, ActionCollection>(nameof(Actions), o => o.Actions);

        /// <summary>
        /// Gets the collection of actions associated with the behavior. This is a avalonia property.
        /// </summary>
        [Content]
        public ActionCollection Actions
        {
            get
            {
                ActionCollection actionCollection = GetValue(ActionsProperty);
                if (actionCollection == null)
                {
                    actionCollection = new ActionCollection();
                    SetValue(ActionsProperty, actionCollection);
                }

                return actionCollection;
            }
        }
    }
}
