using UnityEngine;

public struct NpcData
{
    public int id;
}

public class PlayerData
{
    public int id;
}

public class MsgA : MonoBehaviour
{
    private bool isAddListener = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void GoToLevel(int level)
    {
        Debug.LogError("GoToLevel:" + level);
    }

    private void ChangeScene()
    {
        Debug.LogError("ChangeScene");
    }

    private void PathFind(NpcData data)
    {
        Debug.LogError("PathFind:NpcId:" + data.id);
    }

    private void MoveToExit(PlayerData data)
    {
        Debug.LogError("MoveToExit:PlayerId:" + data.id);
    }

    public void AddListener()
    {
        //if (isAddListener)
        //{
        //    return;
        //}
        //isAddListener = true;
        // 添加泛型消息
        GameNotifycation.GetInstance().AddEventListener<int>(ENUM_MSG_TYPE.MSG_GO_TO_LEVEL, GoToLevel);
        GameNotifycation.GetInstance().AddEventListener(ENUM_MSG_TYPE.MSG_CHANGE_SCENE, ChangeScene);

        // 添加结构体类型消息
        GameNotifycation.GetInstance().AddEventListener<NpcData>(ENUM_MSG_TYPE.MSG_PATH_FIND, PathFind);
        // 添加类类型数据消息
        GameNotifycation.GetInstance().AddEventListener<PlayerData>(ENUM_MSG_TYPE.MSG_MOVE_TO_EXIT, MoveToExit);
    }

    public void RemoveListener()
    {
        //if (!isAddListener)
        //{
        //    return;
        //}
        //isAddListener = false;
        // 移除泛型消息
        GameNotifycation.GetInstance().RemoveEventListener<int>(ENUM_MSG_TYPE.MSG_GO_TO_LEVEL, GoToLevel);
        GameNotifycation.GetInstance().RemoveEventListener(ENUM_MSG_TYPE.MSG_CHANGE_SCENE, ChangeScene);

        // 移除结构体类型消息
        GameNotifycation.GetInstance().RemoveEventListener<NpcData>(ENUM_MSG_TYPE.MSG_PATH_FIND, PathFind);
        // 移除类类型数据消息
        GameNotifycation.GetInstance().RemoveEventListener<PlayerData>(ENUM_MSG_TYPE.MSG_MOVE_TO_EXIT, MoveToExit);
    }

    private void OnDisable()
    {
    }
}
