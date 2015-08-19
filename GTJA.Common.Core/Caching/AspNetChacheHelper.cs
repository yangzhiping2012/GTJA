using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace GTJA.Common.Core.Caching
{
    public class AspNetChacheHelper
    {

        /// <summary>
        /// 增加一个缓存对象
        /// </summary>
        /// <param name="strKey">键值名称</param>
        /// <param name="valueObj">被缓存对象</param>
        /// <param name="timeSpan">缓存失效时间，默认为3分钟</param>
        /// <param name="priority">保留优先级(枚举数值)，1最不会被清除，6最容易被内存管理清除,0为default
        /// 【1:NotRemovable；2:High；3:AboveNormal；4:Normal；5:BelowNormal；6:Low】</param>
        /// <returns>缓存写入是否成功true 、 false</returns>
        public static bool InsertCache(string strKey, object valueObj, TimeSpan timeSpan, int priority)
        {
            TimeSpan ts;
            if (strKey != null && strKey.Length != 0 && valueObj != null)
            {
                //建立回调委托的一个实例

                //onRemove是委托执行的函数，具体方法看下面的onRemove(...)
                CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);
                #region 失效时间设置
                if (timeSpan == null)
                {
                    ts = new TimeSpan(0, 3, 0);//如果不进行设置则为三分钟
                }
                else
                {
                    ts = timeSpan;
                }
                #endregion
                #region System.Web.Caching.Cache 对象中存储的项的相对优先级

                CacheItemPriority cachePriority;
                switch (priority)
                {
                    case 6:
                        cachePriority = CacheItemPriority.Low;
                        break;
                    case 5:
                        cachePriority = CacheItemPriority.BelowNormal;
                        break;
                    case 4:
                        cachePriority = CacheItemPriority.Normal;
                        break;
                    case 3:
                        cachePriority = CacheItemPriority.AboveNormal;
                        break;
                    case 2:
                        cachePriority = CacheItemPriority.High;
                        break;
                    case 1:
                        cachePriority = CacheItemPriority.NotRemovable;
                        break;
                    default:
                        cachePriority = CacheItemPriority.Default;
                        break;
                }
                #endregion

                HttpRuntime.Cache.Insert(strKey, valueObj, null, DateTime.Now.Add(ts), System.Web.Caching.Cache.NoSlidingExpiration, cachePriority, callBack);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断缓存对象是否存在
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        /// <returns>是否存在true 、false</returns>
        public static bool IsExist(string strKey)
        {
            return HttpRuntime.Cache[strKey] != null;
        }

        /// <summary>
        /// 读取缓存对象
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        /// <returns>缓存对象，objec类型</returns>
        public static object GetCache(string strKey)
        {//取出值

            if (HttpRuntime.Cache[strKey] != null)
            {
                object obj = HttpRuntime.Cache[strKey];
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除缓存对象
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        public static void Remove(string strKey)
        {
            if (HttpRuntime.Cache[strKey] != null)
            {
                HttpRuntime.Cache.Remove(strKey);
            }
        }

        /// <summary>
        /// 根据设置的正则表达式清除缓存对象；
        /// 该方法使用正则匹配要删除的键值对象，如果键值命名统一规范，可批处理清除相关缓存数据O(∩_∩)O
        /// </summary>
        /// <param name="pattern">匹配键值的正则表达式</param>
        public static void RemoveByRegexp(string pattern)
        {
            if (pattern != "")
            {
                IDictionaryEnumerator enu = HttpRuntime.Cache.GetEnumerator();
                while (enu.MoveNext())
                {
                    string key = enu.Key.ToString();
                    if (Regex.IsMatch(key, pattern))
                    {
                        Remove(key);
                    }
                }
            }
        }

        /// <summary>
        /// 清除所有缓存对象
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enu = HttpRuntime.Cache.GetEnumerator();
            while (enu.MoveNext())
            {
                Remove(enu.Key.ToString());
            }
        }

        public static CacheItemRemovedReason reason;
        /// <summary>
        /// 此方法在值失效之前调用，可以用于在失效之前更新数据库，或从数据库重新获取数据
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="obj"></param>
        /// <param name="reason"></param>
        private static void onRemove(string strKey, object obj, CacheItemRemovedReason r)
        {
            reason = r;
        }
    }
}
