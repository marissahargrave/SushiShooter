using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceBowlDemo : MonoBehaviour
{
    [SerializeField]
    GameObject slider;
    public void SetFillLevel()
    {
        Material mat = this.gameObject.GetComponent<MeshRenderer>().material;
        mat.SetFloat("FillLevel", slider.GetComponent<UnityEngine.UI.Slider>().value);
    }


}
