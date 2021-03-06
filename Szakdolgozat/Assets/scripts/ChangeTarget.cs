﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeTarget : MonoBehaviour
{
    private EnemyClass ec;
    private List<PlayerThreat> threatList;
    void Start()
    {
        threatList = new List<PlayerThreat>();
        ec = GetComponent<EnemyClass>();

        //szedjük össze a lehetséges célpontokat
        

        //Nexus
        int viewId = GameObject.FindGameObjectWithTag("Nexus").GetComponent<PhotonView>().ViewID;
        float threat = GameObject.FindGameObjectWithTag("Nexus").GetComponent<Nexus>().threat;
        string playerName = "Nexus";
        threatList.Add(new PlayerThreat(viewId, threat, playerName));

        //Játékosok
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < targets.Length; i++)
        {
            viewId = targets[i].GetComponent<PhotonView>().ViewID;
            threat = 0;
            playerName = targets[i].GetComponent<PlayerClass>().PlayerName;
            PlayerThreat pt = new PlayerThreat(viewId,threat,playerName);
            threatList.Add(pt);
        }

        InvokeRepeating("ThreatFade",1f,1f);
    }

    public void ThreatFade()
    {
        for (int i = 0; i < threatList.Count; i++)
        {
            if (!threatList[i].playerName.Equals("Nexus"))
            {
                float distance = Vector3.Distance(PhotonView.Find(threatList[i].viewId).gameObject.transform.position,this.transform.position);
                float newThreat = threatList[i].threat - 1f - distance/2f;
                if (newThreat <= 0)
                    newThreat = 0;
                this.gameObject.GetComponent<PhotonView>().RPC("SetThreat", RpcTarget.All, threatList[i].viewId, newThreat);
            }          
        }
    }

    void Update()
    {
        //nézzük meg hogy melyik célpont a legveszélyesebb (maximum kiválasztás)
        ec.Target = ChooseMostDangerousPlayer();
    }

    public void GenerateThreat(int viewId, float distance, float weaponDmg)
    {
        float threat = 0;
        for (int i = 0; i < threatList.Count; i++)
        {
            if (threatList[i].viewId == viewId)
            {
                threat = threatList[i].threat;
            }
        }
        float newThreat = threat + (weaponDmg / distance);
        this.gameObject.GetComponent<PhotonView>().RPC("SetThreat",RpcTarget.All,viewId,newThreat);
    }

    [PunRPC]
    public void SetThreat(int viewId, float newThreat)
    {
        for (int i = 0; i < threatList.Count; i++)
        {
            if (threatList[i].viewId == viewId)
            {
                threatList[i].threat = newThreat;
                break;
            }
        }
    }
    public Transform ChooseMostDangerousPlayer()
    {
        float max = -1;
        int index = -1;
        for (int i = 0; i < threatList.Count; i++)
        {
            if (threatList[i].threat > max)
            {
                max = threatList[i].threat;
                index = i;
            }
        }
        Debug.Log(GetComponent<PhotonView>().ViewID + " Most Dangerous : " + threatList[index].playerName + "Threat : " + threatList[index].threat);
        return PhotonView.Find(threatList[index].viewId).gameObject.transform;
    }

    private class PlayerThreat
    {

        public int viewId;
        public float threat;
        public string playerName;

        public PlayerThreat(int viewId, float threat, string playerName)
        {
            this.viewId = viewId;
            this.threat = threat;
            this.playerName = playerName;
        }
    }
}
