using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDestroy : MonoBehaviour
{
    [SerializeField] private float stamina = 8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > stamina)
        {
            Destroy(gameObject);
        }
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
