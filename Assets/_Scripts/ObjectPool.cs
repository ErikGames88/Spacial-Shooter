using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    /* ---SINGLETON--- Variable shared by all objects
    The class that is Singleton must have a variable that was:
    * Public
    * Static
    * Same type as the class itself */
    public static ObjectPool SharedInstance; // Broken nomenclature to emphasise that it is a singleton

    [SerializeField]
    [Tooltip("Bullet shot by Player")]
    private GameObject prefab;

    /*[SerializeField]
    [Tooltip("Bullet shot by Enemy")]
    private GameObject enemyPrefab;*/


    // OBJECT POOLING (PROPERTIES)

    [SerializeField]
    [Tooltip("List where the pooled objects are located")]
    private List<GameObject> pooledObjects; // List where the pooled objects are located 
    
    [SerializeField]
    [Tooltip("Number of objects to pool (Number of lasers")]
    private int amountToPool; // Number of objects to pool (Number of bullets)

    void Awake()
    {
        if(SharedInstance == null) // Check that there is a pool in the scene (There will be no other)
        {
            SharedInstance = this; // "This" is the pool
        } 
        else
        {
            Debug.LogWarning("Object Pool duplicates must be destroyed: ", gameObject);
            Destroy(gameObject); // Destroy other possible pools (there is only one)
        }
    }

    void Start()
    {
        // OBJECT POOLING (BUILD)
        pooledObjects = new List<GameObject>(); // Initialise the list where the bullets will be pooled
        GameObject tmp; // Temporal object

        for(int i = 0; i < amountToPool; i++) // Since 0 to the amount to bullets, add +1
        {
            tmp = Instantiate(prefab); // Instantiate a new bullet stored in the temporal variable
            tmp.SetActive(false); // Disable the bullet so that it does not appear on the screen
            pooledObjects.Add(tmp); // Add the bullet to the already instantiated list
        }
    }

    /// <summary>
    /// Method that gets the first bullet (prefab) in the List
    /// </summary>
    /// <returns> The object (prefab) in the first position [i] in the List (Loop for) </returns>
    /// <returns> Null value if there no objects in the List </returns>
    public GameObject GetFirstPooledObject() // POOLING OBJECT (METHOD)
    {
        for(int i = 0; i < amountToPool; i++)
        {
            // Check if the first object in the list is not active in the Hierarchy (first position [i] = 0)
            if(!pooledObjects[i].activeInHierarchy) // It was desable before in Start
            {
                return pooledObjects[i]; // If it is not, return it
            }
        }

        return null; // Return a null value if there are no bullets because there would be no value to return
    }

}
