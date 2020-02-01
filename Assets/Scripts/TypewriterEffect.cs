using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public Text textField;
    private float delta = 0f;
    private float deltaPerChar = 0.4f;
    private int index = 0;
    private string text = "Mega testo super rilevante che cambia le sorti di ogni partita univocamente distinta.";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index < text.Length)
        {
            delta += Time.fixedDeltaTime;
            if (delta >= deltaPerChar)
            {
                delta -= deltaPerChar;
                index++;
                textField.text = text.Substring(0, index) + "<color=#00000000>" + text.Substring(index) + "</color>";
            }
        }
        
    }
}
