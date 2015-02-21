using Data.Enums;
using System;
using Utils;

namespace Data.Structures.World.Requests
{
    /// <summary>
    /// Represents a request made by a player.
    /// </summary>
    public abstract class Request : Uid
    {
        /// <summary>
        /// Clean up mess
        /// </summary>
        public override void Release()
        {
            base.Release();
        }

        /// <summary>
        /// Create new request
        /// </summary>
        /// <param name="type">What exactly player requested to do</param>
        /// <param name="blocking">If this request is made, no other request can be done?</param>
        /// <param name="timeout">For how long this request is alive</param>
        public Request(RequestType type, Boolean blocking, int timeout = 20*1000)
        {
            Type = type;
            Blocking = blocking;
            Timeout = timeout;
        }

        /// <summary>
        /// Indicates whether player can make other requests when this one is pending.
        /// </summary>
        public Boolean Blocking;

        /// <summary>
        /// Type of this request.
        /// </summary>
        public RequestType Type;

        /// <summary>
        /// Whether data, specified for this request is valid.
        /// </summary>
        /// <returns>True if request data is valid, otherwise false</returns>
        public abstract bool IsValid();

        /// <summary>
        /// A player, that made this request.
        /// </summary>
        public Player.Player Owner;

        /// <summary>
        /// A target of this request, null if request is non-targeted.
        /// </summary>
        public Player.Player Target;

        /// <summary>
        /// Time, when request was made.
        /// </summary>
        public long Utc = Funcs.GetCurrentMilliseconds();

        /// <summary>
        /// For how long this request will be alive.
        /// </summary>
        public int Timeout;

        /// <summary>
        /// Action, assigned to this request is in progress?
        /// </summary>
        public bool InProgress = false;
    }
}
