using System;
using BepInEx;
using legs;
using UnityEngine;
using Utilla;
using Newtilla;

namespace legs
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	[ModdedGamemode]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		void Start()
		{
            Newtilla.Newtilla.OnJoinModded += OnModdedJoin;
            Newtilla.Newtilla.OnLeaveModded += OnModdedLeave;
            HarmonyPatches.ApplyHarmonyPatches();
			GorillaTagger.OnPlayerSpawned(Initialized);
		}

		void Initialized()
		{
        }

		[ModdedGamemodeJoin]        
		public void OnModdedJoin(string gamemode)
		{
            GameObject arm1 = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/shoulder.R/");
            arm1.transform.localPosition = new Vector3(-0.0183f, 0.0759f, 0.0791f);
            GameObject arm2 = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/shoulder.L/");
            arm2.transform.localPosition = new Vector3(-0.0183f, 0.0759f, 0.0791f);
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.73f, 1.73f, 1.73f);
            Debug.Log("Enabled Legs");
            inRoom = true;
		}

		[ModdedGamemodeLeave]
		public void OnModdedLeave(string gamemode)
		{
            GameObject arm1 = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/shoulder.R/");
            arm1.transform.localPosition = new Vector3(-0.0183f, 0.3432f, 0.0791f);
            GameObject arm2 = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/shoulder.L/");
            arm2.transform.localPosition = new Vector3(-0.0183f, 0.3432f, 0.0791f);
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("Disabled Legs");
            inRoom = false;
		}
	}
}
