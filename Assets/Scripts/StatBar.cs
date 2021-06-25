using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mhargrave.SushiShooter.UI.Stats
{
    public class StatBar : MonoBehaviour
    {
        /// <summary>
        /// Update value on the stat bar
        /// </summary>
        /// <param name="value"></param>
        public void UpdateStatBar(float value)
        {
            this.GetComponent<Slider>().value = value;
        }

        /// <summary>
        /// Set maximum value on the stat bar
        /// </summary>
        /// <param name="value"></param>
        public void SetMaxStat(float value)
        {
            this.GetComponent<Slider>().maxValue = value;
        }
    }
}
