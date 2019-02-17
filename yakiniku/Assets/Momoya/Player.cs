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
        public override void Initialize()
        {
          
      
            //ここに初期化処理
        }

        public override void Move()
        {
            //マウスの座標を取得
            GetMousePoint();
            //ポジションを2Dバージョンに
         
            //マウスのポジションから角度を求める
            angle.y = SetAim(this.transform.position.x, this.transform.position.z, screenToWorldPos.x,screenToWorldPos.z);
            
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
            Debug.Log(screenToWorldPos);
        }


        //2つのポジションから角度(radian)を返す関数
        public float SetAim(float p1x,float p1y,float p2x,float p2y)
        {
            float dx = p2x - p1x;
          //  Debug.Log(dx);
            float dy = p2y - p1y;
          //  Debug.Log(dy);
            float radangle = Mathf.Atan2(dy, dx);
          
            return radangle ;

        }


        //移動関数
        private void Movement()
        {
            //与えられた角度(y軸)の方向を向いて移動する
            vec.x = Mathf.Cos(angle.y) * speed;
            vec.z = Mathf.Sin(angle.y) * speed;
           
       }
    }
};