using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Search;

namespace AI.Search{
    public class GraphProblem : Problem<string>
    {
        Dictionary<string, Dictionary<string, int>> graph;

        public GraphProblem(string initial,string goal, Dictionary<string, Dictionary<string, int>> graph):base(initial,goal)
        {
            this.graph = graph;
        }
        /// <summary>
        /// 图中的行为列表就是下一个节点
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public override List<string> actions(string state)
        {
            List<string> actions = new List<string>();
            foreach (string action in graph[state].Keys)
            {
                actions.Add(action);
            }
           
            return actions;
        }

        /// <summary>
        /// 选择下一个节点的结果就是那个节点节点本身
        /// </summary>
        /// <param name="state"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public override string result(string state, string action)
        {
            return action;
        }

        public override int value(int state)
        {
            throw new System.NotImplementedException();
        }

        public override int path_cost(int c, string state1, int action, string state2)
        {
            return c + graph[state1][state2];
        }

        public override bool goal_test(string state)
        {
            return goalState == state;
        }
    }
}

