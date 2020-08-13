using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPlayerName : MonoBehaviour
{
    public GameSettings gm;
    public TMP_InputField name;
    public void PlayerNameChanged()
    {
        gm.NickName = name.text;
    }
}
