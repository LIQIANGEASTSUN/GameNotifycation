using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RegisterEvent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            UnRegisterEvent();
        }
    }

    private void OnDestroy()
    {
        UnRegisterEvent();
    }

    private void AMessage()
    {
        Debug.LogError("AMessage");
    }

    private void BMessage(int value)
    {
        Debug.LogError("BMessage:" + value);
    }

    private void CMessage(CObject cObject)
    {
        Debug.LogError("CMessage number:" + cObject.number + "   value:" + cObject.value);
    }

    private void DMessage(DData dData)
    {
        Debug.LogError("DMessage pirce:" + dData.pirce + "    result:" + dData.result);
    }

    private void RegisterEvent()
    {
        GameNotifycation.GetInstance().AddEventListener(ENUM_MSG_TYPE.MSG_A, AMessage);
        GameNotifycation.GetInstance().AddEventListener<int>(ENUM_MSG_TYPE.MSG_B, BMessage);
        GameNotifycation.GetInstance().AddEventListener<CObject>(ENUM_MSG_TYPE.MSG_C, CMessage);
        GameNotifycation.GetInstance().AddEventListener<DData>(ENUM_MSG_TYPE.MSG_D, DMessage);
    }

    private void UnRegisterEvent()
    {
        GameNotifycation.GetInstance().RemoveEventListener(ENUM_MSG_TYPE.MSG_A, AMessage);
        GameNotifycation.GetInstance().RemoveEventListener<int>(ENUM_MSG_TYPE.MSG_B, BMessage);
        GameNotifycation.GetInstance().RemoveEventListener<CObject>(ENUM_MSG_TYPE.MSG_C, CMessage);
        GameNotifycation.GetInstance().RemoveEventListener<DData>(ENUM_MSG_TYPE.MSG_D, DMessage);
    }

}


public class CObject
{
    public int number;
    public int value;
}

public struct DData
{
    public int pirce;
    public bool result;
}