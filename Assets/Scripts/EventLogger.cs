using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Quick script that can be used log an event from whatever that needs a reference to a monobehaviour
 * Useful for example when finding out if/when a Unity Event was triggered
 */
public class EventLogger : MonoBehaviour
{
    public void Log(string log)
    {
        Debug.Log(log);
    }
}
