using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Trees;

namespace Ekom.Tree
{
    [Tree("settings", "ekomTree", TreeTitle = "Ekom", SortOrder = 10)]
    public class EkomTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            var nodes = new TreeNodeCollection();

            return nodes;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            // create a Menu Item Collection to return so people can interact with the nodes in your tree
            var menu = new MenuItemCollection();

            return menu;
        }

        protected override TreeNode CreateRootNode(FormDataCollection queryStrings)
        {
            var root = base.CreateRootNode(queryStrings);

            // set the icon
            root.Icon = "icon-store";
            // could be set to false for a custom tree with a single node.
            root.HasChildren = false;
            //url for menu
            root.MenuUrl = null;

            return root;
        }
    }
}
