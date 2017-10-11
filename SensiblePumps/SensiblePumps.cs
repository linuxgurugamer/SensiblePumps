
namespace SensiblePumps
{
    public class SensiblePumps : PartModule
    {

        [UI_Toggle(disabledText = "off", enabledText = "on")]
        [KSPField(guiActiveEditor = true, guiName = "Sensible Pumps ", isPersistant = true)]
        public bool isSensible = true;

        private int numberOfParts;

        bool isSRB = false;

        public override void OnStart(StartState state)
        {
            if (state != StartState.Editor)
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
        }

        // Ok, I can't figure out if there is a callback I can use or not, screw it, it will work anyway.
        public override void OnFixedUpdate()
        {
            if (isSensible)
            {
                if (numberOfParts != vessel.parts.Count)
                {
                    numberOfParts = vessel.parts.Count;
                    // Number of parts changed, so, let's go to work.
                    // If we're part of a debris object, shutdown all engines.
                    if (!vessel.isCommandable && !isSRB)
                    {
                        foreach (PartModule thatModule in part.Modules)
                        {
                            var thatEngine = thatModule as ModuleEngines;
                            var thatEngineFX = thatModule as ModuleEnginesFX;

                            if (thatEngine != null)
                                thatEngine.Shutdown();
                       
                            if (thatEngineFX != null)
                                thatEngineFX.Shutdown();

                        }
                    }
                    // And selfdestruct the partmodule for good measure, we have no further work to do.
                    Destroy(this);
                }
            }
        }

    }
}

