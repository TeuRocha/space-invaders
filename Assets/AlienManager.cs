using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{

    public List<alienControl> aliens = new List<alienControl>();
    private bool directionChangedThisFrame = false;

    void LateUpdate()
    {
        directionChangedThisFrame = false;
    }

    // Start is called before the first frame update
    public void ChangeDirectionForAll()
    {
        if (directionChangedThisFrame) return;
        foreach (alienControl alien in aliens)
        {
            alien.ChangeState();
            alien.transform.position += new Vector3(0, -0.5f, 0);
        }
        directionChangedThisFrame = true;
    }

}
