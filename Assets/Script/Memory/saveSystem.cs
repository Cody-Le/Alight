
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;

public static class saveSystem
{



    //Static Function on saving, loading and performing check on the path of the characters
    public static void SavePlayer(GameObject player, int scene)
    {
        if(player.tag != "Player")
        {
            Debug.LogError("Object trying to save is not a 'Player' tagged object");
        }
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/player_scene_"+ scene.ToString() + ".algt";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        playerState data = new playerState(player);

        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static playerState LoadPlayer(int scene)
    {
        string path = Application.persistentDataPath + "/player_scene_" + scene.ToString() + ".algt";
        if (!File.Exists(path)) {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        playerState data = formatter.Deserialize(stream) as playerState;
        stream.Close();
    
        return data;


    }


    public static void ResetAllPlayerState()
    {
        string path = Application.persistentDataPath;
        string[] files = System.IO.Directory.GetFiles(path, "player_scene_*.algt");
        if (files.Length > 0)
        {
            foreach(string file in files)
            {
                File.Delete(file);
            }
        }
    }

    public static void ResetOnePlayerState(int scene)
    {
        string path = Application.persistentDataPath + "/player_scene_" + scene.ToString() + ".algt";
        
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static bool CheckPlayerState(int scene)
    {
        string path = Application.persistentDataPath + "/player_scene_" + scene.ToString() + ".algt";
        return File.Exists(path);
    }

    //Static function on loading, saving and checking the path for the scene state


    public static void SaveStoryState(int state, int scene)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/storyState_scene_" + scene.ToString() + ".algt";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        storyState data = new storyState(state);

        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static storyState LoadStoryState(int scene)
    {
        string path = Application.persistentDataPath + "/storyState_scene_" + scene.ToString() + ".algt";
        if (!File.Exists(path))
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        storyState data = formatter.Deserialize(stream) as storyState;
        stream.Close();

        return data;


    }


    public static void ResetAllStoryState()
    {
        string path = Application.persistentDataPath;
        string[] files = System.IO.Directory.GetFiles(path, "story_scene_*.algt");
        if (files.Length > 0)
        {
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
    }

    public static void ResetOneStoryState(int scene)
    {
        string path = Application.persistentDataPath + "/story_scene_" + scene.ToString() + ".algt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static bool CheckStoryState(int scene)
    {
        string path = Application.persistentDataPath + "/storyState_scene_" + scene.ToString() + ".algt";
        return File.Exists(path);
    }


    //Functions to handle the general state of the game (i.e. which level were at, played before?, )
    public static void SaveGameState(int level)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/gameState_scene.algt";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        gameState data = new gameState(level);

        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static gameState LoadGameState()
    {
        string path = Application.persistentDataPath + "/gameState_scene.algt";
        if (!File.Exists(path))
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        gameState data = formatter.Deserialize(stream) as gameState;
        stream.Close();

        return data;


    }

    public static bool CheckGameState()
    {
        string path = Application.persistentDataPath + "/storyState_scene.algt";
        return File.Exists(path);
    }


}
