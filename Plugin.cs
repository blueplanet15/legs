using BepInEx;
using UnityEngine;
using Utilla.Attributes;

namespace legs
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	[ModdedGamemode]
	public class Plugin : BaseUnityPlugin
	{
 
	bool inRoom;
 	
        private readonly string[] targetNames =
		{
            "shoulder.L",
            "shoulder.R"
        };
	
        private void legs()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (MatchesTargetName(obj.name)) // makes it apply to everyone with the target names 
                {
                    obj.transform.localPosition = new Vector3(-0.0183f, 0.0759f, 0.0791f); // moves the shoulder to the 'leg spot'
                }
            }
        }
	
        private void arms()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (MatchesTargetName(obj.name)) // makes it apply to everyone with the target names 
                {
                    obj.transform.localPosition = new Vector3(-0.0183f, 0.3432f, 0.0791f); // moves the shoulder back to the og spot
                }
            }
        }

        private bool MatchesTargetName(string objName)
        {
            foreach (string targetName in targetNames) // matches the target blah blah
            {
                if (objName.Equals(targetName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        void Start()
	{
            HarmonyPatches.ApplyHarmonyPatches();
	    GorillaTagger.OnPlayerSpawned(Initialized);
	}

	void Initialized()
	{
        }

	[ModdedGamemodeJoin]        
	public void OnModdedJoin(string gamemode)
	{
 	    legs();
	    Debug.Log("Enabled Legs");
            inRoom = true;
	}

	[ModdedGamemodeLeave]
	public void OnModdedLeave(string gamemode)
	{
 	    arms();
            Debug.Log("Disabled Legs");
            inRoom = false;
	}
	}
}
