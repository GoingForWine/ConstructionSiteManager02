using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMemory : MonoBehaviour
{
    // Floats created to take in the values from the relationshipFunctions script
    public float GoodMeterNumber;
    public float BadMeterNumber;

    public static SceneMemory Instance;

    // This 'awake' function is called when the above static is loaded
    void Awake()
    {
        if (Instance == null)
        {
            // Anything inside of the relationshipFunctions script which refers to the SceneMemory Instance will not be destroyed
            // This lets us remember all the values that the player has made before, giving us memory.
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            // This is just if the game is closed (I'm guessing though)
            Destroy(gameObject);
        }
    }
}
