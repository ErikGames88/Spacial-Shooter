using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 10f; 

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(lifetime);

        if (gameObject != null && gameObject.scene.isLoaded)
        {
            Destroy(gameObject);
        }
    }
}
