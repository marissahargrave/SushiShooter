using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable] public class _UnityEventFloat : UnityEvent<float> { }
public abstract class Mortal : MonoBehaviour
{
    [SerializeField]
    private _UnityEventFloat healthBarSubscriber;

    [SerializeField]
    protected _UnityEventFloat setMaxHealthStartSubscriber;

    private float health;
    private float healthInitial;
    /// <summary>
    /// Applies damage to the entity, lowering health value.
    /// </summary>
    /// <param name="damage">Amount of damage to apply</param>
    public void ApplyDamage(float damage)
    {
        this.health -= damage;
        healthBarSubscriber.Invoke(this.health);
    }

    /// <summary>
    /// Applies healing to the entity, increasing health value
    /// </summary>
    /// <param name="healing">Amount of damage to heal</param>
    public void ApplyHealing(float healing){
        this.health += healing;
        healthBarSubscriber.Invoke(this.health);
    }

    public float GetHealth()
    {
        return this.health;
    }

    protected void SetMaxHealth(float health)
    {
        setMaxHealthStartSubscriber.Invoke(health);
    }

    protected void SetInitialHealth(float health)
    {
        this.healthInitial = health;
        this.health = health;
        setMaxHealthStartSubscriber.Invoke(health);
        healthBarSubscriber.Invoke(health);
    }
}
