using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public SkinnedMeshRenderer handR, handL;
    public bool isShowHands = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isShowHands = !isShowHands;
            setMeshVisible(isShowHands);
        }
    }

    public void setMeshVisible(bool flag)
    {
        handL.enabled = flag;
        handR.enabled = flag;
    }
}
