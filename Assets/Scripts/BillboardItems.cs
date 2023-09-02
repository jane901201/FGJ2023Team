using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//²�����K��Billboard�A�������b�n�Ϊ��F��W
public class BillboardItems : MonoBehaviour
{
    [SerializeField] private Camera theCam;

    //[Tooltip("�u¶��Y�b��A�p�G�Ҧ��F�賣�b�P�ӥ����W�h�A�Φ���")]
    //public bool yAxisOnly = true;

    //[SerializeField] Vector3 correction;//�V�q�ץ�
    //[SerializeField] Vector3 multiCorrection = Vector3.one;//�t�X�t�@��Billboard Script�������ҭץ�

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
    //    //transform.LookAt(theCam.transform);  //Quad��LookAt�|�ϭ��«e�A���G���򳣬ݤ���

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
