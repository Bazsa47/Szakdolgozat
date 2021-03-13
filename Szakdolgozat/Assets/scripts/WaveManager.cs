using Photon.Pun;
using TMPro;
using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int wave = 0;
    private float multiplierByPlayerNum = 1;
    public int enemyNum;
    [SerializeField] private int maxEnemy;
    public GameObject[] enemySpawnpoints;

    void Start()
    {

       for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++){
            multiplierByPlayerNum += 0.25f;
       }
       StartCoroutine("StartNewWave");        

    }


    public void StartNextWave()
    {     
       
        StartCoroutine("StartNewWave");
    }
    public IEnumerator StartNewWave()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //kiírjuk a canvasra h wave cleared (fadein, fadeout) TODO
        if (wave >= 1)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("cleared").GetComponent<FadeIntext>().FadeIn();
            }
        }

        //ha új wave, akkor várunk egy kicsit, pár mp 
        yield return new WaitForSeconds(10);

        //növeljük a hullám számlálót.
        wave++; 

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PhotonView>().RPC("IncreaseWaves", RpcTarget.All, wave);
        }

        //kinyitjuk az ajtót 
        GameObject.Find("Gate Left").GetComponent<ManageGate>().OpenLeftGate();
        GameObject.Find("Gate Right").GetComponent<ManageGate>().OpenRightGate();

        //lespawnoljuk az új enemiket
        if (maxEnemy <= 40) maxEnemy++;
        SpawnEnemies();

        //várunk egy kicsit, és becsukjuk az ajtót
        StartCoroutine("WaitForDoor");

    }

    public IEnumerator WaitForDoor()
    {
        yield return new WaitForSeconds(10);

        GameObject.Find("Gate Left").GetComponent<ManageGate>().CloseLeftGate();
        GameObject.Find("Gate Right").GetComponent<ManageGate>().CloseRightGate();
    }

    public void SpawnEnemies()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            enemyNum = maxEnemy;
            for (int i = 0; i < maxEnemy; i++)
            {
                GameObject enemy = PhotonNetwork.InstantiateSceneObject("Enemy", enemySpawnpoints[i].transform.position, Quaternion.identity, 0);
                enemy.gameObject.GetComponent<EnemyClass>().Hp = 140f + wave * 10f * multiplierByPlayerNum;
            }
        }
    }

    [PunRPC]
    public void IncreaseWaves(int wave)
    {
        gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("WaveCounter").GetComponent<TextMeshProUGUI>().SetText(wave.ToString());
    }




}
