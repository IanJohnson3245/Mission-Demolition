using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Breakable : MonoBehaviour{

   

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.TryGetComponent<Projectile>(out Projectile script)){
            Destroy(this.gameObject);
            print("Projectile");
        }
    }
}
