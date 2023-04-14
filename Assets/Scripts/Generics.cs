using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generics : MonoBehaviour
{
    private int[] arrayOfInt = { 1, 2, 3 };
    private float[] arrayOfFloat = { 1.5f, 2.5f, 3.5f };
    private string[] arrayOfString = { "String1", "String2", "String3" };
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisplayButtonClick(arrayOfInt);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisplayButtonClick(arrayOfFloat);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisplayButtonClick(arrayOfString);
        }
    }
    public void DisplayButtonClick<Button>(Button[] arr)
    {
        foreach(Button infoType in arr)
        {
            print(infoType);
        }
    }
}
