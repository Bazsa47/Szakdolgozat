using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class PlayerClass : Entity
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private float threat;

    public float Threat {
        get => threat; 
        set => threat = value; 
    }
    public string PlayerName{
        get => playerName;
        set => playerName = value;
    }

    void Awake()
    {
        if (this.GetComponent<PhotonView>().IsMine)
        {
            this.GetComponent<PhotonView>().RPC("SetNames", RpcTarget.All, this.GetComponent<PhotonView>().ViewID,PhotonNetwork.LocalPlayer.NickName.ToString());
            this.PlayerName = PhotonNetwork.LocalPlayer.NickName.ToString();
        }

    }

    [PunRPC]
    public void SetNames(int viewID, string name)
    {
        PhotonView.Find(viewID).gameObject.GetComponent<PlayerClass>().PlayerName = name;
    }

    [SerializeField]
    private bool canTakeDmg = true;
    [SerializeField]
    private float countdown = 3f;
    public override void TakeDmg(float newHp)
    {
        Debug.Log("Dmg taken. HP:" + gameObject.GetComponent<PlayerClass>().Hp);
        this.GetComponent<PhotonView>().RPC("TakeDmgRPC", RpcTarget.All, this.GetComponent<PhotonView>().ViewID, newHp);       
    }

    private void Update()
    {
        if (canTakeDmg == false)
        {
            Debug.Log("asd");
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                canTakeDmg = true;
                countdown = 3f;
            }
        }
    }

    [PunRPC]
    public void ManageHpBars(string name, float newHp)
    {
        for (int i = 0; i < 4; i++)
        {
           if(PhotonNetwork.PlayerList[i].NickName == name)
           {
                Slider slider = gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find(i ==0 ? "HpBar" : "HpBar (" + i+")").GetComponent<Slider>();
                slider.value = newHp;
                break;
            }
        }
        //string name1 = gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar").transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text;
        //string name2 = gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar (1)").transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text;
        //string name3 = gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar (2)").transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text;
        //string name4 = gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar (3)").transform.Find("PlayerName").GetComponent<TextMeshProUGUI>().text;
        //if (name == name1)
        //{
        //    Slider slider = transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar").GetComponent<Slider>();
        //    slider.value = newHp;
        //}
        //else if (name == name2)
        //{
        //    Slider slider = transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar (1)").GetComponent<Slider>();
        //    slider.value = newHp;
        //}
        //else if (name == name3)
        //{
        //    Slider slider = transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar (2)").GetComponent<Slider>();
        //    slider.value = newHp;
        //}
        //else if (name == name4)
        //{
        //    Slider slider = transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("HpBar (3)").GetComponent<Slider>();
        //    slider.value = newHp;
        //}
    }

    [PunRPC]
    public void TakeDmgRPC(int viewID, float newHp)
    {
        if (canTakeDmg == true)
        {
            canTakeDmg = false;
            Debug.Log("Rpc called. hp: " + gameObject.GetComponent<PlayerClass>().Hp);
            PhotonView.Find(viewID).gameObject.GetComponent<PlayerClass>().Hp = newHp;
            Debug.Log("HP subtracted: " + gameObject.GetComponent<PlayerClass>().Hp);
            this.GetComponent<PhotonView>().RPC("ManageHpBars", RpcTarget.All, this.playerName, newHp);
        }
    }

    public override void Die()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        this.GetComponent<PhotonView>().RPC("ChangeScene", RpcTarget.All);
    }

    [PunRPC]
    public void ChangeScene()
    {
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.LoadLevel(0);
        }
    }
}
