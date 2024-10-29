using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemiga : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
        base.Update();
        transform.position += Time.deltaTime * (transform.up * -1) * 2;

    }
}
