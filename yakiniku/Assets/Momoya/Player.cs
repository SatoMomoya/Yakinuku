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
        private float RotationalSpeed; //回転速度
        //変数の宣言
        private Vector3 requestAngle;    //要求されている角度
        public override void Move()
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                angle.y += RotationalSpeed;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angle.y += -RotationalSpeed;
            }
            //与えられた角度(y軸)の方向を向いて移動する

            vec.x = Mathf.Cos(angle.y * (Mathf.Deg2Rad) - 90) * speed;
            vec.z = Mathf.Sin(angle.y * (Mathf.Deg2Rad) - 90) * speed;
        }



    }
};