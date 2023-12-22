using UnityEngine;

public class MsgTest : MonoBehaviour
{
    public MsgA msgA;
    private void OnGUI()
    {
        int index = 0;

        if (GUI.Button(GetRect(index++), "AddListener"))
        {
            msgA.AddListener();
        }

        if (GUI.Button(GetRect(index++), "RemoveListener"))
        {
            msgA.RemoveListener();
        }

        if (GUI.Button(GetRect(index++), "SendGoToLevel"))
        {
            // 发送泛型消息
            GameNotifycation.GetInstance().Notify<int>(ENUM_MSG_TYPE.MSG_GO_TO_LEVEL, 111);
        }

        if (GUI.Button(GetRect(index++), "SendChangeScene"))
        {
            GameNotifycation.GetInstance().Notify(ENUM_MSG_TYPE.MSG_CHANGE_SCENE);
        }

        if (GUI.Button(GetRect(index++), "PathFind"))
        {
            // 发送结构体消息
            NpcData npcData = new NpcData();
            npcData.id = 222;
            
            GameNotifycation.GetInstance().Notify<NpcData>(ENUM_MSG_TYPE.MSG_PATH_FIND, npcData);
        }

        if (GUI.Button(GetRect(index++), "MoveToExit"))
        {
            // 发送类类型数据消息
            PlayerData data = new PlayerData();
            data.id = 333;
            GameNotifycation.GetInstance().Notify<PlayerData>(ENUM_MSG_TYPE.MSG_MOVE_TO_EXIT, data);
        }
    }

    private int MaxCol = 2;
    private Rect GetRect(int index)
    {
        float x = 100 + (index % MaxCol) * 200;
        float y = 100 + (index / MaxCol) * 100;
        float width = 150;
        float height = 50;
        return new Rect(x, y, width, height);
    }

}
