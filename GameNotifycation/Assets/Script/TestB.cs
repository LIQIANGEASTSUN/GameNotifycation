using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameNotifycation.GetInstance().Notify(ENUM_MSG_TYPE.MSG_A);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            GameNotifycation.GetInstance().Notify<int>(ENUM_MSG_TYPE.MSG_B, 10);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CObject cObject = new CObject();
            cObject.number = 100;
            cObject.value = 200;

            GameNotifycation.GetInstance().Notify<CObject>(ENUM_MSG_TYPE.MSG_C, cObject);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DData dData = new DData();
            dData.pirce = 30;
            dData.result = true;

            GameNotifycation.GetInstance().Notify<DData>(ENUM_MSG_TYPE.MSG_D, dData);
        }

    }
}
