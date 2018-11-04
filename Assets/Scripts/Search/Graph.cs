using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Search
{
    public static class CreatGraph
    {
        public static Graph UndirectedGraph(Dictionary<string, Dictionary<string, int>> graph_dict = null) { return new Graph(graph_dict, false); }
    }
    /// <summary>
    /// 图的定义：图包括节点和节点之间的边
    /// 采用字典的方式进行表达，形如 Graph({'A': {'B': 1, 'C': 2})
    /// 表示图中有三个节点，其中A到B一单位距离，A到C二单位距离
    /// </summary>
    public class Graph : MonoBehaviour
    {
        Dictionary<string, Dictionary<string, int>> graph_dict;
        bool directed = true;

        public Graph(Dictionary<string, Dictionary<string, int>> graph_dict,bool directed)
        {
            this.graph_dict = graph_dict;
            this.directed = directed;
            if (!directed)
            {
                make_undirected();
            }
        }

        public void  make_undirected()
        {
            foreach(string a in graph_dict.Keys)
            {
                Dictionary<string, int> next_node = graph_dict[a];
                foreach(string b in next_node.Keys)
                {
                    connect(a, b, next_node[b]);
                }
            }
        }

        /// <summary>
        /// 在A，B节点之间加一条边，并且设置距离
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="distance"></param>
        public void connect(string a,string b,int distance)
        {
            //会不会出现异常         
             graph_dict[a].Add(b, distance);
            if (!directed)
            {
                graph_dict[b].Add(a, distance);
            }
        }

        /// <summary>
        ///获取A，B节点之间的距离
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int get(string a,string b)
        {
            return graph_dict[a][b];
        }
        /// <summary>
        ///获取A节点与下一节点的距离信息
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Dictionary<string,int> get(string a)
        {
            return graph_dict[a];
        }


    }
}

