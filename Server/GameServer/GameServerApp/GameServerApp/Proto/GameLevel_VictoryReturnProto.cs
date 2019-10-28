//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2019-10-28 01:09:09
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 服务器返回战斗胜利消息
/// </summary>
public struct GameLevel_VictoryReturnProto : IProto
{
    public ushort ProtoCode { get { return 12004; } }
    public string ProtoEnName { get { return "GameLevel_VictoryReturn"; } }

    public bool IsSuccess; //是否成功
    public int MsgCode; //消息码

    public byte[] ToArray(MMO_MemoryStream ms, bool isChild = false)
    {
        ms.SetLength(0);
        if (!isChild)
        {
            ms.WriteUShort(ProtoCode);
        }

        ms.WriteBool(IsSuccess);
        if (!IsSuccess)
        {
            ms.WriteInt(MsgCode);
        }

        return ms.ToArray();
    }

    public static GameLevel_VictoryReturnProto GetProto(MMO_MemoryStream ms, byte[] buffer)
    {
        GameLevel_VictoryReturnProto proto = new GameLevel_VictoryReturnProto();
        ms.SetLength(0);
        ms.Write(buffer, 0, buffer.Length);
        ms.Position = 0;

        proto.IsSuccess = ms.ReadBool();
        if (!proto.IsSuccess)
        {
            proto.MsgCode = ms.ReadInt();
        }

        return proto;
    }
}