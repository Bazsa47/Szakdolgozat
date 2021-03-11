using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeTarget : MonoBehaviour
{
    public Transform test;
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
    }

    void Update()
    {
        //nézzük meg hogy melyik célpont a legveszélyesebb (maximum kiválasztás)
        ec.Target = ChooseMostDangerousPlayer();
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
        Debug.Log("Most Dangerous : " + threatList[index].playerName);
        return PhotonView.Find(threatList[index].viewId).gameObject.transform;
    }

    private struct PlayerThreat
    {

        public int viewId;
        [SerializeField]
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
