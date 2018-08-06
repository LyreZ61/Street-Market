using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachClickBauen : MonoBehaviour {

    public void BauenNow(GameObject go)
    {
        Instantiate(go, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
