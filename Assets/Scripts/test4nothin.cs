using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test4nothin : MonoBehaviour
{

    //[SerializeField]
    //private bool flag = false;

    public bool flag = false;

    [Header("Number Ctrl")]
    [Range(0f, 1f)]
    public float value = 0;
    [Range(0, 10)]
    public int val2 = 0;


}
