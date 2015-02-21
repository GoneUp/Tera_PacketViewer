using Data.Structures.Quest.Tasks;

namespace Data.Interfaces
{
    [ProtoBuf.ProtoContract]
    [ProtoBuf.ProtoInclude(1, typeof(QTaskVisit))]
    [ProtoBuf.ProtoInclude(100, typeof(QTaskGather))]
    [ProtoBuf.ProtoInclude(200, typeof(QTaskPlaybackVideo))]
    [ProtoBuf.ProtoInclude(300, typeof(QTaskItemThatStabbedPassed))]
    [ProtoBuf.ProtoInclude(400, typeof(QTaskHuntingDelivery))]
    [ProtoBuf.ProtoInclude(500, typeof(QTaskEscort))]
    [ProtoBuf.ProtoInclude(600, typeof(QTaskObjectAction))]
    [ProtoBuf.ProtoInclude(700, typeof(QTaskAcquisitionHunt))]
    [ProtoBuf.ProtoInclude(800, typeof(QTaskDeliveItems))]
    [ProtoBuf.ProtoInclude(900, typeof(QTaskHunting))]
    [ProtoBuf.ProtoInclude(1000, typeof(QTaskRepeat))]
    [ProtoBuf.ProtoInclude(1100, typeof(QTaskGuard))]
    [ProtoBuf.ProtoInclude(1200, typeof(QTaskMovePC))]
    [ProtoBuf.ProtoInclude(1300, typeof(QTaskConditions))]
    [ProtoBuf.ProtoInclude(1400, typeof(QTaskGroupHunting))]
    [ProtoBuf.ProtoInclude(1500, typeof(QTaskQuarter))]
    [ProtoBuf.ProtoInclude(1600, typeof(QTaskOverTheState))]
    [ProtoBuf.ProtoInclude(1700, typeof(QTaskTeleport))]
    [ProtoBuf.ProtoInclude(1800, typeof(QTaskSkillStrike))]
    [ProtoBuf.ProtoInclude(1900, typeof(QTaskItemUse))]
    [ProtoBuf.ProtoInclude(2000, typeof(QTaskGeomeunteum))]
    [ProtoBuf.ProtoInclude(2100, typeof(QTaskVisitTheBlackCrack))]
    [ProtoBuf.ProtoInclude(10000, typeof(QTaskNotImpliment))]

    public interface IQuestStep
    {

    }
}
