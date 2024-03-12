using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public static LevelManger main;

    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        main =  this;
    }
}