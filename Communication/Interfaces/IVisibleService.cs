using System.Collections.Generic;
using Data.Enums.SkillEngine;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Geometry;
using Data.Structures.World;

namespace Communication.Interfaces
{
    public interface IVisibleService : IComponent
    {
        void Send(Creature creature, ISendPacket packet);
        List<Creature> FindTargets(Creature creature, Point3D position, double distance, TargetingAreaType type);
        List<Creature> FindTargets(Creature creature, WorldPosition position, double distance, TargetingAreaType type);
    }
}