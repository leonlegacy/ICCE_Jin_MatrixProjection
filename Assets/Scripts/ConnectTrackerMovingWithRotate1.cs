using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectTrackerMovingWithRotate1 : MonoBehaviour
{
    public Transform ConnectObject_info;
    public Transform OriginPos;
    public float movementscale = 5.0f;
    Vector3 OffsetPos;
    bool isConnetMove = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ResetOffset", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isConnetMove)
            ConnectMove();
    }
    public void ResetOffset()
    {
        OffsetPos = OriginPos.position - ConnectObject_info.position;

        isConnetMove = true;
        Debug.Log("Start Connect");
    }
    void ConnectMove()
    {
        transform.position = OffsetPos - ConnectObject_info.position * movementscale;
        transform.rotation = ConnectObject_info.rotation;
    }
}
