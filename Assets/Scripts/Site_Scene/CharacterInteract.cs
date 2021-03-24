using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject interactMenu;
    [SerializeField]
    private Animator animController;

    public InteractTimeFrame not = new InteractTimeFrame();

    private int hasBeenPressedOnce = 0;

    
    // Register when player clicks/touches character
    private void OnMouseDown()
    {
        hasBeenPressedOnce++;

        if (hasBeenPressedOnce == 1)
        {
            interactMenu.SetActive(true);

            animController.SetBool("StartTalkingBool", true);
            not.NotifBool = false;

            hasBeenPressedOnce++;

        }
        else if (hasBeenPressedOnce > 1)
        {
            hasBeenPressedOnce = 2;
        }
    }
}
