using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class OpenBook : MonoBehaviour
{
    public GameObject Notebook_Cover;
    
    // This class variable will now properly hold the reference
    public HingeJoint myHinge;

    void Start()
    {
        // REMOVED 'var' so it assigns to the class variable above, not a local one
        myHinge = Notebook_Cover.GetComponent<HingeJoint>();
        
        // CHANGED 'HingeJoint' to 'myHinge'
        if (myHinge != null)
        {
            myHinge.useMotor = false;
        }
    }

    public void OpenUp()
    {
        // CHANGED 'HingeJoint' to 'myHinge'
        if (myHinge != null)
        {
            myHinge.useMotor = true;
        }
        else
        {
            Debug.LogError("HingeJoint component is missing from the Notebook_Cover!", this);
        }
    }
}
