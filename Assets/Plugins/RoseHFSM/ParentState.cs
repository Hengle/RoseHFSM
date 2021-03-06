﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoseHFSM
{
    /// <summary>
    /// A state that contains another HFSM
    /// </summary>
    public class ParentState : State
    {
        [SerializeField]
        private HFSM stateHFSM;
        public HFSM StateHFSM
        {
            get { return stateHFSM;  }
            set { stateHFSM = value;  }
        }

        public override string StateName
        {
            get { return stateName; }
            set
            {
                stateName = value;
                if (stateHFSM != null)
                    stateHFSM.hfsmName = value;
            }
        }

        void OnEnable()
        {
            if (stateHFSM == null)
            {
                stateHFSM = gameObject.AddComponent<HFSM>();
                stateHFSM.hfsmName = stateName;
            }
        }

        protected override State ContinuousAction()
        {
            base.ContinuousAction();

            return stateHFSM.Execute();
        }
    }
}