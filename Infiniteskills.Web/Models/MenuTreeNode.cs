using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infiniteskills.Web.Models
{
    public class MenuTreeNode
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public List<MenuTreeNode> Nodes { get; set; }
        public MenuTreeNode()
        {
            this.Nodes = new List<MenuTreeNode>();
        }
    }
}