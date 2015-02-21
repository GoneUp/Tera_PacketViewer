using System.Collections.Generic;
using Data.Enums;
using Data.Structures.Objects;
using Data.Structures.Player;
using Data.Structures.SkillEngine;
using Data.Structures.World;
using Data.Structures.World.Requests;
using Utils;

namespace Data.Structures
{
    public class UidFactory
    {
        #region static

        protected static Dictionary<ObjectFamily, UidFactory> GlobalFactories = new Dictionary<ObjectFamily, UidFactory>();

        protected static object FactoriesLock = new object();

        public static UidFactory Factory(ObjectFamily family)
        {
            lock (FactoriesLock)
            {
                if (!GlobalFactories.ContainsKey(family))
                    GlobalFactories.Add(family, new UidFactory());
            }

            return GlobalFactories[family];
        }

        public static UidFactory Factory(object o)
        {
            return Factory(GetFamily(o));
        }

        public static ObjectFamily GetFamily(object o)
        {
            if (o is Attack)
                return ObjectFamily.Attack;

            //

            if (o is Player.Player)
                return ObjectFamily.Player;

            if (o is Npc.Npc)
                return ObjectFamily.Npc;

            if (o is Gather.Gather)
                return ObjectFamily.Gather;

            if (o is Item)
                return ObjectFamily.Item;

            if (o is StorageItem)
                return ObjectFamily.InventoryItem;

            if (o is Projectile)
                return ObjectFamily.Projectile;

            if (o is Campfire)
                return ObjectFamily.Campfire;

            if (o is Request)
                return ObjectFamily.Request;



            Log.Error("UidFactory: Unknown object type: {0}", o.GetType().Name);
            return ObjectFamily.System;
        }

        #endregion

        protected object Lock = new object();

        protected int NextUid = 1;

        protected Queue<int> FreeUidList = new Queue<int>();

        protected Dictionary<int, Uid> RegisteredObjects = new Dictionary<int, Uid>();

        public Uid FindObject(int uid)
        {
            lock (Lock)
            {
                return RegisteredObjects.ContainsKey(uid)
                           ? RegisteredObjects[uid]
                           : null;
            }
        }

        public int RegisterObject(Uid o)
        {
            lock (Lock)
            {
                int uid = FreeUidList.Count > 0
                              ? FreeUidList.Dequeue()
                              : NextUid++;

                RegisteredObjects.Add(uid, o);

                return uid;
            }
        }

        public void Release(Uid o, int uid)
        {
            if (uid == 0)
                return;

            lock (Lock)
            {
                RegisteredObjects.Remove(uid);
                FreeUidList.Enqueue(uid);
            }
        }
    }
}
