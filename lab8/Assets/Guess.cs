using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guess : MonoBehaviour
{

    [SerializeField]
    private OVRVirtualKeyboard virtualKeyboard;

    [SerializeField]
    private InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to InputField and Keyboard events
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
        // Add other necessary event subscriptions...
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to prevent memory leaks
        inputField.onEndEdit.RemoveListener(OnInputFieldEndEdit);
        // Remove other subscriptions...
    }

    private void OnInputFieldEndEdit(string arg0)
    {
        // Check if the input text is "Harry" when the Enter key is pressed
        if (arg0.Equals("Harry", System.StringComparison.OrdinalIgnoreCase))
        {
            inputField.text = "Congrats! You are right!";
        }
        else
        {
            // Optional: handle cases where the text is not "Harry"
            inputField.text = "Try Again!";
        }

        // Optionally deactivate the virtual keyboard
        //virtualKeyboard.gameObject.SetActive(false);
    }


}
