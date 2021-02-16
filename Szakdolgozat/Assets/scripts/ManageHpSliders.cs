using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ManageHpSliders : MonoBehaviour
{
    public List<GameObject> sliders = new List<GameObject>();
    void Start()
    {

        switch (PhotonNetwork.PlayerList.Length)
        {
            case 1:
                sliders[0].SetActive(true);
                sliders[0].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[0].NickName);
                break;
            case 2:
                sliders[0].SetActive(true);
                sliders[0].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[0].NickName);
                sliders[1].SetActive(true);
                sliders[1].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[1].NickName);
                break;
            case 3:
                sliders[0].SetActive(true);
                sliders[0].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[0].NickName);
                sliders[1].SetActive(true);
                sliders[1].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[1].NickName);
                sliders[2].SetActive(true);
                sliders[2].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[2].NickName);
                break;
            case 4:
                sliders[0].SetActive(true);
                sliders[0].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[0].NickName);
                sliders[1].SetActive(true);
                sliders[1].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[1].NickName);
                sliders[2].SetActive(true);
                sliders[2].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[2].NickName);
                sliders[3].SetActive(true);
                sliders[3].transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().SetText(PhotonNetwork.PlayerList[3].NickName);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
