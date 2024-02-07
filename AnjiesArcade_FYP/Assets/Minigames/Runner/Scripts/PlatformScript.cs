using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlatformScript : MonoBehaviour
{
    public List<GameObject> platforms;
    public GameObject ground;
    //public GameObject player;
    public static sbyte groundLen = 30;
    public static sbyte groundCount = 5;
    Vector3 spawnPoint;
    private Vector3 displacement = new Vector3(0, 0, groundLen * groundCount);
    private sbyte poolCounter = 0;
    public List<Transform> CoinSpawns;
    public List<Transform> ObsSpawns;
    public List<GameObject> ObstacleOptions;
    public GameObject Coin;
    public GameObject Obs;

    // Start is called before the first frame update
    void Start()
    {


        platforms = new List<GameObject>();
        for ( int i = 0; i < groundCount; i++ )
        {
            GroundMaker(i);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GroundMaker(int i)
    {

        platforms.Add((GameObject)Instantiate(ground, spawnPoint, Quaternion.identity));
        spawnPoint = platforms[i].transform.GetChild(0).transform.position;
        Instantiate(Coin, spawnPoint + new Vector3(randomNum(), 1f, randomNum()), Quaternion.identity);
        Instantiate(Obs, spawnPoint + new Vector3(randomNum(), 1f, randomNum()), Quaternion.identity);
    }

    public void GroundMove()
    {
        
        platforms[poolCounter].transform.position += displacement;
        coinGen();
        ObsGen();
        if (poolCounter > +groundCount - 2)
        {
            poolCounter = 0;
        }
        else
        {
            poolCounter++;
        }
    }

    public void coinGen()
    {
        
        CoinSpawns.Add(ground.transform.GetChild(5));
        CoinSpawns.Add(ground.transform.GetChild(6));
        CoinSpawns.Add(ground.transform.GetChild(7));
        Transform randomElement = CoinSpawns[Random.Range(0, CoinSpawns.Count)];
        
        Instantiate(Coin, platforms[poolCounter].transform.position + new Vector3(randomNum(), 1f, randomNum()), Quaternion.identity);
    }
    public void ObsGen()
    {
        ObsSpawns.Add(ground.transform.GetChild(8));
        ObsSpawns.Add(ground.transform.GetChild(9));
        //int x  = randomNum();
        Transform randomelement = ObsSpawns[Random.Range(0, ObsSpawns.Count)];
        Instantiate(Obs, platforms[poolCounter].transform.position + new Vector3(randomNum(), 1f, randomNum()), Quaternion.identity);
    }

    public int randomNum()
    {
        int randNum = Random.RandomRange(-4, 4);
        return randNum;
    }

    public int RandObs(int x)
    {
        int randNum = Random.RandomRange(0, 2);
        randNum = x;
        return randNum;
    }

}
