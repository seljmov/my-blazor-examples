using System.Collections.Generic;

namespace blazor.treeview.dragdrop.Models
{
    public class TreeItem
    {
        public int Id { get; set; }

        public TreeItem Parent { get; set; }

        public IList<TreeItem> Children { get; set; }
    }
}
