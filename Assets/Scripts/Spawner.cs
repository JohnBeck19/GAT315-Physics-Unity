using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] KeyCode key;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Instantiate(prefab,transform);
        }
    }
}
