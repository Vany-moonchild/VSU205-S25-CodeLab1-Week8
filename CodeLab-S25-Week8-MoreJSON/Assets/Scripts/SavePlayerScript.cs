using UnityEngine;
using SimpleJSON;
using UnityEngine.Serialization;


public class SavePlayerScript : MonoBehaviour
{

    //Sample JSON string for JsonArrayString
    // [
    // {
    //     "name": "Matt",
    //     "age": "25",
    //     "parents": 
    //     [
    //     {
    //         "name": "Terry",
    //         "age": "86"
    //     },
    //     {
    //         "name": "Frida",
    //         "age": "79"
    //     }
    //     ]
    // }, 
    // {
    //     "name": "Bucky",
    //     "age": "108"
    //     "parents": 
    //     [
    //     {
    //         "name": "George",
    //         "age": "86"
    //     },
    //     {
    //         "name": "Winfrid",
    //         "age": "90"
    //     }
    //     ]
    // }
    // ]
    
    
    
    [FormerlySerializedAs("jsonArray")] [TextArea (5, 20)]
    public string jsonArrayString;

    [TextArea(5, 20)] public string displayOurJsonArray;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParseJsonArray();   
        PopulateJsonArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ParseJsonArray()
    {
        JSONNode jNode = JSON.Parse(jsonArrayString); 
        
        JSONArray jArray = jNode.AsArray;

        string result = "";
        
        foreach (JSONObject person in jArray)
        {
            result += "\nPerson:\n";

            result += person["name"].Value;
            
            result += "\nAge: " + person["age"].AsInt;
            
            JSONArray parents = person["parents"].AsArray;

            result += "\nparent names: ";

            
            foreach (JSONObject parent in parents)
            {
                result += parent["name"] + " ";

            }
        }
        Debug.Log(result);
        
    }

    void PopulateJsonArray()
    {
        JSONArray jDisplayArray = new JSONArray();
        
        JSONObject kellogs = new JSONObject();
        kellogs ["name"] = "Kellogs";
        kellogs ["founding year"] = 1906;
        
        JSONObject gMills = new JSONObject();
        gMills ["name"] = "General Mills";
        gMills ["founding year"] = 1856;
        
        
        JSONObject riceKrispy = new JSONObject();
        riceKrispy["name"] = "Rice Krispy";
        riceKrispy["milkRatio"] = 2;
        riceKrispy["brand"] = kellogs;
        
        jDisplayArray.Add(riceKrispy);

        JSONObject kix = new JSONObject();
        kix["name"] = "Kix";
        kix["milkRatio"] = 0.5;
        kix["brand"] = gMills;
        
        jDisplayArray.Add(kix);
        
        
        
        
        
        
        displayOurJsonArray = jDisplayArray.ToString(3);
    }
    
    
}
