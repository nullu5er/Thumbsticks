using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControls : MonoBehaviour
{
    public Text label;
    TouchScreenKeyboard keyboard;

    public void OnEditLabel()
    {
        // use extra parameters here to set keyboard type, turn off auto-correct etc
        keyboard = TouchScreenKeyboard.Open(label.text);
    }

    private void Update()
    {
        // poll while the keyboard is active, and update the text
        if (keyboard != null && keyboard.active)
            label.text = keyboard.text;
    }
}
