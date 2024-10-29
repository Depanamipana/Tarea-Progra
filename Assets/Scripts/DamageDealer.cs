using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("Damage this object will cause.")]
    [SerializeField] int damage = 100;
    public GameObject objectEffect;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        GameObject objFX = Instantiate(objectEffect);
        if (objFX)
        {
            objFX.transform.position = transform.position;
            objFX.transform.rotation = Quaternion.identity;
            objFX.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
