using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject interactMenu;
    [SerializeField]
    private Animator animController;

    private int hasBeenPressedOnce = 0;

    
    // Register when player clicks/touches character
    private void OnMouseDown()
    {
        hasBeenPressedOnce++;

        if (hasBeenPressedOnce == 1)
        {
            //Debug.Log("Press has been registered");
            interactMenu.SetActive(true);

            animController.SetBool("StartTalkingBool", true);

            hasBeenPressedOnce++;

        }
        else if (hasBeenPressedOnce > 1)
        {
            hasBeenPressedOnce = 2;
        }
    }
}
