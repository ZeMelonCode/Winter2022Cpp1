using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public Pickups[] pickupsPrefabArray;
    
    int randomPower;
    // Start is called before the first frame update
    void Start()
    {
        int randomPower = Random.Range(0,3);
        Instantiate(pickupsPrefabArray[randomPower], transform.position, transform.rotation);
    }
}
