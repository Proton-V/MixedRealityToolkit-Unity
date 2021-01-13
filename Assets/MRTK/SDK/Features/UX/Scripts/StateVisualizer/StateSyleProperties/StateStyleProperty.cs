﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Microsoft.MixedReality.Toolkit.UI.Interaction
{
    /// <summary>
    /// The base class for state style property configurations.  A state style property configuration is 
    /// a data container for visual aspects of a game object such as the material or color. 
    /// </summary>
    [Serializable]
    public class StateStyleProperty: IStateStyleProperty
    {
        [SerializeField, HideInInspector]
        private string stylePropertyName;

        /// <summary>
        /// The name of the interaction state associated with this state style property configuration.
        /// </summary>
        public string StylePropertyName
        {
            get => stylePropertyName;
            set => stylePropertyName = value;
        }

        [SerializeField, HideInInspector]
        private string stateName;

        /// <summary>
        /// The name of the interaction state associated with this state style property configuration.
        /// </summary>
        public string StateName
        {
            get => stateName;
            set => stateName = value;
        }

        [SerializeField, HideInInspector]
        private GameObject target;

        /// <summary>
        /// 
        /// </summary>
        public GameObject Target
        {
            get => target;
            set => target = value;
        }

        //[SerializeField]
        //private List<AnimationCurve> animationCurves = new List<AnimationCurve>();

        ///// <summary>
        ///// 
        ///// </summary>
        //public List<AnimationCurve> AnimationCurves
        //{
        //    get => animationCurves;
        //    set => animationCurves = value;
        //}

        [SerializeField]
        private float animationDuration = 0.5f;

        /// <summary>
        ///
        /// </summary>
        public float AnimationDuration
        {
            get => animationDuration;
            set => animationDuration = value;
        }

        public virtual void SetKeyFrames(AnimationClip animationClip) { }
        public virtual void RemoveKeyFrames(AnimationClip animationClip) { }

        protected string GetTargetPath(GameObject target)
        {
            List<string> objectPath = new List<string>();

            Transform startTransform = target.transform;
            Transform initialTransform = target.transform;

            // If the current object is a root and does not have a parent 
            if (startTransform.parent != null)
            {
                while (startTransform.parent != initialTransform)
                {
                    if (startTransform.GetComponent<StateVisualizer>() != null)
                    {
                        // Exit when we reach the root
                        break;
                    }

                    objectPath.Add(startTransform.name);

                    startTransform = startTransform.parent;
                }
            }

            string path = "";

            for (int i = objectPath.Count - 1; i >= 0; i--)
            {
                path += objectPath[i];

                if (i != 0)
                {
                    path += "/";
                }
            }

            return path;
        }
    }
}
