using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public bool keycard = false;
    public bool nearDoor = false;
    public bool nearKeycard = false;
    public Transform thisDoor;
    

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Near door: " + nearDoor);
        // Debug.Log("keycard: " + keycard);
        if(Input.GetButtonDown("E")) 
        {
            if(nearDoor && keycard)
            {
                // Debug.Log("Pressed E");
                if(thisDoor !=null && !thisDoor.transform.GetComponent<doorScript>().unlockedDoor) 
                { 
                    thisDoor.transform.GetComponent<doorScript>().unlockedDoor = true;
                }

            else if(thisDoor != null && !thisDoor.transform.GetComponent<doorScript>().openDoor) 
            {
                thisDoor.transform.GetComponent<doorScript>().openDoor = true;
            }
        }

        else if (nearKeycard)
        {
            GameObject go = GameObject.Find("keycard");
            Destroy(go.gameObject);
            nearKeycard = false;
            keycard = true;
        }
    }
}

    void OnGUI() 
    {
        if(nearDoor)
        {
            if(keycard)
            {
                if(thisDoor !=null && !thisDoor.transform.GetComponent<doorScript>().unlockedDoor)
                {
                    GUI.Label(new Rect(Screen.width/2,Screen.height/2,Screen.width/10,Screen.height/10), "Press E to Unlock");
                }

                else if(thisDoor != null)
                {
                    GUI.Label(new Rect(Screen.width/2,Screen.height/2, Screen.width/10, Screen.height/10), "Press E to Open");
                }
            }

            else 
            {
                GUI.Label(new Rect(Screen.width/2, Screen.height/2,Screen.width/10, Screen.width/10), "You need a Keycard to Unlock!");
            }
        } 
        else if (nearKeycard)
        {
            GUI.Label(new Rect(Screen.width/2,Screen.height/2,Screen.width/10,Screen.height/10), "Press E to pickup Keycard");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Enter a collider");
        if(other.GetComponent<Collider>().gameObject.tag == "door")
        {
            // Debug.Log("Enter door collider");
            nearDoor = true;
            thisDoor = other.GetComponent<Collider>().transform;
        }
        if(other.GetComponent<Collider>().gameObject.tag == "keycard")
        {
            nearKeycard = true;
            // Debug.Log("Enter keycard collider");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Collider>().gameObject.tag == "door")
        {
            nearDoor = false;
            thisDoor = null;
        }
    }

}
