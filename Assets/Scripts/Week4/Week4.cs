using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Week4 : MonoBehaviour
{

    public UnityEvent myEvent;

    public delegate void tradEvent(string test);

    public tradEvent traditionalEvent;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myEvent.Invoke();
        }    
        
        // Add the tesdt function to our event( this is the subscripotion)
        traditionalEvent += TestFunction;
        // fire the even thius will trigger all events in list
        traditionalEvent.Invoke("sadsad wake up");
        // unsubscribe to events
        traditionalEvent -= TestFunction;
    }

    public void TestFunction(string myString)
    {
        Debug.Log("test");
    }
    
}
