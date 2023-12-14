using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/** AfSimpleExtension : Unity����չ���
 * 
 *  ���ߣ��۷�
 *  ������https://afanihao.cn
 *  
 *  ������ǡ�Unity3D���Ž̡̳������ײ�������°汾�ڿγ������л�ȡ��
 *  
 *  ������־��
 *  - 2022-1-28
 *  
 */

public class AfSimpleExtension : Editor
{
    static Quaternion lastRotation;
    //static int view = 0; // ��ǰ�ӽ�

    /** ��ӡ��־
     * 
    */
    static void ShowLog(string message)
    {
        string time = DateTime.Now.ToString("HH:mm"); ;
        time = "[ " + time + " ] - ";

        Debug.Log(time + message);
    }

    [MenuItem("AF/��������ͼ _1" , false , 100)]
    static void ISO_TopView()
    {
        SceneView view = SceneView.lastActiveSceneView;

        if (!view.orthographic)
        {
            ISO_View( new Vector3(90, 0, 0));
            ShowLog("��������ͼ");
        }
        else
        {
            Persp_View();
        }
    }

    [MenuItem("AF/��������ͼ _2", false, 100)]
    static void ISO_BackView()
    {
        SceneView view = SceneView.lastActiveSceneView;

        if (!view.orthographic)
        {
            ISO_View(new Vector3(0, 0, 0));
            ShowLog("��������ͼ");
        }
        else
        {
            Persp_View();
        }
    }

    [MenuItem("AF/��������ͼ _3" , false, 100)]
    static void ISO_RightView()
    {
        SceneView view = SceneView.lastActiveSceneView;

        if (!view.orthographic)
        {
            ISO_View(new Vector3(0, -90, 0));
            ShowLog("��������ͼ");
        }
        else
        {
            Persp_View();           
        }
    }
        

    static void ISO_View( Vector3 angle )
    {
        SceneView view = SceneView.lastActiveSceneView;
        view.orthographic = true;
        lastRotation = view.rotation;
        view.rotation = Quaternion.Euler(angle);
        
    }

    [MenuItem("AF/͸��ͼ _0", false, 100)]
    static void Persp_View()
    {
        SceneView view = SceneView.lastActiveSceneView;
        view.orthographic = false;
        view.rotation = lastRotation;
        ShowLog("͸��ͼ");
    }

    [MenuItem("AF/������ͼ���� _G", false, 200)]
    static void FocusAtObject()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj == null)
        {
            ShowLog("Warn: ��ǰû��ѡ������!");
            return;
        }

        SceneView view = SceneView.lastActiveSceneView;
        view.pivot = obj.transform.position;
    }

    //[MenuItem("AF/ɾ��ѡ������ _X" , false, 200)]
    //static void DeleteSelectObjects()
    //{
    //    GameObject[] objs = Selection.gameObjects;

    //    foreach ( GameObject obj in objs)
    //    {
    //        DestroyImmediate(obj);
    //    }

    //    ShowLog("ɾ���� " + objs.Length + " ������");
    //}
         


    [MenuItem("AF/������ ", false, 300)]
    static void GetDistanceOfObject()
    {
        GameObject[] objs = Selection.gameObjects;
        if(objs.Length > 2)
        {
            ShowLog("Warn: ��ֻѡ��2�����壬��Ҫѡ��̫������!");
            return;
        }
        if(objs.Length != 2)
        {
            ShowLog("Warn: ����ѡ��2�����壬Ȼ����ִ�в�����");
            return;
        }


        float distance = (objs[0].transform.position - objs[1].transform.position).magnitude;

        ShowLog("����Ϊ: " + distance + ", " + objs[0].name + " -> " + objs[1].name);

    }

    [MenuItem("AF/����ߴ� ", false, 300)]
    static void GetMeshDimension()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj == null)
        {
            ShowLog("Warn: ��ǰû��ѡ������!");
            return;
        }

        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        if (renderer == null)
        {
            ShowLog("Warn: ��ǰ����û������ȱ��MeshRenderer��� !");
            return;
        }
        Vector3 size = renderer.bounds.size;

        ShowLog("����: " + obj.name + "  �ߴ�: " + size.ToString("F2"));

    }





   
}
