using UnityEngine;
using TMPro;

public class InputFieldOnlyNumbers : MonoBehaviour
{
    void Start()
    {
        TMP_InputField inputField = GetComponent<TMP_InputField>();
        inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
    }
}
