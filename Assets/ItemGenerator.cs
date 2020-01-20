using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //アイテム生成開始地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //コーン連続生成防止用フラグ
    private bool coneGenerate = true;

    //unitychanを入れる
    [SerializeField] private GameObject unitychan;
    //unitychanの座標
    private float unitychanPos;

    void Start() {
        this.unitychan = GameObject.Find("unitychan");
        //unitychanの初期位置取得
        this.unitychanPos = unitychan.transform.position.z;
    }

    void Update() {
        //unitychanの移動距離
        float moveDistance = unitychan.transform.position.z - this.unitychanPos;
        //アイテムを生成する距離
        float GeneratePos = this.unitychanPos + 50;

        if (moveDistance >= 10) {
            if (GeneratePos >= startPos && GeneratePos < goalPos) {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 3 && coneGenerate) {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f) {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, GeneratePos);
                    }
                    coneGenerate = false;
                } else {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++) {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-4, 5);
                        //60%コイン配置:20%車配置:20%何もなし
                        if (1 <= item && item <= 6) {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, GeneratePos + offsetZ);
                        } else if (7 <= item && item <= 8) {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, GeneratePos + offsetZ);
                        }
                    }
                    coneGenerate = true;
                }
            }
            this.unitychanPos = unitychan.transform.position.z;
        }
    }
}

// //一定の距離ごとにアイテムを生成
// for (int i = startPos; i < goalPos; i += 15) {
//     //どのアイテムを出すのかをランダムに設定
//     int num = Random.Range(1, 11);
//     if (num <= 2) {
//         //コーンをx軸方向に一直線に生成
//         for (float j = -1; j <= 1; j += 0.4f) {
//             GameObject cone = Instantiate(conePrefab) as GameObject;
//             cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
//         }
//     } else {
//         //レーンごとにアイテムを生成
//         for (int j = -1; j <= 1; j++) {
//             //アイテムの種類を決める
//             int item = Random.Range(1, 11);
//             //アイテムを置くZ座標のオフセットをランダムに設定
//             int offsetZ = Random.Range(-5, 6);
//             //60%コイン配置:30%車配置:10%何もなし
//             if (1 <= item && item <= 6) {
//                 //コインを生成
//                 GameObject coin = Instantiate(coinPrefab) as GameObject;
//                 coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
//             } else if (7 <= item && item <= 9) {
//                 //車を生成
//                 GameObject car = Instantiate(carPrefab) as GameObject;
//                 car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
//             }
//         }
//     }
// }