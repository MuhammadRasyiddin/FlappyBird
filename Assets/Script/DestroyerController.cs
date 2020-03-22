using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Point")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag != "Indestructible")
        {
            Destroy(collision.gameObject);

        }
    }
}
