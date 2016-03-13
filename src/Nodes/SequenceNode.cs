using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBehaviourTree
{
    /// <summary>
    /// Runs child nodes in sequence, until one fails.
    /// </summary>
    public class SequenceNode : IParentBehaviourTreeNode
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// List of child nodes.
        /// </summary>
        private List<IBehaviourTreeNode> children = new List<IBehaviourTreeNode>(); //todo: this could be optimized as a baked array.

        public SequenceNode(string name)
        {
            this.name = name;
        }

        public BehaviourTreeStatus Tick(TimeData time)
        {
            foreach (var child in children)
            {
                var childStatus = child.Tick(time);
                if (childStatus != BehaviourTreeStatus.Success)
                {
                    return childStatus;
                }
            }

            return BehaviourTreeStatus.Success;
        }

        /// <summary>
        /// Add a child to the sequence.
        /// </summary>
        public void AddChild(IBehaviourTreeNode child)
        {
            children.Add(child);
        }

        public void Traverse(ref int depth, Action<IBehaviourTreeNode> func) {
            func(this);
            depth += 1;
            foreach (var n in children) {
                func(n);
            }
            depth -= 1;
        }
    }
}
