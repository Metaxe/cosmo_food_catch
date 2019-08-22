using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthyFood : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "bottomBorder")
        {
            GameManager.Attempts -= 1;
            Destroy(this.gameObject);

        }
        else if(col.gameObject.name == "basket" ) {
            
            basketScript.speed += 0.1f;
            GameManager.Increase += 1;
            Destroy(this.gameObject);
        }
    }
}