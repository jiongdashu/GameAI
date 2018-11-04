using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Search
{
    public abstract class Problem<T>  {
        protected T initialState;
        protected T goalState;
        public Problem(T initial, T goal)
        {
            initialState = initial;
            goalState = goal;
        }
        /// <summary>
        /// 给定当前状态，当前行为，获取下一个状态
        /// </summary>
        /// <param name="state"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public abstract T result(T state, T action);
        /// <summary>
        /// 获取当前状态下所有可能的行为列表
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract List<T> actions(T state);

        public abstract bool goal_test(T state);
        
        public virtual int  path_cost(int c, T state1,int action, T state2)
        {
            return c + 1;
        }

        public abstract int value(int state);
   
    }

}
