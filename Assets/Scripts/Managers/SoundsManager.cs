using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SoundsManager : MonoBehaviour
{
    static SoundsManager _instance = null;
    public static SoundsManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
