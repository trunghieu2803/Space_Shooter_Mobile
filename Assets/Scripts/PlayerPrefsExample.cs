using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsExample : MonoBehaviour
{
    int exampleInt = 10;
    float exampleFloat = 1.5f;
    string exampleString = "SaveMe";

    int loadInt;
    float loadFloat;
    string loadString;
    // Start is called before the first frame update
    void Start()
    {
        //SAVE
        //integer
        PlayerPrefs.SetInt("intKey", exampleInt);

        //float
        PlayerPrefs.SetFloat("floatKey", exampleFloat);

        //string
        PlayerPrefs.SetString("stringKey", exampleString);

        //LOAD
        //integer
        loadInt = PlayerPrefs.GetInt("intKey", 0);

        //float
        loadFloat = PlayerPrefs.GetFloat("floatKey", 0);

        //string
        loadString = PlayerPrefs.GetString("stringKey", "Nothing");

        //DELETE
        PlayerPrefs.DeleteKey("intKey");
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
