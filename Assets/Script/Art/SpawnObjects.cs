using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private bool spawnAlongY = false;
    [SerializeField] private int ObjectNumbers = 10;
    [SerializeField]  GameObject[] objectsToSpawn;  // fill in editor
    private GameObject rangeBorder;
    private float rangeXmin, rangeXmax, rangeZmin, rangeZmax;//先宣告產生物件的範圍用變數

    private float rangeYmin, rangeYmax;

    [SerializeField] bool randomScale;//亂數調整物件Scale用
    [SerializeField] Vector3 maxScale, minScale;
    //public bool isCollide;
    public Transform spawnHolder;

    private void Start()
    {
        rangeBorder = gameObject;//產生物件的範圍，就這個程式碼掛的方塊物件自己本身
        //Debug.Log("rangeBorder="+ rangeBorder);//確定一下有沒有抓對物件
        /*抓方塊的邊緣位置來設定產生物件的範圍*/
        Vector3 BorderSize = rangeBorder.GetComponent<Renderer>().bounds.size;
        //Debug.Log("rangeBorder.GetComponent<Renderer>().bounds.size=" + BorderSize);
        rangeXmin = rangeBorder.transform.position.x - (BorderSize.x / 2);
        rangeXmax = rangeBorder.transform.position.x + (BorderSize.x / 2);
        rangeZmin = rangeBorder.transform.position.z - (BorderSize.z / 2);
        rangeZmax = rangeBorder.transform.position.z + (BorderSize.z / 2);
        //Debug.Log("min X="+rangeXmin+", max X="+rangeXmax+", min Z="+rangeZmin+", max Z="+rangeZmax);//確定一下範圍有沒有抓對

        if (spawnAlongY)
        {
            rangeYmin = rangeBorder.transform.position.y - (BorderSize.y / 2);
            rangeYmax = rangeBorder.transform.position.y + (BorderSize.y / 2);
        }

        //Debug.Log("Object Length="+ objectsToSpawn.Length);
        for (int i = 0; i < ObjectNumbers / 2; i++)
        {
            PutObjects();
        }
    }

    //private void Update()
    //{
    //    if (isCollide)
    //        foreach (Transform child in spawnHolder)
    //            child.GetComponent<ColorHit>().isCollide = true;
    //}

    private void PutObjects()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length); //從所有物件類型當中隨機撈一個
        GameObject SpawnObj = objectsToSpawn[randomIndex];
        GameObject ObjHere1;
        GameObject ObjHere2;

        //Debug.Log("Random:" + SpawnObj);
        if (spawnAlongY)
        {
            ObjHere1 = GameObject.Instantiate(SpawnObj, new Vector3(Random.Range(rangeXmin, rangeXmax), Random.Range(rangeYmin, rangeYmax), Random.Range(rangeZmin, rangeZmax)), Quaternion.identity, rangeBorder.transform.parent);
            ObjHere1.transform.parent = spawnHolder;
            ObjHere2 = GameObject.Instantiate(SpawnObj, new Vector3(Random.Range(rangeXmin, rangeXmax), Random.Range(rangeYmin, rangeYmax), Random.Range(rangeZmin, rangeZmax)), Quaternion.identity, rangeBorder.transform.parent);
            ObjHere2.transform.parent = spawnHolder;
        }
        else
        {
            ObjHere1 = GameObject.Instantiate(SpawnObj, new Vector3(Random.Range(rangeXmin, rangeXmax), transform.position.y, Random.Range(rangeZmin, rangeZmax)), Quaternion.identity, rangeBorder.transform.parent);
            ObjHere1.transform.parent = spawnHolder;
            ObjHere2 = GameObject.Instantiate(SpawnObj, new Vector3(Random.Range(rangeXmin, rangeXmax), transform.position.y, Random.Range(rangeZmin, rangeZmax)), Quaternion.identity, rangeBorder.transform.parent);
            ObjHere2.transform.parent = spawnHolder;
        }

        if (randomScale)//嗯如果有要隨機調整大小的話再來改大小
        {
            ObjHere1.transform.localScale = new Vector3(Random.Range(minScale.x, maxScale.x), Random.Range(minScale.y, maxScale.y), Random.Range(minScale.z, maxScale.z));
            ObjHere2.transform.localScale = new Vector3(Random.Range(minScale.x, maxScale.x), Random.Range(minScale.y, maxScale.y), Random.Range(minScale.z, maxScale.z));
        }
    }
}
