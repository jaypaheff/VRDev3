using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class OpenBook : MonoBehaviour
{

    public GameObject Notebook_Cover;
    public HingeJoint HingeJoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var myHinge = Notebook_Cover.GetComponent<HingeJoint>();
        myHinge.useMotor = false;
    }

    // Update is called once per frame
    public void OpenUp()
    {
        HingeJoint.useMotor = true;
        
    }
}
