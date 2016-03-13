using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBehaviourTree
{
    /// <summary>
    /// A behaviour tree leaf node for running an action.
    /// </summary>
    public class ActionNode : IBehaviourTreeNode
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name => name;

        /// <summary>
        /// The name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// Function to invoke for the action.
        /// </summary>
        private Func<TimeData, BehaviourTreeStatus> fn;

        /// <summary>
        /// node timer
        /// </summary>
        private TimeData timer;

        public ActionNode(string name, Func<TimeData, BehaviourTreeStatus> fn)
        {
            this.name=name;
            this.fn=fn;
            this.timer = new TimeData();
        }

        public BehaviourTreeStatus Tick(TimeData time)
        {
            timer.deltaTime = time.deltaTime;
            var status = fn(timer);
            if (status == BehaviourTreeStatus.Running) {
                timer.runningTime += time.deltaTime;
            } else {
                timer.runningTime = 0;
            }
            return status;
        }

        public void Traverse(ref int depth, Action<IBehaviourTreeNode> func) {
            func(this);
        }
    }
}
