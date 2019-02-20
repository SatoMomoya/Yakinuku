using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//writer name is SatoMomoya
//風船を制御するスクリプト
namespace Momoya
{

    public class Balloon : MonoBehaviour
    {
        //変数の宣言
        private Flag flag;  //フラグ
       //列挙型の宣言
        protected enum StateFlag //状態のフラグ
        {
            Move = (1 << 0),  //移動フラグ
            Jump = (1 << 1),  //ジャンプフラグ
            Deth = (1 << 2),  //死亡フラグ
        }


        // Start is called before the first frame update
        void Start()
        {
            flag = GetComponent<Flag>();
        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Needle")
            {
                flag.On((uint)StateFlag.Deth);//needleにふれたら死亡
            }
        }

    }

}