using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momoya
{
    abstract public class GameObject : MonoBehaviour
    {
        //定数の宣言
      
        public const int FallPoint = -5;         //落下ポイント
        [SerializeField]
        protected float speed;                   //スピード
        [SerializeField]
        protected float jumpPower;              //ジャンプパワー

        //変数の宣言
 
        protected Vector3 startPos;     //モンスターの初期位置
        protected Vector3 pos;          //モンスターのポジション
        protected Vector3 vec;          //モンスターのベクトル
        protected Vector3 angle;        //モンスターのアングル
        protected Quaternion rotation;  //モンスターのローテーション
        protected Flag flag;            //フラグ
       
       

        protected enum StateFlag //状態のフラグ
        {
            Move = (1 << 0),  //移動フラグ
            Jump = (1 << 1),  //ジャンプフラグ
            Deth = (1 << 2),  //死亡フラグ
        }

        protected enum MonsterState
        {
            Normal, //普通の状態
            Jump,   //ジャンプ状態

            NumState,
        }

        // Use this for initialization
        void Start()
        {  
            this.startPos = this.transform.position;
            this.vec = this.GetComponent<Rigidbody>().velocity;

            this.flag = GetComponent<Flag>();  //フラグをゲットコンポーネント
            this.rotation = Quaternion.Euler(angle); //オイラー角からクオータニオンへ変換
        }

        // Update is called once per frame
        void Update()
        {

            PositionCtrl(); //ポジションの処理

            Move();         //移動の処理
        }

        //ポジションのゲットとセットをするプロパティ
        public Vector3 Pos
        {
            get { return this.pos; }
            set
            {
                //レアリティの最小値のチェック
             
                pos = value;
            }

        }

        //ベクトルのゲットとセットをするプロパティ
        public Vector3 Vec
        {
            get { return vec; }
            set { vec = value; }
        }

        //アングルのゲットとセットをするプロパティ
        public Vector3 Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        //ポジションをコントロールする関数
        protected void PositionCtrl()
        {
            Rotation(); //回転処理

            Vector3 direction = new Vector3(vec.x, vec.y, vec.z) * speed;

            //移動させる
            GetComponent<Rigidbody>().velocity = new Vector3(direction.x, GetComponent<Rigidbody>().velocity.y, direction.z);

            //もし設定されている場所より多く落ちてしまったら一番最初のポジションに戻す
            if (transform.position.y < FallPoint)
            {
                this.transform.position = startPos;
            }

        }

        //移動する関数
        public abstract void Move();

        public void Rotation()
        {
            //回転に必要な値をangleからもってくる
            rotation = Quaternion.Euler(angle);
            this.transform.localRotation = rotation;
        }

        //何かと当たった時の関数
        protected void OnCollisionEnter(Collision collision)
        {
            //当たった何かのタグを調べる
            switch (collision.transform.tag)
            {
                case "Ground": flag.On((uint)StateFlag.Jump); break; //groundと触れていればジャンプフラグをtrueにする
            }

        }

        //何かと離れたときの関数
        protected void OnCollisionExit(Collision collision)
        {
            //離れた何かのタグを調べる
            switch (collision.transform.tag)
            {
                case "Ground": flag.Off((uint)StateFlag.Jump); break; //groundを離れたらジャンプフラグoffにする
            }
        }

    }

}
