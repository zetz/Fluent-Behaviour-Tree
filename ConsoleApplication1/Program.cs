using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBehaviourTree;
namespace ConsoleApplication1 {

    public class GameObject {

        public IBehaviourTreeNode tree;

        public void buildBehaviorTree() {
            var builder = new BehaviourTreeBuilder();
            tree = builder
                .Sequence("seq-0")
                    .Condition("condi-0", x => { return true; })
                    .Do("action-0", x => {
                        Console.WriteLine("seq-0, action-0");
                        return BehaviourTreeStatus.Success;
                    })
                    .Do("action-1", x => {
                        Console.WriteLine("seq-0, action-1");
                        return BehaviourTreeStatus.Failure;
                    })
                .End()
            .Build();
        }

        public void Update(float elapsedTime) {
            tree?.Tick(new TimeData(elapsedTime));
        }
    }

    class Program {
        static void Main(string[] args) {

            var obj = new GameObject();
            obj.buildBehaviorTree();

            //while (true) {
            //    obj.Update(1.0f);
            //    System.Threading.Thread.Sleep(1000);
            //} 
            int level = 0;
            obj.tree.Traverse(ref level, node => {
                
                var objType = node.GetType().Name;
                var nodeName = node.Name;
                Console.WriteLine($"[{level}]  {objType} - {nodeName}");
            });
            
        }
    }
}
