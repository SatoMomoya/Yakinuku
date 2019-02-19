using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momoya;
//2019/02/15
//プレイヤーのスクリプト
namespace Momoya
{
    public class Player : GameObject
    {
        //定数の宣言
        [SerializeField]
        private float RotationalSpeed;//回転速度
        [SerializeField]
        private float MouseDistance;
        //変数の宣言
        private Vector3 requestAngle; //要求されている角度
        private Vector2 pos2D;        //上から見た場合の座標


        private Vector3 mousePos;     //マウス座標
        private Vector3 screenToWorldPos; //スクリーン座標からマウス座標に変換した座標
        private Vector2 screenToWorldPos2D;//2D版
        // テスト用　親の前の位置
        private Vector3 oncepos = Vector3.zero;

        public override void Initialize()
        {
            // 現在の子の位置を親の前の位置に保存する
            oncepos = transform.GetChild(0).gameObject.transform.position; 
      
            //ここに初期化処理
        }

        public override void Move()
        {
            //マウスの座標を取得
            GetMousePoint();
            //ポジションを2Dバージョンに
         
            //マウスのポジションから角度を求める
            angle.y = SetAim(this.transform.position.z, this.transform.position.x, screenToWorldPos.z,screenToWorldPos.x);
            
            //Debug.Log(mousePos);

            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    angle.y += RotationalSpeed;
            //}

            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    angle.y += -RotationalSpeed;
            //}


            Movement(); //移動


            //// 親が今の位置と前の位置と異なる場合
            //if (transform.position != oncepos)
            //{
            //    // 子を呼ぶ
            //    UnityEngine.GameObject child = transform.GetChild(0).gameObject;
            //    // 子を親が前にいた位置に配置する
            //    child.transform.position = oncepos;

            //}

            //// 親の前の位置を保存する
            //oncepos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

        }

        //マウス座標をゲットする関数
        private void GetMousePoint()
        {
            Vector3 offSet = new Vector3(0.0f, 0.0f, Vector3.Distance(Camera.main.transform.position, Vector3.zero));
            //マウスの座標を入れる
            mousePos = Input.mousePosition;
            mousePos.z = MouseDistance;
            
            //マウス座標をスクリーンからワールド座標へ変換
            screenToWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        }





        //移動関数
        private void Movement()
        {
            ////与えられた角度(y軸)の方向を向いて移動する
            vec.x = Mathf.Sin(angle.y) * speed;
            vec.z = Mathf.Cos(angle.y) * speed;

        }
    }
};