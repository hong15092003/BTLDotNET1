using System.Collections.ObjectModel;


namespace BTLDotNET1.Models
{
   public partial class TreeNode
    {
        public object Child { get; set; }
        public ObservableCollection<TreeNode> Children { get; set; }

        public TreeNode()
        {
            Children = new ObservableCollection<TreeNode>();
        }
    }
}
