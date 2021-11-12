using System.Collections.Generic;

namespace blazor.treeview.Models
{
    public class TreeItem
    {
        public string Text { get; set; }

        public IEnumerable<TreeItem> Children { get; set; }
    }
}
