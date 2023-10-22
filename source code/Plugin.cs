using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Utilla;

namespace gmaskcube
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public Material Material;
        public GameObject codeofconduct;
        public GameObject codeofconductrules;
        public GameObject gmaskdead;
        public GameObject gmaskglitch;
        public GameObject treewood;
        public GameObject motd;
        public GameObject TVS;
        public GameObject TVS2;
        public GameObject scaryboi;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }


        void OnGameInitialized(object sender, EventArgs e)
        {
            var bundle = LoadAssetBundle("gmaskcube.Resources.gmask");
            var asset = bundle.LoadAsset<GameObject>("gmask");
            asset = Instantiate(asset);
            asset.transform.position = new Vector3(-68.6888f, 11.2431f, - 81.7216f);
            asset.transform.rotation = Quaternion.Euler(0f, 353.176f, 0f);
            gmaskdead = asset.transform.Find("gmask dead ) :").gameObject;
            gmaskglitch = asset.transform.Find("gmask").gameObject;
            codeofconduct = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct");
            treewood = GameObject.Find("TreeWood");
            motd = GameObject.Find("motd");
            codeofconductrules = codeofconduct.transform.Find("COC Text").gameObject;
            codeofconductrules.GetComponent<Text>().text = "1 DONT HAVE FUN THAT BAD \n2 FLY FLY BUTTER FLY \nWTF PLAY THIS ITS CURSED";
            codeofconduct.GetComponent<Text>().text = "FUNNY GMASK MOD";
            motd.GetComponent<Text>().text = "GMASK MESSAGE OF THE DAY";
            Material = new Material(Shader.Find("GorillaTag/UberShader"));
            treewood.GetComponent<MeshRenderer>().material = Material;
            Material.color = Color.green;
            gmaskdead.transform.position = new Vector3(-67.3687f, 11.3477f, -82.6138f);
            gmaskdead.transform.rotation = Quaternion.Euler(270f, 266.7433f, 0f);
            gmaskglitch.transform.position = new Vector3(-67.0588f, 9.8738f, -82.9834f);
            gmaskglitch.transform.rotation = Quaternion.Euler(0, 0, 0);
            TVS = GameObject.Find("TVS");
            TVS2 = GameObject.Find("TV 2");
            TVS.transform.position = new Vector3(-65.1383f, 12.0153f, -84.4379f);
            TVS.transform.rotation = Quaternion.Euler(0f, 263.3844f, 0f);
            TVS2.transform.position = new Vector3(-65.6238f, 12.0153f, -84.6017f);
            scaryboi = asset.transform.Find("scary boi").gameObject;
            scaryboi.transform.parent = GorillaLocomotion.Player.Instance.headCollider.transform;
            scaryboi.transform.localPosition = new Vector3(0.0621f, -0.4055f, -0.862f);
            scaryboi.transform.localRotation = Quaternion.Euler(0f, 8.7132f, 0f);
        }
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

    }
}
