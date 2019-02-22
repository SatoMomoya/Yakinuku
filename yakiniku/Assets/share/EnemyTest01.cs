using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momoya;
using UnityEngine.AI;



namespace Momoya
{
    
    public class EnemyTest01 : GameObject
    {
       

        public Transform target;
        NavMeshAgent agent;

        [SerializeField]
        private Rigidbody rig;



        // テスト用　親の前の位置
        private Vector3 oncepos = Vector3.zero;

        public override void Initialize()
        {
            // 現在の子の位置を親の前の位置に保存する
            oncepos = transform.GetChild(0).gameObject.transform.position;

            agent = GetComponent<NavMeshAgent>();
            //ここに初期化処理
        }

        public override void Move()
        {
            if (agent != null)
            {
                agent.SetDestination(target.position);
            }


            //マウスのポジションから角度を求める
            angle.y = SetAim(this.transform.position.z, this.transform.position.x, target.position.z, target.position.x);


            if (transform.GetChild(1).GetChild(0).GetComponent<Flag>().Is((uint)StateFlag.Deth))
            {
                flag.On((uint)StateFlag.Deth);
            }


            //死亡フラグが立ったら消す
            if (flag.Is((uint)StateFlag.Deth))
            {
                Destroy(this.gameObject);
            }

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

       
        
    }
}
