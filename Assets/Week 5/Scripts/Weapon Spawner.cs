using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPreFab;
    public Transform weaponSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Weapon()
    {
            Instantiate(weaponPreFab, weaponSpawn.position, weaponSpawn.rotation);
        
    }

   
}
