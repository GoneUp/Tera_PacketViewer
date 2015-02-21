using Communication;
using Data.Enums;
using Data.Structures.Player;
using Data.Structures.World.Requests;
using Network.Server;
using System;
using System.IO;
using Utils;

namespace Network.Client
{
    public class RpSystemRequest : ARecvPacket
    {
        protected Request Request;

        public override void Read()
        {
            
            short nameShift = (short)(ReadH() - 4);
            short argumentShift = (short)(ReadH() - 4);

            ReadH(); //unk shift

            RequestType type = (RequestType)ReadH();

            switch(type)
            {
                case RequestType.GuildCreate:
                    {
                        Reader.BaseStream.Seek(argumentShift, SeekOrigin.Begin);
                        String guildName = ReadS();
                        Reader.BaseStream.Seek(0, SeekOrigin.End);
                        
                        Request = new GuildCreate(guildName);
                    }
                    break;
                case RequestType.GuildInvite:
                    {
                        Reader.BaseStream.Seek(nameShift, SeekOrigin.Begin);
                        String name = ReadS();
                        Reader.BaseStream.Seek(0, SeekOrigin.End);

                        Player target = Global.PlayerService.GetPlayerByName(name);
                        Request = new GuildInvite(target);
                    }
                    break;
                case RequestType.PartyInvite:
                    {
                        Reader.BaseStream.Seek(nameShift, SeekOrigin.Begin);
                        String name = ReadS();
                        Reader.BaseStream.Seek(0, SeekOrigin.End);

                        Player target = Global.PlayerService.GetPlayerByName(name);
                        Request = new PartyInvite(target);
                    }
                    break;
                case RequestType.Extraction:
                    {
                        Reader.BaseStream.Seek(argumentShift, SeekOrigin.Begin);
                        int extractionType = ReadD();
                        Reader.BaseStream.Seek(0, SeekOrigin.End);
                        Request = new Extract(extractionType);
                    }
                    break;
                case RequestType.DuelInvite:
                    {
                        Reader.BaseStream.Seek(nameShift, SeekOrigin.Begin);
                        String name = ReadS();
                        Reader.BaseStream.Seek(0, SeekOrigin.End);
                        Player target = Global.PlayerService.GetPlayerByName(name);
                        Request = new DuelInvite(target);
                    }
                    break;
                case RequestType.TradeStart:
                    {
                        Reader.BaseStream.Seek(nameShift, SeekOrigin.Begin);
                        String name = ReadS();
                        Reader.BaseStream.Seek(0, SeekOrigin.End);
                        Player target = Global.PlayerService.GetPlayerByName(name);
                        Request = new TradeStart(target);
                    }
                    break;
                default:
                    Log.Debug("RpSystemRequest: Unknown system request {0}", type);
                    break;
            }
        }

        public override void Process()
        {
            if(Request == null)
                return;

            Request.Owner = Connection.Player;

            if (Request.IsValid())
                Global.ActionEngine.AddRequest(Request);
        }
    }
}