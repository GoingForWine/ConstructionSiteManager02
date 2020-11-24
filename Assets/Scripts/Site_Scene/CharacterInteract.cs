using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject interactMenu;

    private bool hasBeenPressed;

    // Update is called once per frame
    void Update()
    {
        if (hasBeenPressed == true)
        {
            //Debug.Log("Press has been registered");
            interactMenu.SetActive(true);

            hasBeenPressed = false;
        }
    }

    // Register when player clicks/touches character
    private void OnMouseDown()
    {
        hasBeenPressed = true;
    }
}
