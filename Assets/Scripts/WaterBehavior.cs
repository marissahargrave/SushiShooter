using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject.GetComponent<FireBehavior>());
        foreach(FireBehavior fire in collider.gameObject.GetComponentsInChildren<FireBehavior>())
        {
            Destroy(fire.gameObject);
        }
    }
}
