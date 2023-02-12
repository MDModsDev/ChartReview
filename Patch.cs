﻿using Assets.Scripts.UI.Panels;
using MuseDashMirror.UICreate;
using UnityEngine;
using UnityEngine.UI;

namespace ChartReview
{
    internal static unsafe class Patch
    {
        internal static GameObject ChartReviewToggle { get; set; }

        internal static unsafe void PnlMenuPostfix(PnlMenu __instance)
        {
            GameObject vSelect = null;
            foreach (Il2CppSystem.Object @object in __instance.transform.parent.parent.Find("Forward"))
            {
                Transform transform = @object.Cast<Transform>();
                if (transform.name == "PnlVolume")
                {
                    vSelect = transform.gameObject;
                }
            }
            fixed (bool* chartReviewEnabled = &Save.data.ChartReviewEnabled)
            {
                if (ChartReviewToggle == null && vSelect != null)
                {
                    ChartReviewToggle = ToggleCreate.CreatePnlMenuToggle("Chart Review Toggle", chartReviewEnabled, "Chart Review On/Off");
                }
            }
        }

        internal static unsafe void SwitchLanguagesPostfix()
        {
            fixed (bool* chartReviewEnabled = &Save.data.ChartReviewEnabled)
            {
                ChartReviewToggle.transform.Find("Txt").GetComponent<Text>().text = "Chart Review On/Off";
            }
        }
    }
}