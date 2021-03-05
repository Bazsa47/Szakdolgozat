using Photon.Pun;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int wave = 0;
    private float multiplierByPlayerNum = 1;
    public int enemyNum;
    [SerializeField] private int maxEnemy;
    public GameObject[] enemySpawnpoints;
    void Start()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            multiplierByPlayerNum += 0.25f;
        }
        StartNewWave();
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

    public void StartNewWave()
    {
        wave++; //ezt ki kell majd iratni az összes canvasra.
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PhotonView>().RPC("IncreaseWaves", RpcTarget.All, wave);
        }
        //kiírjuk a canvasra h wave cleared
        //ha új wave, akkor várunk egy kicsit, pár mp
        //kinyitjuk az ajtót
        //lespawnoljuk az új enemiket
        if(maxEnemy <= 40 ) maxEnemy++;
        SpawnEnemies();
        //becsukjuk az ajtót
    }

    [PunRPC]
    public void IncreaseWaves(int wave)
    {
        gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("WaveCounter").GetComponent<TextMeshProUGUI>().SetText(wave.ToString());
    }




}
