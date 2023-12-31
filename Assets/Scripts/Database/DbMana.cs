using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;

public class DbMana : MonoBehaviour
{
     [SerializeField] InputField userName;
    DatabaseReference reference;
   
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    public void saveData(){
        SceneMana.GoToMenu();
        User user = new User();
        user.UserName = userName.text;
        string json = JsonUtility.ToJson(user);
        reference.Child("User").Child(user.UserName).SetRawJsonValueAsync(json).ContinueWith(task =>{
            if(task.IsCompleted){
                Debug.Log("Successfully added data");
            }
            else{
                Debug.Log("Not Successfully added");
            }
        });
    }
}
