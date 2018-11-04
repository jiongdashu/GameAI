using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 定义在树搜索中的节点
/// 节点中包括当前节点的状态，父亲，到达此状态的行为，路径代价以及深度
/// 如果有两条路径可达此状态，那么就有两个不同的节点包含相同的状态
/// </summary>
/// 

namespace AI.Search
{
    public class Node  {
   
        int m_state;
        Node m_parent;
        int m_action;
        int m_path_cost;
        int m_depth = 0;

        public Node(int state,Node parent = null,int action = -1,int path_cost=0)
        {
            this.m_state = state;
            this.m_parent = parent;
            this.m_action = action;
            this.m_path_cost = path_cost;
            this.m_depth = 0;
            if (parent!=null)
            {
                this.m_depth = parent.m_depth + 1;
            }

        }

        /// <summary>
        /// 获取从当前接节点可以扩展的节点
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        public List<Node> expand(Problem problem)
        {
            List<Node> nodes = new List<Node>();
            foreach(int action in problem.actions(m_state))
            {
                nodes.Add(child_node(problem, action));
            }
            return nodes;
        }
        /// <summary>
        /// 获取在当前状态下采取某一行为获得的下一状态
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public Node child_node(Problem problem,int action)
        {
            int next_state = problem.result(m_state, action);
            Node next_node= new Node(next_state,this,action,
                problem.path_cost(m_path_cost,m_state,action,next_state));
            return next_node;
        }
        /// <summary>
        /// 获取到达当前节点的行为列表
        /// </summary>
        /// <returns></returns>
        public List<int> get_solution()
        {
            List<int> solution = new List<int>();
            foreach(Node node in get_path())
            {
                //去掉第一个，还未添加
                solution.Add(node.m_action);
            }
            return solution;
            
        }
        /// <summary>
        /// 获取从根节点到此节点的路径
        /// </summary>
        /// <returns></returns>
       public List<Node> get_path()
        {
            Node now = this;
            List<Node> path_back = new List<Node>();
            while (now!=null)
            {
                path_back.Add(now);
                now = now.m_parent;
            }
            path_back.Reverse();
            return path_back;
        }

 
    }
}

