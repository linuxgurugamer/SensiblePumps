using System;
using KSP;
using UnityEngine;

namespace SensiblePumps
{
    public class SensiblePumps : PartModule
    {

        [UI_Toggle(disabledText = "Off", enabledText = "On")]
        [KSPField(guiActiveEditor = true, guiName = "Sensible Pumps ", isPersistant = true)]
        public bool isSensible = true;

        private int numberOfParts;

        bool isSRB = false;

        public void Start()
        {

            if (HighLogic.LoadedScene != GameScenes.EDITOR)
            {
                numberOfParts = vessel.parts.Count;
            }

            foreach (PartModule thatModule in part.Modules)
            {
                var thatEngine = thatModule as ModuleEngines;
                var thatEngineFX = thatModule as ModuleEnginesFX;
                if (thatEngine != null)
                {
                    for (int i = 0; i < thatEngine.propellants.Count; i++)
                        if (thatEngine.propellants[i].name == "SolidFuel")
                            isSRB = true;
                }
                if (thatEngineFX != null)
                {
                    for (int i = 0; i < thatEngineFX.propellants.Count; i++)
                        if (thatEngineFX.propellants[i].name == "SolidFuel")
                            isSRB = true;
                }
            }
            if (isSRB)
            {
                Fields["isSensible"].guiActiveEditor = false;
            }
            GameEvents.onPartDeCoupleComplete.Add(onPartDecoupleComplete);
        }
        void Destroy()
        {
            GameEvents.onPartDeCoupleComplete.Remove(onPartDecoupleComplete);
        }

        bool destroyThis = false;

        void onPartDecoupleComplete(Part p)
        {

            if (vessel != null && !vessel.isCommandable && !isSRB && !destroyThis)
            {
                   
                foreach (PartModule thatModule in part.Modules)
                {
                    var thatEngine = thatModule as ModuleEngines;
                    var thatEngineFX = thatModule as ModuleEnginesFX;

                    if (thatEngine != null)
                    {
                        thatEngine.Shutdown();
                        destroyThis = true;
                    }

                    if (thatEngineFX != null)
                    {
                        thatEngineFX.Shutdown();
                        destroyThis = true;
                    }
                }

                // And selfdestruct the partmodule for good measure, we have no further work to do.
                if (destroyThis)
                {
                    this.Destroy();
                    Destroy(this);
                }
            }
        }
    }
}

