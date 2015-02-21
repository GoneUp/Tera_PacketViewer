using System;
using System.Collections.Generic;
using Data.Structures.Player;
using Utils;

namespace Data.Structures
{
    public abstract class Statistical
    {
        private static readonly List<WeakReference> Instances = new List<WeakReference>();
        protected static object InstancesLock = new object();

        protected Statistical()
        {
            if (/*!CUTera.GameServer.UseStatistical || */this is StorageItem)
                return;

            lock (InstancesLock)
            {
                Instances.Add(new WeakReference(this));
            }
        }

        public static List<Statistical> GetInstances()
        {
            lock (InstancesLock)
            {
                List<Statistical> realInstances = new List<Statistical>();

                int removed = 0;

                for (int i = 0; i < Instances.Count; i++)
                {
                    if (Instances[i].IsAlive)
                    {
                        realInstances.Add((Statistical) Instances[i].Target);
                    }
                    else
                    {
                        Instances.RemoveAt(i--);
                        removed++;
                    }
                }

                Log.Info("Removed {0} instances...", removed);

                return realInstances;
            }
        }
    }
}