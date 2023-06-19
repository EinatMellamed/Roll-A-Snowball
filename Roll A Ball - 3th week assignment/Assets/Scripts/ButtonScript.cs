using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public class ButtonHandler : MonoBehaviour
    {
        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(HandleButtonClick);
        }

        private void HandleButtonClick()
        {
            // Add your button click logic here
            Debug.Log("Button Clicked!");
        }
    }
}
