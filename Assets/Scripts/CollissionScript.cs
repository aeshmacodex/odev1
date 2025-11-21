using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CollissionScript : MonoBehaviour
{
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
