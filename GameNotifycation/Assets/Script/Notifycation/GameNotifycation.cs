using System;
using System.Collections.Generic;

public class GameNotifycation : SingletonObject<GameNotifycation>
{

    //Handle
    /// <summary>
    /// 不包含参数的通知
    /// </summary>
    public delegate void NotifycationDelegate();
    /// <summary>
    /// 只包含一个参数的通知
    /// </summary>
    /// <typeparam name="T">可以是 值类型，也可以是引用类型</typeparam>
    /// <param name="args"></param>
    public delegate void NotifycationDelegate<T>(T args);

    /////////////////////////////////////////////////////////////////////////////////
    ///  不要试图添加包含 两个、三个、四个甚至更多参数的通知
    ///  如果有这多个参数需要传递，请创建结构体struct 或者类 class
    ///  以结构体或者类变量的形式传递
    ///  因为参数过多不利于使用，过长的参数容易因为次序错乱导致bug
    /////////////////////////////////////////////////////////////////////////////////

    private Dictionary<ENUM_MSG_TYPE, Delegate> eventDicListeners = new Dictionary<ENUM_MSG_TYPE, Delegate>();

    #region AddListener

    //添加监听
    public void AddEventListener(ENUM_MSG_TYPE msgType, NotifycationDelegate listener)
    {
        AddEventListener(msgType, (Delegate)listener);
    }

    public void AddEventListener<T>(ENUM_MSG_TYPE msgType, NotifycationDelegate<T> listener)
    {
        AddEventListener(msgType, (Delegate)listener);
    }

    private void AddEventListener(ENUM_MSG_TYPE msgType, Delegate cb)
    {
        Delegate list = null;
        if (eventDicListeners.TryGetValue(msgType, out list))
        {
            Delegate[] arr = list.GetInvocationList();
            foreach (var invo in arr)
            {
                // 如果已经存在不再重复添加
                if (Delegate.ReferenceEquals(invo.Method, cb.Method) && Delegate.ReferenceEquals(invo.Target, cb.Target))
                {
                    //UnityEngine.Debug.LogError("已存在:" + invo.Method.Name);
                    return;
                }
            }
        }

        eventDicListeners[msgType] = Delegate.Combine(list, cb);
    }

    #endregion

    #region RemoveListener

    //移除监听
    public void RemoveEventListener(ENUM_MSG_TYPE msgType, NotifycationDelegate listener)
    {
        RemoveEventListener(msgType, (Delegate)listener);
    }

    public void RemoveEventListener<T>(ENUM_MSG_TYPE msgType, NotifycationDelegate<T> listener)
    {
        RemoveEventListener(msgType, (Delegate)listener);
    }

    private void RemoveEventListener(ENUM_MSG_TYPE msgType, Delegate cb)
    {
        Delegate list = null;
        if (GetEventListener(msgType, out list))
        {
            eventDicListeners[msgType] = Delegate.Remove(list, cb);
            if (null == eventDicListeners[msgType])
            {
                RemoveEventListener(msgType);
            }
        }
    }

    public void RemoveEventListener(ENUM_MSG_TYPE msgType)
    {
        eventDicListeners.Remove(msgType);
    }
    #endregion

    #region Notify
    public void Notify(ENUM_MSG_TYPE msgType)
    {
        Delegate list = null;
        if (GetEventListener(msgType, out list))
        {
            ((NotifycationDelegate)list)();
        }
    }

    public void Notify<T>(ENUM_MSG_TYPE msgType, T args)
    {
        Delegate list = null;
        if (GetEventListener(msgType, out list))
        {
            ((NotifycationDelegate<T>)list)(args);
        }
    }
    #endregion

    //是否存在指定事件的监听
    public bool GetEventListener(ENUM_MSG_TYPE msgType, out Delegate list)
    {
        return eventDicListeners.TryGetValue(msgType, out list);
    }
}
