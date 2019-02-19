using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Momoya
{
    public class Needle : GameObject
    {
        // 実験 プレイヤー
        public Player player;
        //回転速度
        [SerializeField]
        private float RotationalSpeed;

        //　初期化関数
        public override void Initialize()
        {
           
        }

        //　移動関数
        public override void Move()
        {
            //プレイヤーのトランスフォームを取得
            Transform target = player.transform;

            // プレイヤーの位置ベクトル
            Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.z);
            // このオブジェクトの位置ベクトル
            Vector2 needlepos = new Vector2(transform.position.x, transform.position.z);


            angle.y = SetAim(needlepos, playerpos);

            //rb.AddForce(vec.x,0.0f,vec.y);

            //  以上
        }

        //回転させる関数
        public override void Rotation()
        {
          
            this.rotation = player.GetRotation * rotation;

            this.transform.localRotation = this.rotation;
        }

    }
}