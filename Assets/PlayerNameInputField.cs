﻿using UnityEngine.UI;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using System.Collections;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    
    const string playerNamePrefKey = "PlayerName";

    void Start() {

        string defaultName = string.Empty;
        InputField _inputField = this.GetComponent<InputField>();

        if (_inputField != null) {
            if (PlayerPrefs.HasKey(playerNamePrefKey)) {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    void SetPlayerName(string name) {
        if (string.IsNullOrEmpty(name)) {
            Debug.LogError("The player name is empty");
            return;
        }

        PhotonNetwork.NickName = name;

        PlayerPrefs.SetString(playerNamePrefKey, name);
    }

}
