//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2019-11-13 22:41:59
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 客户端发送创建角色消息
/// </summary>
public struct RoleOperation_CreateRoleProto : IProto
{
    public ushort ProtoCode { get { return 10003; } }
    public string ProtoEnName { get { return "RoleOperation_CreateRole"; } }

    public byte JobId; //职业ID
    public string RoleNickName; //角色名称

    public byte[] ToArray(MMO_MemoryStream ms, bool isChild = false)
    {
        ms.SetLength(0);
        if (!isChild)
        {
            ms.WriteUShort(ProtoCode);
        }

        ms.WriteByte(JobId);
        ms.WriteUTF8String(RoleNickName);

        return ms.ToArray();
    }

    public static RoleOperation_CreateRoleProto GetProto(MMO_MemoryStream ms, byte[] buffer)
    {
        RoleOperation_CreateRoleProto proto = new RoleOperation_CreateRoleProto();
        ms.SetLength(0);
        ms.Write(buffer, 0, buffer.Length);
        ms.Position = 0;

        proto.JobId = (byte)ms.ReadByte();
        proto.RoleNickName = ms.ReadUTF8String();

        return proto;
    }
}