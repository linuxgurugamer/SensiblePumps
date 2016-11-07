# SensiblePumps

Plugin for Kerbal Space Program solving one annoying problem of rocket range safety.

Ever had a rocket snap in half on you while in flight? I know you have. Ever noticed how the engines in the snapped-off part keep running while there's still fuel in the remaining stage? I know this happened to you as well.

Ever wish the pumps in an uncontrolled piece of debris would behave like real pumps and stop feeding fuel into the engine? I know I did, so I made this little plugin.

## Usage

Just install. It will just work, by adding itself into every part that has engines with ModuleManager. Engines which are part of vessels which cannot be controlled, i.e. are debris, will immediately shut off, and do so only once. This will correctly observe engines which cannot be shut off, i.e. solid fuel rockets.

If this behaviour is, for whatever reason, not what you want on a particular engine, for example, you're making a liquid rocket meant to be used as a dumb projectile, you can toggle it in the editor by right-clicking on the part.

## Source

The source is always available at https://github.com/Mihara/SensiblePumps/
