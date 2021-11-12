using System;
using System.Collections.Generic;
using blazor.treeview.dragdrop.Models;

namespace blazor.treeview.dragdrop.Services
{
    public enum Events
    {
        OnDragEnd,
        OnDragEnter,
        OnDragOver,
        OnDragStart,
    }

    public static class DragDropService
    {
        public static TreeItem DestionationItem { get; set; }

        public static TreeItem DraggableItem { get; set; }

        public static Events LastEvent { get; set; }

        public static void OnDragStart(TreeItem item)
        {
            if (LastEvent != Events.OnDragStart)
            {
                DraggableItem = item;
                LastEvent = Events.OnDragStart;
            }
        }

        public static void OnDragEnter(TreeItem item)
        {
            if (LastEvent != Events.OnDragEnter && item.Id != DraggableItem.Id)
            {
                DestionationItem = item;
                LastEvent = Events.OnDragEnter;
            }
        }

        public static void OnDragOver()
        {
            LastEvent = Events.OnDragOver;
        }

        public static void OnDragEnd()
        {
            if (LastEvent != Events.OnDragEnd)
            {
                var dragParent = DraggableItem.Parent;
                var destParent = DestionationItem.Parent;

                var destItemIndex = destParent.Children.IndexOf(DestionationItem);

                dragParent.Children.Remove(DraggableItem);
                destParent.Children.Insert(destItemIndex, DraggableItem);
                DraggableItem.Parent = destParent;

                LastEvent = Events.OnDragEnd;
            }
        }
    }
}
