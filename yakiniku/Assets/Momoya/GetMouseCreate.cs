using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMouseCreate : MonoBehaviour
{

    private Vector3 mousePos;     //マウス座標
    private Vector3 screenToWorldPos; //スクリーン座標からマウス座標に変換した座標

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePoint();

        this.transform.position = screenToWorldPos;
    }

    //マウス座標をゲットする関数
    private void GetMousePoint()
    {
        Vector3 offSet = new Vector3(0.0f, 0.0f, Vector3.Distance(Camera.main.transform.position, Vector3.zero));
        //マウスの座標を入れる
        mousePos = Input.mousePosition;
        mousePos.z = 15;

        //マウス座標をスクリーンからワールド座標へ変換
        screenToWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
