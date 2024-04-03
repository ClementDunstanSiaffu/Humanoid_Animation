using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameBehaviour : MonoBehaviour
{
    private int _itemCollected = 0;
    private int _playerHP = 10;

    public string labelText = "Collect all 4 items and win your freedom";
    public int maxItems = 4;

    public bool showWinScreen = false;
    public bool showLossScreen = false;
    private Queue<string> activePlayers = new Queue<string>();
    // public Stack <string> lootStack = new Stack<string>();
    
    public int Items{
         get{
            return _itemCollected;
         }
         set{
            _itemCollected = value;

            if (_itemCollected >= maxItems){
                labelText = "You have found all the items";
                showWinScreen = true;
                Time.timeScale = 0f;
            }else{
                labelText = "Item found , only " + (maxItems - _itemCollected) + " more to go!";
            }
         }
    }

    public int HP{
        get{
            return _playerHP;
        }
        set{
            _playerHP = value;
            if (_playerHP <= 0){
                labelText = "You want another life with that";
                showLossScreen = true;
                Time.timeScale = 0;
            }else{
                labelText = "Ouch... that's got hurt";
            }
        }
    }

    void OnGUI (){
        GUI.Box(new Rect(20,20,150,25),"Player Health :" + _playerHP);
        GUI.Box(new Rect(20,50,150,25),"Items Collected :" + _itemCollected);
        GUI.Label(new Rect(Screen.width/2 -100,Screen.height - 50,300,50),labelText);
        
        if (showWinScreen){
            if (GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),"YOU WON!")){
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }

        if (showLossScreen){
            if (GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50,200,100),"You lose...")){
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void initialize(){      
        PlayerBehaviour playerBehaviour = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        playerBehaviour.playerJump += HandlePlayerJump;
        // HashSet <string> activePlayers = new HashSet<string>(){"Joe","Joan","Hank"};
        // activePlayers.Add("Clement");
        // activePlayers.Add("Drako");
        // foreach(var player in activePlayers){
        //     Debug.LogFormat("The current hashset is {0}",player);
        // }
        // Debug.Log(activePlayers.Count);
        // // activePlayers.Remove("Clement");
        // HashSet<string> inactivePlayers = new HashSet<string>{"Rama","Chikuku","Drako"};
        // // activePlayers.UnionWith(inactivePlayers);
        // activePlayers.ExceptWith(inactivePlayers);
        // Debug.Log(activePlayers.Count);
        // activePlayers.Enqueue("Harrison");
        // activePlayers.Enqueue("Alex");
        // activePlayers.Enqueue("Haley");
        // var firstPlayer = activePlayers.Peek();
        // Debug.Log(firstPlayer + " " + "the peek");
        // Debug.Log(activePlayers.Count + " " + "Check count");
        // firstPlayer = activePlayers.Dequeue();
        // Debug.Log(firstPlayer + " " + "the dequeue");
        // Debug.Log(activePlayers.Count + " " + "check count after dequeue");
    //    lootStack.Push("Sword of Doom");
    //    lootStack.Push("HP+");
    //    lootStack.Push("Golden Key");
    //    lootStack.Push("Winged Boot");
    //    lootStack.Push("Mythril Bracers");

    //    string [] copiesLoot = new string[lootStack.Count];
    //    lootStack.CopyTo(copiesLoot,0);
    //    lootStack.ToArray();
    //    string lootItem;
    //    bool popItemPresent = lootStack.TryPop(out lootItem);
    //    if (popItemPresent){
    //         var currentItem = lootStack.Pop();
    //         Debug.Log(lootItem);
    //    }else{
    //         Debug.Log("Stack is empty");
    //    }
    //    var nextItem = lootStack.Peek();
    //    Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!",currentItem,nextItem);
    //    Debug.LogFormat("There are {0} random loot items waiting for you ! ",lootStack.Count);
    //    Debug.Log("The string value " + lootStack.ToString());
    //    lootStack.Clear();
    //    Debug.LogFormat("There are {0} new random loot items waiting for you ! ",lootStack.Count);
    //    Debug.Log("The length is " + copiesLoot.Length);
    }

    public void HandlePlayerJump(){
        Debug.Log("Player has jumped");
    }




    // // Start is called before the first frame update
    // void Start()
    // {
      
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

}
