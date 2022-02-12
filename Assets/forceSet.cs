using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceSet : MonoBehaviour
{
    public Transform plateGroup;
    public Transform jointGroup;
    public float defaultDistance = 0.05f;
    public Transform[] joints;
    public Transform[] plates;

    private void Start()
    {
        plates = new Transform[plateGroup.childCount];
        joints = new Transform[jointGroup.childCount];
        for (int i = 0; i < plates.Length; i++)
        {
            plates[i] = plateGroup.GetChild(i);
            plates[i].localPosition = new Vector3(0f, 0f, i * defaultDistance);
            joints[i] = jointGroup.GetChild(i);
            joints[i].localPosition = new Vector3(0f, 0f, i * defaultDistance);
            plates[i].GetComponent<SpringJoint>().connectedBody = joints[i].GetComponent<Rigidbody>();
        }
    }
}
