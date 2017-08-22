using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class TreeNodeEntity : SaasBaseEntity
    {
        public const int LeafNodeType = 1;
        public const int NormalNodeType = 2;

        public TreeNodeEntity()
        {
            NodeType = LeafNodeType;
        }

        public virtual Guid ParentId { get; set; }
        public virtual int NodeType { get; set; }

        public virtual bool IsRoot()
        {
            return ParentId == Guid.Empty;
        }

        public virtual bool IsLeaf()
        {
            return this.NodeType.Equals(LeafNodeType);
        }

        public virtual TTreeNode SetChild<TTreeNode>(TTreeNode node) where TTreeNode : TreeNodeEntity
        {
            node.ParentId = this.Id;
            if (IsLeaf())
            {
                this.NodeType = TreeNodeEntity.NormalNodeType;
            }
            return node;
        }
    }
}
