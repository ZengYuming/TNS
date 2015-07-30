using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TF.Utility.Mode
{
    public class Singleton<T> where T : class,new()
    {
        private static T _instance;
        public static T Instance {
            get {
                try {
                    if (Singleton<T>._instance == null) {
                        object obj;
                        Monitor.Enter(obj = Singleton<T>.lockHelper);
                    }
                }
                catch (Exception ex){
                //todo: log
                }
                return Singleton<T>._instance;
            }
        }
    }
}
