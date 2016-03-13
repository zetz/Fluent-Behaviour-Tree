using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBehaviourTree
{
    /// <summary>
    /// Interface for behaviour tree nodes.
    /// </summary>
    public interface IBehaviourTreeNode
    {
        /// <summary>
        /// Name of the node.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        BehaviourTreeStatus Tick(TimeData time);

        /// <summary>
        /// Traversese the child nodes.
        /// </summary>
        /// <param name="depth">Depth of the tree node.</param>
        /// <param name="func">Action delegate for node.</param>
        void Traverse(ref int depth, Action<IBehaviourTreeNode> func);

    }
}
