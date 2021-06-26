using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : IInteractable
{
    private bool isOn = false;
    public override void Interact()
    {
        ToggleOnOff();
    }

    public void SetIsOn(bool isOn)
    {
        this.isOn = isOn;
        SetWaterOn();
    }

    private void ToggleOnOff()
    {
        this.isOn = !this.isOn;
        SetWaterOn();
    }

    private void SetWaterOn()
    {
        bool includeInactive = true;
        foreach (ParticleSystem ps in this.gameObject.GetComponentsInChildren<ParticleSystem>(includeInactive))
        {
            if (ps.gameObject.GetComponent<WaterBehavior>())
            {
                ps.gameObject.SetActive(this.isOn);
            }
        }
    }
}
