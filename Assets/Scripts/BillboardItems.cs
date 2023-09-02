using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//簡易陽春型Billboard，直接掛在要用的東西上
public class BillboardItems : MonoBehaviour
{
    [SerializeField] private Camera theCam;

    //[Tooltip("只繞著Y軸轉，如果所有東西都在同個平面上則適用此項")]
    //public bool yAxisOnly = true;

    //[SerializeField] Vector3 correction;//向量修正
    //[SerializeField] Vector3 multiCorrection = Vector3.one;//配合另一個Billboard Script做旋轉比例修正

    //void Start()
    //{
    //    if (theCam == null)
    //        theCam = Camera.main;
    //}

    private void LateUpdate()
    {
        if (theCam == null || !theCam.gameObject.activeInHierarchy)
            theCam = Camera.main;

        if (theCam == null)
            return;

        transform.LookAt(transform.position + theCam.transform.rotation * Vector3.forward, theCam.transform.rotation * Vector3.up);
    }

    //void Update()
    //{
    //    //transform.LookAt(theCam.transform);  //Quad用LookAt會反面朝前，結果什麼都看不到

    //    Vector3 camPos = theCam.transform.position;
    //    Vector3 relativePos;
    //    if (yAxisOnly)
    //    {
    //        relativePos = transform.position - new Vector3(camPos.x, transform.position.y, camPos.z);
    //    }
    //    else
    //    {
    //        relativePos = transform.position - camPos;
    //    }
    //    //relativePos = new Vector3(relativePos.x + correction.x, relativePos.y + correction.y, relativePos.z + correction.z);

    //    Quaternion _rotation = Quaternion.LookRotation(relativePos, Vector3.up);
    //    RotateIt(_rotation);
    //}

    //void RotateIt(Quaternion rot)
    //{
    //    //Vector3 vecRot = rot.eulerAngles + correction;
    //    Vector3 vecRot = new Vector3((rot.eulerAngles.x + correction.x) * multiCorrection.x, (rot.eulerAngles.y + correction.y) * multiCorrection.y, (rot.eulerAngles.z + correction.z) * multiCorrection.z);
    //    transform.localRotation = Quaternion.Euler(vecRot);
    //}


}
