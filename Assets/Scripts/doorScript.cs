using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public bool unlockedDoor = false;
    public bool openDoor = false;

    public Quaternion closedRot;
    public Quaternion openRot;
    // Start is called before the first frame update
    void Start()
    {
        closedRot = transform.rotation;
        openRot = Quaternion.Euler(0,-90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(openDoor)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRot, Time.deltaTime);
        }
        
    }
}
