using System;
using System.Collections;
using System.Net;
using UnityEngine;
/*
 * Below are built for vrc release 1172 and might break in the futre.
 */
using NetworkManager = MonoBehaviourPrivateAc1AcOb2AcInStHa2Unique;
using Player = MonoBehaviourPublicAPOb_v_pObBo_UBoVRObUnique;
// field_Internal_Static_NetworkManager_0 = field_Internal_Static_MonoBehaviourPrivateAc1AcOb2AcInStHa2Unique_0
namespace FumoTagsBepinex.Modules
{
    class CustomTags
    {
        private static GameObject threeSliceFumoTag;
        public static IEnumerator TagListNetworkManager()
        {
            String[] Match = { "|" };
            String[] newline = { "\n" };
            WebClient client = new WebClient();
            string DevList = client.DownloadString("https://raw.githubusercontent.com/FumoClient/Trolly/main/R-ID-DL");
            string LDB = client.DownloadString("https://raw.githubusercontent.com/FumoClient/Trolly/main/R-ID-UL");
            String[] DevDB = DevList.Split(newline, StringSplitOptions.RemoveEmptyEntries);
            String[] DataBase = LDB.Split(newline, StringSplitOptions.RemoveEmptyEntries);
            client.Dispose();

            while (NetworkManager.field_Internal_Static_MonoBehaviourPrivateAc1AcOb2AcInStHa2Unique_0 == null)
            {
                yield return null;
            }
            NetworkManager.field_Internal_Static_MonoBehaviourPrivateAc1AcOb2AcInStHa2Unique_0.field_Internal_ObjectPublicHa1UnT1Unique_1_MonoBehaviourPublicAPOb_v_pObBo_UBoVRObUnique_0.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(RemotePlayer =>
            {
                foreach (var User in DataBase)
                {
                    if (User.Contains(UserProtections.SHA256(RemotePlayer.prop_APIUser_0.id)))
                    {
                        if (Plugin.NameplateTag.Value == true)
                        {
                        /*  https://github.com/Kiokuu/NameplateStats/blob/master/Nameplate.cs refrenced for creation of the three slice :) 
                            I haven't got this part working all the way yet trolly but like boo hoo I am going to release anyways and fix this later cause I GOTTA PLAY FORTNITEETTE FORT5 NITEEEE :)
                            If you see this show them some love <3   */
                            if (!GameObject.Find("Player Nameplate/Canvas/Nameplate").active)  return;
                            if (!threeSliceFumoTag)
                            {
                                GameObject placeholder = GameObject.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats").gameObject;
                                threeSliceFumoTag = GameObject.Instantiate(placeholder);
                                GameObject.DestroyImmediate(threeSliceFumoTag.transform.Find("Trust Icon").gameObject);
                                GameObject.DestroyImmediate(threeSliceFumoTag.transform.Find("Performance Icon").gameObject);
                                GameObject.DestroyImmediate(threeSliceFumoTag.transform.Find("Friend Anchor Stats").gameObject);
                                threeSliceFumoTag.transform.Find("Trust Text").name = "FumoClientUserTag";
                                threeSliceFumoTag.transform.Find("Performance Text").name = "FumoUserTag";
                                threeSliceFumoTag.name = "threeSliceFumoTag";
                                threeSliceFumoTag.SetActive(false);
                                GameObject.DontDestroyOnLoad(threeSliceFumoTag);
                            }
                            if (GameObject.Find("Player Nameplate/Canvas/Nameplate").transform.Find("Contents/FumoTags")) return;
                            var FumoTags = GameObject.Instantiate(threeSliceFumoTag, RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents").transform);
                            FumoTags.name = "FumoTags";

                            FumoTags.transform.localPosition = new Vector3(0, 30, 0);

                            var CTagTM = FumoTags.transform.Find("FumoClientUserTag").GetComponent<TMPro.TextMeshProUGUI>();
                            CTagTM.color = Color.white;
                            CTagTM.text = $"<color=#D0B3FF>Fumo User</color>";
                            String[] TagP = User.Split(Match, StringSplitOptions.RemoveEmptyEntries);
                            if (TagP.Length == 3)
                            {
                                var TagTM = FumoTags.transform.Find("FumoUserTag").GetComponent<TMPro.TextMeshProUGUI>();
                                TagTM.color = Color.white;
                                TagTM.text = $"<color={UserProtections.DecodeBase64(TagP.GetValue(2).ToString())}>{UserProtections.DecodeBase64(TagP.GetValue(1).ToString())}</color>";
                            }
                        }
                        else
                        {
                            var FumoTag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                            FumoTag.name = "FumoClientUserTag";
                            var CTagTM = FumoTag.GetComponent<TMPro.TextMeshProUGUI>();
                            CTagTM.color = Color.white;
                            CTagTM.text = $"<color=#D0B3FF>Fumo User</color>";
                            String[] TagP = User.Split(Match, StringSplitOptions.RemoveEmptyEntries);
                            if (TagP.Length == 3)
                            {
                                var Tag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                                Tag.name = "FumoUserTag";
                                var TagTM = Tag.GetComponent<TMPro.TextMeshProUGUI>();
                                TagTM.color = Color.white;
                                TagTM.text = $"<color={UserProtections.DecodeBase64(TagP.GetValue(2).ToString())}>{UserProtections.DecodeBase64(TagP.GetValue(1).ToString())}</color>";
                            }
                        }
                    }
                }

                foreach (var User in DevDB)
                {
                    if (User.Contains(UserProtections.SHA256(RemotePlayer.prop_APIUser_0.id)))
                    {
                        if (Plugin.NameplateTag.Value == true)
                        {

                            /*  https://github.com/Kiokuu/NameplateStats/blob/master/Nameplate.cs refrenced for helping me with the creation of the three slice style tags :) 
                                If you see this show them some love <3   */
                            if (!GameObject.Find("Player Nameplate/Canvas/Nameplate").active) return;
                            if (!threeSliceFumoTag)
                            {
                                GameObject placeholder = GameObject.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats").gameObject;
                                threeSliceFumoTag = GameObject.Instantiate(placeholder);
                                GameObject.DestroyImmediate(threeSliceFumoTag.transform.Find("Trust Icon").gameObject);
                                GameObject.DestroyImmediate(threeSliceFumoTag.transform.Find("Performance Icon").gameObject);
                                GameObject.DestroyImmediate(threeSliceFumoTag.transform.Find("Friend Anchor Stats").gameObject);
                                threeSliceFumoTag.transform.Find("Trust Text").name = "FumoClientStaffTag";
                                threeSliceFumoTag.transform.Find("Performance Text").name = "FumoUserStaffTag";
                                threeSliceFumoTag.name = "threeSliceFumoTag";
                                threeSliceFumoTag.SetActive(false);
                                GameObject.DontDestroyOnLoad(threeSliceFumoTag);
                            }
                            if (GameObject.Find("Player Nameplate/Canvas/Nameplate").transform.Find("Contents/FumoTags")) return;
                            var FumoTags = GameObject.Instantiate(threeSliceFumoTag, RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents").transform);
                            FumoTags.name = "FumoTags";

                            FumoTags.transform.localPosition = new Vector3(0, 30, 0);

                            var CTagTM = FumoTags.transform.Find("FumoClientStaffTag").GetComponent<TMPro.TextMeshProUGUI>();
                            CTagTM.color = Color.white;
                            CTagTM.text = $"<color=#D0B3FF>Fumo Staff/color>";
                            String[] TagP = User.Split(Match, StringSplitOptions.RemoveEmptyEntries);
                            if (TagP.Length == 3)
                            {
                                var TagTM = FumoTags.transform.Find("FumoUserStaffTag").GetComponent<TMPro.TextMeshProUGUI>();
                                TagTM.color = Color.white;
                                TagTM.text = $"<color={UserProtections.DecodeBase64(TagP.GetValue(2).ToString())}>{UserProtections.DecodeBase64(TagP.GetValue(1).ToString())}</color>";
                            }
                        }
                        else
                        {
                            var FumoTag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                            FumoTag.name = "FumoClientStaffTag";
                            var CTagTM = FumoTag.GetComponent<TMPro.TextMeshProUGUI>();
                            CTagTM.color = Color.white;
                            CTagTM.text = $"<color=#D0B3FF>Fumo Staff</color>";
                            String[] TagP = User.Split(Match, StringSplitOptions.RemoveEmptyEntries);
                            if (TagP.Length == 3)
                            {
                                var Tag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                                Tag.name = "FumoUserStaffTag";
                                var TagTM = Tag.GetComponent<TMPro.TextMeshProUGUI>();
                                TagTM.color = Color.white;
                                TagTM.text = $"<color={UserProtections.DecodeBase64(TagP.GetValue(2).ToString())}>{UserProtections.DecodeBase64(TagP.GetValue(1).ToString())}</color>";
                            }
                        }
                    }
                }
                if (RemotePlayer.prop_APIUser_0.hasModerationPowers)
                {
                    var FCModTag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                    FCModTag.name = "FumoModTag";
                    var TagTM = FCModTag.GetComponent<TMPro.TextMeshProUGUI>();
                    TagTM.color = Color.white;
                    TagTM.text = "<color=red>VRChat Staff</color>";
                    //FumoLogger.Warn("Moderator " + RemotePlayer.prop_APIUser_0.displayName + " is here!", 25);
                    Plugin.FLog.LogWarning("Moderator " + RemotePlayer.prop_APIUser_0.displayName + " is here!");
                    Console.Beep(800, 1500);
                }
            }));
        }
    }
}
