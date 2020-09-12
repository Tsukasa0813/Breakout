using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] Text levelText;             //  レベルの表示用。インスペクタで指定可能

    [SerializeField] StartShot startShot;        //  ボールの制御用
    
    public static int level;                     //  ステージをクリアした回数。シーンをまたいでも引き継ぐようにpublic かつ staticにする
　　
    public static bool isStart;                  //  ゲーム開始かどうかを判断するフラグ。falseなら開始前。trueならゲーム中と判断する　　

    void Start ()
    {
　　 　 if(!isStart)                             //  isStartのフラグを確認し、Falseであれば実行される。「!isStart」は「isStart == false」と同義。
        {
            level = 0;                           //  レベルを0にする
            isStart = true;                      //  ゲーム開始のフラグを立てる。タイトル画面へ戻るとリセットされるようにResetFlags.csで管理する
        }
        levelText.text = level.ToString();　　　 //  levelをLevelTextに表示
    }

    public void LevelUp()                        //  外部（GameMaster.cs）より呼ばれるメソッド
    {
        startShot.BallDestroy();　　　　　　　　 //  ボールを制御するメソッドの呼び出し
        level ++ ;                               //  levelを加算する
        StartCoroutine("NextLevel");             //  コルーチンの呼出し
    }

    IEnumerator NextLevel()                                   //  コルーチン 
    {
        Debug.Log("Please press key");        
　　    while(!Input.GetKey("space")) yield return null;　　　//　スペースキーの入力待ち 
        SceneManager.LoadScene("Main");                       //  スペースキーが押されたらMainシーンを呼び出す
        Debug.Log("Done!");
    }
} 