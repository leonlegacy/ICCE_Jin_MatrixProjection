using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platesSpring : MonoBehaviour
{
    [Header("Plates Settings")]
    public float defaultDistance = 0.05f;
    public float stretchDistance = 1f;
    public float div = 10;
    public Transform[] plates;
    public Transform[] joints;

    public Transform plateGroup;
    public Transform jointGroup;
    
    private void Start()
    {
        plates = new Transform[plateGroup.childCount];
        joints = new Transform[jointGroup.childCount];
        for(int i = 0; i < plates.Length; i++)
        {
            plates[i] = plateGroup.GetChild(i);
            plates[i].localPosition = new Vector3(0f, 0f, i * defaultDistance);
            joints[i] = jointGroup.GetChild(i);
            joints[i].localPosition = new Vector3(0f, 0f, i * defaultDistance);
            plates[i].GetComponent<SpringJoint>().connectedBody = joints[i].GetComponent<Rigidbody>();
        }
        for (int i = 0; i < plates.Length; i++)
        {
            Renderer _renderer = plates[i].GetComponent<Renderer>();
            if (i%2 == 0)
            {
                _renderer.material.color = Color.white;
            }
            else
            {
                Color color = _renderer.material.color;
                color.a = 0;
                _renderer.material.color = color;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hand"))
        {
            for(int i = 1; i< plates.Length; i = i + 2)
            {
                Color color = plates[i].GetComponent<Renderer>().material.color;
                color.a = 1;
                plates[i].GetComponent<Renderer>().material.color = color;
            }
            joints[0].localPosition = new Vector3(0f, 0f, 0.1f);
            Invoke("joint0_reset", 0.5f);
            for (int i = 1; i<joints.Length; i++)
            {
                float e = 0;
                //joints[i].localPosition = new Vector3(0f, 0f, (i * stretchDistance));
                for (int j = 0; j<=i; j++)
                {
                    e = e + (float)j;
                }
                //Debug.Log("Joint " + i + " = " + e);
                joints[i].localPosition = new Vector3(0f, 0f, (e * stretchDistance)/div);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hand"))
        {
            for (int i = 0; i < joints.Length; i++)
            {
                joints[i].localPosition = new Vector3(0f, 0f, i * defaultDistance);
            }
            for (int i = 1; i < plates.Length; i = i + 2)
            {
                Color color = plates[i].GetComponent<Renderer>().material.color;
                color.a = 0;
                plates[i].GetComponent<Renderer>().material.color = color;
            }
        }
    }

    void joint0_reset()
    {
        joints[0].localPosition = new Vector3(0f, 0f, 0f);
    }

}
